using System;
namespace service.Models
{
    //Creates the model for Landfall
    public class Landfall
	{
        //Creates a ATCFCode string property
        public string ATCFCode
        { get; set; }

        //Creates a Name string property
        public string Name
        { get; set; }

        //Creates a Year int property
        public int Year
        { get; set; }

        //Creates a Month int property
        public int Month
        { get; set; }

        //Creates a Day int property
        public int Day
        { get; set; }

        //Creates a MaxWind int property
        public int MaxWind
        { get; set; }

        //Creates a constructor with a parameter of two strings (an atcfCode and a name) and a TrackEntry
        public Landfall(string atcfCode, string name, TrackEntry entry)
		{
            //Assigns the property ATCFCode to atcfCode
            ATCFCode = atcfCode;

            //Assigns the property Name to name
            Name = name;

            //Assigns the property Year to the year of the entry
            int year = entry.Year;
            Year = year;

            //Assigns the property Month to the month of the entry
            int month = entry.Month;
            Month = month;

            //Assigns the property Day to the day of the entry
            int day = entry.Day;
            Day = day;

            //Assigns the property MaxWind to the maxWind of the entry
            int maxWind = entry.MaxWind;
            MaxWind = maxWind;
        }
	}
}

