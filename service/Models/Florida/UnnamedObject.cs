using System;
using System.Text.Json;

namespace service.Models
{
    //Creates the class UnnamedObject
    public class UnnamedObject
	{
        //Creates a nullable Type string property
        public string? Type
        { get; set; }

        //Creates the property Properties, which holds an instance of Properties
        public Properties Properties
        { get; set; }

        //Creates the property Geometry, which holds an instance of Geometry
        public Geometry Geometry
        { get; set; }

        //Creates a constructor of UnnamedObject with a parameter of a JsonDocument
        public UnnamedObject(JsonDocument json)
		{
            //Assigns the nullable string, type, to the desrializezed property "type" derived from the first instance of the property "features"
            //And assigns said string to the property Type
            string? type = json.RootElement.GetProperty("features")[0].GetProperty("type").Deserialize<string>();
            Type = type;

            //Creates a new istance of Properties with the argument of a JsonDocument passed to its constructor
            //And assigns said instance to the property Properties
            Properties properties = new Properties(json);
            Properties = properties;

            //Creates a new istance of Geometry with the argument of a JsonDocument passed to its constructor
            //And assigns said instance to the property Geometry
            Geometry geometry = new Geometry(json);
            Geometry = geometry;
        }
    }
}

