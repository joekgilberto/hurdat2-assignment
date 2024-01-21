using System;
using System.Text.Json;

namespace service.Models
{
    //Creates the model for Florida
    public class Florida
	{
        //Creates a nullable Type string property
        public string? Type
		{ get; set; }

        //Creates a Features property that holds an instance of a Features class
        public Features Features
        { get; set; }

        //Creates a constructor for Florida with a parameter of a JsonDocument
        public Florida(JsonDocument json)
		{
            //Assigns the nullable string, type, to the desrializezed property "type"
            //And assigns said string to the property Type
            string? type = json.RootElement.GetProperty("type").Deserialize<string>();
            Type = type;

            //Creates a new istance of Features with the argument of a JsonDocument passed to its constructor
            //And assigns said instance to the property Features
            Features features = new Features(json);
            Features = features;
        }
    }
}

