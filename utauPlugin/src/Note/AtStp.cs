using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// atStpの初期値
        /// </summary>
        private const float DEFAULT_ATSTP = 0f;
        /// <summary>
        /// atStpの初期化
        /// </summary>
        /// <param name="atStp">UTAUが自動調整したSTP、floatに変換可能な文字列</param>
        public void InitAtStp(string atStp) => this.atStp = new Entry<float>(float.Parse(atStp));
        /// <summary>
        /// atStpの初期化
        /// </summary>
        /// <param name="atStp">UTAUが自動調整したSTP</param>
        public void InitAtStp(float atStp) => this.atStp = new Entry<float>(atStp);
        /// <summary>
        /// atStpの変更
        /// </summary>
        /// <param name="atStp">UTAUが自動調整したSTP、floatに変換可能な文字列</param>
        public void SetAtStp(string atStp)
        {
            if (HasAtStp()) { this.atStp.Set(float.Parse(atStp)); }
            else
            {
                this.atStp = new Entry<float>(0);
                this.atStp.Set(float.Parse(atStp));
            }
        }
        /// <summary>
        /// atStpの変更
        /// </summary>
        /// <param name="atStp">UTAUが自動調整したSTP</param>
        public void SetAtStp(float atStp)
        {
            if (HasAtStp()) { this.atStp.Set(atStp); }
            else
            {
                this.atStp = new Entry<float>(0);
                this.atStp.Set(atStp);
            }
        }

        /// <summary>
        /// atStpの取得
        /// </summary>
        /// <returns>atStp</returns>
        public float GetAtStp() => HasAtStp() ? atStp.Get() : DEFAULT_ATSTP;
        /// <summary>
        /// atStpが変更されたか
        /// </summary>
        /// <returns>変更済みであればtrue</returns>
        public Boolean AtStpIsChanged() => (HasAtStp() && atStp.IsChanged());
        /// <summary>
        /// atStpをこのノートが持っているか判定する。
        /// </summary>
        /// <returns>atStpの値を持っていればtrue</returns>
        public Boolean HasAtStp() => (atStp != null);
    }
}
