using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApplication
{
    class Default
    {
        private static Log logger = new Log();

        static void Main(string[] args)
        {
            List<City> cities;
            CityManager cm = new CityManager();
            City cityTmp;

            //gets the list of the cities from TUI Musement's API and print them
            //call https://api.musement.com/api/v3/cities?json
            cities = cm.GetListCities().GetAwaiter().GetResult();

            foreach(var city in cities)
            {

                //call https://api.musement.com/api/v3/cities/ID?json, in case you need a single city 
                //cityTmp = cm.GetCity(city.id).GetAwaiter().GetResult();

                //call http://api.weatherapi.com/v1/forecast.json?key=[your-key]&q=[lat],[long]&days=2
                cm.printWeatherTodayTomorrow(city);
            }


        }
    }
}
