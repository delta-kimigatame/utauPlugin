using System;

namespace UtauPlugin
{
    public partial class Note
    {
        private const float DEFAULT_ATOVE = 0f;

        public void InitAtOve(string atOve) => this.atOve = new Entry<float>(float.Parse(atOve));
        public void InitAtOve(float atOve) => this.atOve = new Entry<float>(atOve);
        public void SetAtOve(string atOve)
        {
            if (HasAtOve()) { this.atOve.Set(float.Parse(atOve)); }
            else
            {
                this.atOve = new Entry<float>(0);
                this.atOve.Set(float.Parse(atOve));
            }
        }
        public void SetAtOve(float atOve)
        {
            if (HasAtOve()) { this.atOve.Set(atOve); }
            else
            {
                this.atOve = new Entry<float>(0);
                this.atOve.Set(atOve);
            }
        }

        public float GetAtOve() => HasAtOve() ? atOve.Get() : DEFAULT_ATOVE;
        public Boolean AtOveIsChanged() => (HasAtOve() && atOve.IsChanged());
        public Boolean HasAtOve() => (atOve != null);
    }
}
