namespace BlazorApp.Pages
{
    public partial class Counter
    {
        public int CurrentCount {get; private set;} = 0;

        public void IncrementCount()
        {
            CurrentCount++;
        }
    }
}