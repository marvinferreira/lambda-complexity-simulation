using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using N2 = AlgoritmoN2;
using N = AlgoritmoN;
using NV2 = AlgoritmoNV2;
using Repository.Repositories;

namespace LambdaTests.TestsN2
{
    public class FunctionTest
    {
        public FunctionTest()
        {
            StockRepository.GetAvailableModels();
        }
        
        [Fact]
        public void TestN2Algorithm()
        {
            var function = new N2.Function();
            var context = new TestLambdaContext();
            char[] testValues = { 'A', 'C', 'D', 'K', 'I', 'U' };
            var upperCase = function.FunctionHandler(testValues, context);
        }

        [Fact]
        public void TestNAlgorithm()
        {
            var function = new N.Function();
            var context = new TestLambdaContext();
            char[] testValues = { 'A', 'C', 'D', 'K', 'I', 'U' };
            var upperCase = function.FunctionHandler(testValues, context);
        }

        [Fact]
        public void TestNAlgorithmV2()
        {
            var function = new NV2.Function();
            var context = new TestLambdaContext();
            char[] testValues = { 'A', 'C', 'D', 'K', 'I', 'U' };
            var upperCase = function.FunctionHandler(testValues, context);
        }
    }
}
