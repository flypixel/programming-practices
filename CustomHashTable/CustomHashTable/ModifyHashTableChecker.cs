using BenchmarkDotNet.Attributes;
using CustomHashTable.Keys;
using System;

namespace CustomHashTable
{
    [ClrJob(baseline: true)]
    [RPlotExporter, RankColumn]
    public class ModifyHashTableChecker<T> where T: ICustomHashTable, new()
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
            FillArray(_data1);
            FillArray(_data2);
            FillArray(_data3);

            FillArray(_dataWithoutgaps);
            FillArray(_badData);
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
            var htable = new T();
            foreach (var key in data)
            {
                try
                {
                    htable.Add(key, _item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void FillArray<U>(U[] array) where U : KeyObject
        {
            var rand = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (U)Activator.CreateInstance(typeof(U), rand.Next(array.Length));
            }
        }
    }
}
