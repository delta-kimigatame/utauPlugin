using System;

namespace UtauPlugin
{
    public partial class Note
    {
        private const int DEFAULT_VELOCITY = 100;
        public void InitVelocity(string velocity) => this.velocity = new Entry<int>(int.Parse(velocity));
        public void InitVelocity(int velocity) => this.velocity = new Entry<int>(velocity);
        public void SetVelocity(string velocity)
        {
            if (HasVelocity()) { this.velocity.Set(int.Parse(velocity)); }
            else
            {
                this.velocity = new Entry<int>(0);
                this.velocity.Set(int.Parse(velocity));
            }
        }

        public void SetVelocity(int velocity)
        {
            if (HasVelocity()) { this.velocity.Set(velocity); }
            else
            {
                this.velocity = new Entry<int>(0);
                this.velocity.Set(velocity);
            }
        }

        public int GetVelocity() => HasVelocity() ? velocity.Get() : DEFAULT_VELOCITY;
        public Boolean VelocityIsChanged() => (HasVelocity() && velocity.IsChanged());
        public Boolean HasVelocity() => (velocity != null);

    }
}
