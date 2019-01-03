using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace utauPlugin
{
    public class UtauPlugin:Ust
    {
        //private string filePath;
        //private string version;
        //private string projectName;
        //private string voiceDir;
        //private string cacheDir;
        //private string outputFile;
        //private float tempo;
        //private string tool1Path;
        //private string tool2Path;
        //private string flags;
        //private Boolean mode2;
        //private Boolean utf8;
        //public List<Note> note;

        private List<String> ustData;
        private List<String> writeData;
        private int i;
        

        public UtauPlugin() { }
        public UtauPlugin(string filePath) : base(filePath) { }

        public void Input()
        {
            try
            {
                Console.WriteLine(Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.ANSICodePage).WebName);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                //ustData.AddRange(File.ReadAllLines(FilePath, Encoding.GetEncoding("Shift_JIS")));
                GetUstData();
                AnalyzeHeader();
                note = new List<Note>();
                AnalyzeNotes();
            }
            catch (Exception ex)
            {
                File.WriteAllText(".\\utauPluginInputLog.txt", ex.StackTrace, Encoding.GetEncoding("Shift_JIS"));
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
            float nowTempo = Tempo;
            while (ustData.Count > i)
            {
                if (IsNote(ustData[i])){
                    note.Add(new Note());
                    note[note.Count - 1].InitNum(ustData[i].Replace("[#","").Replace("]",""));
                    note[note.Count - 1].InitTempo(nowTempo);
                }
                else if (ustData[i].Contains("Length="))
                {
                    note[note.Count - 1].InitLength(ustData[i].Replace("Length=", ""));
                }
                else if (ustData[i].Contains("Lyric="))
                {
                    note[note.Count - 1].InitLyric(ustData[i].Replace("Lyric=", ""));
                }
                else if (ustData[i].Contains("NoteNum="))
                {
                    note[note.Count - 1].InitNoteNum(ustData[i].Replace("NoteNum=", ""));
                }
                else if (ustData[i].Contains("Tempo="))
                {
                    note[note.Count - 1].InitTempo(ustData[i].Replace("Tempo=", ""));
                    nowTempo = note[note.Count - 1].GetTempo();
                }
                else if (ustData[i].Contains("PreUtterance="))
                {
                    note[note.Count - 1].InitPre(ustData[i].Replace("PreUtterance=", ""));
                }
                else if (ustData[i].Contains("@preuttr="))
                {
                    note[note.Count - 1].InitAtPre(ustData[i].Replace("@preuttr=", ""));
                }
                else if (ustData[i].Contains("VoiceOverlap="))
                {
                    note[note.Count - 1].InitOve(ustData[i].Replace("VoiceOverlap=", ""));
                }
                else if (ustData[i].Contains("@overlap="))
                {
                    note[note.Count - 1].InitAtOve(ustData[i].Replace("@overlap=", ""));
                }
                else if (ustData[i].Contains("StartPoint="))
                {
                    note[note.Count - 1].InitStp(ustData[i].Replace("StartPoint=", ""));
                }
                else if (ustData[i].Contains("@stpoint="))
                {
                    note[note.Count - 1].InitAtStp(ustData[i].Replace("@stpoint=", ""));
                }
                else if (ustData[i].Contains("@filename="))
                {
                    note[note.Count - 1].InitAtFileName(ustData[i].Replace("@filename=", ""));
                }
                else if (ustData[i].Contains("@alias="))
                {
                    note[note.Count - 1].InitAtAlias(ustData[i].Replace("@alias=", ""));
                }
                else if (ustData[i].Contains("Velocity="))
                {
                    note[note.Count - 1].InitVelocity(ustData[i].Replace("Velocity=", ""));
                }
                else if (ustData[i].Contains("Intensity="))
                {
                    note[note.Count - 1].InitIntensity(ustData[i].Replace("Intensity=", ""));
                }
                else if (ustData[i].Contains("Modulation="))
                {
                    note[note.Count - 1].InitMod(ustData[i].Replace("Modulation=", ""));
                }
                else if (ustData[i].Contains("Moduration="))
                {
                    note[note.Count - 1].InitMod(ustData[i].Replace("Moduration=", ""));
                }
                else if (ustData[i].Contains("Piches="))
                {
                    note[note.Count - 1].InitPitches(ustData[i].Replace("Piches=", ""));
                }
                else if (ustData[i].Contains("Pitches="))
                {
                    note[note.Count - 1].InitPitches(ustData[i].Replace("Pitches=", ""));
                }
                else if (ustData[i].Contains("PitchBend="))
                {
                    note[note.Count - 1].InitPitches(ustData[i].Replace("PitchBend=", ""));
                }
                else if (ustData[i].Contains("PBStart="))
                {
                    note[note.Count - 1].InitPbStart(ustData[i].Replace("PBStart=", ""));
                }
                else if (ustData[i].Contains("PBType="))
                {
                    note[note.Count - 1].InitPbType(ustData[i].Replace("PBType=", ""));
                }
                else if (ustData[i].Contains("PBS="))
                {
                    if (!note[note.Count - 1].HasMode2Pitch())
                    {
                        note[note.Count - 1].InitMode2Pitch();
                    }
                    note[note.Count - 1].InitPbs(ustData[i].Replace("PBS=", ""));
                }
                else if (ustData[i].Contains("PBW="))
                {
                    if(!note[note.Count - 1].HasMode2Pitch())
                    {
                        note[note.Count - 1].InitMode2Pitch();
                    }
                    note[note.Count - 1].InitPbw(ustData[i].Replace("PBW=", ""));
                }
                else if (ustData[i].Contains("PBY="))
                {
                    if (!note[note.Count - 1].HasMode2Pitch())
                    {
                        note[note.Count - 1].InitMode2Pitch();
                    }
                    note[note.Count - 1].InitPby(ustData[i].Replace("PBY=", ""));
                }
                else if (ustData[i].Contains("PBM="))
                {
                    if (!note[note.Count - 1].HasMode2Pitch())
                    {
                        note[note.Count - 1].InitMode2Pitch();
                    }
                    note[note.Count - 1].InitPbm(ustData[i].Replace("PBM=", ""));
                }
                else if (ustData[i].Contains("Flags="))
                {
                    note[note.Count - 1].InitFlags(ustData[i].Replace("Flags=", ""));
                }
                else if (ustData[i].Contains("VBR="))
                {
                    note[note.Count - 1].InitVibrato(ustData[i].Replace("VBR=", ""));
                }
                else if (ustData[i].Contains("Envelope="))
                {
                    note[note.Count - 1].InitEnvelope(ustData[i].Replace("Envelope=", ""));
                }
                else if (ustData[i].Contains("Label="))
                {
                    note[note.Count - 1].InitLabel(ustData[i].Replace("Label=", ""));
                }
                else if (ustData[i].Contains("$direct="))
                {
                    note[note.Count - 1].InitDirect(ustData[i].Replace("$direct=", ""));
                }
                else if (ustData[i].Contains("$region="))
                {
                    note[note.Count - 1].InitRegion(ustData[i].Replace("$region=", ""));
                }
                else if (ustData[i].Contains("$region_end="))
                {
                    note[note.Count - 1].InitRegionEnd(ustData[i].Replace("$region_end=", ""));
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
                else
                {
                    writeData.Add("[#" + note.GetNum() + "]");
                }
                //Length
                if (note.GetNum() == "INSERT" || note.LengthIsChanged())
                {
                    writeData.Add("Length=" + note.GetLength().ToString());
                }
                //Lyric
                if (note.GetNum() == "INSERT" || note.LyricIsChanged())
                {
                    writeData.Add("Lyric=" + note.GetLyric());
                }
                //NoteNum
                if (note.GetNum() == "INSERT" || note.NoteNumIsChanged())
                {
                    writeData.Add("NoteNum=" + note.GetNoteNum().ToString());
                }
                //Tempo
                if (note.TempoIsChanged())
                {
                    writeData.Add("Tempo=" + note.GetTempo().ToString());
                }
                //Pre
                if (note.GetNum() == "INSERT" || note.PreIsChanged())
                {
                    if (note.PreHasValue()) { writeData.Add("PreUtterance=" + note.GetPre().ToString()); }
                    else { writeData.Add("PreUtterance="); }

                }
                //Ove
                if (note.HasOve() && (note.GetNum() == "INSERT" || note.OveIsChanged()))
                {
                    writeData.Add("VoiceOverlap=" + note.GetOve().ToString());
                }
                //Stp
                if (note.HasStp() && (note.GetNum() == "INSERT" || note.StpIsChanged()))
                {
                    writeData.Add("StartPoint=" + note.GetStp().ToString());
                }
                //Velocity
                if (note.HasVelocity() && (note.GetNum() == "INSERT" || note.VelocityIsChanged()))
                {
                    writeData.Add("Velocity=" + note.GetVelocity().ToString());
                }
                //Intensity
                if (note.HasIntensity() && (note.GetNum() == "INSERT" || note.IntensityIsChanged()))
                {
                    writeData.Add("Intensity=" + note.GetIntensity().ToString());
                }
                //Mod
                if (note.HasMod() && (note.GetNum() == "INSERT" || note.ModIsChanged()))
                {
                    if (Version == "1.0" || Version == "1.01" || Version == "1.11" || Version == "1.19") { writeData.Add("Moduration=" + note.GetMod().ToString()); }
                    if (Version == "1.19" || Version == "1.20") { writeData.Add("Modulation=" + note.GetMod().ToString()); }

                }
                //Flags
                if (note.HasFlags() && (note.GetNum() == "INSERT" || note.FlagsIsChanged()))
                {
                    writeData.Add("Flags=" + note.GetFlags());
                }
                //pitches
                if (note.HasPitches() && (note.GetNum() == "INSERT" || note.PitchesIsChanged()))
                {
                    if (Version == "1.0" || Version == "1.01" || Version == "1.19") { writeData.Add("Piches=" + string.Join(",", note.GetPitches())); }
                    if (Version == "1.11" || Version == "1.19") { writeData.Add("Pitches=" + string.Join(",", note.GetPitches())); }
                    if (Version == "1.01" || Version == "1.11" || Version == "1.19" || Version == "1.20") { writeData.Add("PitchBend=" + string.Join(",", note.GetPitches())); }
                }
                //pbstart
                if (note.HasPbStart() && (note.GetNum() == "INSERT" || note.PbStartIsChanged()))
                {
                    writeData.Add("PBStart=" + note.GetPbStart().ToString());
                }
                //pbtype
                if (note.HasPbType() && (note.GetNum() == "INSERT" || note.PbTypeIsChanged()))
                {
                    writeData.Add("PBType=" + note.GetPbType().ToString());
                }
                //pbs
                if (note.HasMode2Pitch() && (note.GetNum() == "INSERT" || note.PbsIsChanged()))
                {
                    writeData.Add("PBS=" + note.GetPbs());
                }
                //pbw
                if (note.HasMode2Pitch() && (note.GetNum() == "INSERT" || note.PbwIsChanged()))
                {
                    writeData.Add("PBW=" + string.Join(",", note.GetPbw()));
                }
                //pby
                if (note.HasMode2Pitch() && (note.GetNum() == "INSERT" || note.PbyIsChanged()))
                {
                    List<string> pbyTmp = new List<String>();
                    foreach (float f in note.GetPby())
                    {
                        if (f == 0.0f) { pbyTmp.Add(""); }
                        else { pbyTmp.Add(f.ToString()); }
                    }
                    writeData.Add("PBY=" + string.Join(",", pbyTmp));
                }
                //pbm
                if (note.HasMode2Pitch() && (note.GetNum() == "INSERT" || note.PbmIsChanged()))
                {
                    writeData.Add("PBM=" + string.Join(",", note.GetPbm()));
                }
                //envelope
                if (note.HasEnvelope() && (note.GetNum() == "INSERT" || note.EnvelopeIsChanged()))
                {
                    writeData.Add("Envelope=" + note.GetEnvelope());
                }
                //vibrato
                if (note.HasVibrato() && (note.GetNum() == "INSERT" || note.VibratoIsChanged()))
                {
                    writeData.Add("VBR=" + note.GetVibrato());
                }
                //label
                if (note.HasLabel() && (note.GetNum() == "INSERT" || note.LabelIsChanged()))
                {
                    writeData.Add("Label=" + note.GetLabel());
                }
                //direct
                if (note.HasDirect() && (note.GetNum() == "INSERT" || note.DirectIsChanged()))
                {
                    writeData.Add("$direct=" + note.GetDirect().ToString());
                }
                //region
                if (note.HasRegion() && (note.GetNum() == "INSERT" || note.RegionIsChanged()))
                {
                    writeData.Add("$region=" + note.GetRegion());
                }
                //regionEnd
                if (note.HasRegionEnd() && (note.GetNum() == "INSERT" || note.RegionEndIsChanged()))
                {
                    writeData.Add("$region_end=" + note.GetRegionEnd());
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
                File.WriteAllText(".\\utauPluginOutputLog.txt", ex.StackTrace, Encoding.GetEncoding("Shift_JIS"));
                Environment.Exit(0);
            }
        }
    }
}
