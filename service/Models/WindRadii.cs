using System;
using System.ComponentModel.DataAnnotations;

namespace service.Models
{
	public class WindRadii
	{
        [Required]
        [Range(-999, 999)]
        public int NE
		{ get; set; }

        [Required]
        [Range(-999, 999)]
        public int SE
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int SW
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int NW
        { get; set; }

        public WindRadii(string ne, string se, string sw, string nw)
		{
            int covnertedNe = 0;
            Int32.TryParse(ne, out covnertedNe);
            NE = covnertedNe;

            int covnertedSe = 0;
            Int32.TryParse(se, out covnertedSe);
            SE = covnertedSe;

            int covnertedSw = 0;
            Int32.TryParse(sw, out covnertedSw);
            SW = covnertedSw;

            int covnertedNw = 0;
            Int32.TryParse(nw, out covnertedNw);
            NW = covnertedNw;
        }
	}
}

