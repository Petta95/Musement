using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApplication
{
    class Log
    {
        public void LogError(string method, string message, string stackTrace)
        {
            Console.WriteLine("Method: " + method + ", Message: " + message + ", StackTrace: " + stackTrace);
        }

        public void LogCity(string nameCity, string weatherToday, string weatherTomorrow)
        {
            Console.WriteLine("Processed city " + nameCity + " | " + weatherToday + " - " + weatherTomorrow);
        }

        //day is the day of the week starting from today (0=today, 1=tomorrow, etc)
        public void LogCityDay(string nameCity, string weather, int day)
        {
            switch(day)
            {
                case 0:
                    Console.WriteLine("Processed city " + nameCity + " | weather Today: " + weather);
                    break;
                case 1:
                    Console.WriteLine("Processed city " + nameCity + " | weather Tomorrow: " + weather);
                    break;
                default:
                    Console.WriteLine("Processed city " + nameCity + " | weather Today: " + weather);
                    break;

            }
        }

        public void LogCityTomorrow(string nameCity, string weatherTomorrow)
        {
            Console.WriteLine("Processed city " + nameCity + " | " + weatherTomorrow);
        }

        public void LogCityDay(string nameCity, string weatherDay)
        {
            Console.WriteLine("Processed city " + nameCity + " | " + weatherDay);
        }
    }
}
