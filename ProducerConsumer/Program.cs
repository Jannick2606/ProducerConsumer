using System;
using System.Threading;

namespace ProducerConsumer
{
    class Program
    {
        static Random ran = new Random();
        static bool[] arr = new bool[3];
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Producer);
            Thread t2 = new Thread(Consumer);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }
        static void Producer()
        {
            while (true)
            {
                if (arr[2] == true)
                {
                    Console.WriteLine("Producer fik ikke lov til at producere: 3");
                    Thread.Sleep(ran.Next(1, 1000));
                }
                else if (arr[0] == false)
                {
                    arr[0] = true;
                    Console.WriteLine("Producer fik lov til at producere: 1");
                }
                else if (arr[1] == false)
                {
                    arr[1] = true;
                    Console.WriteLine("Producer fik lov til at producere: 2");
                }
                else
                {
                    arr[2] = true;
                    Console.WriteLine("Producer fik lov til at producere: 3");
                }
            }
        }
        static void Consumer()
        {
            while (true)
            {
                if (arr[0] == false)
                {
                    Console.WriteLine("Consumer fik ikke lov til at tage: 0");
                    Thread.Sleep(ran.Next(1, 1000));
                }
                else if (arr[2] == true)
                {
                    arr[2] = false;
                    Console.WriteLine("Consumer fik lov til at tage: 2");

                }
                else if (arr[1] == true)
                {
                    arr[1] = false;
                    Console.WriteLine("Consumer fik lov til at tage: 1");
                }
                else
                {
                    arr[0] = false;
                    Console.WriteLine("Consumer fik lov til at tage: 0");
                }
            }
        }
    }
}
