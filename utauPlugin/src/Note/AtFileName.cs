using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// atFileNameの初期値
        /// </summary>
        private const string DEFAULT_ATFILENAME = "";
        /// <summary>
        /// atFileNameの初期化
        /// </summary>
        /// <param name="atFileName">UTAUが自動判定したファイル名</param>
        public void InitAtFileName(string atFileName) => this.atFileName = new Entry<string>(atFileName);
        /// <summary>
        /// atFileNameの変更
        /// </summary>
        /// <param name="atFileName">UTAUが自動判定したファイル名</param>
        public void SetAtFileName(string atFileName)
        {
            if (HasAtFileName()) { this.atFileName.Set(atFileName); }
            else
            {
                this.atFileName = new Entry<string>("");
                this.atFileName.Set(atFileName);
            }
        }

        /// <summary>
        /// atFileNameの取得
        /// </summary>
        /// <returns>atFileName</returns>
        public string GetAtFileName() => HasAtFileName() ? atFileName.Get() : DEFAULT_ATFILENAME;
        /// <summary>
        /// atFileNameが変更されたか
        /// </summary>
        /// <returns>変更済みであればtrue</returns>
        public Boolean AtFileNameIsChanged() => (HasAtFileName() && atFileName.IsChanged());
        /// <summary>
        /// atFileNameをこのノートが持っているか判定する。
        /// </summary>
        /// <returns>atFileNameの値を持っていればtrue</returns>
        public Boolean HasAtFileName() => (atFileName != null);
    }
}
