using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IObservableNS
{
    class Program
    {
        [Flags]
        public enum Pets
        {
            Pesho = 0,
            Dog = 1,
            Cat = 2,
            Bird = 4,
            Rabbit = 8,
            Other = 16,
            Combined = Dog | Cat
        }

        [Flags]
        public enum AllowedPeriods : uint
        {
            RegularTime1 = 1 << 1,
            RegularTime2 = 1 << 2,
            RegularTime3 = 1 << 3,
            RegularTime4 = 1 << 4,
            RegularTime5 = 1 << 5,
            RegularTime6 = 1 << 6,
            RegularTime7 = 1 << 7,
            RegularTime8 = 1 << 8,
            RegularTime9 = 1 << 9,
            RegularTime10 = 1 << 10,
            RegularTime11 = 1 << 11,
            RegularTime12 = 1 << 12,
            RegularTime13 = 1 << 13,
            RegularTime14 = 1 << 14,
            RegularTime15 = 1 << 15,
            RegularTime16 = 1 << 16,
            RegularTime17 = 1 << 17,
            RegularTime18 = 1 << 18,
            RegularTime19 = 1 << 19,
            RegularTime20 = 1 << 20,

            OverTime1 = 1 << 21,
            OverTime2 = 1 << 22,
            OverTime3 = 1 << 23,
            OverTime4 = 1 << 24,
            OverTime5 = 1 << 25,
            OverTime6 = 1 << 26,
            OverTime7 = 1 << 27,
            OverTime8 = 1 << 28,
            OverTime9 = 1 << 29,
            OverTime10 = 1 << 30,

            // halfs
            FirstHalf = RegularTime1,
            SecondHalf = RegularTime2,

            //volleyball sets
            FirstSet = RegularTime1,
            SecondSet = RegularTime2,
            ThirdSet = RegularTime3,
            FourthSet = RegularTime4,
            FifthSet = RegularTime5,

            // Quarters
            Quarter1 = RegularTime1,
            Quarter2 = RegularTime2,
            Quarter3 = RegularTime3,
            Quarter4 = RegularTime4,
            FirstHalfQuarters = Quarter1 | Quarter2,
            SecondHalfQuarters = Quarter3 | Quarter4,

            FullTime = RegularTime1 | RegularTime2 | RegularTime3 | RegularTime4 | RegularTime5 |
                RegularTime6 | RegularTime7 | RegularTime8 | RegularTime9 | RegularTime10 |
                RegularTime11 | RegularTime12 | RegularTime13 | RegularTime14 | RegularTime15 |
                RegularTime16 | RegularTime17 | RegularTime18 | RegularTime19 | RegularTime20,

            OverTime = OverTime1 | OverTime2 | OverTime3 | OverTime4 | OverTime5 |
                OverTime6 | OverTime7 | OverTime8 | OverTime9 | OverTime10,

            FullTimePlusOverTime = FullTime | OverTime,
        }

        static void Main(string[] args)
        {
            AllowedPeriods curr = AllowedPeriods.Quarter4 | AllowedPeriods.Quarter3;
            List<AllowedPeriods> strEnums = new List<AllowedPeriods>();

            foreach (AllowedPeriods p in Enum.GetValues(typeof(AllowedPeriods)))
            {
                if ((curr & p) != 0 && p.ToString().StartsWith("RegularTime"))
                {
                    strEnums.Add(p);
                }
            }
            strEnums = strEnums.Distinct().ToList();
            Console.Read();
        }
    }
}
