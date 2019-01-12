using System;
using System.Collections.Generic;
using System.IO;
using UtauVoiceBank;

namespace utauPlugin
{

    public partial class Note
    {
        private Entry<string> num;
        private Entry<int> length;
        private Entry<string> lyric;
        private NoteNum noteNum;
        private Entry<float> tempo;
        private Pre pre;
        private Entry<float> atPre;
        private Entry<string> atFileName;
        private Entry<string> atAlias;
        private Entry<float> ove;
        private Entry<float> atOve;
        private Entry<float> stp;
        private Entry<float> atStp;
        private Entry<int> velocity;
        private Entry<int> intensity;
        private Entry<int> mod;
        private Entry<string> flags;
        private Pitches pitches;
        private Entry<float> pbStart;
        private Entry<string> pbType;
        private Mode2Pitch mode2Pitch;
        public Envelope envelope;
        public Vibrato vibrato;
        private Entry<string> label;
        private Entry<Boolean> direct;
        private Entry<string> region;
        private Entry<string> regionEnd;
        private Dictionary<string,Entry<Object>> originalEntries;
        private AliasData alias;
        private Note prev;
        private Note next;

        public Note Prev { get => prev; set => prev = value; }
        public Note Next { get => next; set => next = value; }

        //各エントリのデフォルト値，メソッドはNoteフォルダ内の各csファイルに記述されています．

        public Note()
        {
            num = new Entry<string>(DEFAULT_NUM);
            length = new Entry<int>(DEFAULT_LENGTH);
            lyric = new Entry<string>(DEFAULT_LYRIC);
            noteNum = new NoteNum(DEFAULT_NOTENUM);
            pre = new Pre(DEFAULT_PRE);
        }
        
        public void ApplyOto(Dictionary<string,MapValue> map, Dictionary<string, Oto> oto)
        {
            if(!HasAlias() && HasAtAlias())
            {
                InitAlias(GetAtAlias());
            }
            else if (!HasAlias())
            {
                InitAlias(GetLyric(),GetNoteNumName(),map);
            }
            ApplyOtoToPre(oto);
            ApplyOtoToOve(oto);
        }

        private void ApplyOtoToPre(Dictionary<string, Oto> oto)
        {
            if (PreHasValue())
            {
                return;
            }
            if (oto.ContainsKey(GetAlias()))
            {
                InitPre(oto[GetAlias()].Pre);
            }
            else
            {
                InitPre(0);
            }
        }

        private void ApplyOtoToOve(Dictionary<string, Oto> oto)
        {

            if (HasOve())
            {
                return;
            }
            if (oto.ContainsKey(GetAlias()))
            {
                InitOve(oto[GetAlias()].Ove);
            }
            else
            {
                InitOve(0);
            }
        }

        private void ApplyOtoToAtFileName(Dictionary<string, Oto> oto)
        {
            if (oto.ContainsKey(GetAlias()))
            {
                InitAtFileName(Path.Combine(oto[GetAlias()].DirPath, oto[GetAlias()].FileName));
            }
            else
            {
                InitAtFileName("");
            }
        }

        public void InitAtParam(Dictionary<string, MapValue> map, Dictionary<string, Oto> oto)
        {
            ApplyOto(map,oto);
            if (!HasAtAlias())
            {
                InitAtAlias(GetAlias());
            }
            if (!HasAtFileName())
            {
                ApplyOtoToAtFileName(oto);
            }
            if (!HasAtPre())
            {
                AutoFitAtParam();
            }
        }

        private void AutoFitAtParam()
        {
            float prevMsLength;
            float tmpVelocity = (float)Math.Pow(2.0f , (GetVelocity() / 100.0f) - 1.0f);
            float tmpPre = GetPre() / tmpVelocity;
            float tmpOve = GetOve() / tmpVelocity;
            float tmpStp = GetStp();
            if (prev!= null)
            {
                if(prev.GetLyric() == "R")
                {
                    prevMsLength = prev.GetMsLength();
                }
                else
                {
                    prevMsLength = prev.GetMsLength()/2;
                }
            }
            else
            {
                prevMsLength = float.MaxValue;
            }



            if( prevMsLength / 2 < tmpPre - tmpOve)
            {
                float fitPre = tmpPre - tmpOve;
                float oldPre = tmpPre;
                tmpPre = tmpPre / fitPre * prevMsLength;
                tmpOve = tmpOve / fitPre * prevMsLength;
                tmpStp = oldPre - tmpPre + tmpStp;
            }
            InitAtPre(tmpPre);
            InitAtOve(tmpOve);
            InitAtStp(tmpStp);
        }

        public int GetMsLength()
        {
            return (int)(60 / GetTempo() * GetLength() / 480 * 1000);
        }
    }
}
