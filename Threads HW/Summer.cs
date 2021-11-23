using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Threads_HW
{
    class Summer
    {
        public long StartNumber { get; set; }
        public long EndNumber { get; set; }
        static public long Sum { get; set; }
        static object LockObject = new object();


        public Summer(long startNumber, long endNumber)
        {
            StartNumber = startNumber;
            EndNumber = endNumber;
        }

        public void SumNumbers() 

        {
            for (int k = 1; k <= 5; k++)
            {

                if (EndNumber - (200000 * k) - StartNumber > 0) 
                {

                    switch (k)
                    {
                        case 1:
                            new Task(() =>
                            {

                                for (long i = StartNumber; i < StartNumber + 200000; i++)
                                {
                                    AddToSum(i);
                                }

                        
                            }).Start();
                            break;
                        case 2:
                            new Task(() =>
                            {

                                for (long i = StartNumber + 200000; i < StartNumber + 400000; i++)
                                {
                                    AddToSum(i);
                                }
                        

                            }).Start();
                            break;
                        case 3:
                            new Task(() =>
                            {

                                for (long i = StartNumber + 400000; i < StartNumber + 600000; i++)
                                {
                                    AddToSum(i);
                                }
                        

                            }).Start();
                            break;
                        case 4:
                            new Task(() =>
                            {

                                for (long i = StartNumber + 600000; i < StartNumber + 800000; i++)
                                {
                                    AddToSum(i);
                                }
                        

                            }).Start();
                            break;
                        case 5:
                            new Task(() =>
                            {

                                for (long i = StartNumber + 800000; i < StartNumber + 1000000; i++)
                                {
                                    AddToSum(i);
                                }
                        

                            }).Start();
                            break;
               
                    }
                }
                else
                {


                    new Task(() =>
                    {
                        for (long i = StartNumber + (k - 1) * 200000; i <= EndNumber; i++)
                        {
                            AddToSum(i);
                        }


                    }).Start();

                    break;
                }

            }

        }

        void AddToSum(long Value)
        {
            lock (LockObject)
            {

                Sum += Value;

                
            }
        }
    }
}
