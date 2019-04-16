using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unions
{
    static class Unions
    {
        public static IEnumerable<U> UnionAll<T, U>(IEnumerable<T> first, IEnumerable<T> second, Func<T, U> selector)
        {
            var all = first.Select(selector).ToList();
            all.AddRange(second.Select(selector));
            return all;
        }

        public static IEnumerable<U> Union<T, U, X>(IEnumerable<T> first, IEnumerable<T> second, Func<T, U> selector, Func<T, X> by)
        {
            var all = new HashSet<T>(new Comparer<T, X>(by));

            all.UnionWith(first);
            all.UnionWith(second);
            
            return all.Select(selector);
        }

        private class Comparer<T, X> : IEqualityComparer<T>
        {
            Func<T, X> _by;
            public Comparer(Func<T, X> by)
            {
                _by = by;
            }

            public bool Equals(T x, T y)
            {
                return _by(x).Equals(_by(y));
            }

            public int GetHashCode(T obj)
            {
                return _by(obj).GetHashCode();
            }
        }
    }
}
