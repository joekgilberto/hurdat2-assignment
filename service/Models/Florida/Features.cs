using System;
using System.Text.Json;

namespace service.Models
{
	//Creates the model for Features
	public class Features
	{
        //Creates the property UnnamedObject, which holds a List of UnnamedObject instances
        public List<UnnamedObject> UnnamedObject
        { get; set; }

        //Creates a constructor of Features with a parameter of a JsonDocument
        public Features(JsonDocument json)
		{
            //Creates a List with a new istance of an UnnamedObject with the argument of a JsonDocument passed to its constructor
            //And assigns said List to the property UnnamedObject
            List<UnnamedObject> unnamedObject = new List<UnnamedObject>() { new UnnamedObject(json) };
            UnnamedObject = unnamedObject;
        }
	}
}

