using System;
namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// 歌詞の初期値
        /// </summary>
        private const string DEFAULT_LYRIC = "";
        /// <summary>
        /// 歌詞の初期化
        /// </summary>
        /// <param name="lyric"></param>
        public void InitLyric(string lyric) => this.lyric = new Entry<string>(lyric);
        /// <summary>
        /// 歌詞の変更
        /// </summary>
        /// <param name="lyric"></param>
        public void SetLyric(string lyric) => this.lyric.Set(lyric);
        /// <summary>
        /// 歌詞の取得
        /// </summary>
        /// <returns></returns>
        public string GetLyric() => lyric.Get();
        /// <summary>
        /// 歌詞を変更していればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean LyricIsChanged() => lyric.IsChanged();
    }
}
