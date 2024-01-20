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

        public FloridaData()
		{
			string jsonString = File.ReadAllText("./Data/fl-state.json");
            using var json = JsonDocument.Parse(jsonString);

			Florida florida = new Florida(json);
			Florida = florida;
			Coordinates = florida.Features.UnnamedObject[0].Geometry.Coordinates;
        }
	}
}

