using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using TechOilFront.Pages.Models;

namespace TechOilFront.Pages
{
    public class ServiciosModel : PageModel
    {
        public List<ServicioModel> servicioList { get; set; }

        [BindProperty]
        public ServicioModel servicio { get; set; }

        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5170/api/Servicios\r\n");

                if (response.IsSuccessStatusCode)
                {
                    servicioList = await response.Content.ReadFromJsonAsync<List<ServicioModel>>();
                }
                else
                {
                    servicioList = new List<ServicioModel>();
                }
            }
        }



        public async Task<IActionResult> OnPostDelete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"http://localhost:5170/api/Servicios/\r\n" + id);

                if (response.IsSuccessStatusCode)
                {
                    await OnGetAsync();
                    return Page();
                }
                else
                {
                    return Page();
                }
            }
        }

        public async Task<IActionResult> OnPost()
        {
            string descr = Request.Form["descr"];
            string valorHora = Request.Form["valorHora"];

            var data = new
            {
                descr = descr,
                valorHora = valorHora

            };

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync("http://localhost:5170/api/Servicios\r\n", content);

                if (response.IsSuccessStatusCode)
                {
                    await OnGetAsync();
                    return Page();
                }
                else
                {
                    return Page();
                }
            }
        }

        public async Task<IActionResult> OnPostPut()
        {
            string codServicio = Request.Form["codServicio"];
            string descr = Request.Form["descr"];
            string valorHora = Request.Form["valorHora"];

            var data = new
            {
                codServicio = codServicio,
                descr = descr,
                valorHora = valorHora

            };

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsync("http://localhost:5170/api/Servicios\r\n", content);

                if (response.IsSuccessStatusCode)
                {
                    await OnGetAsync();
                    return Page();
                }
                else
                {
                    return Page();
                }
            }
        }

    }
}
