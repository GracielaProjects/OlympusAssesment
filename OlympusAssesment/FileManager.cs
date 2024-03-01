using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.WebRequestMethods;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using System.Threading;

namespace OlympusAssesment
{
    internal class FileManager
    {
       
        static string filePathDir = "log";
        static string filePath = Path.Combine(filePathDir, "out.txt");
        static readonly object lockObject = new object(); // Lock object for thread synchronization
        static int lineCount = 0;

        public static void InitializeFile()
        {
            //2. Initialize this file by writing the string “0, 0, <current_time_stamp>
            DateTime now = DateTime.Now;
            string timeStamp = now.ToString("HH:mm:ss.fff");
            string firstLine = "0, 0," + timeStamp;
            try
            {
                //Check if directory exist
                if (!Directory.Exists(filePathDir))
                {
                    Directory.CreateDirectory(filePathDir);
                    Console.WriteLine("Directory created successfully");
                }

                //Check if file exist 
                if(! System.IO.File.Exists(filePath))
                {
                    using (System.IO.File.Create(filePath)) { }
                }

                //Override file each execution
                lock (lockObject)
                {
                    System.IO.File.WriteAllText(filePath, firstLine + Environment.NewLine);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }


        public static void WriteLines(int threadId)
        {
            //4. Each thread then should append 10 lines to the file 
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    string timeStamp = now.ToString("HH:mm:ss.fff");

                    /* 5.When writing the next line, the line count must always be incremented by one, regardless of which thread is performing the write.
                       6. Each line shall be written in a following format: “<line_count>, <thread_id>, <current_time_stamp>” */

                    lock (lockObject)
                    {
                        string line = $"{++lineCount}, {threadId}, {timeStamp}";
                        System.IO.File.AppendAllText(filePath, line + Environment.NewLine);
                        Console.WriteLine($"Thread {threadId} wrote: {line}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error writing file: {e.Message}");
                }
            }

        }
    }
}
