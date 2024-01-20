using System;
using service.Data;
using service.Models;
using NetTopologySuite.Geometries;

namespace service.Utilities
{
	public class LandfallTools
	{

        private readonly FloridaData _florida;

        public LandfallTools()
		{
            _florida = new FloridaData();
        }

        public bool IsHurricane(Hurricane hurricane)
		{
			foreach(TrackEntry entry in hurricane.TrackEntries)
			{
                if (entry.Status == "HU")
				{
					return true;
				}
			}

            return false;
        }

        public bool Landed(Hurricane hurricane)
        {
            foreach(TrackEntry entry in hurricane.TrackEntries)
            {
                double logitude = entry.Longitude;
                double latitude = entry.Latitude;

                if (entry.LongitudeHemisphere.Contains('W'))
                {
                    logitude = logitude * -1;
                }

                if (entry.LatitudeHemisphere.Contains('S'))
                {
                    latitude = latitude * -1;
                }

                Point currentPoint = new Point(new Coordinate(latitude,logitude));

                foreach (List<List<List<double>>> coordGroup in _florida.Coordinates)
                {
                    Coordinate[] coordList = new Coordinate[coordGroup[0].Count];

                    for(int i = 0; i < coordGroup[0].Count; i++)
                    {
                        Coordinate addedCoord = new Coordinate(coordGroup[0][i][1],coordGroup[0][i][0]);
                        coordList[i] = addedCoord;
                    }

                    Polygon section = new Polygon(new LinearRing(coordList));

                    bool passes = section.Contains(currentPoint);

                    if (passes)
                    {
                        if(hurricane.Year>1900 && entry.Status=="HU")
                        {
                            Console.WriteLine(hurricane.ToString());
                            Console.WriteLine(entry.ToString());
                            Console.WriteLine("");
                        }
                        
                        return true;
                    }

                }
            }
            
            return false;
        }

    }
}

