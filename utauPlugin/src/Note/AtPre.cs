using System;

namespace utauPlugin
{
    public partial class Note
    {
        private const float DEFAULT_ATPRE = 0f;
        public void InitAtPre(string atPre) => this.atPre = new Entry<float>(float.Parse(atPre));
        public void InitAtPre(float atPre) => this.atPre = new Entry<float>(atPre);
        public void SetAtPre(string atPre)
        {
            if (HasAtPre()) { this.atPre.Set(float.Parse(atPre)); }
            else
            {
                this.atPre = new Entry<float>(0);
                this.atPre.Set(float.Parse(atPre));
            }
        }
        public void SetAtPre(float atPre)
        {
            if (HasAtPre()) { this.atPre.Set(atPre); }
            else
            {
                this.atPre = new Entry<float>(0);
                this.atPre.Set(atPre);
            }
        }

        public float GetAtPre() => HasAtPre() ? atPre.Get() : DEFAULT_ATPRE;
        public Boolean AtPreIsChanged() => (HasAtPre() && atPre.IsChanged());
        public Boolean HasAtPre() => (atPre != null);
    }
}
