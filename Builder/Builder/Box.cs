using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Box
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        internal int Version { get; set; }

        public override bool Equals(object obj)
        {
            var x = obj as Box;
            if (x == null) return false;
            return x.Width == Width 
                && x.Height == Height
                && x.Length == Length
                && x.Version == Version;
        }

        public override int GetHashCode()
        {
            var hashCode = -592279107;
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            hashCode = hashCode * -1521134295 + Version.GetHashCode();
            return hashCode;
        }
    }
}
