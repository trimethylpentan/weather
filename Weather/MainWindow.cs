using System;
using Gtk;
using Weather;
using System.Collections.Generic;

public partial class MainWindow : Gtk.Window
{
    readonly List<City> cities = new List<City>();

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        cities = CityParser.ParseCities(); 
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void SearchLocation(object sender, EventArgs e)
    {
        TextInsertedArgs arguments = (TextInsertedArgs)e;
        if (locationEntry.Text.Length > 3)
        {
            List<City> matchedCities = new List<City>();
            foreach (City city in cities)
            {
                if (city.name.StartsWith(locationEntry.Text, StringComparison.InvariantCulture))
                {
                    matchedCities.Add(city);
                }
            }

            foreach (City matchedCity in matchedCities)
            {
                Console.WriteLine(matchedCity.name);
            }
        }
    }
}
