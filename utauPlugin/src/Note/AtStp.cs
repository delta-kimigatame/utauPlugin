using System;

namespace UtauPlugin
{
    public partial class Note
    {
        private const float DEFAULT_ATSTP = 0f;
        public void InitAtStp(string atStp) => this.atStp = new Entry<float>(float.Parse(atStp));
        public void InitAtStp(float atStp) => this.atStp = new Entry<float>(atStp);
        public void SetAtStp(string atStp)
        {
            if (HasAtStp()) { this.atStp.Set(float.Parse(atStp)); }
            else
            {
                this.atStp = new Entry<float>(0);
                this.atStp.Set(float.Parse(atStp));
            }
        }
        public void SetAtStp(float atStp)
        {
            if (HasAtStp()) { this.atStp.Set(atStp); }
            else
            {
                this.atStp = new Entry<float>(0);
                this.atStp.Set(atStp);
            }
        }

        public float GetAtStp() => HasAtStp() ? atStp.Get() : DEFAULT_ATSTP;
        public Boolean AtStpIsChanged() => (HasAtStp() && atStp.IsChanged());
        public Boolean HasAtStp() => (atStp != null);
    }
}
