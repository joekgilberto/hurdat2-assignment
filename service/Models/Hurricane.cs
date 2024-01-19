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
        [Range(1, 99)]
        public int TrackEntryCount
        { get; set; }

        public List<TrackEntry> TrackEntries
        { get; set; }

        public Hurricane(string line)
		{
            List<string> lineList = line.Split(",").ToList();

            for(int i = 0; i < lineList.Count; i++)
            {
                lineList[i] = lineList[i].Trim();
            }

            Basin = lineList[0].Substring(0, 2);

            int atcfNumber = 0;
            Int32.TryParse(lineList[0].Substring(2, 4), out atcfNumber);
            AtcfNumber = atcfNumber;

            int year = 0;
            Int32.TryParse(lineList[0].Substring(4, 8), out year);
            Year = year;

            Name = lineList[1];

            int trackEntryCount = 0;
            Int32.TryParse(lineList[2], out trackEntryCount);
            TrackEntryCount = trackEntryCount;

            TrackEntries = new List<TrackEntry>();
        }

        public void addTrackEntries(TrackEntry trackEntry)
        {
            TrackEntries.Add(trackEntry);
        }
	}
}

