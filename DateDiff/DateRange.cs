using System;
using System.Collections.Generic;
using System.Text;

namespace DateDiff
{
    public struct DateRange
    {
        public DateRange(DateTime to, DateTime from)
        {
            To = to.AddMilliseconds(-to.Millisecond);
            From = from.AddMilliseconds(-to.Millisecond);

            var diff = To - From;
            if (diff.TotalMilliseconds<0)
            {
                //throw new Exception("Vremenski raspon nije valjan!")
                // ili
                //To=from;
                //From=to;
            }
        }
        public DateTime To { get; set; }
        public DateTime From { get; set; }
    }
}
