using System.ComponentModel.DataAnnotations;

namespace service.Models
{
	public class Hurricane
	{
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Basin must be two characters long.")]
        public string Basin
		{ get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "ATCF code must be two characters long.")]
        public string Atcf
        { get; set; }

        [Range(1851, 2022)]
        public int Year
		{ get; set; }

        public string Name
        { get; set; }

        public int TrackEntryCount
        { get; set; }

        public List<Object> TrackEntries
        { get; set; }

        public Hurricane(string basin, string atcf, int year, string name, int trackEntryCount, List<Object> trackEntries)
		{
			Basin = basin;
			Atcf = atcf;
			Year = year;
            Name = name;
            TrackEntryCount = trackEntryCount;
            TrackEntries = trackEntries;
        }
	}
}

