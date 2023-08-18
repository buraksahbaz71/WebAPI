using DurakListeApp.Models;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System.Diagnostics;

namespace DurakListeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            List<DurakViewModel> list = new List<DurakViewModel>();

            // HttpClient oluştur
            var httpClient = _httpClientFactory.CreateClient();

            // API isteği oluştur
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7180/api/Durak");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(content);

                foreach (dynamic result in data)
                {
                    DurakViewModel model = new DurakViewModel();
                    model.id = result.id;
                    model.durak_adres = result.durak_adres;
                    model.durak_adi = result.durak_adi;
                    model.durak_no = result.durak_no;
                    list.Add(model);
                }

                return View("Index", list);
            }
            else
            {
                // Hata durumu
                return View("Error");
            }
        }
    }
}