using System;
using System.ComponentModel.DataAnnotations;
using service.CustomValidation;

namespace service.Models
{
	public class TrackEntry
	{
        [Required]
        [Range(1851, 2022)]
        public int Year
        { get; set; }

        [Required]
        [Range(1, 12)]
        public int Month
        { get; set; }

        [Required]
        [Range(1, 31)]
        public int Day
        { get; set; }

        [Required]
        [Range(0, 24)]
        public int Hours
        { get; set; }

        [Required]
        [Range(0, 59)]
        public int Minutes
        { get; set; }

        [Required]
        [ValidateRecordId]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "RecordId must be one characters long.")]
        public string RecordId
        { get; set; }

        public TrackEntry(int year, int month, int day, int hours, int minutes, string recordId)
		{
			Year = year;
            Month = month;
            Day = day;
            Hours = hours;
            Minutes = minutes;
            RecordId = recordId;
        }
	}
}

