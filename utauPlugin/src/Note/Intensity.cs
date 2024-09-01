using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// 音量の初期値
        /// </summary>
        private const int DEFAULT_INTENSITY = 100;
        /// <summary>
        /// 音量の初期化
        /// </summary>
        /// <param name="intensity">intに変換可能な文字列</param>
        public void InitIntensity(string intensity) => this.intensity = new Entry<int>(int.Parse(intensity));
        /// <summary>
        /// 音量の初期化
        /// </summary>
        /// <param name="intensity"></param>
        public void InitIntensity(int intensity) => this.intensity = new Entry<int>(intensity);
        /// <summary>
        /// 音量の変更
        /// </summary>
        /// <param name="intensity">intに変換可能な文字列</param>
        public void SetIntensity(string intensity)
        {
            if (HasIntensity()) { this.intensity.Set(int.Parse(intensity)); }
            else
            {
                this.intensity = new Entry<int>(0);
                this.intensity.Set(int.Parse(intensity));
            }
        }
        /// <summary>
        /// 音量の変更
        /// </summary>
        /// <param name="intensity"></param>
        public void SetIntensity(int intensity)
        {
            if (HasIntensity()) { this.intensity.Set(intensity); }
            else
            {
                this.intensity = new Entry<int>(0);
                this.intensity.Set(intensity);
            }
        }

        /// <summary>
        /// 音量の取得
        /// </summary>
        /// <returns></returns>
        public int GetIntensity() => HasIntensity() ? intensity.Get() : DEFAULT_INTENSITY;
        /// <summary>
        /// 音量が変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean IntensityIsChanged() => (HasIntensity() && intensity.IsChanged());
        /// <summary>
        /// 音量の値を持っていればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasIntensity() => (intensity != null);

    }
}
