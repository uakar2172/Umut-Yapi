using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UmutYapi.Models.Context;
using UmutYapi.Models.Tablolar;
using UmutYapi.Models.ViewModels;

namespace UmutYapi.Controllers
{
    public class MusteriController : Controller
    {
        private readonly YapiMalzemeContext _dbContext;
        private readonly UserManager<Kullanici> _userManager;

        public MusteriController(YapiMalzemeContext dbContext, UserManager<Kullanici> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        [Route("/")]
        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            List<Urun> urunler;
            var user = await _userManager.GetUserAsync(User);
            if (id == null)
            {
                urunler = _dbContext.Urunler.ToList();
            }
            else
            {
                urunler = _dbContext.Urunler.Where(x => x.KategoriId == id).ToList();
            }
            return View(urunler);
        }

        [HttpPost]
        public async Task<IActionResult> SepeteEkle([FromBody] SepetEkleModel model)
        {
            var urun = await _dbContext.Urunler.FindAsync(model.UrunId);
            if (urun == null)
            {
                return NotFound("Ürün bulunamadı.");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var sepet = await _dbContext.Sepetler
                .Include(s => s.SepetItems)
                .FirstOrDefaultAsync(s => s.KullaniciId == user.Id);

            if (sepet == null)
            {
                sepet = new Sepet
                {
                    KullaniciId = user.Id,
                    SepetItems = new List<SepetItem>()
                };
                _dbContext.Sepetler.Add(sepet);
            }

            var existingItem = sepet.SepetItems.FirstOrDefault(u => u.UrunId == model.UrunId);
            if (existingItem != null)
            {
                existingItem.SatınAlınacakAdet += model.Adet;
            }
            else
            {
                sepet.SepetItems.Add(new SepetItem
                {
                    UrunId = urun.Id,
                    SatınAlınacakAdet = model.Adet,
                });
            }

            try
            {
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
            return Ok();
        }

        public IActionResult FilterProducts(string search)
        {
            var filteredUrunler = _dbContext.Urunler
                .Where(u => u.UrunAdi.Contains(search ?? ""))
                .ToList();

            return PartialView("_ProductListPartial", filteredUrunler);
        }

        public async Task<IActionResult> UrunleriSirala(string sortOrder)
        {
            var products = await _dbContext.Urunler.ToListAsync(); // Ürünleri veritabanından veya başka bir kaynaktan alın

            switch (sortOrder)
            {
                case "name_asc":
                    products = products.OrderBy(p => p.UrunAdi).ToList();
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.UrunAdi).ToList();
                    break;
                case "price_asc":
                    products = products.OrderBy(p => p.UrunFiyati).ToList();
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.UrunFiyati).ToList();
                    break;
                case "stock_asc":
                    products = products.OrderBy(p => p.StokAdeti).ToList();
                    break;
                case "stock_desc":
                    products = products.OrderByDescending(p => p.StokAdeti).ToList();
                    break;
                default:
                    break;
            }

            return PartialView("_ProductListPartial", products);
        }
    }
}
