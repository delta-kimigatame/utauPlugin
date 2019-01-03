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
        

        public Note()
        {
            num = new Entry<string>("");
            length = new Entry<int>(0);
            lyric = new Entry<string>("");
            noteNum = new NoteNum(60);
            pre = new Pre(0.0f);
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
        public void InitTempo(int tempo) => this.tempo = new Entry<float>(tempo);
        public void InitTempo(float tempo) => this.tempo = new Entry<float>(tempo);
        public void SetTempo(string tempo) => this.tempo.Set(float.Parse(tempo));
        public void SetTempo(int tempo) => this.tempo.Set(tempo);
        public void SetTempo(float tempo) => this.tempo.Set(tempo);
        public float GetTempo() => tempo.Get();
        public Boolean TempoIsChanged() => tempo.IsChanged();

        public void InitPre(string pre) => this.pre = new Pre(pre);
        public void InitPre(int pre) => this.pre = new Pre(pre);
        public void InitPre(float pre) => this.pre = new Pre(pre);
        public void SetPre(string pre) => this.pre.Set(pre);
        public void SetPre(int pre) => this.pre.Set(pre);
        public void SetPre(float pre) => this.pre.Set(pre);
        public float GetPre() => pre.Get();
        public Boolean PreIsChanged() => pre.IsChanged();
        public Boolean PreHasValue() => pre.HasValue();

        
        public void InitAtPre(string atPre) => this.atPre = new Entry<float>(float.Parse(atPre));
        public void InitAtPre(int atPre) => this.atPre = new Entry<float>(atPre);
        public void InitAtPre(float atPre) => this.atPre = new Entry<float>(atPre);
        public void SetAtPre(string atPre) => this.atPre.Set(float.Parse(atPre));
        public void SetAtPre(int atPre) => this.atPre.Set(atPre);
        public void SetAtPre(float atPre) => this.atPre.Set(atPre);
        public float GetAtPre() => atPre.Get();
        public Boolean AtPreIsChanged() => atPre.IsChanged();
        public Boolean HasAtPre() => (atPre != null);
        
        public void InitAtFileName(string atFileName) => this.atFileName = new Entry<string>(atFileName);
        public void SetAtFileName(string atFileName) => this.atFileName.Set(atFileName);
        public string GetAtFileName() => atFileName.Get();
        public Boolean AtFileNameIsChanged() => atFileName.IsChanged();
        public Boolean HasAtFileName() => (atFileName != null);
        
        public void InitAtAlias(string atAlias) => this.atAlias = new Entry<string>(atAlias);
        public void SetAtAlias(string atAlias) => this.atAlias.Set(atAlias);
        public string GetAtAlias() => atAlias.Get();
        public Boolean AtAliasIsChanged() => atAlias.IsChanged();
        public Boolean HasAtAlias() => (atAlias != null);

        
        public void InitOve(string ove) => this.ove = new Entry<float>(float.Parse(ove));
        public void InitOve(int ove) => this.ove = new Entry<float>(ove);
        public void InitOve(float ove) => this.ove = new Entry<float>(ove);
        public void SetOve(string ove) => this.ove.Set(float.Parse(ove));
        public void SetOve(int ove) => this.ove.Set(ove);
        public void SetOve(float ove) => this.ove.Set(ove);
        public float GetOve() => ove.Get();
        public Boolean OveIsChanged() => ove.IsChanged();
        public Boolean HasOve() => (ove != null);

        
        public void InitAtOve(string atOve) => this.atOve = new Entry<float>(float.Parse(atOve));
        public void InitAtOve(int atOve) => this.atOve = new Entry<float>(atOve);
        public void InitAtOve(float atOve) => this.atOve = new Entry<float>(atOve);
        public void SetAtOve(string atOve) => this.atOve.Set(float.Parse(atOve));
        public void SetAtOve(int atOve) => this.atOve.Set(atOve);
        public void SetAtOve(float atOve) => this.atOve.Set(atOve);
        public float GetAtOve() => atOve.Get();
        public Boolean AtOveIsChanged() => atOve.IsChanged();
        public Boolean HasAtOve() => (atOve != null);

        
        public void InitStp(string stp) => this.stp = new Entry<float>(float.Parse(stp));
        public void InitStp(int stp) => this.stp = new Entry<float>(stp);
        public void InitStp(float stp) => this.stp = new Entry<float>(stp);
        public void SetStp(string stp) => this.stp.Set(float.Parse(stp));
        public void SetStp(int stp) => this.stp.Set(stp);
        public void SetStp(float stp) => this.stp.Set(stp);
        public float GetStp() => stp.Get();
        public Boolean StpIsChanged() => stp.IsChanged();
        public Boolean HasStp() => (stp != null);

        
        public void InitAtStp(string atStp) => this.atStp = new Entry<float>(float.Parse(atStp));
        public void InitAtStp(int atStp) => this.atStp = new Entry<float>(atStp);
        public void InitAtStp(float atStp) => this.atStp = new Entry<float>(atStp);
        public void SetAtStp(string atStp) => this.atStp.Set(float.Parse(atStp));
        public void SetAtStp(int atStp) => this.atStp.Set(atStp);
        public void SetAtStp(float atStp) => this.atStp.Set(atStp);
        public float GetAtStp() => atStp.Get();
        public Boolean AtStpIsChanged() => atStp.IsChanged();
        public Boolean HasAtStp() => (atStp != null);


        private class Velocity
        {
            private int velocity;
            private Boolean isChanged;
            public Velocity(string velocity)
            {
                this.velocity = int.Parse(velocity);
                isChanged = false;
            }
            public Velocity(int velocity)
            {
                this.velocity = velocity;
                isChanged = false;
            }
            public void Set(string velocity) { this.velocity = int.Parse(velocity); isChanged = true; }
            public void Set(int velocity) { this.velocity = velocity; isChanged = true; }
            public int Get() => velocity;
            public Boolean IsChanged() => isChanged;
        }
        public void InitVelocity(string velocity) => this.velocity = new Entry<int>(int.Parse(velocity));
        public void InitVelocity(int velocity) => this.velocity = new Entry<int>(velocity);
        public void SetVelocity(string velocity) => this.velocity.Set(int.Parse(velocity));
        public void SetVelocity(int velocity) => this.velocity.Set(velocity);
        public int GetVelocity() => velocity.Get();
        public Boolean VelocityIsChanged() => velocity.IsChanged();
        public Boolean HasVelocity() => (velocity != null);

        public void InitIntensity(string intensity) => this.intensity = new Entry<int>(int.Parse(intensity));
        public void InitIntensity(int intensity) => this.intensity = new Entry<int>(intensity);
        public void SetIntensity(string intensity) => this.intensity.Set(int.Parse(intensity));
        public void SetIntensity(int intensity) => this.intensity.Set(intensity);
        public int GetIntensity() => intensity.Get();
        public Boolean IntensityIsChanged() => intensity.IsChanged();
        public Boolean HasIntensity() => (intensity != null);
        
        public void InitMod(string mod) => this.mod = new Entry<int>(int.Parse(mod));
        public void InitMod(int mod) => this.mod = new Entry<int>(mod);
        public void SetMod(string mod) => this.mod.Set(int.Parse(mod));
        public void SetMod(int mod) => this.mod.Set(mod);
        public int GetMod() => mod.Get();
        public Boolean ModIsChanged() => mod.IsChanged();
        public Boolean HasMod() => (mod != null);

        public void InitFlags(string flags) => this.flags = new Entry<string>(flags);
        public void SetFlags(string flags) => this.flags.Set(flags);
        public string GetFlags() => flags.Get();
        public Boolean FlagsIsChanged() => flags.IsChanged();
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
        public void SetPitches(string pitches) => this.pitches.Set(pitches);
        public void SetPitches(List<int> pitches) => this.pitches.Set(pitches);
        public List<int> GetPitches() => pitches.Get();
        public Boolean PitchesIsChanged() => pitches.IsChanged();
        public Boolean HasPitches() => (pitches != null);
        
        public void InitPbStart(string pbStart) => this.pbStart = new Entry<float>(float.Parse(pbStart));
        public void InitPbStart(int pbStart) => this.pbStart = new Entry<float>(pbStart);
        public void InitPbStart(float pbStart) => this.pbStart = new Entry<float>(pbStart);
        public void SetPbStart(string pbStart) => this.pbStart.Set(float.Parse(pbStart));
        public void SetPbStart(int pbStart) => this.pbStart.Set(pbStart);
        public void SetPbStart(float pbStart) => this.pbStart.Set(pbStart);
        public float GetPbStart() => pbStart.Get();
        public Boolean PbStartIsChanged() => pbStart.IsChanged();
        public Boolean HasPbStart() => (pbStart != null);
        
        public void InitPbType(string pbType) => this.pbType = new Entry<string>(pbType);
        public void SetPbType(string pbType) => this.pbType.Set(pbType);
        public string GetPbType() => pbType.Get();
        public Boolean PbTypeIsChanged() => pbType.IsChanged();
        public Boolean HasPbType() => (pbType != null);
        
        public Boolean HasMode2Pitch() => (mode2Pitch != null);
        public void InitMode2Pitch() => mode2Pitch = new Mode2Pitch();

        public void InitPbs(string pbs) => mode2Pitch.InitPbs(pbs);
        public void SetPbs(string pbs) => mode2Pitch.SetPbs(pbs);
        public string GetPbs() => mode2Pitch.GetPbs();
        public float GetPbsTime() => mode2Pitch.GetPbsTime();
        public float GetPbsHeight() => mode2Pitch.GetPbsHeight();
        public Boolean PbsIsChanged() => mode2Pitch.PbsIsChanged();

        public void InitPbw(string pbw) => mode2Pitch.InitPbw(pbw);
        public void SetPbw(string pbw) => mode2Pitch.SetPbw(pbw);
        public void SetPbw(string pbw, int point) => mode2Pitch.SetPbw(pbw, point);
        public void SetPbw(int pbw, int point) => mode2Pitch.SetPbw(pbw, point);
        public void SetPbw(List<float> pbw) => mode2Pitch.SetPbw(pbw);
        public List<float> GetPbw() => mode2Pitch.GetPbw();
        public Boolean PbwIsChanged() => mode2Pitch.PbwIsChanged();

        public void InitPby(string pby) => mode2Pitch.InitPby(pby);
        public void SetPby(string pby) => mode2Pitch.SetPby(pby);
        public void SetPby(string pby, int point) => mode2Pitch.SetPby(pby, point);
        public void SetPby(int pby, int point) => mode2Pitch.SetPby(pby, point);
        public void SetPby(List<float> pby) => mode2Pitch.SetPby(pby);
        public List<float> GetPby() => mode2Pitch.GetPby();
        public Boolean PbyIsChanged() => mode2Pitch.PbyIsChanged();

        public void InitPbm(string pbm) => mode2Pitch.InitPbm(pbm);
        public void SetPbm(string pbm) => mode2Pitch.SetPbm(pbm);
        public void SetPbm(string pbm, int point) => mode2Pitch.SetPbm(pbm, point);
        public void SetPbm(List<string> pbm) => mode2Pitch.SetPbm(pbm);
        public List<string> GetPbm() => mode2Pitch.GetPbm();
        public Boolean PbmIsChanged() => mode2Pitch.PbmIsChanged();

        public void InitEnvelope() => envelope = new Envelope();
        public void InitEnvelope(string envelope) => this.envelope = new Envelope(envelope);
        public void SetEnvelope(string envelope) => this.envelope.Set(envelope);
        public string GetEnvelope() => envelope.Get();
        public Boolean EnvelopeIsChanged() => envelope.IsChanged();
        public Boolean HasEnvelope() => (envelope != null);

        public void InitVibrato() => vibrato = new Vibrato();
        public void InitVibrato(string vibrato) => this.vibrato = new Vibrato(vibrato);
        public void SetVibrato(string vibrato) => this.vibrato.Set(vibrato);
        public string GetVibrato() => vibrato.Get();
        public Boolean VibratoIsChanged() => vibrato.IsChanged();
        public Boolean HasVibrato() => (vibrato != null);
        
        public void InitLabel(string label) => this.label = new Entry<string>(label);
        public void SetLabel(string label) => this.label.Set(label);
        public string GetLabel() => label.Get();
        public Boolean LabelIsChanged() => label.IsChanged();
        public Boolean HasLabel() => (label != null);
        
        public void InitDirect(Boolean direct) => this.direct = new Entry<Boolean>(direct);
        public void InitDirect(string direct) => this.direct = new Entry<Boolean>(Boolean.Parse(direct));
        public void SetDirect(Boolean direct) => this.direct.Set(direct);
        public void SetDirect(string direct) => this.direct.Set(Boolean.Parse(direct));
        public Boolean GetDirect() => this.direct.Get();
        public Boolean DirectIsChanged() => direct.IsChanged();
        public Boolean HasDirect() => (direct != null);


        public void InitRegion(string region) => this.region = new Entry<string>(region);
        public void SetRegion(string region) => this.region.Set(region);
        public string GetRegion() => region.Get();
        public Boolean RegionIsChanged() => region.IsChanged();
        public Boolean HasRegion() => (region != null);


        private class RegionEnd
        {
            private string regionEnd;
            private Boolean isChanged;
            public RegionEnd(string regionEnd)
            {
                this.regionEnd = regionEnd;
                isChanged = false;
            }
            public void Set(string regionEnd) { this.regionEnd = regionEnd; isChanged = true; }
            public string Get() => regionEnd;
            public Boolean IsChanged() => isChanged;

        }
        public void InitRegionEnd(string regionEnd) => this.regionEnd = new Entry<string>(regionEnd);
        public void SetRegionEnd(string regionEnd) => this.regionEnd.Set(regionEnd);
        public string GetRegionEnd() => regionEnd.Get();
        public Boolean RegionEndIsChanged() => regionEnd.IsChanged();
        public Boolean HasRegionEnd() => (regionEnd != null);

    }
}
