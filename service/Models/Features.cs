using System;
using System.Text.Json;

namespace service.Models
{
	public class Features
	{
        public List<UnnamedObject> UnnamedObject
        { get; set; }

        public Features(JsonDocument json)
		{
            UnnamedObject = new List<UnnamedObject>() { new UnnamedObject(json) };
		}
	}
}

