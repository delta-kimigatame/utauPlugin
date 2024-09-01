using System;
using System.Collections.Generic;
using UtauVoiceBank;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// エイリアスを空で初期化する。
        /// </summary>
        public void InitAlias()
        {
            alias = new AliasData();
        }
        /// <summary>
        /// @aliasの値を使ってエイリアスを初期化する。
        /// </summary>
        /// <param name="atAlias">UTAUが判定したエイリアス</param>
        public void InitAlias(string atAlias)
        {
            alias = new AliasData(atAlias);
        }
        /// <summary>
        /// 各パラメータからエイリアスを初期化する。
        /// </summary>
        /// <param name="lyric">歌詞</param>
        /// <param name="noteNum">音階</param>
        /// <param name="map">prefix.map</param>
        public void InitAlias(string lyric, string noteNum, Dictionary<string, MapValue> map)
        {
            alias = new AliasData(lyric,noteNum,map);
        }
        /// <summary>
        /// エイリアスをセットする
        /// </summary>
        /// <param name="atAlias">UTAUが判定したエイリアス</param>
        public void SetAlias(string atAlias) => alias.SetAliasFromAtAlias(atAlias);
        /// <summary>
        /// 各パラメータからエイリアスをセットする
        /// </summary>
        /// <param name="lyric">歌詞</param>
        /// <param name="noteNum">音階</param>
        /// <param name="map">prefix.map</param>
        public void SetAlias(string lyric, string noteNum, Dictionary<string, MapValue> map) => alias.SetAliasFromLyric(lyric, noteNum, map);
        /// <summary>
        /// エイリアスを取得する
        /// </summary>
        /// <returns>エイリアス</returns>
        public string GetAlias() => alias.Alias;
        /// <summary>
        /// エイリアスをこのノートが持っているか判定する。
        /// </summary>
        /// <returns>エイリアスの値を持っていればtrue</returns>
        public Boolean HasAlias() => (alias != null);

        /// <summary>
        /// エイリアスのデータを扱う
        /// </summary>
        public class AliasData
        {
            /// <summary>
            /// エイリアス
            /// </summary>
            private string alias;
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <remarks>空の値で初期化する</remarks>
            public AliasData()
            {
                Alias = "";
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="atAlias">UTAUが判定したエイリアス</param>
            public AliasData(string atAlias)
            {
                Alias = atAlias;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="lyric">歌詞</param>
            /// <param name="noteNum">音階</param>
            /// <param name="map">prefix.map</param>
            public AliasData(string lyric, string noteNum, Dictionary<string, MapValue> map)
            {
                Alias = map[noteNum].Pre + lyric + map[noteNum].Su;
            }

            /// <summary>
            /// エイリアスをセットする
            /// </summary>
            /// <param name="atAlias">UTAUが判定したエイリアス</param>
            public void SetAliasFromAtAlias(string atAlias)
            {
                Alias = atAlias;
            }

            /// <summary>
            /// 各パラメータからエイリアスをセットする
            /// </summary>
            /// <param name="lyric">歌詞</param>
            /// <param name="noteNum">音階</param>
            /// <param name="map">prefix.map</param>
            public void SetAliasFromLyric(string lyric,string noteNum,Dictionary<string,MapValue> map)
            {
                Alias = map[noteNum].Pre + lyric + map[noteNum].Su;
            }

            /// <summary>
            /// エイリアス
            /// </summary>
            public string Alias { get => alias; set => alias = value; }
        }

    }
}
