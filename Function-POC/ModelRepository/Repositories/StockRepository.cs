using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class StockRepository
    {
        public static char[] Data { get; set; }
        public static char[] GetAvailableModels() {

            if (StockRepository.Data == null)
            {
                StockRepository.Data = StockRepository.GenerateModels(500000000);
            }
            return StockRepository.Data;
        }

        private static char[] GenerateModels(int size)
        {
            Random integerGenerator = new Random();
            List<char> resultList = new List<char>();

            for (int i = 0; i < size; i++)
                resultList.Add((char)integerGenerator.Next(65, 90));

            return resultList.ToArray();
        }
    }
}
