using System;

namespace EcoMarketProje.ViewModels
{
    public class MusteriViewModel
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Cinsiyet { get; set; }
        public string Meslek { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public Boolean? ReklamMaili { get; set; }
        public string Adres { get; set; }
        public string YasadigiSehir { get; set; }
        public string Tel { get; set; }
        public string Notlar { get; set; }
    }
}