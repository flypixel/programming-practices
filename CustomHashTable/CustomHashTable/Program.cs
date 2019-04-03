using BenchmarkDotNet.Running;
using System;

namespace CustomHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ModifyHashTableChecker>();
            Console.ReadKey();
        }
    }
}
