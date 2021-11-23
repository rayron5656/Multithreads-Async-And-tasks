using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Threads_HW
{
    partial class Program
    {
        static long Sum = 0;
        static object LockObject = new object();


        static void Main(string[] args)
        {
            #region QST 1
            Console.WriteLine("To start Qst 1 press Enter");
            Console.ReadLine();
            Thread T = new Thread(() =>
            {
                for (int i = 0; i <= 5000; i++)
                {
                    Console.WriteLine(i);
                }

            });

            T.Start();

            #endregion

            #region QST 2

            Console.WriteLine("To start Qst 2 press Enter");
            Console.ReadLine();

            Thread T2 = new Thread(() =>
            {

                foreach (string item in Directory.GetDirectories(@"C:\\Program Files"))
                {
                    Debug.WriteLine(item);
                }
            });
            Thread T22 = new Thread(() =>
            {
                foreach (string item in Directory.GetDirectories(@"C:\\Program Files (x86)"))
                {
                    Debug.WriteLine(item);
                }
            });

            T2.Start();
            T22.Start();






            #endregion


            #region QST3

            Debug.WriteLine("Starting Threads");
            NumNum FirstNum = new NumNum("First Num");
            Thread TFirst = new Thread(() => FirstNum.Sleep());
            TFirst.Start();

            NumNum SecondNum = new NumNum("Second Num");
            Thread TSecond = new Thread(() => SecondNum.Sleep());
            TSecond.Start();

            NumNum ThirdNum = new NumNum("Third Num");
            Thread TThird = new Thread(() => ThirdNum.Sleep());
            TThird.Start();

            NumNum FourthNum = new NumNum("Fourth Num");
            Thread TFourth = new Thread(() => FourthNum.Sleep());
            TFourth.Start();
            Debug.WriteLine("Threads started");

            #endregion

            #region QST 4

            Console.WriteLine("Enter a number up to 2 million");

            long N = long.Parse(Console.ReadLine());



            for (int i = 1; i < 10; i++)
            {

                if (200000 * i <= N)
                {
                    switch (i)
                    {
                        case 1:
                            new Thread(() =>
                            {

                                for (int i = 1; i <= 200000; i++)
                                {
                                    AddToSum(i);
                                }

                                PrintSum();
                            }).Start();
                            break;
                        case 2:
                            new Thread(() =>
                            {

                                for (int i = 200001; i <= 400000; i++)
                                {
                                    AddToSum(i);
                                }
                                PrintSum();

                            }).Start();
                            break;
                        case 3:
                            new Thread(() =>
                            {

                                for (int i = 400001; i <= 600000; i++)
                                {
                                    AddToSum(i);
                                }
                                PrintSum();

                            }).Start();
                            break;
                        case 4:
                            new Thread(() =>
                            {

                                for (int i = 600001; i <= 800000; i++)
                                {
                                    AddToSum(i);
                                }
                                PrintSum();

                            }).Start();
                            break;
                        case 5:
                            new Thread(() =>
                            {

                                for (int i = 800001; i <= 1000000; i++)
                                {
                                    AddToSum(i);
                                }
                                PrintSum();

                            }).Start();
                            break;
                        case 6:
                            new Thread(() =>
                            {

                                for (int i = 1000001; i <= 1200000; i++)
                                {
                                    AddToSum(i);
                                }
                                PrintSum();

                            }).Start();
                            break;
                        case 7:
                            new Thread(() =>
                            {

                                for (int i = 1200001; i <= 1400000; i++)
                                {
                                    AddToSum(i);
                                }
                                PrintSum();

                            }).Start();
                            break;
                        case 8:
                            new Thread(() =>
                            {

                                for (int i = 1400001; i <= 1600000; i++)
                                {
                                    AddToSum(i);
                                }
                                PrintSum();

                            }).Start();
                            break;
                        case 9:
                            new Thread(() =>
                            {

                                for (int i = 1600001; i <= 1800000; i++)
                                {
                                    AddToSum(i);
                                }
                                PrintSum();

                            }).Start();
                            break;
                        case 10:
                            new Thread(() =>
                            {

                                for (int i = 1800001; i <= 2000000; i++)
                                {
                                    AddToSum(i);
                                }
                                PrintSum();

                            }).Start();
                            break;
                    }

                }


                else if (200000 * i == N)
                {
                    break;
                }

                else
                {


                    new Thread(() =>
                    {

                        long rangerMin = i * 200000 - 200000;

                        for (long j = 1; j <= (N - rangerMin); j++)
                        {

                            AddToSum(j);

                        }
                        PrintSum();

                    }).Start();
                    break;

                }

            }




            static void AddToSum(long Value)
            {
                lock (LockObject)
                {
                    Sum += Value;


                }
            }

            static void PrintSum()
            {
                Debug.WriteLine(Sum);
            }

            #endregion

            #region QST5

            long L = 345067;

            for (long i = 345068; i <= 678934; i++)
            {
                L += i;

            }

            Debug.WriteLine(L);

            Summer MyfirstSum = new Summer(345067, 678934);

            MyfirstSum.SumNumbers();

            //Summer MySecSum = new Summer(0, 1000000);

            //MySecSum.SumNumbers();


            Thread.Sleep(10000);
            Debug.WriteLine(Summer.Sum);

            #endregion






        }
    }
}
