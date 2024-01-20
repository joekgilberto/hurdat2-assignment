using System;
using System.ComponentModel.DataAnnotations;

namespace service.Models
{
    //Creates the model for TrackEntry
    public class TrackEntry
    {
        //Creates a Year integer property
        public int Year
        { get; set; }

        //Creates a Month integer property
        public int Month
        { get; set; }

        //Creates a Day integer property
        public int Day
        { get; set; }

        //Creates a Hour integer property
        public int Hour
        { get; set; }

        //Creates a Minute integer property
        public int Minute
        { get; set; }

        //Creates a RecordId string property
        public string RecordId
        { get; set; }

        //Creates a Status string property
        public string Status
        { get; set; }

        //Creates a Latitude double property
        public double Latitude
        { get; set; }

        //Creates a LatitudeHemisphere string property
        public string LatitudeHemisphere
        { get; set; }

        //Creates a Longitude double property
        public double Longitude
        { get; set; }

        //Creates a LongitudeHemisphere string property
        public string LongitudeHemisphere
        { get; set; }

        //Creates a MaxWind integer property
        public int MaxWind
        { get; set;}

        //Creates a MaxWind integer property
        public int MinPressure
        { get; set; }

        //Creates a ThirtyFour WindRadii property
        public WindRadii ThirtyFour
        { get; set; }

        //Creates a Fifty WindRadii property
        public WindRadii Fifty
        { get; set; }

        //Creates a SixtyFour WindRadii property
        public WindRadii SixtyFour
        { get; set; }

        //Creates a MaxRadius integer property
        public int MaxRadius
        { get; set; }

        //Creates a constructor with a parameter of an entry line from the .txt file
        public TrackEntry(string line)
		{
            //Splits the line into a list of strings by the commas
            List<string> lines = line.Split(",").ToList();

            //Iterates over the list and cleans up each string by removing spaces from the line and adding them back to their indexed position
            for (int i = 0; i < lines.Count; i++)
            {
                //If the second string is "  ", it is replaced with "N/A"
                if (i == 2 && lines[i] == "  ")
                {
                    lines[i] = "N/A";
                }

                lines[i] = lines[i].Trim();
            }

            //Assigns Year to the first four characters of lines[0], parsed into an integer
            int year = 0;
            Int32.TryParse(lines[0].Substring(0,4), out year);
            Year = year;

            //Assigns Month to the next two characters of lines[0], parsed into an integer
            int month = 0;
            Int32.TryParse(lines[0].Substring(4, 2), out month);
            Month = month;

            //Assigns Day to the final characters of lines[0], parsed into an integer
            int day = 0;
            Int32.TryParse(lines[0].Substring(6), out day);
            Day = day;

            //Assigns Hour to the first two characters of lines[1], parsed into an integer
            int hour = 0;
            Int32.TryParse(lines[1].Substring(0,2), out hour);
            Hour = hour;

            //Assigns Hour to the remaining characters of lines[1], parsed into an integer
            int minute = 0;
            Int32.TryParse(lines[1].Substring(2), out minute);
            Minute = minute;

            //Assigns RecordId to lines[2]
            RecordId = lines[2];

            //Assigns Status to lines[3]
            Status = lines[3];

            //Assigns LatitudeHemisphere to the last character of lines[4]
            LatitudeHemisphere = lines[4][lines[4].Length - 1].ToString();

            //Assigns Latitude to lines[4] exluding its last character, parsed into an double
            string latitude = lines[4].TrimEnd(lines[4][lines[4].Length - 1]);
            Latitude = Convert.ToDouble(latitude);

            //Assigns LongitudeHemisphere to the last character of lines[5]
            LongitudeHemisphere = lines[5][lines[5].Length - 1].ToString();

            //Assigns Longitude to lines[5] exluding its last character, parsed into an double
            string longitude = lines[5].TrimEnd(lines[5][lines[5].Length - 1]);
            Longitude = Convert.ToDouble(longitude);

            //Assigns MaxWind to lines[6] exluding its last character, parsed into an integer
            int maxWind = 0;
            Int32.TryParse(lines[6], out maxWind);
            MaxWind = maxWind;

            //Assigns MinPressure to lines[7] exluding its last character, parsed into an integer
            int minPressure = 0;
            Int32.TryParse(lines[7], out minPressure);
            MinPressure = minPressure;

            //Assigns ThirtyFour to a new instance of WindRadii, containing lines[8], lines[9], lines[10], and lines[11]
            ThirtyFour = new WindRadii(lines[8], lines[9], lines[10], lines[11]);

            //Assigns Fifty to a new instance of WindRadii, containing lines[12], lines[13], lines[14], and lines[15]
            Fifty = new WindRadii(lines[12], lines[13], lines[14], lines[15]);

            //Assigns SixtyFour to a new instance of WindRadii, containing lines[16], lines[17], lines[18], and lines[19]
            SixtyFour = new WindRadii(lines[16], lines[17], lines[18], lines[19]);

            //Assigns MaxRadius to lines[20] exluding its last character, parsed into an integer
            int maxRadius = 0;
            Int32.TryParse(lines[20], out maxRadius);
            MaxRadius = maxRadius;
        }

        //Overrides the existing ToString() method to return a string of the TrackEntry's properties
        public override string ToString()
        {
            return $"Year: {Year}; Month: {Month}; Day: {Day}; Hour: {Hour}; Minute: {Minute}; RecordId: {RecordId};  Status: {Status}; Latitude: {Latitude}{LatitudeHemisphere}; Longitude: {Longitude}{LongitudeHemisphere}; MaxWind: {MaxWind}; MinPressure: {MinPressure}; 34 kt (NE, SE, SW, NW): {ThirtyFour.NE}{ThirtyFour.SE}{ThirtyFour.SW}{ThirtyFour.NW}; 50 kt (NE, SE, SW, NW): {Fifty.NE}{Fifty.SE}{Fifty.SW}{Fifty.NW}; 50 kt (NE, SE, SW, NW): {SixtyFour.NE}{SixtyFour.SE}{SixtyFour.SW}{SixtyFour.NW}; MaxRadius: {MaxRadius};";
        }
    }
}

