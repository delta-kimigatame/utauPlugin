using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// atOveの初期値
        /// </summary>
        private const float DEFAULT_ATOVE = 0f;

        /// <summary>
        /// atoveの初期化
        /// </summary>
        /// <param name="atOve">UTAUが自動調整したオーバーラップ、floatに変換可能な文字列</param>
        public void InitAtOve(string atOve) => this.atOve = new Entry<float>(float.Parse(atOve));
        /// <summary>
        /// atoveの初期化
        /// </summary>
        /// <param name="atOve">UTAUが自動調整したオーバーラップ</param>
        public void InitAtOve(float atOve) => this.atOve = new Entry<float>(atOve);
        /// <summary>
        /// atoveの変更
        /// </summary>
        /// <param name="atOve">UTAUが自動調整したオーバーラップ、floatに変換可能な文字列</param>
        public void SetAtOve(string atOve)
        {
            if (HasAtOve()) { this.atOve.Set(float.Parse(atOve)); }
            else
            {
                this.atOve = new Entry<float>(0);
                this.atOve.Set(float.Parse(atOve));
            }
        }
        /// <summary>
        /// atoveの変更
        /// </summary>
        /// <param name="atOve">UTAUが自動調整したオーバーラップ</param>
        public void SetAtOve(float atOve)
        {
            if (HasAtOve()) { this.atOve.Set(atOve); }
            else
            {
                this.atOve = new Entry<float>(0);
                this.atOve.Set(atOve);
            }
        }
        /// <summary>
        /// atoveの取得
        /// </summary>
        /// <returns>atove</returns>
        public float GetAtOve() => HasAtOve() ? atOve.Get() : DEFAULT_ATOVE;
        /// <summary>
        /// atoveが変更されたか
        /// </summary>
        /// <returns>変更済みであればtrue</returns>
        public Boolean AtOveIsChanged() => (HasAtOve() && atOve.IsChanged());
        /// <summary>
        /// atOveをこのノートが持っているか判定する。
        /// </summary>
        /// <returns>atOveの値を持っていればtrue</returns>
        public Boolean HasAtOve() => (atOve != null);
    }
}
