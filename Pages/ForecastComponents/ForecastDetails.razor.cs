using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages.ForecastComponents
{
    public partial class ForecastDetails
    {
        public WeatherForecast Forecast { get; set; } = new WeatherForecast();

        [Parameter]
        public string Date { get; set; }

        [Parameter]
        public bool ShowDetails { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            var forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
            Forecast = forecasts.Single(forecast => forecast.Date.ToString("yyy-MM-dd").Equals(Date));
        }
    }
}