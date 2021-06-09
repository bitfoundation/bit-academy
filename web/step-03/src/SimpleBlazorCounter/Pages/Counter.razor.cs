namespace SimpleBlazorCounter.Pages
{
    public partial class Counter
    {
        public int currentCount = 0;

        public void Increase()
        {
            currentCount++;
        }

        public void Decrease()
        {
            currentCount--;
        }
    }
}
