using System;
using System.ComponentModel.DataAnnotations;
using service.CustomValidation;

namespace service.Models
{
    public class TrackEntry
    {
        [Required]
        [Range(1851, 2022)]
        public int Year
        { get; set; }

        [Required]
        [Range(1, 12)]
        public int Month
        { get; set; }

        [Required]
        [Range(1, 31)]
        public int Day
        { get; set; }

        [Required]
        [Range(0, 18)]
        public int Hour
        { get; set; }

        [Required]
        [Range(0, 59)]
        public int Minute
        { get; set; }

        [Required]
        [RecordId(ErrorMessage = "RecordId must be N/A, C, G, I, L, P, R, S, T, or W.")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "RecordId must be 1 to 3 characters long.")]
        public string RecordId
        { get; set; }

        [Required]
        [Status(ErrorMessage = "Status must be TD, TS, HU, EX, SD, SS, LO, WV, or DB.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Status must be 2 characters long.")]
        public string Status
        { get; set; }

        [Required]
        public double Latitude
        { get; set; }

        [Required]
        [LatitudeHemisphere(ErrorMessage = "LatitudeHemisphere must be North or West")]
        public string LatitudeHemisphere
        { get; set; }

        [Required]
        public double Longitude
        { get; set; }

        [Required]
        [LongitudeHemisphere(ErrorMessage = "LongitudeHemisphere must be West or East")]
        public string LongitudeHemisphere
        { get; set; }

        [Required]
        [Range(0,999)]
        public int MaxWind
        { get; set;}

        [Required]
        [Range(0, 9999)]
        public int MinPressure
        { get; set; }

        [Required]
        public WindRadii ThirtyFour
        { get; set; }

        [Required]
        public WindRadii Fifty
        { get; set; }

        [Required]
        public WindRadii SixtyFour
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int MaxRadius
        { get; set; }

        public TrackEntry(string line)
		{
            List<string> lines = line.Split(",").ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                if (i == 2 && lines[i] == "  ")
                {
                    lines[i] = "N/A";
                }

                lines[i] = lines[i].Trim();
            }

            int year = 0;
            Int32.TryParse(lines[0].Substring(0,4), out year);
            Year = year;

            int month = 0;
            Int32.TryParse(lines[0].Substring(4, 2), out month);
            Month = month;

            int day = 0;
            Int32.TryParse(lines[0].Substring(6), out day);
            Day = day;

            int hour = 0;
            Int32.TryParse(lines[1].Substring(0,2), out hour);
            Hour = hour;

            int minute = 0;
            Int32.TryParse(lines[1].Substring(2), out minute);
            Minute = minute;

            RecordId = lines[2];

            Status = lines[3];

            LatitudeHemisphere = lines[4][lines[4].Length - 1].ToString();

            string latitude = "";
            if (lines[4].Contains("N"))
            {
                latitude = lines[4].TrimEnd('N');
            }
            else if (lines[4].Contains("S"))
            {
                latitude = lines[4].TrimEnd('S');
            }
            latitude = latitude.Replace('.',',');
            Latitude = Convert.ToDouble(latitude);

            LongitudeHemisphere = lines[5][lines[5].Length - 1].ToString();

            string longitude = "";
            if (lines[5].Contains("W"))
            {
                longitude = lines[5].TrimEnd('W');
            }
            else if (lines[5].Contains("E"))
            {
                longitude = lines[5].TrimEnd('E');
            }
            longitude = longitude.Replace('.', ',');
            Longitude = Convert.ToDouble(longitude);

            int maxWind = 0;
            Int32.TryParse(lines[6], out maxWind);
            MaxWind = maxWind;

            int minPressure = 0;
            Int32.TryParse(lines[7], out minPressure);
            MinPressure = minPressure;

            ThirtyFour = new WindRadii(lines[8], lines[9], lines[10], lines[11]);

            Fifty = new WindRadii(lines[12], lines[13], lines[14], lines[15]);

            SixtyFour = new WindRadii(lines[16], lines[17], lines[18], lines[19]);

            int maxRadius = 0;
            Int32.TryParse(lines[20], out maxRadius);
            MaxRadius = maxRadius;
        }

        public override string ToString()
        {
            return $"Year: {Year}; Month: {Month}; Day: {Day}; Hour: {Hour}; Minute: {Minute}; RecordId: {RecordId}; Latitude: {Latitude}{LatitudeHemisphere}; Longitude:{Longitude}{LongitudeHemisphere}; MaxWind: {MaxWind}; MinPressure: {MinPressure}; 34 kt (NE, SE, SW, NW): {ThirtyFour.NE}{ThirtyFour.SE}{ThirtyFour.SW}{ThirtyFour.NW}; 50 kt (NE, SE, SW, NW): {Fifty.NE}{Fifty.SE}{Fifty.SW}{Fifty.NW}; 50 kt (NE, SE, SW, NW): {SixtyFour.NE}{SixtyFour.SE}{SixtyFour.SW}{SixtyFour.NW}; MaxRadius: {MaxRadius};";
        }
    }
}

