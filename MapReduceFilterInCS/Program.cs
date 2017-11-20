using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapReduceFilterInCS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Map = Select |
            var map = Enumerable.Range(1, 10).Select(x => x + 2);
            //Reduce = Aggregate |
            var reduce = Enumerable.Range(1, 10)
                .Aggregate(0,
                (acc, x) =>
                {
                    return acc + x;
                });
            //Filter = Where |
            var filter = Enumerable.Range(1, 10).Where(x => x % 2 == 0);

            int[] foo = new int[] { 1, 2, 3, 4, 5, 6, 9 };
            var zip = foo.Zip(foo.Skip(1), (a, b) => $"{a},{b}");

            //find biggest delta
            var z = 0;
        }
    }
}
