using System;
namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// pbtypeの初期値
        /// </summary>
        private const string DEFAULT_PBTYPE = "5";
        /// <summary>
        /// pbtypeの初期化
        /// </summary>
        /// <param name="pbType"></param>
        public void InitPbType(string pbType) => this.pbType = new Entry<string>(pbType);
        /// <summary>
        /// pbtypeの変更
        /// </summary>
        /// <param name="pbType"></param>
        public void SetPbType(string pbType)
        {
            if (HasPbType()) { this.pbType.Set(pbType); }

            else
            {
                this.pbType = new Entry<string>("");
                this.pbType.Set(pbType);
            }
        }

        /// <summary>
        /// pbtypeの取得
        /// </summary>
        /// <returns></returns>
        public string GetPbType() => HasPbType() ? pbType.Get() : DEFAULT_PBTYPE;
        /// <summary>
        /// pbtypeが変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean PbTypeIsChanged() => (HasPbType() && pbType.IsChanged());
        /// <summary>
        /// pbtypeの値を持っていればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasPbType() => (pbType != null);
    }
}

