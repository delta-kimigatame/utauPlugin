using System;
namespace UtauPlugin
{
    public partial class Note
    {
        private const string DEFAULT_LYRIC = "";
        public void InitLyric(string lyric) => this.lyric = new Entry<string>(lyric);
        public void SetLyric(string lyric) => this.lyric.Set(lyric);
        public string GetLyric() => lyric.Get();
        public Boolean LyricIsChanged() => lyric.IsChanged();
    }
}
