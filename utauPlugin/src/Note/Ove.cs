using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// オーバーラップの初期値
        /// </summary>
        private const float DEFAULT_OVE = 0f;
        /// <summary>
        /// オーバーラップの初期化
        /// </summary>
        /// <param name="ove">floatに変換可能な文字列</param>
        public void InitOve(string ove) => this.ove = new Entry<float>(float.Parse(ove));
        /// <summary>
        /// オーバーラップの初期化
        /// </summary>
        /// <param name="ove"></param>
        public void InitOve(float ove) => this.ove = new Entry<float>(ove);
        /// <summary>
        /// オーバーラップの変更
        /// </summary>
        /// <param name="ove">floatに変換可能な文字列</param>
        public void SetOve(string ove)
        {
            if (HasOve()) { this.ove.Set(float.Parse(ove)); }
            else
            {
                this.ove = new Entry<float>(0);
                this.ove.Set(float.Parse(ove));
            }
        }
        /// <summary>
        /// オーバーラップの変更
        /// </summary>
        /// <param name="ove"></param>
        public void SetOve(float ove)
        {
            if (HasOve()) { this.ove.Set(ove); }
            else
            {
                this.ove = new Entry<float>(0);
                this.ove.Set(ove);
            }
        }
        /// <summary>
        /// オーバーラップの取得
        /// </summary>
        /// <returns></returns>
        public float GetOve() => HasOve() ? ove.Get() : DEFAULT_OVE;
        /// <summary>
        /// オーバーラップが変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean OveIsChanged() => (HasOve() && ove.IsChanged());
        /// <summary>
        /// オーバーラップ値を持っていればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasOve() => (ove != null);
    }
}
