using _01_FirstWebProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_FirstWebProject.Controllers
{
    public class PersonelController : Controller
    {
        private static List<Personel> pList = new List<Personel>()
            {
                new Personel() {Id = 1, Ad="Ali", Soyad="Metin", Maas= 35000},
                new Personel() {Id = 2, Ad="Can", Soyad="Mutlu", Maas= 135000},
                new Personel() {Id = 3, Ad="Esin", Soyad="Yener", Maas= 55000},
            };
        public IActionResult PersonelleriListele() // tum personelleri listeler.
        {
            return View(pList);
        }

        public IActionResult Veriler()
        {
            Kisi kisi = new Kisi()
            { ID = 1, Ad = "Eda", Soyad = "Aydın" };

            List<Personel> pList = new List<Personel>()
            {
                new Personel() {Id = 1, Ad="Ali", Soyad="Metin", Maas= 35000},
                new Personel() {Id = 2, Ad="Can", Soyad="Mutlu", Maas= 135000},
                new Personel() {Id = 3, Ad="Esin", Soyad="Yener", Maas= 55000},
            };

            Master master = new Master();
            master.Kisi = kisi;
            master.Personellerim = pList;
            master.Adet = 5;

            return View(master);
        }

        public IActionResult PersonelOlustur()
        {
            return View(new Personel());
        }


        [HttpPost]
        public IActionResult PersonelOlustur(Personel personel)
        {

            if (ModelState.IsValid) // basari
            {
                // statik listeye ekle, herkesin listelendigi sayfaya gotur beni
                pList.Add(personel);
                //  return RedirectToAction("Index", "Home"); // once action, sonra controller.
                return RedirectToAction("PersonelleriListele");
            }
            // ekleme yapma ve beni hata sayfasına yonlendir.
            return View("PersonelHata");
        }




    }
}
