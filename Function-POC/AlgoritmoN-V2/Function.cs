using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Repository.Repositories;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AlgoritmoNV2
{
    public class Function
    {
        public int[] FunctionHandler(char[] models, ILambdaContext context)
        {
            var stockModels = StockRepository.Data;
            var mapper = new int[26];
            var result = new int[26];
            double counter = 0;

            DateTime startTime = DateTime.Now;
            for (int j = 0; j < stockModels.Length; j++)
            {
                mapper[stockModels[j] - 65] += 1;
                counter++;
            }
            int position = 0;
            for (int i = 0; i < models.Length; i++)
            {
                position = models[i] - 65;
                result[position] = mapper[position];
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
