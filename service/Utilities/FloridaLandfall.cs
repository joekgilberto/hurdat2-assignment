using System;
using System.Drawing;
using service.Data;
using service.Models;

namespace service.Utilities
{
	public class FloridaLandfall
	{

        private readonly FloridaData _florida;

        public FloridaLandfall()
		{
            _florida = new FloridaData();
        }

        public bool IsHurricane(Hurricane hurricane)
		{
			foreach(TrackEntry entry in hurricane.TrackEntries)
			{
                if (entry.Status == "HU")
				{
					return true;
				}
			}

            return false;
        }

        public void Landed(Hurricane hurricane)
        {

            //Point p1, p2;
            //bool inside = false;

            //if (poly.Length < 3)
            //{
            //    return inside;
            //}

            //var oldPoint = new Point(
            //    poly[poly.Length - 1].X, poly[poly.Length - 1].Y);

            //for (int i = 0; i < poly.Length; i++)
            //{
            //    var newPoint = new Point(poly[i].X, poly[i].Y);

            //    if (newPoint.X > oldPoint.X)
            //    {
            //        p1 = oldPoint;
            //        p2 = newPoint;
            //    }
            //    else
            //    {
            //        p1 = newPoint;
            //        p2 = oldPoint;
            //    }

            //    if ((newPoint.X < p.X) == (p.X <= oldPoint.X)
            //        && (p.Y - (long)p1.Y) * (p2.X - p1.X)
            //        < (p2.Y - (long)p1.Y) * (p.X - p1.X))
            //    {
            //        inside = !inside;
            //    }

            //    oldPoint = newPoint;
            //}

            //return inside;
        }


    }
}

