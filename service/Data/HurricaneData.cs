using System;
using service.Models;
using Microsoft.AspNetCore.Http;

namespace service.Data
{
    //Creates the class HurricaneData
	public class HurricaneData
	{
        //Creates the property Hurricanes, which holds a list of Hurricane instances
        public List<Hurricane> Hurricanes
        { get; set; }

        //Creates the property Landfalls, which holds a list of Landfall instances
        public List<Landfall> Landfalls
        { get; set; }

        //Creates a constructor (with no parameters) for HurricaneData
        public HurricaneData()
        {
            //Takes the lines of the hurdat2 .txt file and turns them into a list of strings stored in lines
            string hurdat2Path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "hurdat2-1851-2022-050423.txt");
            List<string> lines = File.ReadAllLines(hurdat2Path).ToList();

            //Creates an instance of FloridaData
            FloridaData floridaData = new FloridaData();

            //Creates an empty List of Hurricane instances
            List<Hurricane> hurricaneStore = new List<Hurricane>();

            //Creates an empty List of Landfall instances
            List<Landfall> landfallStore = new List<Landfall>();

            //Creates a new instance of Hurricane based on the first line of the .txt file
            Hurricane hurricaneCache = new Hurricane(lines[0]);

            //Creates a for loop starting on the second line of the .txt file and continues throughout each line of the file
            for (int i = 1; i < lines.Count; i++)
            {
                //Identifies if a line is a header for a new hurricane
                if (lines[i].Length == 37)
                {
                    //Calls the createLandfall method on the cached Hurricane and returns either null or an instance of Landfall
                    Landfall? landfallCache = hurricaneCache.createLandfall(floridaData);

                    //Checks if a Landfall was succesfully created or returned null
                    if (landfallCache != null)
                    {
                        //If the Landfall was created, it's added to the Landfall List
                        landfallStore.Add(landfallCache);
                    }

                    //Adds the current hurricane to the list of Hurricane instances
                    hurricaneStore.Add(hurricaneCache);

                    //Clears the hurricaneCache to start adding to a new Hurricane instance
                    hurricaneCache = new Hurricane(lines[i]);
                } else {
                    //If the line is not a header, it is made into a new TrackEntry instance and added to the cached Hurricane
                    hurricaneCache.addTrackEntries(new TrackEntry(lines[i]));
                }
            }
            //Adds final hurricane in hurricaneCache to the hurricaneStore
            hurricaneStore.Add(hurricaneCache);

            //Sets the Hurricane property to the hurricaneStore List of Hurricane instances once the entire file has been read
            Hurricanes = hurricaneStore;

            //Sets the Landfalls property to the landfallStore List of Landfall instances once the entire file has been read
            Landfalls = landfallStore;
        }
    }
}

