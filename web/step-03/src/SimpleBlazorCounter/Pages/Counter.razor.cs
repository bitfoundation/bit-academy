namespace SimpleBlazorCounter.Pages;

public partial class Counter
{
    public int CurrentCount { get; set; }

    public void Increase()
    {
        CurrentCount++;
    }

    public void Decrease()
    {
        CurrentCount--;
    }
}
