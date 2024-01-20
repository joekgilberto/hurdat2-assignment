using System;
using System.Text.Json;
using Azure.Core.GeoJson;
using service.Models;

namespace service.Data
{
    public class FloridaData
	{
		public Florida Florida
		{ get; set; }

        public List<List<List<List<double>>>> Coordinates
		{ get; set; }

        public List<GeoPolygon> Maps
        { get; set; }

        public FloridaData()
		{
			string jsonString = File.ReadAllText("./Data/fl-state.json");
            using var json = JsonDocument.Parse(jsonString);

			Florida florida = new Florida(json);
			Florida = florida;
			Coordinates = florida.Features.UnnamedObject[0].Geometry.Coordinates;

            Maps = new List<GeoPolygon>();

            List<GeoPosition> positions = new List<GeoPosition>();

            foreach (List<List<List<double>>> coordinateGroup in Coordinates)
            {

                foreach (List<List<double>> coordinates in coordinateGroup)
                {
                    for (int i = 0; i < coordinates.Count; i++)
                    {
                        positions.Add(new GeoPosition(coordinates[i][0], coordinates[i][1]));
                    }
                }

                GeoPolygon cache = new GeoPolygon(positions);

                Maps.Add(cache);

                positions = new List<GeoPosition>();

            }
        }
	}
}

