using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barcelona.Data;
using BenchmarkDotNet.Running;

namespace Unions
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic selector(BarcelonaCity x) => new { x.Name, x.Latitude, x.Longitude };
            Console.WriteLine($"{nameof(Unions.Union)}: {Unions.Union(Storage.GetBarcelona1(), Storage.GetBarcelona2(), selector, selector).Count()}");
            Console.WriteLine($"{nameof(Unions.UnionAll)}: {Unions.UnionAll(Storage.GetBarcelona1(), Storage.GetBarcelona2(), selector).Count()}");
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
            var summary = BenchmarkRunner.Run<UnionBenchmarks>();
            Console.ReadKey();
        }
    }
}
