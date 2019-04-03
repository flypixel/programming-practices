using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHashTable.Keys
{
    public sealed class KeyObject3 : KeyObject
    {
        public KeyObject3(int value) : base(value)
        {
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}
