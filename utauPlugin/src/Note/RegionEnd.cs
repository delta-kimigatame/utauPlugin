using System;

namespace UtauPlugin
{
    public partial class Note
    {
        private const string DEFAULT_REGIONEND = "";
        public void InitRegionEnd(string regionEnd) => this.regionEnd = new Entry<string>(regionEnd);
        public void SetRegionEnd(string regionEnd)
        {
            if (HasRegionEnd()) { this.regionEnd.Set(regionEnd); }
            else
            {
                this.regionEnd = new Entry<string>("");
                this.regionEnd.Set(regionEnd);
            }
        }

        public string GetRegionEnd() => HasRegionEnd() ? regionEnd.Get() : DEFAULT_REGIONEND;
        public Boolean RegionEndIsChanged() => (HasRegionEnd() && regionEnd.IsChanged());
        public Boolean HasRegionEnd() => (regionEnd != null);
    }
}
