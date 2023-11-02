using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using TechOilFront.Pages.Models;

namespace TechOilFront.Pages
{
    public class UsuariosModel : PageModel
    {
        public List<UsuarioModel> usuarioList { get; set; }

        [BindProperty]
        public UsuarioModel usuario { get; set; }
        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5170/api/Usuarios\r\n");

                if (response.IsSuccessStatusCode)
                {
                    usuarioList = await response.Content.ReadFromJsonAsync<List<UsuarioModel>>();
                }
                else
                {
                    usuarioList = new List<UsuarioModel>();
                }
            }
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"http://localhost:5170/api/Usuarios/\r\n" + id);

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
            string dni = Request.Form["dni"];
            string contrase�a = Request.Form["contrase�a"];

            var data = new
            {
                nombre = nombre,
                dni = dni,
                contrase�a = contrase�a
                
            };

            var content= new StringContent(JsonConvert.SerializeObject(data),Encoding.UTF8,"application/json");

            using (var httpClient=new HttpClient())
            {
                var response = await httpClient.PostAsync("http://localhost:5170/api/Usuarios\r\n", content);

                if(response.IsSuccessStatusCode)
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
