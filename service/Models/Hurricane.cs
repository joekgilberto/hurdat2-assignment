using System;
using System.ComponentModel.DataAnnotations;

namespace service.Models
{
	public class Hurricane
	{
        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Basin must be two characters long.")]
        public string Basin
		{ get; set; }

        [Required]
        [Range(1, 99)]
        public int AtcfNumber
        { get; set; }

        [Required]
        [Range(1851, 2022)]
        public int Year
		{ get; set; }

        [Required]
        public string Name
        { get; set; }

        [Required]
        public int TrackEntryCount
        { get; set; }

        [Required]
        public List<Object> TrackEntries
        { get; set; }

        public Hurricane(string basin, int atcfNumber, int year, string name, int trackEntryCount, List<Object> trackEntries)
		{
			Basin = basin;
            AtcfNumber = atcfNumber;
			Year = year;
            Name = name;
            TrackEntryCount = trackEntryCount;
            TrackEntries = trackEntries;
        }
	}
}

