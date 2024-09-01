using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// atAliasの初期値
        /// </summary>
        private const string DEFAULT_ATALIAS = "";

        /// <summary>
        /// ataliasの初期化
        /// </summary>
        /// <param name="atAlias">UTAUが自動判定したエイリアス</param>
        public void InitAtAlias(string atAlias) => this.atAlias = new Entry<string>(atAlias);
        /// <summary>
        /// atAliasの変更
        /// </summary>
        /// <param name="atAlias">新しい<c>atAlias値</c></param>
        public void SetAtAlias(string atAlias)
        {
            if (HasAtAlias()) { this.atAlias.Set(atAlias); }
            else
            {
                this.atAlias = new Entry<string>("");
                this.atAlias.Set(atAlias);
            }
        }

        /// <summary>
        /// atAliasの取得
        /// </summary>
        /// <returns>atAlias</returns>
        public string GetAtAlias() => HasAtAlias() ? atAlias.Get() : DEFAULT_ATALIAS;
        /// <summary>
        /// atAliasが変更されたか
        /// </summary>
        /// <returns>変更済みであればtrue</returns>
        public Boolean AtAliasIsChanged() => (HasAtAlias() && atAlias.IsChanged());
        /// <summary>
        /// atAliasをこのノートが持っているか判定する。
        /// </summary>
        /// <returns>atAliasの値を持っていればtrue</returns>
        public Boolean HasAtAlias() => (atAlias != null);
    }
}
