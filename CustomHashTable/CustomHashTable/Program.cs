using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using CustomHashTable.HashTables;
using System;

namespace CustomHashTable
{
    public class Bench : ModifyHashTableChecker<HashTable>
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
            var summary = BenchmarkRunner.Run<ModifyHashTableChecker<HashTable>>();
            Console.ReadKey();
        }
    }
}
