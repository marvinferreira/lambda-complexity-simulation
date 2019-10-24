using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Repository.Repositories;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AlgoritmoN
{
    public class Function
    {
        public Hashtable FunctionHandler(char[] models, ILambdaContext context)
        {
            var stockModels = StockRepository.Data;
            var result = new Hashtable();
            double counter = 0;

            DateTime startTime = DateTime.Now;
            for (int i = 0; i < models.Length; i++)
            {
                result.Add(models[i], 0);
                counter++;
            }
                
            for (int j = 0; j < stockModels.Length; j++)
            {
                var value = stockModels[j];
                if (result.ContainsKey(value))
                    result[value] = (int)result[value] + 1;
                counter++;
            }

            //Voltas: 500000006

            DateTime endTime = DateTime.Now;
            TimeSpan span = endTime.Subtract(startTime);
           
            LambdaLogger.Log("Time Difference (minutes): " + span.Minutes);
            LambdaLogger.Log("Time Difference (seconds): " + span.Seconds);
            LambdaLogger.Log("Time Difference (miliseconds): " + span.Milliseconds);
            return result;
        }
    }
}
