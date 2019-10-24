using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Repository.Repositories;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AlgoritmoN2
{
    public class Function
    {
        public List<ModelResult> FunctionHandler(char[] models, ILambdaContext context)
        {
            var stockModels = StockRepository.Data;

            DateTime startTime = DateTime.Now;
            var result = new List<ModelResult>();
            double counter = 0;
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

            LambdaLogger.Log("Time Difference (minutes): " + span.Minutes);
            LambdaLogger.Log("Time Difference (seconds): " + span.Seconds);
            LambdaLogger.Log("Time Difference (miliseconds): " + span.Milliseconds);
            return result;
        }

        
    }
}
