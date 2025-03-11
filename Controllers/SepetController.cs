using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UmutYapi.Models.Context;
using UmutYapi.Models.Tablolar;
using UmutYapi.Models.ViewModels;

namespace UmutYapi.Controllers
{
    public class SepetController : Controller
    {
        private readonly UserManager<Kullanici> _userManager;
        private readonly SignInManager<Kullanici> _signInManager;
        private readonly YapiMalzemeContext _dbContext;
        private readonly RoleManager<UserRole> _roleManager;

        public SepetController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager, YapiMalzemeContext dbContext, RoleManager<UserRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _roleManager = roleManager;
        }

        // Sepeti göster
        public async Task<ActionResult> Index()
        {
            var sepet = await KullaniciSepetiniGetir();
            if (sepet == null)
            {
                return View(Enumerable.Empty<SepetViewModel>());
            }
            var urunIds = sepet.SepetItems.Select(x => x.UrunId);
            var urunler = _dbContext.Urunler.Where(x => urunIds.Contains(x.Id)).ToList();
            var sepetViewModel = sepet.SepetItems.Select(x =>
            {
                var urun = urunler.First(y => y.Id == x.UrunId);
                return new SepetViewModel()
                {
                    UrunId = urun.Id,
                    Adet = x.SatınAlınacakAdet,
                    BirimFiyat = urun.UrunFiyati,
                    Fotograf = urun.UrunFoto,
                    ToplamFiyat = urun.UrunFiyati * x.SatınAlınacakAdet,
                    UrunAciklama = urun.Aciklama,
                    UrunAdi = urun.UrunAdi
                };
            });
            ViewBag.UrunStoklari = urunler.ToDictionary(x => x.Id, x => x.StokAdeti);
            return View(sepetViewModel);
        }

        private async Task<Sepet> KullaniciSepetiniGetir()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return new Sepet();
            }

            return _dbContext.Sepetler.Include(x => x.SepetItems).FirstOrDefault(x => x.KullaniciId == user.Id);
        }

        // Ürün ekle
        [HttpPost]
        public async Task<JsonResult> AdetGuncelle(int urunId, int adet)
        {
            try
            {
                var sepet = await KullaniciSepetiniGetir();
                var sepetItem = _dbContext.SepetItemler.FirstOrDefault(x => x.SepetId == sepet.Id && x.UrunId == urunId);
                if (sepetItem != null)
                {
                    sepetItem.SatınAlınacakAdet = adet;
                    _dbContext.SaveChanges();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // Ürün çıkar
        [HttpPost]
        public async Task<ActionResult> UrunCikart(int urunId)
        {
            var sepet = await KullaniciSepetiniGetir();
            var sepetItem = _dbContext.SepetItemler.FirstOrDefault(x => x.SepetId == sepet.Id && x.UrunId == urunId);
            _dbContext.Remove(sepetItem);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> SepetiTemizle()
        {
            var sepet = await KullaniciSepetiniGetir();
            _dbContext.SepetItemler.RemoveRange(sepet.SepetItems);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // Siparişi tamamlama
        [HttpPost]
        public async Task<ActionResult> SatinAl()
        {
            var sepet = await KullaniciSepetiniGetir();
            var user = await _userManager.GetUserAsync(User);

            var urunIds = sepet.SepetItems.Select(x => x.UrunId);
            var urunler = _dbContext.Urunler.Where(x => urunIds.Contains(x.Id)).ToList();

            // Sipariş oluşturma
            Siparis siparis = new Siparis()
            {
                KullaniciId = user.Id,
                SatınAlmaTarihi = DateTime.Now,
                SiparisTutarı = SiparisTutarınıHesapla(urunler, sepet),
            };

            try
            {
                _dbContext.Siparisler.Add(siparis);
                await _dbContext.SaveChangesAsync(); // Siparişi kaydediyoruz, böylece siparişin Id'si oluşuyor

                var siparisItems = sepet.SepetItems.Select(x => new SiparisItem()
                {
                    Adet = x.SatınAlınacakAdet,
                    UrunId = x.UrunId,
                    SiparisId = siparis.Id // SiparisId'yi atıyoruz
                }).ToList();

                _dbContext.SiparisItems.AddRange(siparisItems);

                // Stok güncelleme ve sepet boşaltma
                foreach (var item in sepet.SepetItems)
                {
                    var urun = _dbContext.Urunler.FirstOrDefault(u => u.Id == item.UrunId);
                    if (urun != null)
                    {
                        urun.StokAdeti -= item.SatınAlınacakAdet;
                    }
                }

                _dbContext.SepetItemler.RemoveRange(sepet.SepetItems);

                await _dbContext.SaveChangesAsync(); // Değişiklikleri kaydediyoruz
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                throw;
            }

            return RedirectToAction("Index", "Siparis");
        }

        private decimal SiparisTutarınıHesapla(List<Urun> urunler, Sepet sepet)
        {
            return sepet.SepetItems.Sum(x =>
            {
                var urun = urunler.First(y => y.Id == x.UrunId);
                return urun.UrunFiyati * x.SatınAlınacakAdet;
            });
        }

        [HttpGet]
        public async Task<IActionResult> ToplamSepetTutarınıHesapla()
        {
            var sepet = await KullaniciSepetiniGetir();
            var urunIds = sepet.SepetItems.Select(x => x.UrunId);
            var urunler = _dbContext.Urunler.Where(x => urunIds.Contains(x.Id)).ToList();
            var sepetTutarı = SiparisTutarınıHesapla(urunler, sepet);
            return Json(new { SiparisTutarı = sepetTutarı, success = true });
        }
    }
}
