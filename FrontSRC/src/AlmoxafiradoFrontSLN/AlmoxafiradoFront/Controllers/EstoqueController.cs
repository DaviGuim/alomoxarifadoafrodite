using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace AlmoxafiradoFront.Controllers
{
    public class EstoqueController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:44366/listaEstoque";
            List<EstoqueDTO> estoques = new List<EstoqueDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                estoques = JsonSerializer.Deserialize<List<EstoqueDTO>>(json);
                ViewBag.Estoques = estoques;
                return View();


            }
            catch (Exception)
            {
                return View();

            }

            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
