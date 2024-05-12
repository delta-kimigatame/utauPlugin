using System;

namespace UtauPlugin
{
    public partial class Note
    {
        private const int DEFAULT_MOD = 0;
        public void InitMod(string mod) => this.mod = new Entry<int>(int.Parse(mod));
        public void InitMod(int mod) => this.mod = new Entry<int>(mod);
        public void SetMod(string mod)
        {
            if (HasMod()) { this.mod.Set(int.Parse(mod)); }
            else
            {
                this.mod = new Entry<int>(0);
                this.mod.Set(int.Parse(mod));
            }
        }

        public void SetMod(int mod)
        {
            if (HasMod()) { this.mod.Set(mod); }
            else
            {
                this.mod = new Entry<int>(0);
                this.mod.Set(mod);
            }
        }

        public int GetMod() => HasMod() ? mod.Get() : DEFAULT_MOD;
        public Boolean ModIsChanged() => (HasMod() && mod.IsChanged());
        public Boolean HasMod() => (mod != null);
    }
}

