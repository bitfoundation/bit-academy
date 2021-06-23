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

        public string FinalResult { get; set; }

        public void AddNumbers()
        {
            FinalResult = (Num1 + Num2).ToString("0.##");
        }

        public void SubtractNumbers()
        {
            FinalResult = (Num1 - Num2).ToString("0.##");
        }

        public void MultiplyNumbers()
        {
            FinalResult = (Num1 * Num2).ToString("0.##");
        }

        public void DivideNumbers()
        {
            if (Num2 != 0)
            {
                FinalResult = (Num1 / Num2).ToString("0.##");
            }
            else
            {
                FinalResult = "Cannot Divide by Zero";
            }
        }
    }
}
