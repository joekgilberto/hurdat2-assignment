using System;
using service.Models;

namespace service.Utilities
{
	public class FloridaLandfall
	{
        private double NorthMostLatitude
        { get; set; }

        private double SouthMostLatitude
		{ get; set; }

		private double EastMostLongitude
		{ get; set; }

        private double WestMostLongitude
        { get; set; }

        public FloridaLandfall()
		{
			NorthMostLatitude = 31.2;
            SouthMostLatitude = 24.3;
            EastMostLongitude = -79.8;
			WestMostLongitude = -87.85;
        }

		public bool Check(Hurricane h)
		{
			foreach(TrackEntry entry in h.TrackEntries)
			{
                double latitude = entry.Latitude;
                if (entry.LatitudeHemisphere == "S")
                {
                    latitude = latitude * -1;

                }

                double longitude = entry.Longitude;
                if (entry.LongitudeHemisphere == "W")
				{
					longitude = longitude * -1;

                }

                if (entry.Status == "HU" && latitude <= NorthMostLatitude && latitude >= SouthMostLatitude && longitude <= EastMostLongitude && longitude >= WestMostLongitude)
				{
					return true;
				}
			}

            return false;
        }


    }
}

