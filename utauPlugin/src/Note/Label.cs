using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// ラベルの初期値
        /// </summary>
        private const string DEFAULT_LABEL = "";
        /// <summary>
        /// ラベルの初期化
        /// </summary>
        /// <param name="label"></param>
        public void InitLabel(string label) => this.label = new Entry<string>(label);
        /// <summary>
        /// ラベルの変更
        /// </summary>
        /// <param name="label"></param>
        public void SetLabel(string label)
        {
            if (HasLabel()) { this.label.Set(label); }
            else
            {
                this.label = new Entry<string>("");
                this.label.Set(label);
            }
        }
        /// <summary>
        /// ラベルの取得
        /// </summary>
        /// <returns></returns>
        public string GetLabel() => HasLabel() ? label.Get() : DEFAULT_LABEL;
        /// <summary>
        /// ラベルが変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean LabelIsChanged() => (HasLabel() && label.IsChanged());
        /// <summary>
        /// ラベルの値を持っていればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasLabel() => (label != null);
    }
}
