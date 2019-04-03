using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHashTable.Keys
{
    public sealed class KeyObject1 : KeyObject
    {
        public KeyObject1(int value) : base(value)
        {
        }

        public override int GetHashCode()
        {
            return 101 * ((Value >> 24) + 101 * ((Value >> 16) + 101 * (Value >> 8))) + Value;
        }
    }
}
