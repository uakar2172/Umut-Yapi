using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UmutYapi.Models.Context;
using UmutYapi.Models.Tablolar;
using UmutYapi.Models.ViewModels;

namespace UmutYapi.Controllers
{
    public class SiparisController : Controller
    {
        private readonly UserManager<Kullanici> _userManager;
        private readonly SignInManager<Kullanici> _signInManager;
        private readonly YapiMalzemeContext _dbContext;
        private readonly RoleManager<UserRole> _roleManager;

        public SiparisController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager, YapiMalzemeContext dbContext, RoleManager<UserRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var siparisler = _dbContext.Siparisler.Include(x => x.SiparisItems).Where(x => x.KullaniciId == user.Id).ToList();
            if(siparisler.Count == 0)
            {
                
                return View(Enumerable.Empty<SiparisViewModel>());
            }
            var urunIds = siparisler.SelectMany(x=> x.SiparisItems).Select(x => x.UrunId);
            var urunler = _dbContext.Urunler.Where(x => urunIds.Contains(x.Id)).ToList();

            var siparisViewModel = siparisler.Select(x=>
            {
                return new SiparisViewModel()
                {
                    SiparisId = x.Id,
                    SiparisItems = x.SiparisItems.Select(x =>
                    {
                        var urun = urunler.First(y => y.Id == x.UrunId);
                        return new SiparisItemViewModel()
                        {
                            Adet = x.Adet,
                            Aciklama = urun.Aciklama,
                            BirimFiyat = urun.UrunFiyati,
                            Forograf = urun.UrunFoto,
                            UrunAdi = urun.UrunAdi
                        };
                    }).ToList()
                };
            }); 

            return View(siparisViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SiparisiIptalEt(int siparisId)
        {
            var siparis = _dbContext.Siparisler.Include(x=>x.SiparisItems).First(x=>x.Id == siparisId);
            var urunIds = siparis.SiparisItems.Select(x => x.UrunId);
            var urunler = _dbContext.Urunler.Where(x => urunIds.Contains(x.Id)).ToList();

            foreach (var urun in urunler)
            {
                var siparisItem = siparis.SiparisItems.FirstOrDefault(x => x.UrunId == urun.Id);
                urun.StokAdeti += siparisItem.Adet;
            }

            _dbContext.Remove(siparis);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
