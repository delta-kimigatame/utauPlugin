using System;

namespace UtauPlugin
{
    public partial class Note
    {
        private const string DEFAULT_ATFILENAME = "";
        public void InitAtFileName(string atFileName) => this.atFileName = new Entry<string>(atFileName);
        public void SetAtFileName(string atFileName)
        {
            if (HasAtFileName()) { this.atFileName.Set(atFileName); }
            else
            {
                this.atFileName = new Entry<string>("");
                this.atFileName.Set(atFileName);
            }
        }

        public string GetAtFileName() => HasAtFileName() ? atFileName.Get() : DEFAULT_ATFILENAME;
        public Boolean AtFileNameIsChanged() => (HasAtFileName() && atFileName.IsChanged());
        public Boolean HasAtFileName() => (atFileName != null);
    }
}
