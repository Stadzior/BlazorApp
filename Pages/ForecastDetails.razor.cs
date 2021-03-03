using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class ForecastDetails
    {
        public WeatherForecast Forecast { get; set; } = new WeatherForecast();

        [Parameter]
        public string Date { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            var forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
            Forecast = forecasts.Single(forecast => forecast.Date.ToString("yyy-MM-dd").Equals(Date));
        }
    }
}