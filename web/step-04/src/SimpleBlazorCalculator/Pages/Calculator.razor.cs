using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlazorCalculator.Pages
{
    public partial class Calculator
    {
        string num1;
        string num2;
        string finalresult;

        void AddNumbers()
        {
            finalresult = (Convert.ToDouble(num1) + Convert.ToDouble(num2)).ToString();
        }

        void SubtractNumbers()
        {
            finalresult = (Convert.ToDouble(num1) - Convert.ToDouble(num2)).ToString();
        }

        void MultiplyNumbers()
        {
            finalresult = (Convert.ToDouble(num1) * Convert.ToDouble(num2)).ToString();
        }

        void DivideNumbers()
        {
            if (Convert.ToDouble(num2) != 0)
            {
                finalresult = (Convert.ToDouble(num1) / Convert.ToDouble(num2)).ToString();
            }
            else
            {
                finalresult = "Cannot Divide by Zero";
            }
        }
    }
}
