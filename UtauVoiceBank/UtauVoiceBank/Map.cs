using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UtauVoiceBank
{
    public partial class VoiceBank
    {

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
        //飴屋Pのツイートから予想される仕様ですが，2019/01/05現在UTAU本体未対応です．
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


    public class MapValue
    {
        private string pre;
        private string su;
        public MapValue() { }
        public string Pre { get => pre; set => pre = value; }
        public string Su { get => su; set => su = value; }
    }

}
