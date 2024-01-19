using System;
using System.Text.Json;
using service.Models;

namespace service.Data
{
	public class FloridaData
	{
		public Object Florida
		{ get; set; }

		public FloridaData()
		{
			string jsonString = File.ReadAllText("./Data/fl-state.json");
            Object florida = JsonSerializer.Deserialize<Object>(jsonString);
			Florida = florida;
        }
	}
}

