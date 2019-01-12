using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtauVoiceBank
{
    public partial class VoiceBank
    {
        private string dirPath;
        public Dictionary<string,Oto> oto;
        public Dictionary<string, MapValue> prefixMap;
        public Dictionary<string, Dictionary<string, MapValue>> prefixMaps;
        List<string> inputData;

        public string DirPath { get => dirPath; set => dirPath = value; }

        public VoiceBank(string dirPath)
        {
            DirPath = dirPath;
            oto = new Dictionary<string, Oto>();
            prefixMap = new Dictionary<string, MapValue>();
            prefixMaps = new Dictionary<string, Dictionary<string, MapValue>>();
        }
        public VoiceBank()
        {
            DirPath = "";
            prefixMap = new Dictionary<string, MapValue>();
            prefixMaps = new Dictionary<string, Dictionary<string, MapValue>>();
        }
    }
}
