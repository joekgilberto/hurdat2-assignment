using System;
using System.Text.Json;

namespace service.Models
{
	public class UnnamedObject
	{
        public string Type
        { get; set; }

        public Properties Properties
        { get; set; }

        public Geometry Geometry
        { get; set; }

        public UnnamedObject(JsonDocument json)
		{
            Type = json.RootElement.GetProperty("features")[0].GetProperty("type").Deserialize<string>();
            Properties = new Properties(json);
            Geometry = new Geometry(json);
        }
    }
}

