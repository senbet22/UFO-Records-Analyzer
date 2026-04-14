using UFO_Records_Analyzer.Models;

namespace UFO_Records_Analyzer.Services
{
    public class CsvReader
    {
        public List<UfoSighting> ReadCsv(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var data = new List<UfoSighting>();

            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',');

                // Skip bad rows
                if (parts.Length < 11)
                    continue;

                double.TryParse(parts[5], out var duration);
                double.TryParse(parts[9], out var latitude);
                double.TryParse(parts[10], out var longitude);

                DateTime.TryParse(parts[0], out var dateTime);
                DateTime.TryParse(parts[8], out var datePosted);

                var sighting = new UfoSighting
                {
                    DateTime = dateTime,
                    City = parts[1],
                    State = parts[2],
                    Country = parts[3],
                    Shape = parts[4],
                    DurationSeconds = duration,
                    Comments = parts[7],
                    DatePosted = datePosted,
                    Latitude = latitude,
                    Longitude = longitude
                };

                data.Add(sighting);
            }

            return data;
        }
    }
}

