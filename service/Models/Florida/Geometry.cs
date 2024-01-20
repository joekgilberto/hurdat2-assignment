using System;
using System.Text.Json;

namespace service.Models
{
	public class Geometry
	{
		public string Type
		{ get; set; }

		public List<List<List<List<double>>>> Coordinates
        { get; set; }

        public Geometry(JsonDocument json)
		{
            Type = json.RootElement.GetProperty("features")[0].GetProperty("geometry").GetProperty("type").Deserialize<string>();
            Coordinates = json.RootElement.GetProperty("features")[0].GetProperty("geometry").GetProperty("coordinates").Deserialize<List<List<List<List<double>>>>>();
        }
    }
}

