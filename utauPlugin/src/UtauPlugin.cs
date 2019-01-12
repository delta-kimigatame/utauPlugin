using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using UtauVoiceBank;

namespace utauPlugin
{
    public partial class UtauPlugin:Ust
    {

        private List<String> ustData;
        private List<String> writeData;
        private int i;
        private float nowTempo;
        private VoiceBank vb;


        public UtauPlugin() { InitEntries(); }
        public UtauPlugin(string filePath) : base(filePath) { InitEntries(); }

        public void Input()
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
                File.WriteAllText(".\\utauPluginInputLog.txt", ex.Message+"\n"+ex.StackTrace, Encoding.GetEncoding("Shift_JIS"));
                File.WriteAllLines(".\\InputData.txt",ustData);
                Environment.Exit(0);
            }
        }

        private void GetUstData()
        {
            string line;
            long pos=0;
            ustData = new List<string>();
            StreamReader file = new StreamReader(FilePath, Encoding.GetEncoding(Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.ANSICodePage).WebName));
            
            while (IsHeader(line = file.ReadLine()))
            {
                ustData.Add(line);
                pos += line.Length;
            }
            file.Close();
            StreamReader file2 = new StreamReader(FilePath, Encoding.GetEncoding("Shift_JIS"));
            file2.BaseStream.Seek(pos, SeekOrigin.Begin);
            if(!IsHeader(line = file2.ReadLine()))
            {
                ustData.Add(line);
            }
            while ((line = file2.ReadLine()) != null)
            {
                ustData.Add(line);
            }
            file2.Close();
        }

        private Boolean IsHeader(string value) => !(Regex.IsMatch(value, @"\[#([0-9]+|PREV|NEXT)\]$"));
        private Boolean IsNote(string value) => Regex.IsMatch(value, @"\[#([0-9]+|PREV|NEXT)\]$");
        private void AnalyzeHeader()
        {
            i = 0;
            while (IsHeader(ustData[i]))
            {
                if (ustData[i].Contains("UstVersion="))
                {
                    Version=ustData[i].Replace("UstVersion=","");
                }
                else if(ustData[i].Contains("UST Version "))
                {
                    Version = ustData[i].Replace("UST Version ", "");
                }
                else if (ustData[i].Contains("Tempo="))
                {
                    Tempo=float.Parse(ustData[i].Replace("Tempo=", ""));
                }
                else if (ustData[i].Contains("Project="))
                {
                    ProjectName=ustData[i].Replace("Project=", "");
                }
                else if (ustData[i].Contains("VoiceDir="))
                {
                    VoiceDir=ustData[i].Replace("VoiceDir=", "");
                }
                else if (ustData[i].Contains("OutFile="))
                {
                    OutputFile=ustData[i].Replace("OutFile=", "");
                }
                else if (ustData[i].Contains("CacheDir="))
                {
                    CacheDir=ustData[i].Replace("CacheDir=", "");
                }
                else if (ustData[i].Contains("Tool1="))
                {
                    Tool1Path=ustData[i].Replace("Tool1=", "");
                }
                else if (ustData[i].Contains("Tool2="))
                {
                    Tool2Path=ustData[i].Replace("Tool2=", "");
                }
                else if (ustData[i].Contains("Flags="))
                {
                    Flags=ustData[i].Replace("Flags=", "");
                }
                else if (ustData[i].Contains("Mode2="))
                {
                    Mode2=Boolean.Parse(ustData[i].Replace("Mode2=", ""));
                }
                i++;
            }

        }
        private void AnalyzeNotes()
        {
            nowTempo = Tempo;
            while (ustData.Count > i)
            {
                if (IsNote(ustData[i])){
                    note.Add(new Note());
                    if (note.Count != 1)
                    {
                        note[note.Count - 2].Next = note[note.Count - 1];
                        note[note.Count - 1].Prev = note[note.Count - 2];
                    }
                    note[note.Count - 1].InitNum(ustData[i].Replace("[#","").Replace("]",""));
                    note[note.Count - 1].InitTempo(nowTempo);
                }
                foreach (string key in entries.Keys)
                {
                    if (ustData[i].Contains(key+"=")){
                        entries[key].Input(note.Count - 1, key);
                        continue;
                    }
                }
                i++;
            }
        }

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
                foreach(string key in entries.Keys)
                {
                    entries[key].Output?.Invoke(note,key);
                }
            }
        }
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
                File.WriteAllText(".\\utauPluginOutputLog.txt", ex.Message + "\n"+ex.StackTrace, Encoding.GetEncoding("Shift_JIS"));
                File.WriteAllLines(".\\InputData.txt", ustData);
                Environment.Exit(0);
            }
        }

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
            if(nextNote != null)
            {
                note[index].Prev = note[index + 1].Prev;
                note[index + 1].Prev = note[index];
            }
            else if(prevNote != null)
            {
                note[index].Prev = note[index - 1];
            }
        }

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

        public void InputVoiceBank()
        {
            vb = new VoiceBank(VoiceDir);
            vb.InputPrefixMap();
            vb.InputOtoAll();
        }

        //先行発声やオーバーラップ値が与えられていないノートに原音設定値を設定する．
        //書き出しには影響しない
        public void ApplyOto()
        {

            for (int i=0;i<note.Count;i++)
            {
                note[i].ApplyOto(vb.prefixMap, vb.oto);
            }
        }
        //@パラメータが存在しないノートの原音設定値から初期化する．
        public void InitAtParam()
        {
            for (int i = 0; i < note.Count; i++)
            {
                note[i].InitAtParam(vb.prefixMap, vb.oto);
            }
        }
        
    }
}
