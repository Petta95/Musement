using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CityApplication
{
    public class CityManager
    {
        private const string CityURL = "https://api.musement.com/api/v3/cities"; 
        private const string WeatherURL = "https://api.weatherapi.com/v1/forecast.json";
        private static Log logger = new Log();
        private static string key = "c4df82a7ba994254b20211529220308";
        HttpClient client = new HttpClient();

        //gets the list of the cities from TUI Musement's API
        public async Task<List<City>> GetListCities()
        {
            List<City> listCities = new List<City>();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await client.GetAsync(CityURL + ".json"); 
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    listCities = JsonConvert.DeserializeObject<List<City>>(content);
                }
            }
            catch (System.Exception ex)
            {
                logger.LogError("GetListCities", ex.Message, ex.StackTrace);
            }

            return listCities;
        }

        //gets city from TUI Musement's API based on its ID
        public async Task<City> GetCity(int id)
        {
            City city = null;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await client.GetAsync(CityURL + "/" + id + ".json");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    city = JsonConvert.DeserializeObject<City>(content);
                }
                
            }
            catch (System.Exception ex)
            {
                logger.LogError("GetCity", ex.Message, ex.StackTrace);
            }

            return city;
        }

        //Log City name and Weather of today and tomorrow
        public async void printWeatherTodayTomorrow(City city)
        {
            try
            {
                Weather result = await GetInfoWeather(city, 2);

                logger.LogCity(city.name, result.current.Condition.text, result.forecast.forecastDay[1].day.condition.text);
            }
            catch (System.Exception ex)
            {
                logger.LogError("printWeatherTodayTomorrow", ex.Message, ex.StackTrace);
            }

        }

        //What's the weather in [city] today ?
        public async void printWeatherToday(City city)
        {
            try
            {
                Weather result = await GetInfoWeather(city, 1);

                logger.LogCityDay(city.name, result.current.Condition.text, 0);
            }
            catch (System.Exception ex)
            {
                logger.LogError("printWeatherToday", ex.Message, ex.StackTrace);
            }
        }

        //What will it be the weather in [city] tomorrow ?
        public async void printWeatherTomorrow(City city)
        {
            try
            {
                Weather result = await GetInfoWeather(city, 2);

                logger.LogCityTomorrow(city.name, result.forecast.forecastDay[1].day.condition.text);
            }
            catch (System.Exception ex)
            {
                logger.LogError("printWeatherTomorrow", ex.Message, ex.StackTrace);
            }

        }


        //What will it be the weather in [city] in [days] ? (etc: weather in 2 days, you have to take days+1 from url)
        public async void printWeatherDay(City city, int days)
        {
            try
            {
                Weather result = await GetInfoWeather(city, days+1);

                logger.LogCityTomorrow(city.name, result.forecast.forecastDay[days].day.condition.text);
            }
            catch (System.Exception ex)
            {
                logger.LogError("printWeatherTomorrow", ex.Message, ex.StackTrace);
            }
        }

        //gets the info of the city from Weather's API
        public async Task<Weather> GetInfoWeather(City city, int days)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Weather result = null;
            var response = await client.GetAsync(WeatherURL + "?key=" + key + "&q=" + city.latitude + "," + city.longitude + "&days=" + days);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Weather>(content);
            }
            return result;
        }


    }
}
