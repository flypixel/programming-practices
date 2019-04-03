using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHashTable.Keys
{
    public sealed class KeyObject2 : KeyObject
    {
        public KeyObject2(int value) : base(value)
        {
        }

        public override int GetHashCode()
        {
            return ((Value >> 16) ^ Value) * 0x45d9f3b
;
        }
    }
}
