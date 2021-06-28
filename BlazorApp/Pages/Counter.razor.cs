namespace BlazorApp.Pages
{
    public partial class Counter
    {
        public int CurrentCount {get; set;}

        public void IncrementCount()
        {
            CurrentCount++;
        }
        public void DecrementCount()
        {
            if (CurrentCount > 0)
                CurrentCount--;
        }
        public void ResetCount()
        {
            CurrentCount = 0;
        }
    }
}