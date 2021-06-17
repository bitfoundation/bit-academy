namespace SimpleBlazorCalculator.Pages
{
    public partial class Calculator
    {
        public decimal Num1 { get; set; }

        public decimal Num2 { get; set; }

        public string Finalresult { get; set; }

        void AddNumbers()
        {
            Finalresult = (Num1 + Num2).ToString();
        }

        void SubtractNumbers()
        {
            Finalresult = (Num1 - Num2).ToString();
        }

        void MultiplyNumbers()
        {
            Finalresult = (Num1 * Num2).ToString();
        }

        void DivideNumbers()
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
