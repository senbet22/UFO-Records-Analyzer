
using UFO_Records_Analyzer.Services;

namespace UFO_Records_Analyzer.Controllers
{
    public class AppController
    {
        public void Run()
        {
            var reader = new CsvReader();

            string filePath = "ufodata.csv";

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File not found -> {filePath}");
                return;
            }

            var data = reader.ReadCsv(filePath);

            // Select() query to extract cities from the data.(First 10 cities)
            var cities = data.Select(d => d.City);

            Console.WriteLine("Cities:");
            foreach (var city in cities.Take(10))
            {
                Console.WriteLine(city);
            }

            Console.WriteLine();

            // Where() query to filter sightings in the US.
            var usSightings = data.Where(d => d.Country == "us");

            Console.WriteLine("US Sightings:");
            foreach (var sighting in usSightings.Take(10))
            {
                Console.WriteLine($"{sighting.City}, {sighting.State}");
            }

            // Filtering by date range. (year, month, day)
            Console.WriteLine("Filtered Data by Date Range:");
            DateTime startDate = new DateTime(1998, 6, 7);
            DateTime endDate = new DateTime(1998, 6, 8);
            var filteredData = data
                .Where(r => r.DateTime >= startDate && r.DateTime <= endDate)
                .ToList();

            foreach (var record in filteredData.Take(10))
            {
                Console.WriteLine($"{record.DateTime}: {record.City}, {record.Country}");
            };

            // Demonstration of Select() and Distinct() to find unique countries in the dataset.
            Console.WriteLine("Unique Countries: in the Dataset");
            var uniqueCountries = data.Select(d => d.Country).Distinct();

            Console.WriteLine("Countries:");
            foreach (var country in uniqueCountries)
            {
                Console.WriteLine(country);
            }
        }
    }
}
