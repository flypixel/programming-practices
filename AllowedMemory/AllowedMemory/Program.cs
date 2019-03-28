using System;
using System.Collections.Generic;

namespace AllowedMemory
{
    class Program
    {
        const int mb = 1024 * 1024;
        private static int AmaoutOfAvailableMemory()
        {
            int i = 0;
            try
            {
                var blocks = new LinkedList<byte[]>();
                for (; ; i++)
                {
                    blocks.AddLast(new byte[mb]);
                }
            }
            catch (OutOfMemoryException)
            {
            }
            return i;
        }

        private static int SingleBlockOfMemory()
        {
            int i = 20;
            try
            {
                for (; ; i++)
                {
                    var bytes = new long[(i + 1) * mb];
                }
            }
            catch (OutOfMemoryException)
            {
            }
            return i * 8;
        }

        static void Main(string[] args)
        {
            var memory = AmaoutOfAvailableMemory();
            Console.WriteLine($"1. Amount of memory to allocate is {memory} MB");
            GC.Collect();
            var single = SingleBlockOfMemory();
            Console.WriteLine($"2. Amount of single block of memory is {single} MB");
        }
    }
}
