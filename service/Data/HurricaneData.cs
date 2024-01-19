using System;
using Microsoft.EntityFrameworkCore;
using service.Models;

namespace service.Data
{
	public class HurricaneData
	{
        public List<string> Hurricanes
        { get; set; }

        public HurricaneData()
        {
            Hurricanes = File.ReadAllLines("./Data/hurdat2-1851-2022-050423.txt").ToList();

            Hurricane testOne = new Hurricane(Hurricanes[0]);

            TrackEntry testTwo = new TrackEntry(Hurricanes[5]);

            Console.WriteLine(testOne.ToString());
            Console.WriteLine(testTwo.ToString());

            //foreach(string line in Hurricanes)
            //{
            //    Console.WriteLine(line);
            //}
        }
    }
}

