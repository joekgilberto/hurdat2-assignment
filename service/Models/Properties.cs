using System;
using System.Text.Json;

namespace service.Models
{
	public class Properties
	{
		public string GEO_ID
		{ get; set; }

        public string STATE
        { get; set; }

        public string NAME
        { get; set; }

        public string LSAD
        { get; set; }

        public double CENSUSAREA
        { get; set; }

        public Properties(JsonDocument json)
		{
            GEO_ID = json.RootElement.GetProperty("features")[0].GetProperty("properties").GetProperty("GEO_ID").Deserialize<string>();
            STATE = json.RootElement.GetProperty("features")[0].GetProperty("properties").GetProperty("STATE").Deserialize<string>();
            NAME = json.RootElement.GetProperty("features")[0].GetProperty("properties").GetProperty("NAME").Deserialize<string>();
            LSAD = json.RootElement.GetProperty("features")[0].GetProperty("properties").GetProperty("LSAD").Deserialize<string>();
            CENSUSAREA = json.RootElement.GetProperty("features")[0].GetProperty("properties").GetProperty("CENSUSAREA").Deserialize<double>();
        }
    }
}

