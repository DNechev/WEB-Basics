using System;
using System.Text;

namespace Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            Chronometer chronometer = new Chronometer();

            string input = string.Empty;

            while(input != "exit")
            {
                input = Console.ReadLine();

                if (input == "start")
                {
                    chronometer.Start();
                }
                else if(input == "stop")
                {
                    chronometer.Stop();
                }
                else if(input == "reset")
                {
                    chronometer.Reset();
                }
                else if(input == "time")
                {
                    string lap = chronometer.Lap();
                    Console.WriteLine(lap);
                }
                else if (input == "laps")
                {
                    if (chronometer.Laps.Count == 0)
                    {
                        Console.WriteLine("No laps!");
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < chronometer.Laps.Count; i++)
                        {
                            sb.AppendLine($"{i}. {chronometer.Laps[i]}");
                        }
                        Console.WriteLine(sb.ToString().Trim());
                    }
                    
                }
            }
        }
    }
}
