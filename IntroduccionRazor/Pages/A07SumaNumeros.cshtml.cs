using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages
{
    public class A07SumaNumerosModel : PageModel
    {
        // Definimos los atributos
        [BindProperty]
        public string num1 { get; set; } = "";
        [BindProperty]
        public string num2 { get; set; } = "";
        public int suma = 0;
        public void OnGet()
        {
        }

        public void OnPost()
        {
            // Recibimos los datos del formulario y los convertimos a número
            int numero1 = Convert.ToInt32(num1);
            int numero2 = Convert.ToInt32(num2);
            suma = numero1 + numero2;
            ModelState.Clear();
        }
    }
}