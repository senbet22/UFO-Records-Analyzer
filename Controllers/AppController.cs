using System;
using System.Collections.Generic;
using System.Text;
using UFO_Records_Analyzer.Services;

namespace UFO_Records_Analyzer.Controllers
{
    public class AppController
    {
        public void Run()
        {
            var reader = new CsvReader();
            var data = reader.ReadCsv("ufodata.csv");

            // Select()
            var cities = data.Select(d => d.City);

            Console.WriteLine("Cities:");
            foreach (var city in cities.Take(10))
            {
                Console.WriteLine(city);
            }

            Console.WriteLine();


            // Where()
            var usSightings = data.Where(d => d.Country == "us");

            Console.WriteLine("US Sightings:");
            foreach (var sighting in usSightings.Take(10))
            {
                Console.WriteLine($"{sighting.City}, {sighting.State}");
            }




            // Filtering by date range. (year, month, day)
            DateTime startDate = new DateTime(1998, 6, 7);
            DateTime endDate = new DateTime(1998, 6, 8);
            var filteredData = data
                .Where(r => r.DateTime >= startDate && r.DateTime <= endDate)
                .ToList();

            foreach (var record in filteredData.Take(10))
            {
                Console.WriteLine($"{record.DateTime}: {record.City}, {record.Country}");
            };
        }
    }
}
