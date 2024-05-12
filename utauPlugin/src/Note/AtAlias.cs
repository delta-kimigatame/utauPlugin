using System;

namespace UtauPlugin
{
    public partial class Note
    {
        private const string DEFAULT_ATALIAS = "";

        public void InitAtAlias(string atAlias) => this.atAlias = new Entry<string>(atAlias);
        public void SetAtAlias(string atAlias)
        {
            if (HasAtAlias()) { this.atAlias.Set(atAlias); }
            else
            {
                this.atAlias = new Entry<string>("");
                this.atAlias.Set(atAlias);
            }
        }

        public string GetAtAlias() => HasAtAlias() ? atAlias.Get() : DEFAULT_ATALIAS;
        public Boolean AtAliasIsChanged() => (HasAtAlias() && atAlias.IsChanged());
        public Boolean HasAtAlias() => (atAlias != null);
    }
}
