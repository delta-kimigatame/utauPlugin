using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// ノート長の初期値
        /// </summary>
        private const int DEFAULT_LENGTH = 480;
        /// <summary>
        /// ノート長の初期化。
        /// </summary>
        /// <param name="length">intに変換可能な文字列</param>
        public void InitLength(string length) => this.length = new Entry<int>(int.Parse(length));
        /// <summary>
        /// ノート長の初期化
        /// </summary>
        /// <param name="length"></param>
        public void InitLength(int length) => this.length = new Entry<int>(length);
        /// <summary>
        /// ノート長の変更
        /// </summary>
        /// <param name="length">intに変換可能な文字列</param>
        public void SetLength(string length) => this.length.Set(int.Parse(length));
        /// <summary>
        /// ノート長の変更
        /// </summary>
        /// <param name="length"></param>
        public void SetLength(int length) => this.length.Set(length);
        /// <summary>
        /// ノート長の取得
        /// </summary>
        /// <returns></returns>
        public int GetLength() => length.Get();
        /// <summary>
        /// ノート長が変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean LengthIsChanged() => length.IsChanged();
        /// ノート長は常に値を持つため、HasLengthはサポートしない
    }
}
