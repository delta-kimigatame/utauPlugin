using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtauVoiceBank;

namespace utauPlugin
{
    public partial class Note
    {
        public void InitAlias()
        {
            alias = new AliasData();
        }
        public void InitAlias(string atAlias)
        {
            alias = new AliasData(atAlias);
        }
        public void InitAlias(string lyric, string noteNum, Dictionary<string, MapValue> map)
        {
            alias = new AliasData(lyric,noteNum,map);
        }
        public void SetAlias(string atAlias) => alias.SetAliasFromAtAlias(atAlias);
        public void SetAlias(string lyric, string noteNum, Dictionary<string, MapValue> map) => alias.SetAliasFromLyric(lyric, noteNum, map);
        public string GetAlias() => alias.Alias;
        public Boolean HasAlias() => (alias != null);


        public class AliasData
        {
            private string alias;
            public AliasData()
            {
                Alias = "";
            }
            public AliasData(string atAlias)
            {
                Alias = atAlias;
            }
            public AliasData(string lyric, string noteNum, Dictionary<string, MapValue> map)
            {
                Alias = map[noteNum].Pre + lyric + map[noteNum].Su;
            }

            public void SetAliasFromAtAlias(string atAlias)
            {
                Alias = atAlias;
            }

            public void SetAliasFromLyric(string lyric,string noteNum,Dictionary<string,MapValue> map)
            {
                Alias = map[noteNum].Pre + lyric + map[noteNum].Su;
            }

            public string Alias { get => alias; set => alias = value; }
        }

    }
}
