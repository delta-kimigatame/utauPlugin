using System;

namespace UtauPlugin
{
    public partial class Note
    {
        private const int DEFAULT_INTENSITY = 100;
        public void InitIntensity(string intensity) => this.intensity = new Entry<int>(int.Parse(intensity));
        public void InitIntensity(int intensity) => this.intensity = new Entry<int>(intensity);
        public void SetIntensity(string intensity)
        {
            if (HasIntensity()) { this.intensity.Set(int.Parse(intensity)); }
            else
            {
                this.intensity = new Entry<int>(0);
                this.intensity.Set(int.Parse(intensity));
            }
        }

        public void SetIntensity(int intensity)
        {
            if (HasIntensity()) { this.intensity.Set(intensity); }
            else
            {
                this.intensity = new Entry<int>(0);
                this.intensity.Set(intensity);
            }
        }

        public int GetIntensity() => HasIntensity() ? intensity.Get() : DEFAULT_INTENSITY;
        public Boolean IntensityIsChanged() => (HasIntensity() && intensity.IsChanged());
        public Boolean HasIntensity() => (intensity != null);

    }
}
