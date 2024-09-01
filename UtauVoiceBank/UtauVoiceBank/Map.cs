using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UtauVoiceBank
{
    public partial class VoiceBank
    {
        /// <summary>
        /// 音源ルートフォルダにあるprefix.mapを読み込む。
        /// </summary>
        /// <remarks>
        /// 存在しない場合、空のprefix.mapを読み込んだものとして初期化する。
        /// </remarks>
        public void InputPrefixMap()
        {
            if (!File.Exists(Path.Combine(DirPath, "prefix.map")))
            {
                MakeDefaultPrefixMap();
            }
            else
            {
                inputData = new List<string>();
                inputData.AddRange(File.ReadAllLines(Path.Combine(DirPath, "prefix.map"), Encoding.GetEncoding("Shift_JIS")));
                ParsePrefixMap(prefixMap, inputData);
            }

        }

        /// <summary>
        /// 子フォルダ内にあるprefix.mapをすべて読み込む。
        /// </summary>
        /// <remarks>
        /// 飴屋Pのツイートから予想される仕様ですが、2024/05/12現在UTAU本体未対応です。
        /// </remarks>
        public void InputPrefixMapsAll()
        {
            InputPrefixMap();
            inputData = new List<string>();
            prefixMaps.Add("",prefixMap);
            foreach (string fileName in Directory.GetDirectories(DirPath))
            {
                if (!File.Exists(Path.Combine(fileName, "prefix.map"))){
                    continue;
                }
                else
                {
                    prefixMaps.Add(Path.GetFileName(fileName), new Dictionary<string, MapValue>());
                    inputData.Clear();
                    inputData.AddRange(File.ReadAllLines(Path.Combine(fileName, "prefix.map"), Encoding.GetEncoding("Shift_JIS")));
                    ParsePrefixMap(prefixMaps[Path.GetFileName(fileName)], inputData);
                }
            }
        }

        /// <summary>
        /// <c>inputData</c>をパースして<c>prefixMap</c>に<see cref="MapValue">MapValue</see>を追加する。
        /// </summary>
        /// <param name="prefixMap">更新する辞書データ</param>
        /// <param name="inputData">prefix.mapのデータが1行毎に格納されたList</param>
        private void ParsePrefixMap(Dictionary<string, MapValue> prefixMap, List<string> inputData)
        {
            foreach (string line in inputData)
            {
                string[] splitData = line.Split('\t');
                prefixMap.Add(splitData[0], new MapValue());
                prefixMap[splitData[0]].Pre = splitData[1];
                prefixMap[splitData[0]].Su = splitData[2];
            }
        }

        /// <summary>
        /// 空のprefix.mapを作成する。
        /// </summary>
        /// <remarks>
        /// 24(C1)～107(B7)のキーをもつ、<see cref="MapValue">MapValue</see>型の辞書
        /// </remarks>
        private void MakeDefaultPrefixMap()
        {
            string[] NOTE_NUM_NAME = new string[12] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            string key;
            //C1が24,B7が107
            for (int i = 24; i <= 107; i++)
            {
                key = NOTE_NUM_NAME[i % 12] + ((i - 12) / 12).ToString();
                prefixMap.Add(key, new MapValue());
            }
        }
    }

    /// <summary>
    /// prefix.mapの1レコード当たりのデータを扱う。
    /// </summary>
    public class MapValue
    {
        /// <summary>
        /// エイリアスの前方に補完する値。prefix
        /// </summary>
        private string pre;
        /// <summary>
        /// エイリアスの後方に補完する値。suffix
        /// </summary>
        private string su;
        public MapValue() { }
        /// <summary>
        /// エイリアスの前方に補完する値。prefix
        /// </summary>
        public string Pre { get => pre; set => pre = value; }
        /// <summary>
        /// エイリアスの後方に補完する値。suffix
        /// </summary>
        public string Su { get => su; set => su = value; }
    }

}
