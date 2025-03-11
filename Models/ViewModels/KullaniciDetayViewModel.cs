using Microsoft.EntityFrameworkCore.Metadata;
using UmutYapi.Models.Tablolar;

namespace UmutYapi.Models.ViewModels
{
    public class KullaniciDetayViewModel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelefonNo { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Ulke { get; set; }
        public KullaniciDetayViewModel()
        {
                
        }

        public KullaniciDetayViewModel(Kullanici kullanici)
        {
            Ad = kullanici.Ad;
            Soyad = kullanici.Soyad;
            TelefonNo = kullanici.TelefonNo;
            Email = kullanici.Email;
            Adres = kullanici.Adres;
            Sehir = kullanici.Sehir;
            Ulke = kullanici.Ulke;
        }
    }
}
