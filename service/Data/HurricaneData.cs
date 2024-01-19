using System;
using Microsoft.EntityFrameworkCore;
using service.Models;

namespace service.Data
{
	public class HurricaneData
	{
        public List<Hurricane> Hurricanes
        { get; set; }

        public HurricaneData()
        {
            List<string> lines = File.ReadAllLines("./Data/hurdat2-1851-2022-050423.txt").ToList();

            Hurricane cache = new Hurricane(lines[0]);
            List <Hurricane> store = new List<Hurricane>();

            for (int i = 1; i < lines.Count; i++)
            {
                if (lines[i].Length == 37)
                {
                    store.Add(cache);
                    cache = new Hurricane(lines[i]);
                }
                else
                {
                    cache.addTrackEntries(new TrackEntry(lines[i]));
                }
            }

            Hurricanes = store;
        }
    }
}

