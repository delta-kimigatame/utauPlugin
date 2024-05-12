using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UtauVoiceBank
{
    public partial class VoiceBank
    {
        /// <summary>
        /// 音源ルート以下のすべてのoto.iniを読み込む。
        /// </summary>
        /// <remarks>
        /// 2024年5月現在、本家UTAUは再帰読み込みを実施しない。
        /// </remarks>
        /// <param name="Recursive">孫フォルダ以降のoto.iniを探索するか否か</param>
        public void InputOtoAll(Boolean Recursive = false)
        {
            InputOto();
            SearchOto(Recursive);
        }

        /// <summary>
        /// 子フォルダ以降のoto.iniを読み込む。
        /// </summary>
        /// <remarks>
        /// 2024年5月現在、本家UTAUは再帰読み込みを実施しない。
        /// </remarks>
        /// <param name="Recursive">孫フォルダ以降のoto.iniを探索するか否か</param>
        /// <param name="subDirPath">再帰的に探索する場合、現在探索中のディレクトリ</param>
        private void SearchOto(Boolean Recursive,string subDirPath = "")
        {
            foreach (string fileName in Directory.GetDirectories(Path.Combine(DirPath,subDirPath)))
            {
                if (!File.Exists(Path.Combine(fileName, "oto.ini")))
                {
                    if (subDirPath == "" && Directory.GetDirectories(fileName).Length != 0)
                    {
                        SearchOto(Recursive, Path.Combine(subDirPath, Path.GetFileName(fileName)));
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    if (inputData != null)
                    {
                        inputData.Clear();
                    }
                    else
                    {
                        inputData = new List<string>();
                    }
                    inputData.AddRange(File.ReadAllLines(Path.Combine(fileName, "oto.ini"), Encoding.GetEncoding("Shift_JIS")));
                    ParseOto(oto, inputData, Path.Combine(subDirPath, Path.GetFileName(fileName)));
                    if(Directory.GetDirectories(fileName).Length != 0 && Recursive)
                    {
                        SearchOto(Recursive, Path.Combine(subDirPath, Path.GetFileName(fileName)));
                    }

                }
            }
        }

        /// <summary>
        /// <c>DirPatth</c>直下のotoファイルを読み込み<c>oto</c>に追加する。
        /// </summary>
        /// <remarks>
        /// <para>
        /// <c>oto</c>が存在しない場合空の辞書として作成され、その後oto.iniの読込を実行する。
        /// </para>
        /// <para>
        /// oto.iniが見つからない場合も空のotoは作成される。
        /// </para>
        /// </remarks>
        public void InputOto()
        {
            if( oto == null)
            {
                oto = new Dictionary<string, Oto>();
            }
            if (File.Exists(Path.Combine(DirPath, "oto.ini")))
            {
                inputData = new List<string>();
                inputData.AddRange(File.ReadAllLines(Path.Combine(DirPath, "oto.ini"), Encoding.GetEncoding("Shift_JIS")));
                ParseOto(oto, inputData);
            }
        }
        /// <summary>
        /// <c>inputData</c>をパースして<c>oto</c>に<see cref="Oto">Oto</see>を追加する。
        /// </summary>
        /// <remarks>
        /// <c>inputData</c>に特に記載が無くても、wavファイル名と同名のエイリアスが設定されることに注意する。
        /// </remarks>
        /// <param name="oto">更新する原音設定の辞書</param>
        /// <param name="inputData">oto.iniのデータが1行毎に格納されたList</param>
        /// <param name="subDirPath">音源ルートからoto.iniがあるフォルダまでの相対パス</param>
        public void ParseOto(Dictionary<string, Oto> oto, List<string> inputData,string subDirPath ="")
        {
            foreach (string x in inputData)
            {
                if(!x.Contains("="))
                {
                    continue;
                }
                string[] tmp = x.Split('=');
                string[] splitData = tmp[1].Split(',');
                //ファイル名でエイリアス追加
                AddOto(oto, Path.Combine(subDirPath,tmp[0].Replace(".wav","")), subDirPath, tmp[0], splitData);
                //エイリアスがあればエイリアス通り追加
                if (splitData[0] != "")
                {
                    AddOto(oto, splitData[0], subDirPath, tmp[0], splitData);
                }

            }
        }

        /// <summary>
        /// <c>oto</c>に新しい<c>Oto</c>を追加する。
        /// </summary>
        /// <remarks>
        /// <para>
        /// <c>alias</c>がすでに<c>oto</c>のキーとして使用されている場合、何もしない。
        /// </para>
        /// <para>
        /// <c>splitData[1]～splitData[5]</c>がそれぞれfloatに変換できない場合、各値は0として扱う。
        /// </para>
        /// </remarks>
        /// <param name="oto">更新する原音設定の辞書</param>
        /// <param name="alias">エイリアス、otoのキーになる。</param>
        /// <param name="subDirPath">音源ルートからoto.iniがあるフォルダまでの相対パス</param>
        /// <param name="fileName">oto.iniからwaveファイルまでの相対パス</param>
        /// <param name="splitData">
        /// oto.iniから読み込んだパラメータ
        /// <para>
        /// <term>splitData[0]</term>エイリアス
        /// </para>
        /// <para>
        /// <term>splitData[1]</term>オフセット
        /// </para>
        /// <para>
        /// <term>splitData[2]</term>先行発声
        /// </para>
        /// <para>
        /// <term>splitData[3]</term>オーバーラップ
        /// </para>
        /// <para>
        /// <term>splitData[4]</term>子音部
        /// </para>
        /// <para>
        /// <term>splitData[5]</term>ブランク
        /// </para></param>
        private void AddOto(Dictionary<string, Oto> oto,string alias,string subDirPath,string fileName,string[] splitData)
        {
            if (oto.ContainsKey(alias))
            {
                return;
            }
            oto.Add(alias, new Oto());
            oto[alias].DirPath = subDirPath;
            oto[alias].FileName = fileName;
            oto[alias].Alias = alias;
            try
            {
                oto[alias].Offset = float.Parse(splitData[1]);
            }
            catch
            {
                oto[alias].Offset = 0f;
            }
            try
            {
                oto[alias].Vel = float.Parse(splitData[2]);
            }
            catch
            {
                oto[alias].Vel = 0f;
            }
            try
            {
                oto[alias].Blank = float.Parse(splitData[3]);
            }
            catch
            {
                oto[alias].Blank = 0f;
            }
            try
            {
                oto[alias].Pre = float.Parse(splitData[4]);
            }
            catch
            {
                oto[alias].Pre = 0f;
            }
            try
            {
                oto[alias].Ove = float.Parse(splitData[5]);
            }
            catch
            {
                oto[alias].Ove = 0f;
            }

        }

    }

    /// <summary>
    /// 原音設定データ1レコードを扱うクラス
    /// </summary>
    public class Oto
    {
        /// <summary>
        /// 音源ルートからの相対パス
        /// </summary>
        private string dirPath;
        /// <summary>
        /// oto.iniから見たwaveファイルの相対パス
        /// </summary>
        private string fileName;
        /// <summary>
        /// エイリアス
        /// </summary>
        private string alias;
        /// <summary>
        /// オフセット
        /// </summary>
        /// <remarks>
        /// setParamでは左ブランク
        /// </remarks>
        private float offset;
        /// <summary>
        /// 先行発声
        /// </summary>
        private float pre;
        /// <summary>
        /// オーバーラップ
        /// </summary>
        private float ove;
        /// <summary>
        /// 子音部
        /// </summary>
        /// <remarks>
        /// setParamでは固定範囲
        /// </remarks>
        private float vel;
        /// <summary>
        /// ブランク、右ブランク
        /// </summary>
        /// <remarks>
        /// setParamでは右ブランク
        /// </remarks>
        private float blank;
        /// <summary>
        /// wavファイルの長さ
        /// </summary>
        private int wavLength;
        /// <summary>
        /// 既にwavファイルの長さを計算済みか否かの判定
        /// </summary>
        /// <remarks>
        /// waveファイルの長さはoto.iniに記録されておらず、waveファイルのバイナリ読み込みが必要なため、
        /// 一度読み込んだ場合フラグを立てて、2回目以降参照する際は記録している値を使用する。
        /// </remarks>
        private Boolean hasWavLength;

        /// <summary>
        /// oto.iniから見たwaveファイルの相対パス
        /// </summary>
        public string DirPath { get => dirPath; set => dirPath = value; }
        /// <summary>
        /// エイリアス
        /// </summary>
        public string FileName { get => fileName; set => fileName = value; }
        /// <summary>
        /// エイリアス
        /// </summary>
        public string Alias { get => alias; set => alias = value; }
        /// <summary>
        /// オフセット
        /// </summary>
        /// <remarks>
        /// setParamでは左ブランク
        /// </remarks>
        public float Offset { get => offset; set => offset = value; }
        /// <summary>
        /// 先行発声
        /// </summary>
        public float Pre { get => pre; set => pre = value; }
        /// <summary>
        /// オーバーラップ
        /// </summary>
        public float Ove { get => ove; set => ove = value; }
        /// <summary>
        /// 子音部
        /// </summary>
        /// <remarks>
        /// setParamでは固定範囲
        /// </remarks>
        public float Vel { get => vel; set => vel = value; }
        /// <summary>
        /// ブランク、右ブランク
        /// </summary>
        /// <remarks>
        /// setParamでは右ブランク
        /// </remarks>
        public float Blank { get => blank; set => blank = value; }
        /// <summary>
        /// wavファイルの長さ
        /// </summary>
        public int WavLength { get => wavLength; set => wavLength = value; }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <value>
        /// 各値は以下の通り初期化される。
        /// <list type="bullet">
        /// <item>
        /// <term>dirPath</term>""
        /// </item>
        /// <item>
        /// <term>fileName</term>""
        /// </item>
        /// <item>
        /// <term>alias</term>""
        /// </item>
        /// <item>
        /// <term>offset</term>0
        /// </item>
        /// <item>
        /// <term>pre</term>0
        /// </item>
        /// <item>
        /// <term>ove</term>0
        /// </item>
        /// <item>
        /// <term>vel</term>0
        /// </item>
        /// <item>
        /// <term>blank</term>0
        /// </item>
        /// </list>
        /// </value>
        public Oto()
        {
            DirPath = "";
            FileName = "";
            Alias = "";
            Offset = 0;
            Pre = 0;
            Ove = 0;
            Vel = 0;
            Blank = 0;
            hasWavLength = false;
        }

        /// <summary>
        /// 初期値付きの初期化
        /// </summary>
        /// <param name="dirPath">音源ルートからの相対パス</param>
        /// <param name="fileName">oto.iniから見たwaveファイルの相対パス</param>
        /// <param name="alias">エイリアス</param>
        /// <param name="offset">オフセット(setParamでは左ブランク)</param>
        /// <param name="pre">先行発声</param>
        /// <param name="ove">オーバーラップ</param>
        /// <param name="vel">子音部(setParamでは固定範囲)</param>
        /// <param name="blank">ブランク(setParamでは右ブランク)</param>
        public Oto(string dirPath,string fileName,string alias,float offset,float pre, float ove,float vel,float blank)
        {
            DirPath = dirPath;
            FileName = fileName;
            Alias = alias;
            Offset = offset;
            Pre = pre;
            Ove = ove;
            Vel = vel;
            Blank = blank;
            hasWavLength = false;
        }

        /// <summary>
        /// waveファイルの長さをms単位で取得し返す。
        /// </summary>
        /// <remarks>
        /// waveファイルの長さをms単位で取得し返す。
        /// 既に実行している場合、保存している値を返す。
        /// </remarks>
        /// <returns>
        /// waveファイルの長さ(ms)
        /// </returns>
        public int GetWavLength()
        {
            if (!hasWavLength)
            {
                Wave.Wave wav = new Wave.Wave(Path.Combine(dirPath, fileName));
                wav.Read();
                WavLength = wav.PlayTime;
                hasWavLength = true;
            }
            return WavLength;
        }

        /// <summary>
        /// ブランクの形式を変換する。
        /// </summary>
        /// <remarks>
        /// <para>
        /// UTAUのブランクには、waveファイル末尾からの時間(ms)を格納する正のブランクと
        /// 先行発声からの時間(ms)を格納する負のブランクがある。
        /// </para>
        /// <para>
        /// このメソッドでは、ブランクの形式の正負を変換する。
        /// </para>
        /// </remarks>
        public float GetInverseBlank()
        {
            if(Blank<0) { return GetWavLength() - Offset + Blank; }
            else { return Blank - GetWavLength() + Offset; }
        }
    }
}
