using _01_FirstWebProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_FirstWebProject.Controllers
{
    public class ProductController : Controller
    {
        private static List<Category> categories = new List<Category>()
        {
            new Category { Id = 1, CategoryName = "Sebze", Description =" Vitaminlidir" },
            new Category { Id = 2, CategoryName = "Meyve", Description =" cok sevilir" },
            new Category { Id = 3, CategoryName = "Kuruyemis", Description =" fiyatları el yakiyor" },
            new Category { Id = 4, CategoryName = "Temizlik", Description =" abartmaya gerek yok" }
        };

        private static List<Product> products = new List<Product>()
        {
            new Product () {Id=1, ProductName="Ceviz", Price=8, Stock=5, CategoryId=3}
        };

        public IActionResult Create()
        {
            // categorilerini view'a tasıman lazım ki secim yapılabilsin !

            ProductVM vm = new ProductVM();
            vm.Categories = categories;

            return View(vm);
        }

        // view doldurmak. product + categoryleri basacagını unutma !
        // category secildiginde id'sini alabildigine emin ol !
        // http metoduna gelen parametrede product icin gerekli tum propları doldurduysan product nesnesinş olusturup globaldeki statik listeye ata ve her sey yolundaysa bizi product listeleme sayfasına gotur.
        // hata varsa aynı viewa aynı verilerle iade et iade ederken categories bakalım !!


        [HttpPost]
        public IActionResult Create(ProductVM vm)
        {
            if (KontrolUrun(vm.Product))
            {
                // statik liste olustur ekle listeleme sayfasına git.
                products.Add(vm.Product);
                return RedirectToAction("Listeleme");
            }
            // kategorileri 1 kez daha doldurmalısın sonra view'a gitmelisin ama aynı vm ile !
            return View(vm);
        }

        // metot yazarsın id ad fiyat stok check eder.

        public bool KontrolUrun(Product product)
        {
            if (!string.IsNullOrWhiteSpace(product.ProductName) && product.Id > 0 && product.Stock > 0 && product.Price > 0) return true;
            return false;
        }

        public IActionResult Listeleme()
        {
            return View(products);
        }


    }
}
