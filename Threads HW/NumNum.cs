using System;
using System.Diagnostics;
using System.Threading;

namespace Threads_HW
{
    public class NumNum
    {
        public string Name { get; set; }
        public int SleepTime { get; set; }
        

        public NumNum(string name)
        {
            Name = name;
            Random R = new Random();
            
            SleepTime  = R.Next(0, 5000);

            Debug.WriteLine($"Thread: {Name} ; Sleep Time {((float)SleepTime / 1000.0)} Seconds ");

            
        }

        public void Sleep()
        {
            Debug.WriteLine($"{Name} Going to sleep");
            
            Thread.Sleep(SleepTime);
            Debug.WriteLine($"{Name} Done sleeping");

        }
    }
}
