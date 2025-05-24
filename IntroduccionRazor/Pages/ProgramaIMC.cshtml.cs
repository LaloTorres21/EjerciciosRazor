using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages
{
    public class ProgramaIMCModel : PageModel
    {
        [BindProperty]
        public double peso { get; set; }
        [BindProperty]
        public double altura { get; set; }

        public double imc { get; set; }
        public string clasificacion { get; set; } = "";
        public string imagen { get; set; } = "";

        public void OnGet() { }

        public void OnPost()
        {
            if (peso > 0 && altura > 0)
            {
                imc = peso / Math.Pow(altura / 100, 2);

                switch (imc)
                {
                    case < 18:
                        clasificacion = "Peso bajo";
                        imagen = "/img/pesobajo.png";
                        break;

                    case >= 18 and < 25:
                        clasificacion = "Peso normal";
                        imagen = "/img/pesonormal.png";
                        break;

                    case >= 25 and < 27:
                        clasificacion = "Sobrepeso";
                        imagen = "/img/sobrepeso.png";
                        break;

                    case >= 27 and < 30:
                        clasificacion = "Obesidad grado I";
                        imagen = "/img/obesidad1.png";
                        break;

                    case >= 30 and < 40:
                        clasificacion = "Obesidad grado II";
                        imagen = "/img/obesidad2.png";
                        break;

                    case >= 40:
                        clasificacion = "Obesidad grado III";
                        imagen = "/img/obesidad3.png";
                        break;
                }
            }
        }
    }
}