using System;
using System.Text.Json;

namespace service.Models
{
    //Creates the class Geometry
    public class Geometry
	{
        //Creates a nullable Type string property
        public string? Type
		{ get; set; }

        //Creates a nullable property Coordinates, which holds a List of a List of a List of a List of doubles (as structured by the GeoJSON file)
        public List<List<List<List<double>>>>? Coordinates
        { get; set; }

        //Creates a constructor of Geometry with a parameter of a JsonDocument
        public Geometry(JsonDocument json)
		{
            //Assigns the nullable string, type, to the desrializezed property "type" derived from the property "geometry" derived from the first instance of the property "features"
            //And assigns the string to the property Type
            string? type = json.RootElement.GetProperty("features")[0].GetProperty("geometry").GetProperty("type").Deserialize<string>();
            Type = type;

            //Assigns the nullable List of a List of a List of a List of doubles, coordinates, to the desrializezed property "coordinates" derived from the property "geometry" derived from the first instance of the property "features"
            //And assigns the List to the property Coordinates
            List<List<List<List<double>>>>? coordinates = json.RootElement.GetProperty("features")[0].GetProperty("geometry").GetProperty("coordinates").Deserialize<List<List<List<List<double>>>>>();
            Coordinates = coordinates;
        }
    }
}

