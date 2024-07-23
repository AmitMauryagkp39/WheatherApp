using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.Service
{
    public static class ApiService
    {
        public static async Task<Root> Getweather(double latitude,double longitude)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&units=metric&appid=10b92ab92187c6818e3075b450ce6759",latitude,longitude));
            return JsonConvert.DeserializeObject<Root>(response);
        }

        public static async Task<Root> GetweatherByCity(string city)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&units=metric&appid=10b92ab92187c6818e3075b450ce6759", city));
            return JsonConvert.DeserializeObject<Root>(response);
        }
    }
}
