using System;
using service.Models;

namespace service.Data
{
    //Creates the class HurricaneData
	public class HurricaneData
	{
        //Creates the property Hurricanes, which holds a list of Hurricane instances
        public List<Hurricane> Hurricanes
        { get; set; }

        //Creates a constructor (with no parameters) for HurricaneData
        public HurricaneData()
        {
            //Takes the lines of the hurdat2 .txt file and turns them into a list of strings stored in lines
            List<string> lines = File.ReadAllLines("./Data/hurdat2-1851-2022-050423.txt").ToList();

            //Creates a new instance of Hurricane based on the first line of the .txt file
            Hurricane cache = new Hurricane(lines[0]);

            //Creates an empty list of Hurricane instances
            List<Hurricane> store = new List<Hurricane>();

            //Creates a for loop starting on the second line of the .txt file and continues throughout each line of the file
            for (int i = 1; i < lines.Count; i++)
            {
                //Identifies if a line is a header for a new hurricane
                if (lines[i].Length == 37)
                {
                    //Adds the current hurricane to the list of Hurricane instances
                    store.Add(cache);

                    //Clears the cache to start adding to a new Hurricane instance
                    cache = new Hurricane(lines[i]);
                } else {
                    //If the line is not a header, it is made into a new TrackEntry instance and added to the cached Hurricane
                    cache.addTrackEntries(new TrackEntry(lines[i]));
                }
            }
            //Adds final hurricane in cache to the store
            store.Add(cache);

            //Sets the Hurricane property to the store of Hurricane instances once the entire file has been read.
            Hurricanes = store;
        }
    }
}

