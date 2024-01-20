using System;
using System.ComponentModel.DataAnnotations;

namespace service.Models
{
    //Creates the model for WindRadii
    public class WindRadii
	{
        //Creates a NE integer property
        public int NE
		{ get; set; }

        //Creates a SE integer property
        public int SE
        { get; set; }

        //Creates a SW integer property
        public int SW
        { get; set; }

        //Creates a NW integer property
        public int NW
        { get; set; }

        //Creates a constructor with four string parameter
        public WindRadii(string ne, string se, string sw, string nw)
		{
            //Assigns NE to ne, parsed into an integer
            int covnertedNe = 0;
            Int32.TryParse(ne, out covnertedNe);
            NE = covnertedNe;

            //Assigns SE to se, parsed into an integer
            int covnertedSe = 0;
            Int32.TryParse(se, out covnertedSe);
            SE = covnertedSe;

            //Assigns SW to sw, parsed into an integer
            int covnertedSw = 0;
            Int32.TryParse(sw, out covnertedSw);
            SW = covnertedSw;

            //Assigns NW to nw, parsed into an integer
            int covnertedNw = 0;
            Int32.TryParse(nw, out covnertedNw);
            NW = covnertedNw;
        }
	}
}

