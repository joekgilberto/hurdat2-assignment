using System;
using System.Data;
using System.Text.Json;

namespace service.Models
{
    public class Florida
	{

        public string Type
		{ get; set; }

        public Features Features
        { get; set; }

        public Florida(JsonDocument json)
		{
            Type = json.RootElement.GetProperty("type").Deserialize<string>();
            Features = new Features(json);
        }
    }
}

