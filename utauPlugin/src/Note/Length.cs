using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utauPlugin
{
    public partial class Note
    {
        private const int DEFAULT_LENGTH = 480;
        public void InitLength(string length) => this.length = new Entry<int>(int.Parse(length));
        public void InitLength(int length) => this.length = new Entry<int>(length);
        public void SetLength(string length) => this.length.Set(int.Parse(length));
        public void SetLength(int length) => this.length.Set(length);
        public int GetLength() => length.Get();
        public Boolean LengthIsChanged() => length.IsChanged();
    }
}
