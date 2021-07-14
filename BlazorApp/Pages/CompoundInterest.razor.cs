using System;

namespace BlazorApp.Pages
{
    public partial class CompoundInterest 
    {
        public double Principal { get; set; } = 5000;
        public double InterestRate { get; set; } = 5;
        public int Years { get; set; } = 10;
        public string Total { get; private set; }
        
        public void Calculate()
        {
            var total = Principal * Math.Pow(1 + InterestRate / (1200.0), Years * 12);
            Total = total.ToString("C");
        }
    }
}