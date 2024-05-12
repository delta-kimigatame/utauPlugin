using System;

namespace UtauPlugin
{
    public partial class Note
    {
        private const float DEFAULT_PBSTART = 0f;
        public void InitPbStart(string pbStart) => this.pbStart = new Entry<float>(float.Parse(pbStart));
        public void InitPbStart(float pbStart) => this.pbStart = new Entry<float>(pbStart);
        public void SetPbStart(string pbStart)
        {
            if (HasPbStart()) { this.pbStart.Set(float.Parse(pbStart)); }
            else
            {
                this.pbStart = new Entry<float>(0);
                this.pbStart.Set(float.Parse(pbStart));
            }
        }
        public void SetPbStart(float pbStart)
        {
            if (HasPbStart()) { this.pbStart.Set(pbStart); }
            else
            {
                this.pbStart = new Entry<float>(0);
                this.pbStart.Set(pbStart);
            }
        }

        public float GetPbStart() => HasPbStart() ? pbStart.Get() : DEFAULT_PBSTART;
        public Boolean PbStartIsChanged() => (HasPbStart() && pbStart.IsChanged());
        public Boolean HasPbStart() => (pbStart != null);
    }
}
