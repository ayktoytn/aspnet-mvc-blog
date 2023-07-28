using Microsoft.AspNetCore.Mvc;
using ResultTurleri.Models;
using System;
using System.Diagnostics;

namespace ResultTurleri.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Mesaj = "Result türümüz bir view";
            return View();
        }
        public PartialViewResult Index2()
        {
            // sayfa içerisindeki js kodlarını parçalamak için kullanırız. 
            //PartialViewResult result = new PartialViewResult();
            PartialViewResult result = PartialView(); // bunu kullanmamızın nedeni ana sayfanın js kod yükünü almak. Metot oluşturur gibi bu kısımlarda da belli küçük kod bütünleri oluşturur ve lazım olunca çağırırız.
            return result;
        }

        public JsonResult GetAllPerson()
        {
            JsonResult data = Json(
                new Person { Name = "Selami", Surname = "Şahin" },
                new Person { Name = "Bülent", Surname = "Ersoy" }

                );
            return data;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}