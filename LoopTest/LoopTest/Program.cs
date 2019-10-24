using System;
using System.Collections;
using System.Collections.Generic;

namespace LoopTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StockRepository.GetAvailableModels();
            Console.WriteLine("Initializing structures comparison!");
            QuadraticLoops();
            LinearWithHash();
            LinearWithDictionary();
            Console.ReadLine();
        }
        

        static void LinearWithHash()
        {
            char[] models = { 'A', 'C', 'D', 'K', 'I', 'U' };
            var stockModels = StockRepository.Data;
            var result = new Hashtable();
            double x = 0;

            Console.WriteLine("Starting the linear with Hash!");
            for (int i = 0; i < models.Length; i++)
            {
                result.Add(models[i], 0);
                x++;
            }

            DateTime startTime = DateTime.Now;
            for (int j = 0; j < stockModels.Length; j++)
            {
                var value = stockModels[j];
                if (result.ContainsKey(value))
                    result[value] = (int)result[value] + 1;
                x++;
            }

            DateTime endTime = DateTime.Now;
            TimeSpan span = endTime.Subtract(startTime);

            Console.WriteLine("Time Difference (minutes): " + span.Minutes);
            Console.WriteLine("Time Difference (seconds): " + span.Seconds);
            Console.WriteLine("Time Difference (miliseconds): " + span.Milliseconds);
            Console.WriteLine("***Linear Finished***");

        }

        static void LinearWithDictionary()
        {
            char[] models = { 'A', 'C', 'D', 'K', 'I', 'U' };
            var stockModels = StockRepository.Data;
            var result = new Dictionary<char,int>();
            double x = 0;

            Console.WriteLine("Starting the linear with Dictionary!");
            for (int i = 0; i < models.Length; i++)
            {
                result.Add(models[i], 0);
                x++;
            }

            DateTime startTime = DateTime.Now;
            for (int j = 0; j < stockModels.Length; j++)
            {
                var value = stockModels[j];
                if (result.ContainsKey(value))
                    result[value] = (int)result[value] + 1;
                x++;
            }

            DateTime endTime = DateTime.Now;
            TimeSpan span = endTime.Subtract(startTime);

            Console.WriteLine("Time Difference (minutes): " + span.Minutes);
            Console.WriteLine("Time Difference (seconds): " + span.Seconds);
            Console.WriteLine("Time Difference (miliseconds): " + span.Milliseconds);
            Console.WriteLine("***Linear Finished***");

        }

        static void QuadraticLoops()
        {
            char[] models = { 'A', 'C', 'D', 'K', 'I', 'U' };
            var stockModels = StockRepository.Data;

            DateTime startTime = DateTime.Now;
            var result = new List<ModelResult>();
            double counter = 0;
            Console.WriteLine("Starting the Quadratic!");

            for (int i = 0; i < models.Length; i++)
            {
                result.Add(new ModelResult() { Value = models[i], Total = 0 });
                for (int j = 0; j < stockModels.Length; j++)
                {
                    if (stockModels[j] == models[i])
                        result[i].Total += 1;
                    counter++;
                }
            }
            //Voltas totais: 3000000000

            DateTime endTime = DateTime.Now;
            TimeSpan span = endTime.Subtract(startTime);

            Console.WriteLine("Time Difference (minutes): " + span.Minutes);
            Console.WriteLine("Time Difference (seconds): " + span.Seconds);
            Console.WriteLine("Time Difference (miliseconds): " + span.Milliseconds);
            Console.WriteLine("***Quadratic Finished***");

        }

    }

    public class ModelResult
    {
        public char Value { get; set; }
        public int Total { get; set; }
    }
}
