using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace IntroduccionRazor.Pages
{
    public class FormulaModel : PageModel
    {
        [BindProperty] public int A { get; set; }
        [BindProperty] public int B { get; set; }
        [BindProperty] public int X { get; set; }
        [BindProperty] public int Y { get; set; }
        [BindProperty] public int N { get; set; }
        public string Resultado { get; set; } = "";

        public void OnPost()
        {
            StringBuilder resultado = new();

            for (int k = 0; k <= N; k++)
            {
                long coef = Binomial(N, k);
                double axPow = Math.Pow(A * X, N - k);
                double byPow = Math.Pow(B * Y, k);
                double term = coef * axPow * byPow;

                resultado.Append($"{term}");

                if (k < N)
                    resultado.Append(" + ");
            }

            Resultado = resultado.ToString();
        }

        private long Binomial(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        private long Factorial(int num)
        {
            long result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}