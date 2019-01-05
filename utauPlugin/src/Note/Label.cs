using System;

namespace utauPlugin
{
    public partial class Note
    {
        private const string DEFAULT_LABEL = "";
        public void InitLabel(string label) => this.label = new Entry<string>(label);
        public void SetLabel(string label)
        {
            if (HasLabel()) { this.label.Set(label); }
            else
            {
                this.label = new Entry<string>("");
                this.label.Set(label);
            }
        }

        public string GetLabel() => HasLabel() ? label.Get() : DEFAULT_LABEL;
        public Boolean LabelIsChanged() => (HasLabel() && label.IsChanged());
        public Boolean HasLabel() => (label != null);
    }
}
