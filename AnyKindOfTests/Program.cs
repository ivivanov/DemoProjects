using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyKindOfTests
{
    public class Kola
    {
        public Kola()
        {
            Console.WriteLine("ctor Kola");

        }

        public virtual void ZapaliKola()
        {
            Console.WriteLine("ot Kola");
        }
    }

    public class BMW : Kola
    {
        public BMW()
        {
            Console.WriteLine("ctor BMW");
        }

        public override void ZapaliKola()
        {
            Console.WriteLine("ot BMW");
            base.ZapaliKola();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var z = new BMW();
            //z.ZapaliKola();
            //Console.Read();
            //long key1 = 1 << 33;
            //long key2 = int.MaxValue;
            //Console.WriteLine("{0} key1", Convert.ToString(key1, 2).PadLeft(64, '0'));
            //Console.WriteLine("{0} key2", Convert.ToString(key2, 2).PadLeft(64, '0'));
            //Console.WriteLine("{0} key1 shifted back", Convert.ToString(key1 >> 30, 2).PadLeft(64, '0'));
            //long composite = key1;
            //Console.WriteLine("{0} composite", Convert.ToString(composite, 2).PadLeft(64, '0'));
            //composite <<= 31;
            //Console.WriteLine("{0} composite", Convert.ToString(composite, 2).PadLeft(64, '0'));
            //composite = composite | key2;
            int QAParameter1 = 157867129;
            int QAParameter2 = 157867121;
            long composite = (long)QAParameter2 << 32 | QAParameter1;
            //Key	678034121966541945	long

            Console.WriteLine(composite>>32);
            Console.WriteLine(composite & int.MaxValue);
            Console.WriteLine("{0} composite", Convert.ToString(int.MaxValue, 2));
            Console.WriteLine("{0} composite", Convert.ToString(long.MaxValue, 2));
            //long mask = 1 << 32;
            //Console.WriteLine("{0} key2 decoded", composite & mask);
            //composite >>= 32;
            //Console.WriteLine(composite);

            //Console.WriteLine("{0} key1 decoded", composite & mask);
            Console.Read();
        }
    }
}
