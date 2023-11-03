using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace TechOilFront.Pages
{
    public class LoginModel : PageModel
    {
        public UsuariosModel usuario { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            string nombre = Request.Form["nombre"];
            string contraseña = Request.Form["contraseña"];


            var data = new
            {
                nombre = nombre,
                contraseña = contraseña

            };

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync("http://localhost:5170/api/Auth\r\n", content);

                if (response.IsSuccessStatusCode)
                {
                    
                    return RedirectToPage("/Index");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}
