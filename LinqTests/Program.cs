using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LinqTests
{
    class Program
    {

        public static bool IsOpen(Bar bar, DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Thursday:
                    return bar.Thursday;
                default:
                    return false;
            }
        }
        static void Main(string[] args)
        {
            var repo = new BarsRepo();
            var dateToday = DateTime.Today;
            int flag = 234;//GetFlag(dateToday.DayOfWeek);

            using (BarsDbContext db = new BarsDbContext())
            {
                var openBarsToday = db.Bars
                    .Where(x => x.OpeningDay < dateToday)
                    .Where(x => IsOpen(x, dateToday.DayOfWeek));

                //Print
                foreach (var bar in openBarsToday)
                {
                    Console.WriteLine(bar.Name);
                }
            }

            //using (BarsDbContext db = new BarsDbContext())
            //{
            //    var openBarsToday = db.Bars
            //        .Where(x => x.OpeningDay < dateToday)
            //        .Where(x => (x.OpenWeekDays | flag) > 0);


            //    //Print
            //    foreach (var bar in openBarsToday)
            //    {
            //        Console.WriteLine(bar.Name);
            //    }
            //}

            //var openBarsToday = repo.GetAll()
            //       .Where(x => x.OpeningDay.Date < dateToday)
            //       .Where(x => x.IsOpen(dateToday.DayOfWeek));
            ////.Where(x => x.OpenWeekDays.HasFlag(dateToday.DayOfWeek));

            ////Print
            //foreach (var bar in openBarsToday)
            //{
            //    Console.WriteLine(bar.Name);
            //}

            //Console.Read();
        }
    }

    public static class Extentions
    {

        //public static bool IsOpen(this Bar _this, DayOfWeek dayOfWeek)
        //{
        //    switch (dayOfWeek)
        //    {
        //        case DayOfWeek.Thursday:
        //            return _this.Thursday;
        //        default:
        //            return false;
        //    }
        //}

        public static bool HasFlag(this int _this, DayOfWeek dayOfWeek)
        {
            return false;
        }
    }

    public class Bar
    {
        public int Id { get; set; }
        public DateTime OpeningDay { get; set; }
        public int OpenWeekDays { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wendnesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public string Name { get; set; }
    }

    public class BarsRepo
    {
        public IEnumerable<Bar> GetAll()
        {
            yield return new Bar() { OpeningDay = DateTime.Now.AddDays(-2), Thursday = true, Name = "Paddy's" };
            yield return new Bar() { OpeningDay = DateTime.Now.AddDays(-1), Thursday = false, Name = "Walker's" };
            yield return new Bar() { OpeningDay = DateTime.Now.AddDays(-1), Thursday = true, Name = "Jhonny's" };
            yield return new Bar() { OpeningDay = DateTime.Now.AddDays(+1), Thursday = true, Name = "Chivas's" };
        }
    }
}
