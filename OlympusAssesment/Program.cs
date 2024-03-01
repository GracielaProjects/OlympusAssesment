using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Diagnostics.Metrics;

namespace OlympusAssesment
{
    internal class Program
    {
        static int completedThreads = 0;
        static void Main(string[] args)
        {
            // 1.Create a text file at location /log/out.txt.
            FileManager.InitializeFile();

            //3.Launch 10 threads to run simultaneously
            Thread[] threads = new Thread[10];
            for (int t = 0; t < threads.Length; t++)
                
            {
                threads[t] = new Thread(() =>
                {
                    /* 7.	Each thread should gracefully terminate after it has performed 10 writes to the file.
                    Each thread runs the WriteLines method, which contains a loop to write 10 lines to the file.
                    no more code for the thread to execute within the method, so the thread naturally terminates. */

                    FileManager.WriteLines(Thread.CurrentThread.ManagedThreadId);

                });

                threads[t].Start();
            }


            //8. When all ten threads have terminated, wait for a character press, then exit.
            foreach (var thread in threads)
            {
                thread.Join(); // Wait for each thread to complete
            }

            Console.WriteLine("Press any key to exit Graciela Assesment by Olympus.");
          
            Console.ReadKey();
        }
    }
}

