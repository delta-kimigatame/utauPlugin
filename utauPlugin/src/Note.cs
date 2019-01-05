using System;
using System.Collections.Generic;

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

        //定義されていないパラメータをGetされた時用のデフォルトパラメータ
        //原音設定値に依存するpre,oveはデフォルト値は普通使いませんが一応定義
        private const string DEFAULT_NUM = "";
        private const int DEFAULT_LENGTH = 480;
        private const string DEFAULT_LYRIC = "";
        private const int DEFAULT_NOTENUM = 60;
        private const float DEFAULT_TEMPO = 120.0f;
        private const float DEFAULT_PRE = 0f;
        private const float DEFAULT_ATPRE = 0f;
        private const string DEFAULT_ATFILENAME = "";
        private const string DEFAULT_ATALIAS = "";
        private const float DEFAULT_OVE = 0f;
        private const float DEFAULT_ATOVE = 0f;
        private const float DEFAULT_STP = 0f;
        private const float DEFAULT_ATSTP = 0f;
        private const int DEFAULT_VELOCITY = 100;
        private const int DEFAULT_INTENSITY = 100;
        private const int DEFAULT_MOD = 0;
        private const string DEFAULT_FLAGS = "";
        private const float DEFAULT_PBSTART = 0f;
        private IReadOnlyList<int> DEFAULT_PITCHES = new List<int>() { }.AsReadOnly();
        private const string DEFAULT_PBTYPE = "5";
        private const string DEFAULT_PBS = "-25";
        private const float DEFAULT_PBS_TIME = -25f;
        private const float DEFAULT_PBS_HEIGHT = 0f;
        private IReadOnlyList<float> DEFAULT_PBW = new List<float>() {50}.AsReadOnly();
        private IReadOnlyList<float> DEFAULT_PBY = new List<float>() { }.AsReadOnly();
        private IReadOnlyList<string> DEFAULT_PBM = new List<string>() { }.AsReadOnly();
        private const string DEFAULT_ENVELOPE = "0,5,35,0,100,100,0";
        private const string DEFAULT_VIBRATO = "65,180,35,20,20,0,0,0";
        private const string DEFAULT_LABEL = "";
        private const Boolean DEFAULT_DIRECT = false;
        private const string DEFAULT_REGION = "";
        private const string DEFAULT_REGIONEND = "";




        public Note()
        {
            num = new Entry<string>(DEFAULT_NUM);
            length = new Entry<int>(DEFAULT_LENGTH);
            lyric = new Entry<string>(DEFAULT_LYRIC);
            noteNum = new NoteNum(DEFAULT_NOTENUM);
            pre = new Pre(DEFAULT_PRE);
        }
        
        public void InitNum(string num) => this.num = new Entry<string>(num);
        public void SetNum(string num) => this.num.Set(num);
        public string GetNum() => num.Get();
        
        public void InitLength(string length) => this.length = new Entry<int>(int.Parse(length));
        public void InitLength(int length) => this.length = new Entry<int>(length);
        public void SetLength(string length) => this.length.Set(int.Parse(length));
        public void SetLength(int length) => this.length.Set(length);
        public int GetLength() => length.Get();
        public Boolean LengthIsChanged() => length.IsChanged();
        
        public void InitLyric(string lyric) => this.lyric = new Entry<string>(lyric);
        public void SetLyric(string lyric) => this.lyric.Set(lyric);
        public string GetLyric() => lyric.Get();
        public Boolean LyricIsChanged() => lyric.IsChanged();

        public void InitNoteNum(string noteNum) => this.noteNum = new NoteNum(noteNum);
        public void InitNoteNum(int noteNum) => this.noteNum = new NoteNum(noteNum);
        public void SetNoteNum(string noteNum) => this.noteNum.Set(noteNum);
        public void SetNoteNum(int noteNum) => this.noteNum.Set(noteNum);
        public int GetNoteNum() => noteNum.Get();
        public string GetNoteNumName() => noteNum.GetName();
        public string GetKey() => noteNum.GetKey();
        public Boolean NoteNumIsChanged() => noteNum.IsChanged();
        
        public void InitTempo(string tempo) => this.tempo = new Entry<float>(float.Parse(tempo));
        public void InitTempo(float tempo) => this.tempo = new Entry<float>(tempo);
        public void SetTempo(string tempo) => this.tempo.Set(float.Parse(tempo));
        public void SetTempo(int tempo) => this.tempo.Set(tempo);
        public void SetTempo(float tempo) => this.tempo.Set(tempo);
        public float GetTempo() => HasTempo() ? tempo.Get() : DEFAULT_TEMPO;
        public Boolean TempoIsChanged() => tempo.IsChanged();
        public Boolean HasTempo() => (tempo != null);

        public void InitPre(string pre) => this.pre = new Pre(pre);
        public void InitPre(float pre) => this.pre = new Pre(pre);
        public void SetPre(string pre) => this.pre.Set(pre);
        public void SetPre(float pre) => this.pre.Set(pre);
        public float GetPre() => pre.Get();
        public Boolean PreIsChanged() => pre.IsChanged();
        public Boolean PreHasValue() => pre.HasValue();

        
        public void InitAtPre(string atPre) => this.atPre = new Entry<float>(float.Parse(atPre));
        public void InitAtPre(float atPre) => this.atPre = new Entry<float>(atPre);
        public void SetAtPre(string atPre)
        {
            if (HasAtPre()) { this.atPre.Set(float.Parse(atPre)); }
            else
            {
                this.atPre = new Entry<float>(0);
                this.atPre.Set(float.Parse(atPre));
            }
        }
        public void SetAtPre(float atPre)
        {
            if (HasAtPre()) { this.atPre.Set(atPre); }
            else
            {
                this.atPre = new Entry<float>(0);
                this.atPre.Set(atPre);
            }
        }

        public float GetAtPre() => HasAtPre() ? atPre.Get() : DEFAULT_ATPRE;
        public Boolean AtPreIsChanged() => (HasAtPre() && atPre.IsChanged());
        public Boolean HasAtPre() => (atPre != null);
        
        public void InitAtFileName(string atFileName) => this.atFileName = new Entry<string>(atFileName);
        public void SetAtFileName(string atFileName)
        {
            if (HasAtFileName()) { this.atFileName.Set(atFileName); }
            else
            {
                this.atFileName = new Entry<string>("");
                this.atFileName.Set(atFileName);
            }
        }

        public string GetAtFileName() => HasAtFileName() ? atFileName.Get() : DEFAULT_ATFILENAME;
        public Boolean AtFileNameIsChanged() => (HasAtFileName() && atFileName.IsChanged());
        public Boolean HasAtFileName() => (atFileName != null);

        public void InitAtAlias(string atAlias) => this.atAlias = new Entry<string>(atAlias);
        public void SetAtAlias(string atAlias)
        {
            if (HasAtAlias()) { this.atAlias.Set(atAlias); }
            else
            {
                this.atAlias = new Entry<string>("");
                this.atAlias.Set(atAlias);
            }
        }

        public string GetAtAlias() => HasAtAlias() ? atAlias.Get() : DEFAULT_ATALIAS;
        public Boolean AtAliasIsChanged() => (HasAtAlias() && atAlias.IsChanged());
        public Boolean HasAtAlias() => (atAlias != null);


        public void InitOve(string ove) => this.ove = new Entry<float>(float.Parse(ove));
        public void InitOve(float ove) => this.ove = new Entry<float>(ove);
        public void SetOve(string ove)
        {
            if (HasOve()) { this.ove.Set(float.Parse(ove)); }
            else
            {
                this.ove = new Entry<float>(0);
                this.ove.Set(float.Parse(ove));
            }
        }
        public void SetOve(float ove)
        {
            if (HasOve()) { this.ove.Set(ove); }
            else
            {
                this.ove = new Entry<float>(0);
                this.ove.Set(ove);
            }
        }

        public float GetOve() => HasOve() ? ove.Get() : DEFAULT_OVE;
        public Boolean OveIsChanged() => (HasOve() && ove.IsChanged());
        public Boolean HasOve() => (ove != null);


        public void InitAtOve(string atOve) => this.atOve = new Entry<float>(float.Parse(atOve));
        public void InitAtOve(float atOve) => this.atOve = new Entry<float>(atOve);
        public void SetAtOve(string atOve)
        {
            if (HasAtOve()) { this.atOve.Set(float.Parse(atOve)); }
            else
            {
                this.atOve = new Entry<float>(0);
                this.atOve.Set(float.Parse(atOve));
            }
        }
        public void SetAtOve(float atOve)
        {
            if (HasAtOve()) { this.atOve.Set(atOve); }
            else
            {
                this.atOve = new Entry<float>(0);
                this.atOve.Set(atOve);
            }
        }

        public float GetAtOve() => HasAtOve() ? atOve.Get() : DEFAULT_ATOVE;
        public Boolean AtOveIsChanged() => (HasAtOve() && atOve.IsChanged());
        public Boolean HasAtOve() => (atOve != null);


        public void InitStp(string stp) => this.stp = new Entry<float>(float.Parse(stp));
        public void InitStp(float stp) => this.stp = new Entry<float>(stp);
        public void SetStp(string stp)
        {
            if (HasStp()) { this.stp.Set(float.Parse(stp)); }
            else
            {
                this.stp = new Entry<float>(0);
                this.stp.Set(float.Parse(stp));
            }
        }
        public void SetStp(float stp)
        {
            if (HasStp()) { this.stp.Set(stp); }
            else
            {
                this.stp = new Entry<float>(0);
                this.stp.Set(stp);
            }
        }

        public float GetStp() => HasStp() ? stp.Get() : DEFAULT_STP;
        public Boolean StpIsChanged() => (HasStp() && stp.IsChanged());
        public Boolean HasStp() => (stp != null);


        public void InitAtStp(string atStp) => this.atStp = new Entry<float>(float.Parse(atStp));
        public void InitAtStp(float atStp) => this.atStp = new Entry<float>(atStp);
        public void SetAtStp(string atStp)
        {
            if (HasAtStp()) { this.atStp.Set(float.Parse(atStp)); }
            else
            {
                this.atStp = new Entry<float>(0);
                this.atStp.Set(float.Parse(atStp));
            }
        }
        public void SetAtStp(float atStp)
        {
            if (HasAtStp()) { this.atStp.Set(atStp); }
            else
            {
                this.atStp = new Entry<float>(0);
                this.atStp.Set(atStp);
            }
        }

        public float GetAtStp() => HasAtStp() ? atStp.Get() : DEFAULT_ATSTP;
        public Boolean AtStpIsChanged() => (HasAtStp() && atStp.IsChanged());
        public Boolean HasAtStp() => (atStp != null);
        
        public void InitVelocity(string velocity) => this.velocity = new Entry<int>(int.Parse(velocity));
        public void InitVelocity(int velocity) => this.velocity = new Entry<int>(velocity);
        public void SetVelocity(string velocity)
        {
            if (HasVelocity()) { this.velocity.Set(int.Parse(velocity)); }
            else
            {
                this.velocity = new Entry<int>(0);
                this.velocity.Set(int.Parse(velocity));
            }
        }

        public void SetVelocity(int velocity)
        {
            if (HasVelocity()) { this.velocity.Set(velocity); }
            else
            {
                this.velocity = new Entry<int>(0);
                this.velocity.Set(velocity);
            }
        }

        public int GetVelocity() => HasVelocity() ? velocity.Get() : DEFAULT_VELOCITY;
        public Boolean VelocityIsChanged() => (HasVelocity() && velocity.IsChanged());
        public Boolean HasVelocity() => (velocity != null);
        

        public void InitIntensity(string intensity) => this.intensity = new Entry<int>(int.Parse(intensity));
        public void InitIntensity(int intensity) => this.intensity = new Entry<int>(intensity);
        public void SetIntensity(string intensity)
        {
            if (HasIntensity()) { this.intensity.Set(int.Parse(intensity)); }
            else
            {
                this.intensity = new Entry<int>(0);
                this.intensity.Set(int.Parse(intensity));
            }
        }

        public void SetIntensity(int intensity)
        {
            if (HasIntensity()) { this.intensity.Set(intensity); }
            else
            {
                this.intensity = new Entry<int>(0);
                this.intensity.Set(intensity);
            }
        }

        public int GetIntensity() => HasIntensity() ? intensity.Get() : DEFAULT_INTENSITY;
        public Boolean IntensityIsChanged() => (HasIntensity() && intensity.IsChanged());
        public Boolean HasIntensity() => (intensity != null);


        public void InitMod(string mod) => this.mod = new Entry<int>(int.Parse(mod));
        public void InitMod(int mod) => this.mod = new Entry<int>(mod);
        public void SetMod(string mod)
        {
            if (HasMod()) { this.mod.Set(int.Parse(mod)); }
            else
            {
                this.mod = new Entry<int>(0);
                this.mod.Set(int.Parse(mod));
            }
        }

        public void SetMod(int mod)
        {
            if (HasMod()) { this.mod.Set(mod); }
            else
            {
                this.mod = new Entry<int>(0);
                this.mod.Set(mod);
            }
        }

        public int GetMod() => HasMod() ? mod.Get() : DEFAULT_MOD;
        public Boolean ModIsChanged() => (HasMod() && mod.IsChanged());
        public Boolean HasMod() => (mod != null);



        public void InitFlags(string flags) => this.flags = new Entry<string>(flags);
        public void SetFlags(string flags)
        {
            if (HasFlags()) { this.flags.Set(flags); }
            else
            {
                this.flags = new Entry<string>("");
                this.flags.Set(flags);
            }
        }

        public string GetFlags() => HasFlags() ? flags.Get() : DEFAULT_FLAGS;
        public Boolean FlagsIsChanged() => (HasFlags() && flags.IsChanged());
        public Boolean HasFlags() => (flags != null);


        private class Pitches
        {
            private List<int> pitches;
            private Boolean isChanged;
            public Pitches(string pitches)
            {
                this.pitches = new List<int>();
                foreach (string x in pitches.Split(','))
                {
                    if (x != "") { this.pitches.Add(int.Parse(x)); }
                    else { this.pitches.Add(0); }
                    
                }
            }
            public void Set(string pitches)
            {
                this.pitches.Clear();
                foreach (string x in pitches.Split(','))
                {
                    if (x != "") { this.pitches.Add(int.Parse(x)); }
                    else { this.pitches.Add(0); }
                }
                isChanged = true;
            }
            public void Set(List<int> pitches)
            {
                this.pitches.Clear();
                this.pitches.AddRange(pitches);
                isChanged = true;
            }
            public List<int> Get() => pitches;
            public Boolean IsChanged() => isChanged;

        }
        public void InitPitches(string pitches) => this.pitches=new Pitches(pitches);
        public void SetPitches(string pitches)
        {
            if (HasPitches()) { this.pitches.Set(pitches); }
            else
            {
                this.pitches = new Pitches("");
                this.pitches.Set(pitches);
            }
        }

        public void SetPitches(List<int> pitches)
        {
            if (HasPitches()) { this.pitches.Set(pitches); }
            else
            {
                this.pitches = new Pitches("");
                this.pitches.Set(pitches);
            }
        }

        public List<int> GetPitches() => HasPitches() ? pitches.Get() : new List<int>(DEFAULT_PITCHES);
        public Boolean PitchesIsChanged() => (HasPitches() && pitches.IsChanged());
        public Boolean HasPitches() => (pitches != null);

        public void InitPbStart(string pbStart) => this.pbStart = new Entry<float>(float.Parse(pbStart));
        public void InitPbStart(float pbStart) => this.pbStart = new Entry<float>(pbStart);
        public void SetPbStart(string pbStart)
        {
            if (HasPbStart()) { this.pbStart.Set(float.Parse(pbStart)); }
            else
            {
                this.pbStart = new Entry<float>(0);
                this.pbStart.Set(float.Parse(pbStart));
            }
        }
        public void SetPbStart(float pbStart)
        {
            if (HasPbStart()) { this.pbStart.Set(pbStart); }
            else
            {
                this.pbStart = new Entry<float>(0);
                this.pbStart.Set(pbStart);
            }
        }

        public float GetPbStart() => HasPbStart() ? pbStart.Get() : DEFAULT_PBSTART;
        public Boolean PbStartIsChanged() => (HasPbStart() && pbStart.IsChanged());
        public Boolean HasPbStart() => (pbStart != null);


        public void InitPbType(string pbType) => this.pbType = new Entry<string>(pbType);
        public void SetPbType(string pbType)
        {
            if (HasPbType()){ this.pbType.Set(pbType);} 
            
            else
            {
                this.pbType = new Entry<string>("");
                this.pbType.Set(pbType);
            }
        }

        public string GetPbType() => HasPbType() ? pbType.Get() : DEFAULT_PBTYPE;
        public Boolean PbTypeIsChanged() => (HasPbType() && pbType.IsChanged());
        public Boolean HasPbType() => (pbType != null);
        
        public Boolean HasMode2Pitch() => (mode2Pitch != null);
        public void InitMode2Pitch() => mode2Pitch = new Mode2Pitch();

        public void InitPbs(string pbs) => mode2Pitch.InitPbs(pbs);
        public void SetPbs(string pbs)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbs(pbs); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbs(pbs);
            }
        }

        public string GetPbs() => HasMode2Pitch() ? mode2Pitch.GetPbs() : DEFAULT_PBS;
        public float GetPbsTime() => HasMode2Pitch() ? mode2Pitch.GetPbsTime() : DEFAULT_PBS_TIME;
        public float GetPbsHeight() => HasMode2Pitch() ? mode2Pitch.GetPbsHeight() : DEFAULT_PBS_HEIGHT;
        public Boolean PbsIsChanged() => (HasMode2Pitch() && mode2Pitch.PbsIsChanged());

        public void InitPbw(string pbw) => mode2Pitch.InitPbw(pbw);
        public void SetPbw(string pbw)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbw(pbw); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbw(pbw);
            }
        }

        public void SetPbw(string pbw, int point)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbw(pbw, point); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbw(pbw, point);
            }
        }

        public void SetPbw(int pbw, int point)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbw(pbw, point); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbw(pbw, point);
            }
        }

        public void SetPbw(List<float> pbw)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbw(pbw); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbw(pbw);
            }
        }

        public List<float> GetPbw() => HasMode2Pitch() ? mode2Pitch.GetPbw() : new List<float>(DEFAULT_PBW);
        public Boolean PbwIsChanged() => (HasMode2Pitch() && mode2Pitch.PbwIsChanged());

        public void InitPby(string pby) => mode2Pitch.InitPby(pby);
        public void SetPby(string pby)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPby(pby); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPby(pby);
            }
        }

        public void SetPby(string pby, int point)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPby(pby, point); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPby(pby, point);
            }
        }

        public void SetPby(int pby, int point)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPby(pby, point); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPby(pby, point);
            }
        }

        public void SetPby(List<float> pby)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPby(pby); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPby(pby);
            }
        }

        public List<float> GetPby() => HasMode2Pitch() ? mode2Pitch.GetPby() : new List<float>(DEFAULT_PBY);
        public Boolean PbyIsChanged() => (HasMode2Pitch() && mode2Pitch.PbyIsChanged());

        public void InitPbm(string pbm) => mode2Pitch.InitPbm(pbm); public void SetPbm(string pbm)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbm(pbm); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbm(pbm);
            }
        }

        public void SetPbm(string pbm, int point)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbm(pbm, point); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbm(pbm, point);
            }
        }


        public void SetPbm(List<string> pbm)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbm(pbm); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbm(pbm);
            }
        }
        public List<string> GetPbm() => HasMode2Pitch() ? mode2Pitch.GetPbm() : new List<string>(DEFAULT_PBM);
        public Boolean PbmIsChanged() => (HasMode2Pitch() && mode2Pitch.PbmIsChanged());

        public void InitEnvelope() => envelope = new Envelope();
        public void InitEnvelope(string envelope) => this.envelope = new Envelope(envelope);
        public void SetEnvelope(string envelope)
        {
            if (HasEnvelope()) { this.envelope.Set(envelope); }
            else
            {
                this.envelope = new Envelope();
                this.envelope.Set(envelope);
            }
        }

        public string GetEnvelope() => HasEnvelope() ? envelope.Get() : DEFAULT_ENVELOPE;
        public Boolean EnvelopeIsChanged() => (HasEnvelope() && envelope.IsChanged());
        public Boolean HasEnvelope() => (envelope != null);

        public void InitVibrato() => vibrato = new Vibrato();
        public void InitVibrato(string vibrato) => this.vibrato = new Vibrato(vibrato);
        public void SetVibrato(string vibrato)
        {
            if (HasVibrato()) { this.vibrato.Set(vibrato); }
            else
            {
                this.vibrato = new Vibrato();
                this.vibrato.Set(vibrato);
            }
        }

        public string GetVibrato() => HasVibrato() ? vibrato.Get() : DEFAULT_VIBRATO;
        public Boolean VibratoIsChanged() => (HasVibrato() && vibrato.IsChanged());
        public Boolean HasVibrato() => (vibrato != null);

        public void InitLabel(string label) => this.label = new Entry<string>(label);
        public void SetLabel(string label)
        {
            if (HasLabel()) { this.label.Set(label); }
            else
            {
                this.label = new Entry<string>("");
                this.label.Set(label);
            }
        }

        public string GetLabel() => HasLabel() ? label.Get() : DEFAULT_LABEL;
        public Boolean LabelIsChanged() => (HasLabel() && label.IsChanged());
        public Boolean HasLabel() => (label != null);



        public void InitDirect(Boolean direct) => this.direct = new Entry<Boolean>(direct);
        public void InitDirect(string direct) => this.direct = new Entry<Boolean>(Boolean.Parse(direct));
        public void SetDirect(Boolean direct)
        {
            if (HasDirect()) { this.direct.Set(direct); }
            else
            {
                this.direct = new Entry<Boolean>(false);
                this.direct.Set(direct);
            }
            
        }

        public void SetDirect(string direct)
        {
            if (HasDirect()) { this.direct.Set(Boolean.Parse(direct)); }
            else
            {
                this.direct = new Entry<Boolean>(false);
                this.direct.Set(Boolean.Parse(direct));
            }
        }

        public Boolean GetDirect() => HasDirect() ? this.direct.Get() : DEFAULT_DIRECT;
        public Boolean DirectIsChanged() => (HasDirect() && direct.IsChanged());
        public Boolean HasDirect() => (direct != null);



        public void InitRegion(string region) => this.region = new Entry<string>(region);
        public void SetRegion(string region)
        {
            if (HasRegion()) { this.region.Set(region); }
            else
            {
                this.region = new Entry<string>("");
                this.region.Set(region);
            }
        }

        public string GetRegion() => HasRegion() ? region.Get(): DEFAULT_REGION;
        public Boolean RegionIsChanged() => (HasRegion() && region.IsChanged());
        public Boolean HasRegion() => (region != null);




        public void InitRegionEnd(string regionEnd) => this.regionEnd = new Entry<string>(regionEnd);
        public void SetRegionEnd(string regionEnd)
        {
            if (HasRegionEnd()) { this.regionEnd.Set(regionEnd); }
            else
            {
                this.regionEnd = new Entry<string>("");
                this.regionEnd.Set(regionEnd);
            }
        }

        public string GetRegionEnd() => HasRegionEnd() ? regionEnd.Get() : DEFAULT_REGIONEND;
        public Boolean RegionEndIsChanged() => (HasRegionEnd() && regionEnd.IsChanged());
        public Boolean HasRegionEnd() => (regionEnd != null);



    }
}
