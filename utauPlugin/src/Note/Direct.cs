using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// directの初期値
        /// </summary>
        private const Boolean DEFAULT_DIRECT = false;
        /// <summary>
        /// directの初期化
        /// </summary>
        /// <param name="direct">$directの値</param>
        public void InitDirect(Boolean direct) => this.direct = new Entry<Boolean>(direct);
        /// <summary>
        /// directの初期化
        /// </summary>
        /// <param name="direct">$directの値、booleanに変換可能な文字列</param>
        public void InitDirect(string direct) => this.direct = new Entry<Boolean>(Boolean.Parse(direct));
        /// <summary>
        /// directの変更
        /// </summary>
        /// <param name="direct">$directの値</param>
        public void SetDirect(Boolean direct)
        {
            if (HasDirect()) { this.direct.Set(direct); }
            else
            {
                this.direct = new Entry<Boolean>(false);
                this.direct.Set(direct);
            }

        }

        /// <summary>
        /// directの変更
        /// </summary>
        /// <param name="direct">$directの値、booleanに変換可能な文字列</param>
        public void SetDirect(string direct)
        {
            if (HasDirect()) { this.direct.Set(Boolean.Parse(direct)); }
            else
            {
                this.direct = new Entry<Boolean>(false);
                this.direct.Set(Boolean.Parse(direct));
            }
        }

        /// <summary>
        /// directの取得
        /// </summary>
        /// <returns>direct</returns>
        public Boolean GetDirect() => HasDirect() ? this.direct.Get() : DEFAULT_DIRECT;
        /// <summary>
        /// directが変更されたか
        /// </summary>
        /// <returns>変更済みであればtrue</returns>
        public Boolean DirectIsChanged() => (HasDirect() && direct.IsChanged());
        /// <summary>
        /// directをこのノートが持っているか判定する。
        /// </summary>
        /// <returns>directの値を持っていればtrue</returns>
        public Boolean HasDirect() => (direct != null);
    }
}
