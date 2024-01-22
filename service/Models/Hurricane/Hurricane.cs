using System;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;
using service.Data;

namespace service.Models
{
    //Creates the model for Hurricane
	public class Hurricane
	{
        //Creates a ATCFCode string property
        public string ATCFCode
        { get; set; }

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

        //Creates a TrackEntryCount integer property
        public int TrackEntryCount
        { get; set; }

        //Creates a TrackEntries property that is a list of TrackEntry instances
        public List<TrackEntry> TrackEntries
        { get; set; }

        public int LandfallEntry
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

            //Assigns ATCFCode to lines[0]
            ATCFCode = lines[0];

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

        //Creates a method to return etheir an instance of Landfall or null based on if the instance of Hurricane made landfall in Florida as a hurricane status from 1900 onward
        public Landfall? createLandfall(FloridaData floridaData)
        {

            //Iterates through the TrackEntries property
            for(int i = 0; i < TrackEntries.Count; i++)
            {
                //Caches the current TrackEntry to the TrackEntry variable entry
                TrackEntry entry = TrackEntries[i];

                //Assigns longitude and latitude doubles to the Longitude and Latitude properties of the selected TrackEntry
                double longitude = entry.Longitude;
                double latitude = entry.Latitude;

                //If the LongitudeHemisphere of the TrackEntry is W (for West), the logitude is made negative
                if (entry.LongitudeHemisphere.Contains('W'))
                {
                    longitude = longitude * -1;
                }

                //If the LatitudeHemisphere of the TrackEntry is S (for South), the latitude is made negative
                if (entry.LatitudeHemisphere.Contains('S'))
                {
                    latitude = latitude * -1;
                }

                //Creates a new instance of a Point a new instance a Coordinate passed as an argument to its constructor, with the latitude and longitude doubles passed to the Coordinate constructor
                Point currentPoint = new Point(new Coordinate(latitude, longitude));

                //Checks to ensure floridaData.Coordinates is not null, and if floridaData.Coordinates is null the method returns null
                if (floridaData.Coordinates == null)
                {
                    return null;
                } else {
                    //Iterates through floridaData.Coordinates
                    foreach (List<List<List<double>>> coordGroup in floridaData.Coordinates)
                    {
                        //Creates a new list of Coordinate that is the length of the first list of the coordGroup's length
                        Coordinate[] coordList = new Coordinate[coordGroup[0].Count];

                        //Iterates over the first list of a coordGroup
                        for (int j = 0; j < coordGroup[0].Count; j++)
                        {
                            //For each set of cooridnates in the coordGroup's second list, it passes the latitude and longitude (second and first index of the final nested list respectively) to the constructor of a new Coordinate instance
                            //And assigns said the create coordinate to the current index of the coordList
                            Coordinate addedCoord = new Coordinate(coordGroup[0][j][1], coordGroup[0][j][0]);
                            coordList[j] = addedCoord;
                        }

                        //Creates a new Polygon with a new LinearRing passed as an argument to its constructor, with the coordList passed as the argument to the LinearRing constructor
                        Polygon section = new Polygon(new LinearRing(coordList));

                        //The polygon, section, checks if the currentPoint is in said polygon and saves the boolean return value to passes
                        bool passes = section.Contains(currentPoint);

                        //If passes is true, the current TrackEntry's method, IsHurricane, returns true, and the entry is from 1900 or later, the current index is saved to the LandfallEntry property and the method returns an instance of Landfall constructed with the ATCFCode and Name properties as well as the current entry
                        if (passes && entry.IsHurricane() && entry.Year >= 1900)
                        {
                            LandfallEntry = i;
                            Landfall landfall = new Landfall(ATCFCode, Name, entry);
                            return landfall;
                        }

                    }
                }

            }

            //If true is not returned beforehand (because no coordinates in the TrackEntries property are found within the polyogns and/or because the entry that is found within the polygon is not a hurricane upon landing in Florida from 1900 onward), the method defaults to returning null
            return null;
        }

        //Overrides the existing ToString() method to return a string of the Hurricane's properties
        public override string ToString()
        {
            return $"ATCFCode: {ATCFCode}; Basin: {Basin}; ATCFNumber: {ATCFNumber}; Year: {Year}; Name: {Name}; TrackEntryCount:{TrackEntryCount};";
        }
    }
}

