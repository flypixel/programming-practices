using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHashTable.Keys
{
    public class BadKeyObject : KeyObject
    {
        public BadKeyObject(int value) : base(value)
        {
        }

        public override int GetHashCode()
        {
            return 10;
        }
    }
}
