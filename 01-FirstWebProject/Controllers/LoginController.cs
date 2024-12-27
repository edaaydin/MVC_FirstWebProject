using Microsoft.AspNetCore.Mvc;

namespace _01_FirstWebProject.Controllers
{
    public class LoginController : Controller
    {
        // get veri alır, post veri gonderir
        public IActionResult Giris()
        {
            // kullanıcıya ad ve sifresini soracak olan sayfa, dogru yazılırsa
            return View();
        }

        [HttpPost]
        public IActionResult Giris(string kullaniciAd, string sifre)
        {
            // form tarafından gelen kullanıcıad ve sifre bilgisi admin - 123 ise anasayfaya yonlendir degilse hata sayfasına yonlendir !

            if (kullaniciAd.Equals("admin") && sifre.Equals("123"))
            {
                return View("Anasayfa");
            }
            return View("Hata");
        }

        /*
         
        Kisi olustur adında bir action yazınız.
        kisinin ıd, ad, soyad ve maas bilgilerini sayfaya giden model aracılıgıyla alınız.
        Personeli aynı kontrollerin icindeki statik bir listeye ekleyiniz.
        tüm bilgileri alındıgı taktirde basarılı ekleme sayfası olarak tum kisilerin listelendigi sayfayı gosteriniz.
        Bilgiler bos gecilmeye kalkılırsa hata sayfası olursuturup kisiyi o listeye eklemeyiniz.

         */
    }
}
