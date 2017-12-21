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
            //string arrayString = "[29,[15852,43.64443855,15854,41.38360298,-630.712288,-0.0383,15853,3192.79867954,16602,15323]]";
            string arrayString = "[15,'hb']";

            if (true)
            {

            }

            if (arrayString.StartsWith("[") && arrayString.EndsWith("]"))
            {
                int commaIndex = arrayString.IndexOf(',');
                int channelId = int.Parse(arrayString.Substring(1, commaIndex - 1));
                int closeNestedArrIndex = arrayString.IndexOf(']', commaIndex);
                string nestedArr = arrayString.Substring(commaIndex + 1, closeNestedArrIndex - commaIndex);
            }


            //Base.SafeExecute(() =>
            //{
            //    Console.WriteLine(1);
            //    Console.Read();
            //});
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
