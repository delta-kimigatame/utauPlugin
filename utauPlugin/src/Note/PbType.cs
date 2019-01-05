using System;
namespace utauPlugin
{
    public partial class Note
    {
        private const string DEFAULT_PBTYPE = "5";
        public void InitPbType(string pbType) => this.pbType = new Entry<string>(pbType);
        public void SetPbType(string pbType)
        {
            if (HasPbType()) { this.pbType.Set(pbType); }

            else
            {
                this.pbType = new Entry<string>("");
                this.pbType.Set(pbType);
            }
        }

        public string GetPbType() => HasPbType() ? pbType.Get() : DEFAULT_PBTYPE;
        public Boolean PbTypeIsChanged() => (HasPbType() && pbType.IsChanged());
        public Boolean HasPbType() => (pbType != null);
    }
}

