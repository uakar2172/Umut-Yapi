using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UmutYapi.Models.Context;
using UmutYapi.Models.Tablolar;
using UmutYapi.Models.ViewModels;

namespace UmutYapi.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly UserManager<Kullanici> _userManager;
        private readonly SignInManager<Kullanici> _signInManager;
        private readonly YapiMalzemeContext _dbContext;
        private readonly RoleManager<UserRole> _roleManager;

        public KullaniciController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager, YapiMalzemeContext dbContext, RoleManager<UserRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Giris(GirisViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.KullaniciAdi) ?? await _userManager.FindByNameAsync(model.KullaniciAdi);
            if (user is null) return View(model);

            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Sifre, false, false);
            if (result.Succeeded)
            {
                // Session'a kullanıcı adını kaydet
                HttpContext.Session.SetString("KullaniciAdi", user.UserName.ToUpper());

                // Diğer bilgileri de session'a ekleyebilirsiniz
                HttpContext.Session.SetString("Fotograf", user.Fotograf);

                HttpContext.Session.SetString("GirisYapildiMi", "True");

                return RedirectToAction("Index", "Musteri");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Kayit(KayitViewModel model)
        {
            if (model.Sifre != model.SifreTekrar)
            {
                //Hata
                return View(model);
            }

            if (_dbContext.Kullanicilar.FirstOrDefault(x => x.UserName == model.KullaniciAdi || x.Email == model.Email) == null)
            {
                Kullanici musteri = new Kullanici()
                {
                    Email = model.Email,
                    Id = new Guid(),
                    UserName = model.KullaniciAdi
                };
                var result = await _userManager.CreateAsync(musteri, model.Sifre);
                if (result.Succeeded)
                {
                    _dbContext.SaveChanges();
                }
                return RedirectToAction("Giris", "Kullanici", new GirisViewModel() { KullaniciAdi = model.Email, Sifre = model.Sifre });
            }

            //Hata
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Cikis()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Giris", "Kullanici");
        }

        [HttpGet]
        public async Task<IActionResult> Detay()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {

            }
            var viewModel = new KullaniciDetayViewModel(user);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Detay(KullaniciDetayViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                user.BilgileriGuncelle(model);
                var updateResult = await _userManager.UpdateAsync(user);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> FotografGuncelle(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileExtension = Path.GetExtension(file.FileName);
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

                if (!allowedExtensions.Contains(fileExtension.ToLower()) || file.Length > 800 * 1024)
                {
                    // Dosya uzantısı veya boyutu uygun değil
                    ModelState.AddModelError("", "Geçersiz dosya formatı veya dosya boyutu.");
                    return View();
                }

                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound();
                }

                var newFileName = Guid.NewGuid() + fileExtension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/KullaniciFoto", newFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Yeni dosya adını kaydetme
                user.Fotograf = newFileName;
                _dbContext.Update(user);
                await _dbContext.SaveChangesAsync();
                HttpContext.Session.SetString("Fotograf", user.Fotograf);
                return Json(new { newAvatarUrl = Url.Content($"~/img/KullaniciFoto/{newFileName}") });
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FotografiSifirla()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            user.Fotograf = "defaultuser.png";
            _dbContext.Update(user);
            _dbContext.SaveChanges();

            return Json(new { newAvatarUrl = Url.Content($"~/img/KullaniciFoto/defaultuser.png") });
        }
    }
}
