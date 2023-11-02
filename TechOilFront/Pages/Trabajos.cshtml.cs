using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using TechOilFront.Pages.Models;

namespace TechOilFront.Pages
{
    public class TrabajosModel : PageModel
    {

        public List<TrabajoModel> trabajoList { get; set; }
        
        [BindProperty]
        public TrabajoModel trabajo {  get; set; }
        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5170/api/Trabajos\r\n");

                if (response.IsSuccessStatusCode)
                {
                    trabajoList = await response.Content.ReadFromJsonAsync<List<TrabajoModel>>();
                }
                else
                {
                    trabajoList = new List<TrabajoModel>();
                }
            }
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"http://localhost:5170/api/Trabajos/\r\n" + id);

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
            string codProyecto = Request.Form["codProyecto"];
            string codServicio = Request.Form["codServicio"];
            string cantHoras = Request.Form["cantHoras"];

            var data = new
            {
                codProyecto = codProyecto,
                codServicio = codServicio,
                cantHoras = cantHoras

            };

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync("http://localhost:5170/api/Trabajos\r\n", content);

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
