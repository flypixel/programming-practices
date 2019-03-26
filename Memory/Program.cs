using System;
using System.Collections.Generic;

namespace Memory
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
                for(;; i++)
                {
                    blocks.AddLast(new byte[mb]);
                }
            }
            catch(OutOfMemoryException)
            { 
            }
            return i;
        }

        private static int SingleBlockOfMemory()
        {
            int i = 0;
            try
            {
                for(;; i++)
                {
                    var bytes = new byte[(i + 1) * mb];
                }
            }
            catch(OutOfMemoryException)
            { 
            }
            return i;
        }

        static void Main(string[] args)
        {
            var memory = AmaoutOfAvailableMemory();
            Console.WriteLine($"1. Amount of memory to allocate is {memory} MB");

            var single = SingleBlockOfMemory();
            Console.WriteLine($"2. Amount of single block of memory is {single} MB");
        }
    }
}
