using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using TechOilFront.Pages.Models;

namespace TechOilFront.Pages
{
    public class ProyectosModel : PageModel
    {
        public List<ProyectoModel> proyectoList { get; set; }
        
        [BindProperty]
        public ProyectoModel proyecto {  get; set; }
        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5170/api/Proyectos\r\n");

                if (response.IsSuccessStatusCode)
                {
                    proyectoList = await response.Content.ReadFromJsonAsync<List<ProyectoModel>>();
                }
                else
                {
                    proyectoList = new List<ProyectoModel>();
                }
            }
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"http://localhost:5170/api/Proyectos/\r\n" + id);

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
            string nombre = Request.Form["nombre"];
            string direccion = Request.Form["direccion"];
       

            var data = new
            {
                nombre = nombre,
                direccion = direccion

            };

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync("http://localhost:5170/api/Proyectos\r\n", content);

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
