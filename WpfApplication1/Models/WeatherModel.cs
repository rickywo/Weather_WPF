using DarkSkyApi.Models;
using DarkSkyApi;
using System.Threading.Tasks;

namespace WpfApplication1.Models
{
    public class WeatherModel:ObservableObject
    {
        private DarkSkyService client;
        public Forecast result { get; set; }

        public WeatherModel()
        {
            client = new DarkSkyService("1b595caae53771e816c2f6771a521e98");
        }

        public async Task<bool> getForcast()
        {
            result = await client.GetWeatherDataAsync(37.8267, -122.423);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
