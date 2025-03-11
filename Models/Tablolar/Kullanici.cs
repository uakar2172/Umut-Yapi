using Microsoft.AspNetCore.Identity;
using UmutYapi.Models.ViewModels;

namespace UmutYapi.Models.Tablolar
{
    public class Kullanici : IdentityUser<Guid>
    {
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? TelefonNo { get; set; }
        public string? Adres { get; set; }
        public string? Sehir { get; set; }
        public string? Ulke { get; set; }
        public string Fotograf { get; set; } = "defaultuser.png";
        public int? SepetId { get; set; }
        public virtual Sepet Sepet { get; set; }
        public virtual ICollection<Siparis> Siparisler { get; set; }

        public void BilgileriGuncelle(KullaniciDetayViewModel model)
        {
            Ad = model.Ad;
            Soyad = model.Soyad;
            Adres = model.Adres;
            TelefonNo = model.TelefonNo;
            Ulke = model.Ulke;
            Sehir = model.Sehir;
            Email = model.Email;
        }
    }
}
