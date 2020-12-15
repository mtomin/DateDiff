using System;

namespace DateDiff
{
    class Program
    {
        static void Main(string[] args)
        {
            var from = DateTime.Now;
            var dr1 = new DateRange
            {
                From = from.Add(new TimeSpan(0,0,0)),
                To = from.Add(new TimeSpan(1, 0, 0))

            };
            var dr2 = new DateRange
            {
                From = from.Add(new TimeSpan(1, 0, 0)),
                To = from.Add(new TimeSpan(1, 0, 0))
            };
            try
            {

                var drDiff = CalculationHelper.Calculate(dr1, dr2);
                Console.WriteLine($"Overlap from {drDiff.From:yyyy-MM-dd HH:mm:ss} to {drDiff.To:yyyy-MM-dd HH:mm:ss}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
