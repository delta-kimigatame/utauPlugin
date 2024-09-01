using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// flagsの初期値
        /// </summary>
        private const string DEFAULT_FLAGS = "";
        /// <summary>
        /// flagsの初期化
        /// </summary>
        /// <param name="flags"></param>
        public void InitFlags(string flags) => this.flags = new Entry<string>(flags);
        /// <summary>
        /// flagsの変更
        /// </summary>
        /// <param name="flags"></param>
        public void SetFlags(string flags)
        {
            if (HasFlags()) { this.flags.Set(flags); }
            else
            {
                this.flags = new Entry<string>("");
                this.flags.Set(flags);
            }
        }

        /// <summary>
        /// flagsの取得
        /// </summary>
        /// <returns></returns>
        public string GetFlags() => HasFlags() ? flags.Get() : DEFAULT_FLAGS;
        /// <summary>
        /// flagsが変更済みであればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean FlagsIsChanged() => (HasFlags() && flags.IsChanged());
        /// <summary>
        /// flags値を持っていればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasFlags() => (flags != null);
    }
}
