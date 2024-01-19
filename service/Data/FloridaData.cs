using System;
using System.Text.Json;
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


            Console.WriteLine(json.GetType());

			var coordinates = json.RootElement.GetProperty("features")[0].GetProperty("geometry").GetProperty("coordinates").Deserialize<List<List<List<List<double>>>>>();
			Console.WriteLine(coordinates[0][0][0]);

            Coordinates = coordinates;
        }
	}
}

