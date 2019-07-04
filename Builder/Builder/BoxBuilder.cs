using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Builder
{
    public class BoxBuilder: IDisposable
    {
        private const int InitVersion = 0;
        private volatile int _version = InitVersion;
        private int _width;
        private int _height;
        private int _length;
        private ThreadLocal<Box> _local = new ThreadLocal<Box>(() => new Box { Version = InitVersion });

        public BoxBuilder SetWith(int value)
        {
            int version;
            do
            {
                version = _version;
                _width = value;
            } while (++version != Interlocked.Increment(ref _version));
            return this;
        }

        public BoxBuilder SetHeight(int value)
        {
            int version;
            do
            {
                version = _version;
                _height = value;
            } while (++version != Interlocked.Increment(ref _version));
            return this;
        }

        public BoxBuilder SetLenght(int value)
        {
            int version;
            do
            {
                version = _version;
                _length = value;
            } while (++version != Interlocked.Increment(ref _version));
            return this;
        }

        public Box Create()
        {
            if (_local.Value.Version != _version)
            {
                _local.Value = new Box
                {
                    Height = _height,
                    Width = _width,
                    Length = _length,
                    Version = _version
                };
            }
            return _local.Value;
        }

        public void Dispose()
        {
            _local.Dispose();
        }
    }
}
