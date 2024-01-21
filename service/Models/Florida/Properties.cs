using System;
using System.Text.Json;

namespace service.Models
{
    //Creates the class Properties
    public class Properties
	{
        //Creates a nullable GEO_ID string property
        public string? GEO_ID
		{ get; set; }

        //Creates a nullable STATE string property
        public string? STATE
        { get; set; }

        //Creates a nullable NAME string property
        public string? NAME
        { get; set; }

        //Creates a nullable LSAD string property
        public string? LSAD
        { get; set; }

        //Creates a nullable CENSUSAREA double property
        public double? CENSUSAREA
        { get; set; }

        public Properties(JsonDocument json)
		{
            //Assigns the nullable string, geoId, to the desrializezed property "GEO_ID" derived from the property "properties" derived from the first instance of the property "features"
            //And assigns said string to the property GEO_ID
            string? geoId = json.RootElement.GetProperty("features")[0].GetProperty("properties").GetProperty("GEO_ID").Deserialize<string>();
            GEO_ID = geoId;

            //Assigns the nullable string, geoId, to the desrializezed property "STATE" derived from the property "properties" derived from the first instance of the property "features"
            //And assigns said string to the property STATE
            string? state = json.RootElement.GetProperty("features")[0].GetProperty("properties").GetProperty("STATE").Deserialize<string>();
            STATE = state;

            //Assigns the nullable string, geoId, to the desrializezed property "NAME" derived from the property "properties" derived from the first instance of the property "features"
            //And assigns said string to the property NAME
            string? name = json.RootElement.GetProperty("features")[0].GetProperty("properties").GetProperty("NAME").Deserialize<string>();
            NAME = name;

            //Assigns the nullable string, geoId, to the desrializezed property "LSAD" derived from the property "properties" derived from the first instance of the property "features"
            //And assigns said string to the property LSAD
            string? lsad = json.RootElement.GetProperty("features")[0].GetProperty("properties").GetProperty("LSAD").Deserialize<string>();
            LSAD = lsad;

            //Assigns the nullable string, geoId, to the desrializezed property "CENSUSAREA" derived from the property "properties" derived from the first instance of the property "features"
            //And assigns said string to the property CENSUSAREA
            double? censusArea = json.RootElement.GetProperty("features")[0].GetProperty("properties").GetProperty("CENSUSAREA").Deserialize<double>();
            CENSUSAREA = censusArea;
        }
    }
}

