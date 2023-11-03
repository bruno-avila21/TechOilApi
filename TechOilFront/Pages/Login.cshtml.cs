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
            string contrase�a = Request.Form["contrase�a"];


            var data = new
            {
                nombre = nombre,
                contrase�a = contrase�a

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
