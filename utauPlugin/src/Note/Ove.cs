using System;

namespace UtauPlugin
{
    public partial class Note
    {
        private const float DEFAULT_OVE = 0f;
        public void InitOve(string ove) => this.ove = new Entry<float>(float.Parse(ove));
        public void InitOve(float ove) => this.ove = new Entry<float>(ove);
        public void SetOve(string ove)
        {
            if (HasOve()) { this.ove.Set(float.Parse(ove)); }
            else
            {
                this.ove = new Entry<float>(0);
                this.ove.Set(float.Parse(ove));
            }
        }
        public void SetOve(float ove)
        {
            if (HasOve()) { this.ove.Set(ove); }
            else
            {
                this.ove = new Entry<float>(0);
                this.ove.Set(ove);
            }
        }

        public float GetOve() => HasOve() ? ove.Get() : DEFAULT_OVE;
        public Boolean OveIsChanged() => (HasOve() && ove.IsChanged());
        public Boolean HasOve() => (ove != null);
    }
}
