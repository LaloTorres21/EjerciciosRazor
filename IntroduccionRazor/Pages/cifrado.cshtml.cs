using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace IntroduccionRazor.Pages
{
    public class cifradoModel : PageModel
    {
        [BindProperty]
        public string Mensaje { get; set; } = "";

        [BindProperty]
        public int Desplazamiento { get; set; }

        [BindProperty]
        public string Opcion { get; set; } = "codificar";

        public string Resultado { get; set; } = "";

        public void OnPost()
        {
            string mensajeMayus = Mensaje.ToUpper();
            StringBuilder resultado = new();

            if (Opcion == "codificar")
            {
                // Usamos ciclo while para codificar
                int i = 0;
                while (i < mensajeMayus.Length)
                {
                    char c = mensajeMayus[i];
                    if (char.IsLetter(c))
                    {
                        char nuevo = (char)(((c - 'A' + Desplazamiento) % 26) + 'A');
                        resultado.Append(nuevo);
                    }
                    else
                    {
                        resultado.Append(c);
                    }
                    i++;
                }
            }
            else if (Opcion == "decodificar")
            {
                // Usamos ciclo do-while para decodificar
                int i = 0;
                do
                {
                    if (i >= mensajeMayus.Length) break;

                    char c = mensajeMayus[i];
                    if (char.IsLetter(c))
                    {
                        char nuevo = (char)(((c - 'A' - Desplazamiento + 26) % 26) + 'A');
                        resultado.Append(nuevo);
                    }
                    else
                    {
                        resultado.Append(c);
                    }
                    i++;
                } while (i < mensajeMayus.Length);
            }

            Resultado = resultado.ToString();
        }

        public void OnGet() { }
    }
}