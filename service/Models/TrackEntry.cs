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
        [Range(0, 18)]
        public int Hours
        { get; set; }

        [Required]
        [Range(0, 59)]
        public int Minutes
        { get; set; }

        [Required]
        [RecordId(ErrorMessage = "RecordId must be C, G, I, L, P, R, S, T, or W.")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "RecordId must be one character long.")]
        public string RecordId
        { get; set; }

        [Required]
        [Status(ErrorMessage = "Status must be TD, TS, HU, EX, SD, SS, LO, WV, or DB.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Status must be two characters long.")]
        public string Status
        { get; set; }

        [Required]
        public double Latitude
        { get; set; }

        [Required]
        [LatitudeHemisphere(ErrorMessage = "LatitudeHemisphere must be North or West")]
        public string LatitudeHemisphere
        { get; set; }

        [Required]
        public double Longitude
        { get; set; }

        [Required]
        [LongitudeHemisphere(ErrorMessage = "LongitudeHemisphere must be West or East")]
        public string LongitudeHemisphere
        { get; set; }

        [Required]
        [Range(0,999)]
        public int MaxWind
        { get; set;}

        [Required]
        [Range(0, 9999)]
        public int MinPressure
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int ThirtyFourWindRadiiNEQuad
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int ThirtyFourWindRadiiSEQuad
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int ThirtyFourWindRadiiSWQuad
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int ThirtyFourWindRadiiNWQuad
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int FiftyWindRadiiNEQuad
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int FiftyWindRadiiSEQuad
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int FiftyWindRadiiSWQuad
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int FiftyWindRadiiNWQuad
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int SixtyFourWindRadiiNEQuad
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int SixtyFourWindRadiiSEQuad
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int SixtyFourWindRadiiSWQuad
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int SixtyFourWindRadiiNWQuad
        { get; set; }

        [Required]
        [Range(-999, 999)]
        public int MaxRadius
        { get; set; }

        public TrackEntry(
            int year,
            int month,
            int day,
            int hours,
            int minutes,
            string recordId,
            string status,
            double latitude,
            string latitudeHemisphere,
            double longitude,
            string longitudeHemisphere,
            int thirtyFourWindRadiiNEQuad,
            int thirtyFourWindRadiiSEQuad,
            int thirtyFourWindRadiiSWQuad,
            int thirtyFourWindRadiiNWQuad,
            int fiftyWindRadiiNEQuad,
            int fiftyWindRadiiSEQuad,
            int fiftyWindRadiiSWQuad,
            int fiftyWindRadiiNWQuad,
            int sixtyFourWindRadiiNEQuad,
            int sixtyFourWindRadiiSEQuad,
            int sixtyFourWindRadiiSWQuad,
            int sixtyFourWindRadiiNWQuad
        )
		{
			Year = year;
            Month = month;
            Day = day;
            Hours = hours;
            Minutes = minutes;
            RecordId = recordId;
            Status = status;
            Latitude = latitude;
            LatitudeHemisphere = latitudeHemisphere;
            Longitude = longitude;
            LongitudeHemisphere = longitudeHemisphere;
            ThirtyFourWindRadiiNEQuad = thirtyFourWindRadiiNEQuad;
            ThirtyFourWindRadiiSEQuad = thirtyFourWindRadiiSEQuad;
            ThirtyFourWindRadiiSWQuad = thirtyFourWindRadiiSWQuad;
            ThirtyFourWindRadiiNWQuad = thirtyFourWindRadiiNWQuad;
            FiftyWindRadiiNEQuad = fiftyWindRadiiNEQuad;
            FiftyWindRadiiSEQuad = fiftyWindRadiiSEQuad;
            FiftyWindRadiiSWQuad = fiftyWindRadiiSWQuad;
            FiftyWindRadiiNWQuad = fiftyWindRadiiNWQuad;
            SixtyFourWindRadiiNEQuad = sixtyFourWindRadiiNEQuad;
            SixtyFourWindRadiiSEQuad = sixtyFourWindRadiiSEQuad;
            SixtyFourWindRadiiSWQuad = sixtyFourWindRadiiSWQuad;
            SixtyFourWindRadiiNWQuad = sixtyFourWindRadiiNWQuad;
        }
	}
}

