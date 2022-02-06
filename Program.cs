//Program requirements:
//Your assignment is to complete the TODO in the code. You will need to parse the file and display a "weekly report" displayed at the system console. You should use string interpolation to complete the task.
//Of course, you will need to figure how the data is formatted in the text file that is generated. To get you started, each line, represents 1 weeks worth of data. The data contains the start date of the week followed by the # of hours of slept for each night (Sunday – Saturday).
//There is a "," separating the date from the hours of sleep and a "|" is used as a delimiter for each night’s hours of sleep.



using System;
using System.IO;

namespace SleepData
{
    class Program
    {
        static void Main(string[] args)
        {   

            string file = "data.txt";

            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();
            if (resp == "1")
            {
                // create data file
                 // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());
                 // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
                
                // random number generator
                Random rnd = new Random();

                // create file
                StreamWriter sw = new StreamWriter(file);
                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }
            else if (resp == "2")
            {
                if (File.Exists(file))
                    {

                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            //Reading the line in the file.
                        string line = sr.ReadLine();
                            //Splitting the file by commas into substrings of the week and the date.
                        string[] week = line.Split(',');
                        DateTime date = DateTime.Parse(week[0]);
                            //splitting the Array by | and reading all of the pieces of information that were split
                        int[] hours = Array.ConvertAll(week[1].Split('|'), int.Parse);

                        //outputting information
                        Console.WriteLine($"Week of {date:MMM}, {date:dd}, {date:yyyy}");
                        Console.WriteLine($"{"Su", 3}{"Mo", 3}{"Tu", 3}{"We", 3}{"Th", 3}{"Fr", 3}{"Sa", 3}");
                        Console.WriteLine($"{"--", 3}{"--", 3}{"--", 3}{"--", 3}{"--", 3}{"--", 3}{"--", 3}");
                        Console.WriteLine($"{hours[0],3}{hours[1],3}{hours[2],3}{hours[3],3}{hours[4],3}{hours[5],3}{hours[6],3}"); 
                        Console.WriteLine(" ");
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("The file does not exist. Please create a file, and then try again.");
                    }
            }
        }
    }
}