using System;

namespace utauPlugin
{
    public partial class Note
    {
        private const Boolean DEFAULT_DIRECT = false;
        public void InitDirect(Boolean direct) => this.direct = new Entry<Boolean>(direct);
        public void InitDirect(string direct) => this.direct = new Entry<Boolean>(Boolean.Parse(direct));
        public void SetDirect(Boolean direct)
        {
            if (HasDirect()) { this.direct.Set(direct); }
            else
            {
                this.direct = new Entry<Boolean>(false);
                this.direct.Set(direct);
            }

        }

        public void SetDirect(string direct)
        {
            if (HasDirect()) { this.direct.Set(Boolean.Parse(direct)); }
            else
            {
                this.direct = new Entry<Boolean>(false);
                this.direct.Set(Boolean.Parse(direct));
            }
        }

        public Boolean GetDirect() => HasDirect() ? this.direct.Get() : DEFAULT_DIRECT;
        public Boolean DirectIsChanged() => (HasDirect() && direct.IsChanged());
        public Boolean HasDirect() => (direct != null);
    }
}
