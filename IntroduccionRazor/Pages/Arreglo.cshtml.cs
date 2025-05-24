using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroduccionRazor.Pages
{
    public class ArregloModel : PageModel
    {
        [BindProperty]
        public int[] Numeros { get; set; } = new int[20];

        [BindProperty]
        public int[] NumerosOrdenados { get; set; } = new int[20];

        public int Suma { get; set; }
        public double Promedio { get; set; }
        public List<int> Modas { get; set; } = new List<int>();
        public double Mediana { get; set; }

        public void OnGet()
        {
            GenerarNumeros();
            CalcularEstadisticas();
        }

        public IActionResult OnPostGenerar()
        {
            GenerarNumeros();
            CalcularEstadisticas();
            return Page();
        }

        private void GenerarNumeros()
        {
            var aleatorio = new Random();
            for (int i = 0; i < 20; i++)
            {
                Numeros[i] = aleatorio.Next(0, 101);
            }
        }

        private void CalcularEstadisticas()
        {
            // Calcular suma y promedio
            Suma = Numeros.Sum();
            Promedio = Numeros.Average();

            // Ordenar números
            NumerosOrdenados = Numeros.OrderBy(n => n).ToArray();

            // Calcular moda
            var frecuencia = new Dictionary<int, int>();
            foreach (var num in Numeros)
            {
                if (frecuencia.ContainsKey(num))
                    frecuencia[num]++;
                else
                    frecuencia[num] = 1;
            }
            int frecuenciaMaxima = frecuencia.Values.Max();
            Modas = frecuencia.Where(par => par.Value == frecuenciaMaxima).Select(par => par.Key).ToList();

            // Calcular mediana
            int longitud = NumerosOrdenados.Length;
            if (longitud % 2 == 0)
            {
                Mediana = (NumerosOrdenados[longitud / 2 - 1] + NumerosOrdenados[longitud / 2]) / 2.0;
            }
            else
            {
                Mediana = NumerosOrdenados[longitud / 2];
            }
        }
    }
}