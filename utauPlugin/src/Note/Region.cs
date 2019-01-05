using System;

namespace utauPlugin
{
    public partial class Note
    {
        private const string DEFAULT_REGION = "";
        public void InitRegion(string region) => this.region = new Entry<string>(region);
        public void SetRegion(string region)
        {
            if (HasRegion()) { this.region.Set(region); }
            else
            {
                this.region = new Entry<string>("");
                this.region.Set(region);
            }
        }

        public string GetRegion() => HasRegion() ? region.Get() : DEFAULT_REGION;
        public Boolean RegionIsChanged() => (HasRegion() && region.IsChanged());
        public Boolean HasRegion() => (region != null);
    }
}
