using System.Collections.Generic;

namespace UtauVoiceBank
{
    /// <summary>
    /// UTAU音源に関連するデータを扱う。
    /// </summary>
    public partial class VoiceBank
    {
        /// <summary>
        /// 音源ルートの絶対パス
        /// </summary>
        private string dirPath;
        /// <summary>
        /// oto.iniのデータを扱う、エイリアスをキーとする<see cref="Oto">Oto</see>型の辞書
        /// </summary>
        public Dictionary<string,Oto> oto;
        /// <summary>
        /// prefix.mapのデータを扱う、音高をNoteNumのルールに従って整数化したものをキーとする<see cref="MapValue">MapValue</see>型の辞書
        /// </summary>
        public Dictionary<string, MapValue> prefixMap;
        /// <summary>
        /// UTAU本体がmultiprefix.mapに対応した場合にprefix.mapを扱うための辞書。
        /// </summary>
        /// <remarks>
        /// 第一キーを表情名、第二キーが音高をNoteNumのルールに従って整数化したものとする<see cref="MapValue">MapValue</see>型の辞書
        /// </remarks>
        public Dictionary<string, Dictionary<string, MapValue>> prefixMaps;
        List<string> inputData;

        /// <summary>
        /// 音源ルートの絶対パス
        /// </summary>
        public string DirPath { get => dirPath; set => dirPath = value; }

        /// <summary>
        /// 初期化、otoとprefixMapは現時点では読み込まれない。
        /// </summary>
        /// <param name="dirPath">音源ルートの絶対パス</param>
        public VoiceBank(string dirPath)
        {
            DirPath = dirPath;
            oto = new Dictionary<string, Oto>();
            prefixMap = new Dictionary<string, MapValue>();
            prefixMaps = new Dictionary<string, Dictionary<string, MapValue>>();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <remarks>
        /// <see cref="InputPrefixMap">InputPrefixMap</see>もしくは<see cref="InputOtoAll">InputOtoAll</see>を実行するまでに<c>dirPath</c>の定義が必要。
        /// </remarks>
        public VoiceBank()
        {
            DirPath = "";
            prefixMap = new Dictionary<string, MapValue>();
            prefixMaps = new Dictionary<string, Dictionary<string, MapValue>>();
        }
    }
}
