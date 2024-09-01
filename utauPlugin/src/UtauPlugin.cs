using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UtauVoiceBank;

namespace UtauPlugin
{
    /// <summary>
    /// UtauPluginの読み書きを扱う
    /// </summary>
    public partial class UtauPlugin : Ust
    {
        /// <summary>
        /// 行毎に読み込んだ入力データ
        /// </summary>
        public List<String> UstData { get; private set; }
        /// <summary>
        /// UTAU音源
        /// </summary>
        public VoiceBank vb;
        /// <summary>
        /// 出力データを行毎に格納する
        /// </summary>
        private List<String> writeData;
        /// <summary>
        /// ループカウンタ
        /// </summary>
        private int i;
        /// <summary>
        /// 現在のBPM
        /// </summary>
        private float nowTempo;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UtauPlugin() { InitEntries(); }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filePath">Utauプラグインのtmpファイルのパス</param>
        public UtauPlugin(string filePath) : base(filePath) { InitEntries(); }

        /// <summary>
        /// Utauプラグインのtmpファイルを読み込む。
        /// </summary>
        /// <param name="autoLogOutputAndExit">読み込みエラー時の挙動。trueの場合ログファイルを出力し、falseの場合エラーを送出する。</param>
        public void Input(bool autoLogOutputAndExit = true)
        {
            try
            {
                Console.WriteLine(Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.ANSICodePage).WebName);
                //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                //ustData.AddRange(File.ReadAllLines(FilePath, Encoding.GetEncoding("Shift_JIS")));
                GetUstData();
                AnalyzeHeader();
                note = new List<Note>();
                AnalyzeNotes();
            }
            catch (Exception ex)
            {
                if (autoLogOutputAndExit)
                {
                    try
                    {
                        File.WriteAllText(".\\utauPluginInputLog.txt", ex.Message + "\n" + ex.StackTrace, Encoding.GetEncoding("Shift_JIS"));
                        File.WriteAllLines(".\\InputData.txt", UstData);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(ex.ToString());
                        Console.WriteLine(e.ToString());
                    }
                    finally
                    {
                        Environment.Exit(0);
                    }
                }
                else
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Utauプラグイン用tmpファイル読込における、実際のファイル読込部分。
        /// </summary>
        /// <remarks>
        /// ヘッダ部分はANSI、body部分はShift_JISで読み込む。
        /// </remarks>
        private void GetUstData()
        {
            string line;
            long pos = 0;
            UstData = new List<string>();
            StreamReader file = new StreamReader(FilePath, Encoding.GetEncoding(Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.ANSICodePage).WebName));

            while ((line = file.ReadLine()) != null)
            {
                if (IsHeader(line))
                {
                    break;
                }
                UstData.Add(line);
                pos += line.Length;
            }
            file.Close();
            StreamReader file2 = new StreamReader(FilePath, Encoding.GetEncoding("Shift_JIS"));
            file2.BaseStream.Seek(pos, SeekOrigin.Begin);
            if (!IsHeader(line = file2.ReadLine()))
            {
                UstData.Add(line);
            }
            while ((line = file2.ReadLine()) != null)
            {
                UstData.Add(line);
            }
            file2.Close();
        }
        /// <summary>
        /// 読み込んだデータがustのヘッダ部分か否かを判定する。
        /// </summary>
        /// <param name="value">読み込んだファイルの1行分のデータ</param>
        /// <returns>ヘッダであればtrue</returns>
        private Boolean IsHeader(string value)
        {
            if (value == null)
            {
                return (false);
            }
            else
            {
                return (!(Regex.IsMatch(value, @"\[#([0-9]+|PREV|NEXT)\]$")));
            }
        }
        /// <summary>
        /// 読み込んだデータがノートの始点行か否かを判定する。
        /// </summary>
        /// <param name="value">読み込んだファイルの1行分のデータ</param>
        /// <returns>ノートの開始行であればtrue</returns>
        private Boolean IsNote(string value) => Regex.IsMatch(value, @"\[#([0-9]+|PREV|NEXT)\]$");
        /// <summary>
        /// ヘッダ部分をパースし、値を格納する。
        /// </summary>
        private void AnalyzeHeader()
        {
            i = 0;
            while (IsHeader(UstData[i]))
            {
                if (UstData[i].Contains("UstVersion="))
                {
                    Version = UstData[i].Replace("UstVersion=", "");
                }
                else if (UstData[i].Contains("UST Version "))
                {
                    Version = UstData[i].Replace("UST Version ", "");
                }
                else if (UstData[i].Contains("Tempo="))
                {
                    Tempo = float.Parse(UstData[i].Replace("Tempo=", ""));
                }
                else if (UstData[i].Contains("Project="))
                {
                    ProjectName = UstData[i].Replace("Project=", "");
                }
                else if (UstData[i].Contains("VoiceDir="))
                {
                    VoiceDir = UstData[i].Replace("VoiceDir=", "");
                }
                else if (UstData[i].Contains("OutFile="))
                {
                    OutputFile = UstData[i].Replace("OutFile=", "");
                }
                else if (UstData[i].Contains("CacheDir="))
                {
                    CacheDir = UstData[i].Replace("CacheDir=", "");
                }
                else if (UstData[i].Contains("Tool1="))
                {
                    Tool1Path = UstData[i].Replace("Tool1=", "");
                }
                else if (UstData[i].Contains("Tool2="))
                {
                    Tool2Path = UstData[i].Replace("Tool2=", "");
                }
                else if (UstData[i].Contains("Flags="))
                {
                    Flags = UstData[i].Replace("Flags=", "");
                }
                else if (UstData[i].Contains("Mode2="))
                {
                    Mode2 = Boolean.Parse(UstData[i].Replace("Mode2=", ""));
                }
                i++;
                if (UstData.Count <= i)
                {
                    break;
                }
            }

        }
        /// <summary>
        /// ノート部分をパースし、値を格納する。
        /// </summary>
        private void AnalyzeNotes()
        {
            nowTempo = Tempo;
            while (UstData.Count > i)
            {
                if (IsNote(UstData[i]))
                {
                    note.Add(new Note());
                    if (note.Count != 1)
                    {
                        note[note.Count - 2].Next = note[note.Count - 1];
                        note[note.Count - 1].Prev = note[note.Count - 2];
                    }
                    note[note.Count - 1].InitNum(UstData[i].Replace("[#", "").Replace("]", ""));
                    note[note.Count - 1].InitTempo(nowTempo);
                }
                foreach (string key in entries.Keys)
                {
                    if (UstData[i].StartsWith(key + "="))
                    {
                        entries[key].Input(note.Count - 1, key);
                        continue;
                    }
                }
                i++;
            }
        }
        /// <summary>
        /// ノート部分を出力する。
        /// </summary>
        private void OutputHelper()
        {
            foreach (Note note in this.note)
            {
                //number
                if (note.GetNum() == "PREV" || note.GetNum() == "NEXT")
                {
                    continue;
                }
                else if (note.GetNum() == "DELETE")
                {
                    writeData.Add("[#" + note.GetNum() + "]");
                    continue;
                }
                else if (note.GetDirect() == false && note.DirectIsChanged())
                {
                    writeData.Add("[#DELETE]");
                    note.SetNum("INSERT");
                    writeData.Add("[#" + note.GetNum() + "]");
                }
                else
                {
                    writeData.Add("[#" + note.GetNum() + "]");
                }
                foreach (string key in entries.Keys)
                {
                    entries[key].Output?.Invoke(note, key);
                }
            }
        }
        /// <summary>
        /// プラグイン実行結果を出力する。
        /// </summary>
        public void Output()
        {
            try
            {
                writeData = new List<String>();
                OutputHelper();
                File.WriteAllLines(FilePath, writeData, Encoding.GetEncoding("Shift_JIS"));
            }
            catch (Exception ex)
            {
                File.WriteAllText(".\\utauPluginOutputLog.txt", ex.Message + "\n" + ex.StackTrace, Encoding.GetEncoding("Shift_JIS"));
                File.WriteAllLines(".\\InputData.txt", UstData);
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// ノートを追加する。
        /// </summary>
        /// <param name="index">ノートを追加する位置</param>
        public void InsertNote(int index)
        {
            note.Insert(index, new Note());
            note[index].SetNum("INSERT");
            note[index].InitPre("");
            Note prevNote = GetPrevNote(index - 1);
            Note nextNote = GetNextNote(index + 1);
            if (prevNote != null)
            {
                note[index].Next = prevNote.Next;
                prevNote.Next = note[index];
            }
            else if (nextNote != null)
            {
                note[index].Next = note[index + 1];
            }
            if (nextNote != null)
            {
                note[index].Prev = note[index + 1].Prev;
                note[index + 1].Prev = note[index];
            }
            else if (prevNote != null)
            {
                note[index].Prev = note[index - 1];
            }

            if (note[index].Prev != null)
            {
                note[index].InitTempo(note[index].Prev.GetTempo());
            }
            else
            {
                note[index].InitTempo(Tempo);
            }
        }

        /// <summary>
        /// ノートを削除する
        /// </summary>
        /// <param name="index">削除するノートのインデックス</param>
        public void DeleteNote(int index)
        {
            note[index].SetNum("DELETE");
            if (note[index].Prev != null)
            {
                note[index].Prev.Next = note[index].Next;
            }
            if (note[index].Next != null)
            {
                note[index].Next.Prev = note[index].Prev;
            }
        }

        /// <summary>
        /// DELETEしたノートを無視し、1つ前のノートを取得する
        /// </summary>
        /// <param name="index">基準となるノートのインデックス</param>
        /// <returns>1つ前のノートへの参照</returns>
        private Note GetPrevNote(int index)
        {
            while (index >= 0)
            {
                if (note[index].GetNum() != "DELETE")
                {
                    return note[index];
                }
                index--;
            }
            return null;
        }
        /// <summary>
        /// DELETEしたノートを無視し、1つ次のノートを取得する
        /// </summary>
        /// <param name="index">基準となるノートのインデックス</param>
        /// <returns>1つ次のノートへの参照</returns>
        private Note GetNextNote(int index)
        {
            while (index < note.Count)
            {
                if (note[index].GetNum() != "DELETE")
                {
                    return note[index];
                }
                index++;
            }
            return null;
        }
        /// <summary>
        /// UTAU音源を読み込む
        /// </summary>
        /// <param name="recursive">再帰的にフォルダを読み込むか否か。通常のUTAUではfalse</param>

        public void InputVoiceBank(bool recursive = false)
        {
            vb = new VoiceBank(VoiceDir);
            vb.InputPrefixMap();
            vb.InputOtoAll(recursive);
        }

        /// <summary>
        /// 先行発声・オーバーラップが空欄のノートを原音設定値で補完する。書き出しには影響しない。
        /// </summary>
        public void ApplyOto()
        {
            for (int i = 0; i < note.Count; i++)
            {
                note[i].ApplyOto(vb.prefixMap, vb.oto);
            }
        }
        /// <summary>
        /// @パラメータが存在しないノートを自動調整で補完する。書き出しには影響しない。
        /// </summary>
        public void InitAtParam()
        {
            for (int i = 0; i < note.Count; i++)
            {
                note[i].InitAtParam(vb.prefixMap, vb.oto);
            }
        }

    }
}
