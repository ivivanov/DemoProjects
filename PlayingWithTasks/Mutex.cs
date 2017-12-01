using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithTasks
{
    public class TestMutex
    {
        public void Start()
        {
            using (var mutex = new Mutex(false, "foo"))
            {
                if (!mutex.WaitOne(5000, false))
                {
                    Console.WriteLine($"onother instance of {nameof(ImportantProgram)} is currently runnig");
                    Console.ReadLine();
                    return;
                }

                ImportantProgram();
            }
        }

        public void ImportantProgram()
        {
            Console.WriteLine($"running {nameof(ImportantProgram)}");
            Console.ReadLine();
        }
    }
}
