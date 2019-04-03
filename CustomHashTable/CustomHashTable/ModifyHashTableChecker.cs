using BenchmarkDotNet.Attributes;
using CustomHashTable.Keys;
using System;
using System.Linq;

namespace CustomHashTable
{
    [ClrJob(baseline: true)]
    [RPlotExporter, RankColumn]
    public class ModifyHashTableChecker
    {

        const int size = 3_000_000;
        const string _item = "item";
        private readonly KeyObject1[] _data1 = new KeyObject1[size];
        private readonly KeyObject2[] _data2 = new KeyObject2[size];
        private readonly KeyObject3[] _data3 = new KeyObject3[size];

        private readonly KeyObject3[] _dataWithoutgaps = new KeyObject3[1000_000];
        private readonly BadKeyObject[] _badData = new BadKeyObject[1000_000];

        [GlobalSetup]
        public void Setup()
        {
            FillArray(_data1, _data1.Length);
            FillArray(_data2, _data1.Length);
            FillArray(_data3, _data1.Length);

            FillArray(_dataWithoutgaps, _data1.Length);
            FillArray(_badData, _data1.Length);
        }


        [Benchmark]
        public void ArrayWithoutGaps()
        {
            BenchmarkBody(_dataWithoutgaps);
        }

        [Benchmark]
        public void ArrayWithBadItems()
        {
            BenchmarkBody(_badData);
        }

        [Benchmark]
        public void FirstHashFunction()
        {
            BenchmarkBody(_data1);
        }

        [Benchmark]
        public void SecondtHashFunction()
        {
            BenchmarkBody(_data2);
        }

        [Benchmark]
        public void ThirdHashFunction()
        {
            BenchmarkBody(_data3);
        }

        private void BenchmarkBody(KeyObject[] data)
        {
            var htable = new HashTable();
            foreach (var key in data)
            {
                htable.Add(key, _item);
            }
        }

        private void FillArray<T>(T[] array, int size) where T : KeyObject
        {
            var rand = new Random();
            array.Aggregate(_badData, (result, x) => {
                x = (T)Activator.CreateInstance(typeof(T), rand.Next(size));
                return result;
            });
        }
    }
}
