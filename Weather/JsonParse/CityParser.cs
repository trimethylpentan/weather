using System;
using GLib;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Weather
{
    public static class CityParser
    {
        public static List<City> ParseCities()
        {
            StreamReader streamReader = new StreamReader("data/city.list.json");
            string json = streamReader.ReadToEnd();
            List<City> cities = JsonConvert.DeserializeObject<List<City>>(json);

            return cities;
        }
    }
}
