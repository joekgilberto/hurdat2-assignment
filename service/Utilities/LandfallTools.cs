using System;
using System.Drawing;
using Azure.Core.GeoJson;
using service.Data;
using service.Models;

namespace service.Utilities
{
	public class LandfallTools
	{

        private readonly FloridaData _florida;

        private List<GeoPolygon> _maps;

        private List<GeoBoundingBox> _boxes;

        public LandfallTools()
		{
            _florida = new FloridaData();

            _maps = new List<GeoPolygon>();

            _boxes = new List<GeoBoundingBox>();

            List<GeoPosition> positions = new List<GeoPosition>();

            foreach(List<List<List<double>>> coordinateGroup in _florida.Coordinates)
            {
                double maxX = -180;
                double minX = 0;
                double maxY = 0;
                double minY = 180;

                foreach (List<List<double>> coordinates in coordinateGroup)
                {
                    for (int i = 0; i < coordinates.Count; i++)
                    {
                        positions.Add(new GeoPosition(coordinates[i][0], coordinates[i][1]));
                        maxX = Math.Max(maxX, coordinates[i][0]);
                        minX = Math.Min(minX, coordinates[i][0]);
                        maxY = Math.Max(maxX, coordinates[i][1]);
                        minY = Math.Min(minY, coordinates[i][1]);
                    }
                }

                GeoBoundingBox box = new GeoBoundingBox(minX,minY,maxX,maxY);
                GeoPolygon cache = new GeoPolygon(positions);

                _maps.Add(cache);
                _boxes.Add(box);

                positions = new List<GeoPosition>();

            }
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
                foreach (GeoBoundingBox coors in _boxes)
                {
                    double latitude = entry.Latitude;
                    double longitude = entry.Longitude;

                    if(entry.LongitudeHemisphere.Contains('W'))
                    {
                        longitude = longitude * -1;
                    }

                    if ((latitude >= coors.South && latitude <= coors.North) && (longitude >= coors.West && longitude <= coors.East))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}

