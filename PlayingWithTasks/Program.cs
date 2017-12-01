﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithTasks
{
    class Program
    {
        private static object locker1 = new object();
        private static object locker2 = new object();

        static void Main(string[] args)
        {
            //TaskDelay.Start();
            //new TimerAndTasks().Start();
            //new Threads().Start();
            //new ThreadsConcurency().Start();
            //new TwoThreadsSameData().Start();
            //new ForeGRAndBGR().Start();
            //new Deadlock().Start();

            //Console.WriteLine("end");

            new Thread(() =>
            {
                Console.WriteLine("hello from NT");
                lock (locker1)
                {
                    Console.WriteLine("NT 1st lock");
                    Thread.Sleep(1000);
                    lock (locker2) { Console.WriteLine("NT 2nd lock"); }
                }
            }).Start();

            Console.WriteLine("main thread");

            lock (locker2)
            {
                Console.WriteLine("main 2nd lock");
                Thread.Sleep(1000);
                lock (locker1) { Console.WriteLine("main 1st lock"); }
            }
        }
    }
}
