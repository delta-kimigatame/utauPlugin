namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// ノート番号の初期値
        /// </summary>
        private const string DEFAULT_NUM = "";
        /// <summary>
        /// ノート番号の初期化
        /// </summary>
        /// <param name="num"></param>
        public void InitNum(string num) => this.num = new Entry<string>(num);
        /// <summary>
        /// ノート番号の変更
        /// </summary>
        /// <param name="num"></param>
        public void SetNum(string num) => this.num.Set(num);
        /// <summary>
        /// ノート番号の取得
        /// </summary>
        /// <returns></returns>
        public string GetNum() => num.Get();
    }
}
