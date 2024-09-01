using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// atPreの初期値
        /// </summary>
        private const float DEFAULT_ATPRE = 0f;

        /// <summary>
        /// atpreの初期化
        /// </summary>
        /// <param name="atPre">UTAUが自動調整した先行発声、floatに変換可能な文字列</param>

        public void InitAtPre(string atPre) => this.atPre = new Entry<float>(float.Parse(atPre));
        /// <summary>
        /// atpreの初期化
        /// </summary>
        /// <param name="atPre">UTAUが自動調整した先行発声</param>
        public void InitAtPre(float atPre) => this.atPre = new Entry<float>(atPre);
        /// <summary>
        /// atpreの変更
        /// </summary>
        /// <param name="atPre">UTAUが自動調整したオーバーラップ、floatに変換可能な文字列</param>
        public void SetAtPre(string atPre)
        {
            if (HasAtPre()) { this.atPre.Set(float.Parse(atPre)); }
            else
            {
                this.atPre = new Entry<float>(0);
                this.atPre.Set(float.Parse(atPre));
            }
        }
        /// <summary>
        /// atpreの変更
        /// </summary>
        /// <param name="atPre">UTAUが自動調整したオーバーラップ</param>
        public void SetAtPre(float atPre)
        {
            if (HasAtPre()) { this.atPre.Set(atPre); }
            else
            {
                this.atPre = new Entry<float>(0);
                this.atPre.Set(atPre);
            }
        }

        /// <summary>
        /// atPreの取得
        /// </summary>
        /// <returns>atove</returns>
        public float GetAtPre() => HasAtPre() ? atPre.Get() : DEFAULT_ATPRE;
        /// <summary>
        /// atpreが変更されたか
        /// </summary>
        /// <returns>変更済みであればtrue</returns>
        public Boolean AtPreIsChanged() => (HasAtPre() && atPre.IsChanged());
        /// <summary>
        /// atPreをこのノートが持っているか判定する。
        /// </summary>
        /// <returns>atPreの値を持っていればtrue</returns>
        public Boolean HasAtPre() => (atPre != null);
    }
}
