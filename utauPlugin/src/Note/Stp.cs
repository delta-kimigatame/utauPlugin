using System;

namespace utauPlugin
{
    public partial class Note
    {
        private const float DEFAULT_STP = 0f;
        public void InitStp(string stp) => this.stp = new Entry<float>(float.Parse(stp));
        public void InitStp(float stp) => this.stp = new Entry<float>(stp);
        public void SetStp(string stp)
        {
            if (HasStp()) { this.stp.Set(float.Parse(stp)); }
            else
            {
                this.stp = new Entry<float>(0);
                this.stp.Set(float.Parse(stp));
            }
        }
        public void SetStp(float stp)
        {
            if (HasStp()) { this.stp.Set(stp); }
            else
            {
                this.stp = new Entry<float>(0);
                this.stp.Set(stp);
            }
        }

        public float GetStp() => HasStp() ? stp.Get() : DEFAULT_STP;
        public Boolean StpIsChanged() => (HasStp() && stp.IsChanged());
        public Boolean HasStp() => (stp != null);
    }
}
