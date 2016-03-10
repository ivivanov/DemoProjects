using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeExecuteFuncAsParam
{
    public class Program : Base
    {
        static void Main(string[] args)
        {
            Base.SafeExecute(() =>
            {
                Console.WriteLine(1);
                Console.Read();
            });
        }
    }

    public class Base
    {
        public static void SafeExecute(Action func)
        {
            func.Invoke();
        }
    }
}
