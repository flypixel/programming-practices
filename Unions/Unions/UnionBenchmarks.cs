using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barcelona.Data;

namespace Unions
{
    [ClrJob(baseline: true)]
    [RPlotExporter, RankColumn]
    public class UnionBenchmarks
    {

        private BarcelonaCity[] _first;
        private BarcelonaCity[] _second;

        [GlobalSetup]
        public void Setup()
        {
            _first = Storage.GetBarcelona1();
            _second = Storage.GetBarcelona2();
        }


        [Benchmark]
        public void UnionAll()
        {
            Unions.UnionAll(_first, 
                _second, 
                x => new { x.Name, x.Latitude, x.Longitude }
            );
        }

        [Benchmark]
        public void Union()
        {
            dynamic selector(BarcelonaCity x) => new { x.Name, x.Latitude, x.Longitude };
            Unions.Union(_first, _second, selector, selector);
        }
    }
}
