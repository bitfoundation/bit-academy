using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlazorCalculator.Pages
{
    public partial class Calculator
    {
        public decimal Num1 { get; set; }

        public decimal Num2 { get; set; }

        public string Finalresult { get; set; }

        public void AddNumbers()
        {
            Finalresult = (Num1 + Num2).ToString();
        }

        public void SubtractNumbers()
        {
            Finalresult = (Num1 - Num2).ToString();
        }

        public void MultiplyNumbers()
        {
            Finalresult = (Num1 * Num2).ToString();
        }

        public void DivideNumbers()
        {
            if (Num2 != 0)
            {
                Finalresult = (Num1 / Num2).ToString("0.##");
            }
            else
            {
                Finalresult = "Cannot Divide by Zero";
            }
        }
    }
}
