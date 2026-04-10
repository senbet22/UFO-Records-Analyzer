namespace UFO_Records_Analyzer.Models
{
    internal class UfoSighting
    {
        // datetime,city,state,country,shape,duration (seconds),duration (hours/min),comments,date posted,latitude,longitude
        public DateTime DateTime { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Shape { get; set; }
        public double DurationSeconds { get; set; }
        public string? DurationHoursMin { get; set; }
        public string? Comments { get; set; }
        public DateTime DatePosted { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
