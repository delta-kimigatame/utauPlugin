using System;

namespace UtauPlugin
{
    public partial class Note
    {
        private const string DEFAULT_FLAGS = "";
        public void InitFlags(string flags) => this.flags = new Entry<string>(flags);
        public void SetFlags(string flags)
        {
            if (HasFlags()) { this.flags.Set(flags); }
            else
            {
                this.flags = new Entry<string>("");
                this.flags.Set(flags);
            }
        }

        public string GetFlags() => HasFlags() ? flags.Get() : DEFAULT_FLAGS;
        public Boolean FlagsIsChanged() => (HasFlags() && flags.IsChanged());
        public Boolean HasFlags() => (flags != null);
    }
}
