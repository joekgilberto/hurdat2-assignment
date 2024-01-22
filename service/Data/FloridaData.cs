using System;
using System.Text.Json;
using Azure.Core.GeoJson;
using service.Models;

namespace service.Data
{
    //Creates the class FloridaData
    public class FloridaData
	{
        //Creates the property Florida, which holds an instance of Florida
        public Florida Florida
		{ get; set; }

        //Creates the nullable property Coordinates, which holds a List of a List of a List of a List of doubles (as structured by the GeoJSON file)
        public List<List<List<List<double>>>>? Coordinates
		{ get; set; }

        //Creates a constructor for FloridaData
        public FloridaData()
		{
            //Parses Florida GEOJson to a string;
            string floridaPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "fl-state.json");
            string jsonString = File.ReadAllText(floridaPath);

			//Parses jsonString into JsonDocument json
            var json = JsonDocument.Parse(jsonString);

            //Creates a new instance of Florida based on the parsed JsonDocument
            //And assigns the property Florida to said instance
            Florida florida = new Florida(json);
			Florida = florida;

            //Assigns the Geometry instance (of the first index of the UnnamedObject instance of the Features instance of the Florida instance) to the nullable List of a List of a List of a List of doubles, coordinates
            //And assigns List to the Coordinates property
            List<List<List<List<double>>>>? coordinates = florida.Features.UnnamedObject[0].Geometry.Coordinates;
            Coordinates = coordinates;
        }
	}
}

