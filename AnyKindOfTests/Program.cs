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
            var z = new BMW();
            z.ZapaliKola();
            Console.Read();
        }
    }
}
