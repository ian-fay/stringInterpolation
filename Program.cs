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


            Console.WriteLine("1) Create data file.");
            Console.WriteLine("2) Read data from file");
            Console.WriteLine("3) Quit");

            string userResponse = Console.ReadLine();
            if (userResponse == "1")
            {

                Console.WriteLine("How many weeks of data are needed?");
                int weeks = int.Parse(Console.ReadLine());
                DateTime today = DateTime.Now;
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
                
                Random random = new Random();

                StreamWriter sw = new StreamWriter(file);
                while (dataDate < dataEndDate)
                {
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        hours[i] = random.Next(4, 13);
                    }
                    Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }
            else if (userResponse == "2")
            {
                if (File.Exists(file))
                    {

                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                        string line = sr.ReadLine();
                        string[] week = line.Split(',');
                        DateTime date = DateTime.Parse(week[0]);
                        int[] hours = Array.ConvertAll(week[1].Split('|'), int.Parse);

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
                        Console.WriteLine("The file does not exist. Please make the file and then try the program again.");
                    }
            }
        }
    }
}