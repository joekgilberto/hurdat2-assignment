using System;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;
using service.Data;

namespace service.Models
{
    //Creates the model for Hurricane
	public class Hurricane
	{
        //Creates a Basin string property
        public string Basin
		{ get; set; }

        //Creates an ATCFNumber integer property
        public int ATCFNumber
        { get; set; }

        //Creates a Year integer property
        public int Year
		{ get; set; }

        //Requries a Name string property
        public string Name
        { get; set; }

        //Creates an TrackEntryCount integer property
        public int TrackEntryCount
        { get; set; }

        //Creates a TrackEntries property that is a list of TrackEntry instances
        public List<TrackEntry> TrackEntries
        { get; set; }

        //Creates a constructor with a parameter of an entry line from the .txt file
        public Hurricane(string line)
		{
            //Splits the line into a list of strings by the commas
            List<string> lines = line.Split(",").ToList();

            //Iterates over the list and cleans up each string by removing spaces from the line and adding them back to their indexed position
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = lines[i].Trim();
            }

            //Assigns Basin to the first two characters of lines[0]
            Basin = lines[0].Substring(0, 2);

            //Assigns ATCFNumber to the second two characters of lines[0], parsed into an integer
            int atcfNumber = 0;
            Int32.TryParse(lines[0].Substring(2, 2), out atcfNumber);
            ATCFNumber = atcfNumber;

            //Assigns Year to the final characters of lines[0], parsed into an integer
            int year = 0;
            Int32.TryParse(lines[0].Substring(4), out year);
            Year = year;

            //Assigns Name to lines[1]
            Name = lines[1];

            //Assigns TrackEntryCount to lines[2], parsed into an integer
            int trackEntryCount = 0;
            Int32.TryParse(lines[2], out trackEntryCount);
            TrackEntryCount = trackEntryCount;

            //Assigns TrackEntries to an empty list of TrackEntry instances
            TrackEntries = new List<TrackEntry>();
        }

        //Creates a method to add TrackEntry instances to the TrackEntries property (a TrackEntry list)
        public void addTrackEntries(TrackEntry trackEntry)
        {
            TrackEntries.Add(trackEntry);
        }

        //Creates a method to return a string that represents the full ATCF code of a hurricane
        public string FullATCFCode()
        {
            string neededZero = "0";

            if (ATCFNumber < 10)
            {
                return $"{Basin}{neededZero}{ATCFNumber}{Year}";
            } else
            {
                return $"{Basin}{ATCFNumber}{Year}";
            }
            
        }


        public bool LandedInFlorida()
        {
            FloridaData florida = new FloridaData();

            foreach (TrackEntry entry in TrackEntries)
            {
                double longitude = entry.Longitude;
                double latitude = entry.Latitude;

                if (entry.LongitudeHemisphere.Contains('W'))
                {
                    longitude = longitude * -1;
                }

                if (entry.LatitudeHemisphere.Contains('S'))
                {
                    latitude = latitude * -1;
                }

                Point currentPoint = new Point(new Coordinate(latitude, longitude));

                foreach (List<List<List<double>>> coordGroup in florida.Coordinates)
                {
                    Coordinate[] coordList = new Coordinate[coordGroup[0].Count];

                    for (int i = 0; i < coordGroup[0].Count; i++)
                    {
                        Coordinate addedCoord = new Coordinate(coordGroup[0][i][1], coordGroup[0][i][0]);
                        coordList[i] = addedCoord;
                    }

                    Polygon section = new Polygon(new LinearRing(coordList));

                    bool passes = section.Contains(currentPoint);

                    if (passes && entry.IsHurricane())
                    {
                        return true;
                    }

                }
            }

            return false;
        }

        //Overrides the existing ToString() method to return a string of the Hurricane's properties
        public override string ToString()
        {
            return $"ATCFCode: {FullATCFCode()}; Basin: {Basin}; ATCFNumber: {ATCFNumber}; Year: {Year}; Name: {Name}; TrackEntryCount:{TrackEntryCount}; TrackEntries.Count: {TrackEntries.Count};";
        }
    }
}

