using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHashTable.Keys
{
    public class KeyObject
    {
        public int Value { get; }

        public KeyObject(int value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            var x = (KeyObject)obj;
            return Value == x.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        public static bool operator ==(KeyObject o1, KeyObject o2)
        {
            return o1.Equals(o2);
        }

        public static bool operator !=(KeyObject o1, KeyObject o2)
        {
            return !o1.Equals(o2);
        }
    }
}
