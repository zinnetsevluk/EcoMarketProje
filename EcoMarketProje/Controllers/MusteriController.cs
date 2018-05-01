using System;
using System.Linq;
using System.Web.Http;

using EcoMarketProje.Models;
using EcoMarketProje.ViewModels;

namespace EcoMarketProje.Controllers
{
    public class MusteriController : ApiController
    {
        [HttpGet]
        public object GetAllCustomer()
        {
            try
            {
                var db = new CustomerDatabaseEntities();
                var model = db.Customers.ToList().OrderBy(x => x.AdSoyad).Select(x => new MusteriViewModel
                {
                    Id = x.Id,
                    AdSoyad = x.AdSoyad,
                    Cinsiyet = x.Cinsiyet,
                    Meslek = x.Meslek,
                    DogumTarihi = x.DogumTarihi,
                    Email = x.Email,
                    WebSite = x.WebSite,
                    ReklamMaili = x.ReklamMaili,
                    Adres = x.Adres,
                    YasadigiSehir = x.YasadigiSehir,
                    Tel = x.Telefon,
                    Notlar = x.Notlar
                });
                return new
                {
                    success = true,
                    data = model
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = ex.Message
                };
            }
        }

        [HttpPost]
        public object UpdateCustomer(MusteriViewModel model)
        {
            try
            {
                var db = new CustomerDatabaseEntities();
                var cus = db.Customers.Find(model.Id);
                cus.AdSoyad = model.AdSoyad;
                cus.Cinsiyet = model.Cinsiyet;
                cus.DogumTarihi = model.DogumTarihi;
                cus.YasadigiSehir = model.YasadigiSehir;
                cus.Email = model.Email;
                cus.Meslek = model.Meslek;
                cus.Telefon = model.Tel;
                cus.ReklamMaili = model.ReklamMaili;
                cus.WebSite = model.WebSite;
                cus.Notlar = model.Notlar;
                db.SaveChanges();
                return new
                {
                    success = true
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = ex.Message
                };
            }
        }

        [HttpPost]
        public object NewCustomer(MusteriViewModel model)
        {
            try
            {
                var db = new CustomerDatabaseEntities();
                db.Customers.Add(new Customer()
                {
                    AdSoyad = model.AdSoyad,
                    Cinsiyet = model.Cinsiyet,
                    Adres = model.Adres,
                    DogumTarihi = model.DogumTarihi,
                    YasadigiSehir = model.YasadigiSehir,
                    Email = model.Email,
                    Meslek = model.Meslek,
                    Telefon = model.Tel,
                    ReklamMaili = model.ReklamMaili,
                    WebSite = model.WebSite,
                    Notlar = model.Notlar

                });
                db.SaveChanges();
                return new
                {
                    success = true
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = ex.Message
                };
            }
        }
    }
}
