using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utauPlugin
{
    public partial class UtauPlugin : Ust
    {
        private void ParseLength(int index, string key) { note[index].InitLength(UstData[i].Replace(key+"=", "")); }
        private void ParseLyric(int index, string key) { note[index].InitLyric(UstData[i].Replace(key + "=", "")); }
        private void ParseNoteNum(int index, string key) { note[index].InitNoteNum(UstData[i].Replace(key + "=", "")); }
        private void ParseTempo(int index, string key) { note[index].InitTempo(UstData[i].Replace(key + "=", "")); nowTempo = note[index].GetTempo(); }
        private void ParsePre(int index, string key) { note[index].InitPre(UstData[i].Replace(key + "=", "")); }
        private void ParseAtPre(int index, string key) { note[index].InitAtPre(UstData[i].Replace(key + "=", "")); }
        private void ParseOve(int index, string key) { note[index].InitOve(UstData[i].Replace(key + "=", "")); }
        private void ParseAtOve(int index, string key) { note[index].InitAtOve(UstData[i].Replace(key + "=", "")); }
        private void ParseStp(int index, string key) { note[index].InitStp(UstData[i].Replace(key + "=", "")); }
        private void ParseAtStp(int index, string key) { note[index].InitAtStp(UstData[i].Replace(key + "=", "")); }
        private void ParseAtFileName(int index, string key) { note[index].InitAtFileName(UstData[i].Replace(key + "=", "")); }
        private void ParseAtAlias(int index, string key) { note[index].InitAtAlias(UstData[i].Replace(key + "=", "")); }
        private void ParseVelocity(int index, string key) { note[index].InitVelocity(UstData[i].Replace(key + "=", "")); }
        private void ParseIntensity(int index, string key) { note[index].InitIntensity(UstData[i].Replace(key + "=", "")); }
        private void ParseMod(int index, string key) { note[index].InitMod(UstData[i].Replace(key + "=", "")); }
        private void ParsePitches(int index, string key) { note[index].InitPitches(UstData[i].Replace(key + "=", "")); }
        private void ParsePbStart(int index, string key) { note[index].InitPbStart(UstData[i].Replace(key + "=", "")); }
        private void ParsePbType(int index, string key) { note[index].InitPbType(UstData[i].Replace(key + "=", "")); }
        private void ParsePbs(int index, string key) { if (!note[index].HasMode2Pitch()) { note[index].InitMode2Pitch(); } note[index].InitPbs(UstData[i].Replace(key + "=", "")); }
        private void ParsePbw(int index, string key) { if (!note[index].HasMode2Pitch()) { note[index].InitMode2Pitch(); } note[index].InitPbw(UstData[i].Replace(key + "=", "")); }
        private void ParsePby(int index, string key) { if (!note[index].HasMode2Pitch()) { note[index].InitMode2Pitch(); } note[index].InitPby(UstData[i].Replace(key + "=", "")); }
        private void ParsePbm(int index, string key) { if (!note[index].HasMode2Pitch()) { note[index].InitMode2Pitch(); } note[index].InitPbm(UstData[i].Replace(key + "=", "")); }
        private void ParseFlags(int index, string key) { note[index].InitFlags(UstData[i].Replace(key + "=", "")); }
        private void ParseVibrato(int index, string key) { note[index].InitVibrato(UstData[i].Replace(key + "=", "")); }
        private void ParseEnvelope(int index, string key) { note[index].InitEnvelope(UstData[i].Replace(key + "=", "")); }
        private void ParseLabel(int index, string key) { note[index].InitLabel(UstData[i].Replace(key + "=", "")); }
        private void ParseDirect(int index, string key) { note[index].InitDirect(UstData[i].Replace(key + "=", "")); }
        private void ParseRegion(int index, string key) { note[index].InitRegion(UstData[i].Replace(key + "=", "")); }
        private void ParseRegionEnd(int index, string key) { note[index].InitRegionEnd(UstData[i].Replace(key + "=", "")); }
        private void ParseOriginalEntry(int index, string key) { note[index].InitOriginalEntry(key,UstData[i].Replace(key + "=", "")); }
        private void WriteLength(Note note, string key)
        {
            if (note.GetNum() == "INSERT" || note.LengthIsChanged())
            {
                writeData.Add("Length=" + note.GetLength().ToString());
            }
        }

        private void WriteLyric(Note note, string key)
        {
            if (note.GetNum() == "INSERT" || note.LyricIsChanged())
            {
                writeData.Add("Lyric=" + note.GetLyric());
            }
        }

        private void WriteNoteNum(Note note, string key)
        {
            if (note.GetNum() == "INSERT" || note.NoteNumIsChanged())
            {
                writeData.Add("NoteNum=" + note.GetNoteNum().ToString());
            }
        }

        private void WriteTempo(Note note, string key)
        {
            if (note.TempoIsChanged())
            {
                writeData.Add("Tempo=" + note.GetTempo().ToString());
            }
        }

        private void WritePre(Note note, string key)
        {
            if (note.GetNum() == "INSERT" || note.PreIsChanged())
            {
                if (note.PreHasValue()) { writeData.Add("PreUtterance=" + note.GetPre().ToString()); }
                else { writeData.Add("PreUtterance="); }

            }
        }
        

        private void WriteOve(Note note, string key)
        {
            if (note.HasOve() && (note.GetNum() == "INSERT" || note.OveIsChanged()))
            {
                writeData.Add("VoiceOverlap=" + note.GetOve().ToString());
            }
        }
        

        private void WriteStp(Note note, string key)
        {
            if (note.HasStp() && (note.GetNum() == "INSERT" || note.StpIsChanged()))
            {
                writeData.Add("StartPoint=" + note.GetStp().ToString());
            }
        }
                
        private void WriteVelocity(Note note, string key)
        {
            if (note.HasVelocity() && (note.GetNum() == "INSERT" || note.VelocityIsChanged()))
            {
                writeData.Add("Velocity=" + note.GetVelocity().ToString());
            }
        }

        private void WriteIntensity(Note note, string key)
        {
            if (note.HasIntensity() && (note.GetNum() == "INSERT" || note.IntensityIsChanged()))
            {
                writeData.Add("Intensity=" + note.GetIntensity().ToString());
            }
        }

        private void WriteMod(Note note, string key)
        {
            if (note.HasMod() && (note.GetNum() == "INSERT" || note.ModIsChanged()))
            {
                if (Version == "1.0" || Version == "1.01" || Version == "1.11" || Version == "1.19") { writeData.Add("Moduration=" + note.GetMod().ToString()); }
                if (Version == "1.19" || Version == "1.20") { writeData.Add("Modulation=" + note.GetMod().ToString()); }

            }
        }

        private void WritePitches(Note note, string key)
        {
            if (note.HasPitches() && (note.GetNum() == "INSERT" || note.PitchesIsChanged()))
            {
                if (Version == "1.0" || Version == "1.01" || Version == "1.19") { writeData.Add("Piches=" + string.Join(",", note.GetPitches())); }
                if (Version == "1.11" || Version == "1.19") { writeData.Add("Pitches=" + string.Join(",", note.GetPitches())); }
                if (Version == "1.01" || Version == "1.11" || Version == "1.19" || Version == "1.20") { writeData.Add("PitchBend=" + string.Join(",", note.GetPitches())); }
            }
        }

        private void WritePbStart(Note note, string key)
        {
            if (note.HasPbStart() && (note.GetNum() == "INSERT" || note.PbStartIsChanged()))
            {
                writeData.Add("PBStart=" + note.GetPbStart().ToString());
            }
        }

        private void WritePbType(Note note, string key)
        {
            if (note.HasPbType() && (note.GetNum() == "INSERT" || note.PbTypeIsChanged()))
            {
                writeData.Add("PBType=" + note.GetPbType().ToString());
            }
        }

        private void WritePbs(Note note, string key)
        {
            if (note.HasMode2Pitch() && (note.GetNum() == "INSERT" || note.PbsIsChanged()))
            {
                writeData.Add("PBS=" + note.GetPbs());
            }
        }

        private void WritePbw(Note note, string key)
        {
            if (note.HasMode2Pitch() && (note.GetNum() == "INSERT" || note.PbwIsChanged()))
            {
                writeData.Add("PBW=" + string.Join(",", note.GetPbw()));
            }
        }

        private void WritePby(Note note, string key)
        {
            if (note.HasMode2Pitch() && (note.GetNum() == "INSERT" || note.PbyIsChanged()))
            {
                List<string> pbyTmp = new List<String>();
                foreach (float f in note.GetPby())
                {
                    pbyTmp.Add(f.ToString());
                    //if (f == 0.0f) { pbyTmp.Add(""); }
                    //else { pbyTmp.Add(f.ToString()); }
                }
                writeData.Add("PBY=" + string.Join(",", pbyTmp));
            }
        }

        private void WritePbm(Note note, string key)
        {
            if (note.HasMode2Pitch() && (note.GetNum() == "INSERT" || note.PbmIsChanged()))
            {
                writeData.Add("PBM=" + string.Join(",", note.GetPbm()));
            }
        }

        private void WriteFlags(Note note, string key)
        {
            if (note.HasFlags() && (note.GetNum() == "INSERT" || note.FlagsIsChanged()))
            {
                writeData.Add("Flags=" + note.GetFlags());
            }
        }

        private void WriteVibrato(Note note, string key)
        {
            if (note.HasVibrato() && (note.GetNum() == "INSERT" || note.VibratoIsChanged()))
            {
                writeData.Add("VBR=" + note.GetVibrato());
            }
        }

        private void WriteEnvelope(Note note, string key)
        {
            if (note.HasEnvelope() && (note.GetNum() == "INSERT" || note.EnvelopeIsChanged()))
            {
                writeData.Add("Envelope=" + note.GetEnvelope());
            }
        }

        private void WriteLabel(Note note, string key)
        {
            if (note.HasLabel() && (note.GetNum() == "INSERT" || note.LabelIsChanged()))
            {
                writeData.Add("Label=" + note.GetLabel());
            }
        }

        private void WriteDirect(Note note, string key)
        {
            if (note.HasDirect() && (note.GetNum() == "INSERT" || note.DirectIsChanged()) && note.GetDirect())
            {
                writeData.Add("$direct=" + note.GetDirect().ToString());
            }
        }

        private void WriteRegion(Note note, string key)
        {
            if (note.HasRegion() && (note.GetNum() == "INSERT" || note.RegionIsChanged()))
            {
                writeData.Add("$region=" + note.GetRegion());
            }
        }

        private void WriteRegionEnd(Note note, string key)
        {
            if (note.HasRegionEnd() && (note.GetNum() == "INSERT" || note.RegionEndIsChanged()))
            {
                writeData.Add("$region_end=" + note.GetRegionEnd());
            }
        }
        private void WriteOriginalEntry(Note note, string key)
        {
            if (note.HasOriginalEntry(key) && (note.GetNum() == "INSERT" || note.OriginalEntryIsChanged(key)))
            {
                writeData.Add(key +"="+ note.GetOriginalEntry(key).ToString());
            }
        }

        private Dictionary<string, EntryMethods> entries;

        private void InitEntries()
        {
            entries = new Dictionary<string, EntryMethods>();
            entries.Add("Length", new EntryMethods());
            entries["Length"].Input = ParseLength;
            entries["Length"].Output = WriteLength;
            entries.Add("Lyric", new EntryMethods());
            entries["Lyric"].Input = ParseLyric;
            entries["Lyric"].Output = WriteLyric;
            entries.Add("NoteNum", new EntryMethods());
            entries["NoteNum"].Input = ParseNoteNum;
            entries["NoteNum"].Output = WriteNoteNum;
            entries.Add("Tempo", new EntryMethods());
            entries["Tempo"].Input = ParseTempo;
            entries["Tempo"].Output = WriteTempo;
            entries.Add("PreUtterance", new EntryMethods());
            entries["PreUtterance"].Input = ParsePre;
            entries["PreUtterance"].Output = WritePre;
            entries.Add("@preuttr", new EntryMethods());
            entries["@preuttr"].Input = ParseAtPre;
            entries["@preuttr"].Output = null;
            entries.Add("VoiceOverlap", new EntryMethods());
            entries["VoiceOverlap"].Input = ParseOve;
            entries["VoiceOverlap"].Output = WriteOve;
            entries.Add("@overlap", new EntryMethods());
            entries["@overlap"].Input = ParseAtOve;
            entries["@overlap"].Output = null;
            entries.Add("StartPoint", new EntryMethods());
            entries["StartPoint"].Input = ParseStp;
            entries["StartPoint"].Output = WriteStp;
            entries.Add("@stpoint", new EntryMethods());
            entries["@stpoint"].Input = ParseAtStp;
            entries["@stpoint"].Output = null;
            entries.Add("@filename", new EntryMethods());
            entries["@filename"].Input = ParseAtFileName;
            entries["@filename"].Output = null;
            entries.Add("@alias", new EntryMethods());
            entries["@alias"].Input = ParseAtAlias;
            entries["@alias"].Output = null;
            entries.Add("Velocity", new EntryMethods());
            entries["Velocity"].Input = ParseVelocity;
            entries["Velocity"].Output = WriteVelocity;
            entries.Add("Intensity", new EntryMethods());
            entries["Intensity"].Input = ParseIntensity;
            entries["Intensity"].Output = WriteIntensity;
            entries.Add("Moduration", new EntryMethods());
            entries["Moduration"].Input = ParseMod;
            entries["Moduration"].Output = WriteMod;
            entries.Add("Modulation", new EntryMethods());
            entries["Modulation"].Input = ParseMod;
            entries["Modulation"].Output = null;
            entries.Add("Piches", new EntryMethods());
            entries["Piches"].Input = ParsePitches;
            entries["Piches"].Output = null;
            entries.Add("Pitches", new EntryMethods());
            entries["Pitches"].Input = ParsePitches;
            entries["Pitches"].Output = null;
            entries.Add("PitchBend", new EntryMethods());
            entries["PitchBend"].Input = ParsePitches;
            entries["PitchBend"].Output = null;
            entries.Add("PBStart", new EntryMethods());
            entries["PBStart"].Input = ParsePbStart;
            entries["PBStart"].Output = WritePbStart;
            entries.Add("PBType", new EntryMethods());
            entries["PBType"].Input = ParsePbType;
            entries["PBType"].Output = WritePbType;
            entries.Add("PBS", new EntryMethods());
            entries["PBS"].Input = ParsePbs;
            entries["PBS"].Output = WritePbs;
            entries.Add("PBW", new EntryMethods());
            entries["PBW"].Input = ParsePbw;
            entries["PBW"].Output = WritePbw;
            entries.Add("PBY", new EntryMethods());
            entries["PBY"].Input = ParsePby;
            entries["PBY"].Output = WritePby;
            entries.Add("PBM", new EntryMethods());
            entries["PBM"].Input = ParsePbm;
            entries["PBM"].Output = WritePbm;
            entries.Add("Flags", new EntryMethods());
            entries["Flags"].Input = ParseFlags;
            entries["Flags"].Output = WriteFlags;
            entries.Add("VBR", new EntryMethods());
            entries["VBR"].Input = ParseVibrato;
            entries["VBR"].Output = WriteVibrato;
            entries.Add("Envelope", new EntryMethods());
            entries["Envelope"].Input = ParseEnvelope;
            entries["Envelope"].Output = WriteEnvelope;
            entries.Add("Label", new EntryMethods());
            entries["Label"].Input = ParseLabel;
            entries["Label"].Output = WriteLabel;
            entries.Add("$direct", new EntryMethods());
            entries["$direct"].Input = ParseDirect;
            entries["$direct"].Output = WriteDirect;
            entries.Add("$region", new EntryMethods());
            entries["$region"].Input = ParseRegion;
            entries["$region"].Output = WriteRegion;
            entries.Add("$region_end", new EntryMethods());
            entries["$region_end"].Input = ParseRegionEnd;
            entries["$region_end"].Output = WriteRegionEnd;

        }
        public List<string> debug;
        public void InitOriginalEntry(string entryName,Object defaultValue)
        {
            debug = new List<string>();
            Note.InitOriginalEntryDefault(entryName, defaultValue);
            debug.AddRange(Note.originalEntriesDefaultValue.Keys);
            entries.Add(entryName, new EntryMethods());
            entries[entryName].Input = ParseOriginalEntry;
            entries[entryName].Output = WriteOriginalEntry;
        }

        public class EntryMethods
        {
            public delegate void InputDelegate(int index, string key);
            public delegate void OutputDelegate(Note ntoe, string key);
            private InputDelegate input;
            private OutputDelegate output;

            public InputDelegate Input { get => input; set => input = value; }
            public OutputDelegate Output { get => output; set => output = value; }

            public EntryMethods()
            {
            }
        }
    }
}
