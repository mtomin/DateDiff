using System;
using System.Collections.Generic;
using System.Text;

namespace DateDiff
{
    public static class CalculationHelper
    {
        public static DateRange Calculate(DateRange dr1, DateRange dr2)
        {
            var result = new DateRange();

            var overlap = GetOverlap(dr1, dr2);

            var ts = overlap.To - overlap.From;

            if(ts.TotalMilliseconds>=0)
            {
                result.To = overlap.To;
                result.From = overlap.From;
            }

            else
            {
                throw new Exception("Datumi se ne preklapaju!");
            }

            return result;
        }

        private static DateRange GetOverlap(DateRange dr1, DateRange dr2)
        {
            DateRange result = new DateRange();

            result.From = dr1.From >= dr2.From ? dr1.From : dr2.From;

            result.To = dr1.To <= dr2.To ? dr1.To : dr2.To;

            return result;
        }
    }
}
