using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CityApplication
{
    //url = https://api.weatherapi.com/v1/forecast.json?key=c4df82a7ba994254b20211529220308&q=52.374,4.9&days=2

    public class Weather
    {
        [JsonProperty("location")]
        public Location location { get; set; }
        
        [JsonProperty("current")]
        public Current current { get; set; }

        [JsonProperty("forecast")]
        public Forecast forecast { get; set; }
    }

    //example:
    //"location":{"name":"Weesperzijde","region":"North Holland","country":"Netherlands","lat":52.37,"lon":4.9,"tz_id":"Europe/Amsterdam","localtime_epoch":1659561634,"localtime":"2022-08-03 23:20"}
    public class Location
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("region")]
        public string region { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("lat")]
        public double lat { get; set; }

        [JsonProperty("lon")]
        public double lon { get; set; }

        [JsonProperty("tz_id")]
        public string  tz_id { get; set; }

        [JsonProperty("localtime_epoch")]
        public int localtime_epoch { get; set; }

        [JsonProperty("localtime")]
        public DateTime localtime { get; set; }
        
    }

    //example:
    //"current":{"last_updated_epoch":1659561300,"last_updated":"2022-08-03 23:15","temp_c":21.0,"temp_f":69.8,"is_day":0,"condition":{"text":"Clear","icon":"//cdn.weatherapi.com/weather/64x64/night/113.png","code":1000},"wind_mph":5.6,"wind_kph":9.0,"wind_degree":150,"wind_dir":"SSE","pressure_mb":1013.0,"pressure_in":29.91,"precip_mm":0.0,"precip_in":0.0,"humidity":73,"cloud":0,"feelslike_c":21.0,"feelslike_f":69.8,"vis_km":10.0,"vis_miles":6.0,"uv":1.0,"gust_mph":5.1,"gust_kph":8.3}
    public class Current
    {
        [JsonProperty("condition")]
        public Condition Condition { get; set; }
    }

    //example:
    //"condition":{"text":"Clear","icon":"//cdn.weatherapi.com/weather/64x64/night/113.png","code":1000}
    public class Condition
    {
        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("icon")]
        public string icon { get; set; }

        [JsonProperty("code")]
        public string code { get; set; }
    }

    //example:
    //"forecast":{"forecastday":[{"date":"2022-08-03","date_epoch":1659484800,"day":{.....}]}
    public class Forecast
    {
        [JsonProperty("forecastday")]
        public ForecastDay[] forecastDay { get; set; }
    }

    //example:
    //"forecastday":[{"date":"2022-08-03","date_epoch":1659484800,"day":{.....}]}
    public class ForecastDay
    {
        [JsonProperty("date")]
        public DateTime date { get; set; }

        [JsonProperty("day")]
        public Day day { get; set; }
    }

    //example:
    //"day":{"maxtemp_c":31.4,"maxtemp_f":88.5,...,"condition":{"text":"Sunny","icon":"//cdn.weatherapi.com/weather/64x64/day/113.png","code":1000},"uv":6.0},"astro":{"sunrise":...
    public class Day
    {
        [JsonProperty("condition")]
        public Condition condition { get; set; }
    }


}
