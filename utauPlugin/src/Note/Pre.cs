using System;

namespace UtauPlugin
{

    public partial class Note
    {
        /// <summary>
        /// 先行発声の初期値
        /// </summary>
        private const float DEFAULT_PRE = 0f;
        /// <summary>
        /// 先行発声の初期化
        /// </summary>
        /// <param name="pre">floatに変更可能な文字列。""の場合0として扱う</param>
        public void InitPre(string pre) => this.pre = new Pre(pre);
        /// <summary>
        /// 先行発声の初期化
        /// </summary>
        /// <param name="pre"></param>
        public void InitPre(float pre) => this.pre = new Pre(pre);
        /// <summary>
        /// 先行発声の変更
        /// </summary>
        /// <param name="pre">floatに変更可能な文字列。""の場合0として扱う</param>
        public void SetPre(string pre) => this.pre.Set(pre);
        /// <summary>
        /// 先行発声の変更
        /// </summary>
        /// <param name="pre"></param>
        public void SetPre(float pre) => this.pre.Set(pre);
        /// <summary>
        /// 先行発声値の取得
        /// </summary>
        /// <returns></returns>
        public float GetPre() => pre.Get();
        /// <summary>
        /// 先行発声値が変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean PreIsChanged() => pre.IsChanged();
        /// <summary>
        /// 先行発声値を持っていればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean PreHasValue() => pre.HasValue();
        /// <summary>
        /// 先行発声値
        /// </summary>
        private class Pre
        {
            /// <summary>
            /// 先行発声値
            /// </summary>
            private float pre;
            /// <summary>
            /// 値を持っているか
            /// </summary>
            private Boolean hasValue;
            /// <summary>
            /// 変更済みか
            /// </summary>
            private Boolean isChanged;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="pre">floatに変更可能な文字列。""の場合0として扱う</param>
            public Pre(string pre)
            {
                if (pre == "")
                {
                    this.pre = 0.0f;
                    isChanged = false;
                    hasValue = false;
                }
                else
                {
                    this.pre = float.Parse(pre);
                    isChanged = false;
                    hasValue = true;
                }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="pre"></param>
            public Pre(int pre)
            {
                this.pre = (float)pre;
                hasValue = true;
                isChanged = false;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="pre"></param>
            public Pre(float pre)
            {
                this.pre = pre;
                hasValue = true;
                isChanged = false;
            }
            /// <summary>
            /// 先行発声値の変更
            /// </summary>
            /// <param name="pre">floatに変更可能な文字列。""の場合0として扱う</param>
            public void Set(string pre) { this.pre = float.Parse(pre); isChanged = true; hasValue = true; }
            /// <summary>
            /// 先行発声値の変更
            /// </summary>
            /// <param name="pre"></param>
            public void Set(int pre) { this.pre = pre; isChanged = true; hasValue = true; }
            /// <summary>
            /// 先行発声値の変更
            /// </summary>
            /// <param name="pre"></param>
            public void Set(float pre) { this.pre = pre; isChanged = true; hasValue = true; }
            /// <summary>
            /// 先行発声値の取得
            /// </summary>
            /// <returns></returns>
            public float Get() => pre;
            /// <summary>
            /// 先行発声値を変更済みならtrue
            /// </summary>
            /// <returns></returns>
            public Boolean IsChanged() => isChanged;
            /// <summary>
            /// 先行発声値を持っていればtrue
            /// </summary>
            /// <remarks>""で初期化した場合はfalse</remarks>
            /// <returns></returns>
            public Boolean HasValue() => hasValue;
        }

    }
}
