using System;
using System.Collections.Generic;

namespace utauPlugin
{

    public class Note
    {
        private Num num;
        private Length length;
        private Lyric lyric;
        private NoteNum noteNum;
        private Tempo tempo;
        private Pre pre;
        private AtPre atPre;
        private AtFileName atFileName;
        private AtAlias atAlias;
        private Ove ove;
        private AtOve atOve;
        private Stp stp;
        private AtStp atStp;
        private Velocity velocity;
        private Intensity intensity;
        private Mod mod;
        private Flags flags;
        private Pitches pitches;
        private PbStart pbStart;
        private PbType pbType;
        private Mode2Pitch mode2Pitch;
        public Envelope envelope;
        public Vibrato vibrato;
        private Label label;
        private Direct direct;
        private Region region;
        private RegionEnd regionEnd;

        public Note()
        {
            num = new Num("");
            length = new Length(0);
            lyric = new Lyric("");
            noteNum = new NoteNum(60);
            pre = new Pre(0.0f);
        }

        private class Num
        {
            private string num;
            public Num(string num)
            {
                this.num = num;
            }
            public void Set(string num) => this.num = num;
            public string Get() => num;
        }
        public void InitNum(string num) => this.num = new Num(num);
        public void SetNum(string num) => this.num.Set(num);
        public string GetNum() => num.Get();

        private class Length
        {
            private int length;
            private Boolean isChanged;
            public Length(string length)
            {
                this.length = int.Parse(length);
                isChanged = false;
            }
            public Length(int length)
            {
                this.length = length;
                isChanged = false;
            }
            public void Set(string length) { this.length = int.Parse(length); isChanged = true; }
            public void Set(int length) { this.length = length; isChanged = true; }
            public int Get() => length;
            public Boolean IsChanged() => isChanged;
        }
        public void InitLength(string length) => this.length = new Length(length);
        public void InitLength(int length) => this.length = new Length(length);
        public void SetLength(string length) => this.length.Set(length);
        public void SetLength(int length) => this.length.Set(length);
        public int GetLength() => length.Get();
        public Boolean LengthIsChanged() => length.IsChanged();

        private class Lyric
        {
            private string lyric;
            private Boolean isChanged;
            public Lyric(string lyric)
            {
                this.lyric = lyric;
                isChanged = false;
            }
            public void Set(string lyric) { this.lyric = lyric; isChanged = true; }
            public string Get() => lyric;
            public Boolean IsChanged() => isChanged;

        }
        public void InitLyric(string lyric) => this.lyric = new Lyric(lyric);
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

        private class Tempo
        {
            private float tempo;
            private Boolean isChanged;

            public Tempo(string tempo)
            {
                this.tempo = float.Parse(tempo);
                isChanged = false;
            }
            public Tempo(int tempo)
            {
                this.tempo = (float)tempo;
                isChanged = false;
            }
            public Tempo(float tempo)
            {
                this.tempo = tempo;
                isChanged = false;
            }
            public void Set(string tempo) { this.tempo = float.Parse(tempo); isChanged = true; }
            public void Set(int tempo) { this.tempo = tempo; isChanged = true; }
            public void Set(float tempo) { this.tempo = tempo; isChanged = true; }
            public float Get() => tempo;
            public Boolean IsChanged() => isChanged;
        }
        public void InitTempo(string tempo) => this.tempo = new Tempo(tempo);
        public void InitTempo(int tempo) => this.tempo = new Tempo(tempo);
        public void InitTempo(float tempo) => this.tempo = new Tempo(tempo);
        public void SetTempo(string tempo) => this.tempo.Set(tempo);
        public void SetTempo(int tempo) => this.tempo.Set(tempo);
        public void SetTempo(float tempo) => this.tempo.Set(tempo);
        public float GetTempo() => tempo.Get();
        public Boolean TempoIsChanged() => tempo.IsChanged();

        private class Pre
        {
            private float pre;
            private Boolean hasValue;
            private Boolean isChanged;

            public Pre(string pre)
            {
                if (pre == "")
                {
                    this.pre = 0.0f;
                    isChanged = false;
                    hasValue = false;
                }
                else
                {
                    this.pre = float.Parse(pre);
                    isChanged = false;
                    hasValue = true;
                }
            }
            public Pre(int pre)
            {
                this.pre = (float)pre;
                hasValue = true;
                isChanged = false;
            }
            public Pre(float pre)
            {
                this.pre = pre;
                hasValue = true;
                isChanged = false;
            }
            public void Set(string pre) { this.pre = float.Parse(pre); isChanged = true; hasValue = true; }
            public void Set(int pre) { this.pre = pre; isChanged = true; hasValue = true; }
            public void Set(float pre) { this.pre = pre; isChanged = true; }
            public float Get() => pre;
            public Boolean IsChanged() => isChanged;
            public Boolean HasValue() => hasValue;
        }
        public void InitPre(string pre) => this.pre = new Pre(pre);
        public void InitPre(int pre) => this.pre = new Pre(pre);
        public void InitPre(float pre) => this.pre = new Pre(pre);
        public void SetPre(string pre) => this.pre.Set(pre);
        public void SetPre(int pre) => this.pre.Set(pre);
        public void SetPre(float pre) => this.pre.Set(pre);
        public float GetPre() => pre.Get();
        public Boolean PreIsChanged() => pre.IsChanged();
        public Boolean PreHasValue() => pre.HasValue();


        private class AtPre
        {
            private float atPre;
            private Boolean isChanged;

            public AtPre(string atPre)
            {
                this.atPre = float.Parse(atPre);
                isChanged = false;
            }
            public AtPre(int atPre)
            {
                this.atPre = (float)atPre;
                isChanged = false;
            }
            public AtPre(float atPre)
            {
                this.atPre = atPre;
                isChanged = false;
            }
            public void Set(string atPre) { this.atPre = float.Parse(atPre); isChanged = true; }
            public void Set(int atPre) { this.atPre = atPre; isChanged = true; }
            public void Set(float atPre) { this.atPre = atPre; isChanged = true; }
            public float Get() => atPre;
            public Boolean IsChanged() => isChanged;
        }
        public void InitAtPre(string atPre) => this.atPre = new AtPre(atPre);
        public void InitAtPre(int atPre) => this.atPre = new AtPre(atPre);
        public void InitAtPre(float atPre) => this.atPre = new AtPre(atPre);
        public void SetAtPre(string atPre) => this.atPre.Set(atPre);
        public void SetAtPre(int atPre) => this.atPre.Set(atPre);
        public void SetAtPre(float atPre) => this.atPre.Set(atPre);
        public float GetAtPre() => atPre.Get();
        public Boolean AtPreIsChanged() => atPre.IsChanged();
        public Boolean HasAtPre() => (atPre != null);

        private class AtFileName
        {
            private string atFileName;
            private Boolean isChanged;
            public AtFileName(string atFileName)
            {
                this.atFileName = atFileName;
                isChanged = false;
            }
            public void Set(string atFileName) { this.atFileName = atFileName; isChanged = true; }
            public string Get() => atFileName;
            public Boolean IsChanged() => isChanged;

        }
        public void InitAtFileName(string atFileName) => this.atFileName = new AtFileName(atFileName);
        public void SetAtFileName(string atFileName) => this.atFileName.Set(atFileName);
        public string GetAtFileName() => atFileName.Get();
        public Boolean AtFileNameIsChanged() => atFileName.IsChanged();
        public Boolean HasAtFileName() => (atFileName != null);


        private class AtAlias
        {
            private string atAlias;
            private Boolean isChanged;
            public AtAlias(string atAlias)
            {
                this.atAlias = atAlias;
                isChanged = false;
            }
            public void Set(string atAlias) { this.atAlias = atAlias; isChanged = true; }
            public string Get() => atAlias;
            public Boolean IsChanged() => isChanged;

        }
        public void InitAtAlias(string atAlias) => this.atAlias = new AtAlias(atAlias);
        public void SetAtAlias(string atAlias) => this.atAlias.Set(atAlias);
        public string GetAtAlias() => atAlias.Get();
        public Boolean AtAliasIsChanged() => atAlias.IsChanged();
        public Boolean HasAtAlias() => (atAlias != null);


        private class Ove
        {
            private float ove;
            private Boolean isChanged;

            public Ove(string ove)
            {
                this.ove = float.Parse(ove);
                isChanged = false;
            }
            public Ove(int ove)
            {
                this.ove = (float)ove;
                isChanged = false;
            }
            public Ove(float ove)
            {
                this.ove = ove;
                isChanged = false;
            }
            public void Set(string ove) { this.ove = float.Parse(ove); isChanged = true; }
            public void Set(int ove) { this.ove = ove; isChanged = true; }
            public void Set(float ove) { this.ove = ove; isChanged = true; }
            public float Get() => ove;
            public Boolean IsChanged() => isChanged;
        }
        public void InitOve(string ove) => this.ove = new Ove(ove);
        public void InitOve(int ove) => this.ove = new Ove(ove);
        public void InitOve(float ove) => this.ove = new Ove(ove);
        public void SetOve(string ove) => this.ove.Set(ove);
        public void SetOve(int ove) => this.ove.Set(ove);
        public void SetOve(float ove) => this.ove.Set(ove);
        public float GetOve() => ove.Get();
        public Boolean OveIsChanged() => ove.IsChanged();
        public Boolean HasOve() => (ove != null);


        private class AtOve
        {
            private float atOve;
            private Boolean isChanged;

            public AtOve(string atOve)
            {
                this.atOve = float.Parse(atOve);
                isChanged = false;
            }
            public AtOve(int atOve)
            {
                this.atOve = (float)atOve;
                isChanged = false;
            }
            public AtOve(float atOve)
            {
                this.atOve = atOve;
                isChanged = false;
            }
            public void Set(string atOve) { this.atOve = float.Parse(atOve); isChanged = true; }
            public void Set(int atOve) { this.atOve = atOve; isChanged = true; }
            public void Set(float atOve) { this.atOve = atOve; isChanged = true; }
            public float Get() => atOve;
            public Boolean IsChanged() => isChanged;
        }
        public void InitAtOve(string atOve) => this.atOve = new AtOve(atOve);
        public void InitAtOve(int atOve) => this.atOve = new AtOve(atOve);
        public void InitAtOve(float atOve) => this.atOve = new AtOve(atOve);
        public void SetAtOve(string atOve) => this.atOve.Set(atOve);
        public void SetAtOve(int atOve) => this.atOve.Set(atOve);
        public void SetAtOve(float atOve) => this.atOve.Set(atOve);
        public float GetAtOve() => atOve.Get();
        public Boolean AtOveIsChanged() => atOve.IsChanged();
        public Boolean HasAtOve() => (atOve != null);


        private class Stp
        {
            private float stp;
            private Boolean isChanged;

            public Stp(string stp)
            {
                this.stp = float.Parse(stp);
                isChanged = false;
            }
            public Stp(int stp)
            {
                this.stp = (float)stp;
                isChanged = false;
            }
            public Stp(float stp)
            {
                this.stp = stp;
                isChanged = false;
            }
            public void Set(string stp) { this.stp = float.Parse(stp); isChanged = true; }
            public void Set(int stp) { this.stp = stp; isChanged = true; }
            public void Set(float stp) { this.stp = stp; isChanged = true; }
            public float Get() => stp;
            public Boolean IsChanged() => isChanged;
        }
        public void InitStp(string stp) => this.stp = new Stp(stp);
        public void InitStp(int stp) => this.stp = new Stp(stp);
        public void InitStp(float stp) => this.stp = new Stp(stp);
        public void SetStp(string stp) => this.stp.Set(stp);
        public void SetStp(int stp) => this.stp.Set(stp);
        public void SetStp(float stp) => this.stp.Set(stp);
        public float GetStp() => stp.Get();
        public Boolean StpIsChanged() => stp.IsChanged();
        public Boolean HasStp() => (stp != null);


        private class AtStp
        {
            private float atStp;
            private Boolean isChanged;

            public AtStp(string atStp)
            {
                this.atStp = float.Parse(atStp);
                isChanged = false;
            }
            public AtStp(int atStp)
            {
                this.atStp = (float)atStp;
                isChanged = false;
            }
            public AtStp(float atStp)
            {
                this.atStp = atStp;
                isChanged = false;
            }
            public void Set(string atStp) { this.atStp = float.Parse(atStp); isChanged = true; }
            public void Set(int atStp) { this.atStp = atStp; isChanged = true; }
            public void Set(float atStp) { this.atStp = atStp; isChanged = true; }
            public float Get() => atStp;
            public Boolean IsChanged() => isChanged;
        }
        public void InitAtStp(string atStp) => this.atStp = new AtStp(atStp);
        public void InitAtStp(int atStp) => this.atStp = new AtStp(atStp);
        public void InitAtStp(float atStp) => this.atStp = new AtStp(atStp);
        public void SetAtStp(string atStp) => this.atStp.Set(atStp);
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
        public void InitVelocity(string velocity) => this.velocity = new Velocity(velocity);
        public void InitVelocity(int velocity) => this.velocity = new Velocity(velocity);
        public void SetVelocity(string velocity) => this.velocity.Set(velocity);
        public void SetVelocity(int velocity) => this.velocity.Set(velocity);
        public int GetVelocity() => velocity.Get();
        public Boolean VelocityIsChanged() => velocity.IsChanged();
        public Boolean HasVelocity() => (velocity != null);

        private class Intensity
        {
            private int intensity;
            private Boolean isChanged;
            public Intensity(string intensity)
            {
                this.intensity = int.Parse(intensity);
                isChanged = false;
            }
            public Intensity(int intensity)
            {
                this.intensity = intensity;
                isChanged = false;
            }
            public void Set(string intensity) { this.intensity = int.Parse(intensity); isChanged = true; }
            public void Set(int intensity) { this.intensity = intensity; isChanged = true; }
            public int Get() => intensity;
            public Boolean IsChanged() => isChanged;
        }
        public void InitIntensity(string intensity) => this.intensity = new Intensity(intensity);
        public void InitIntensity(int intensity) => this.intensity = new Intensity(intensity);
        public void SetIntensity(string intensity) => this.intensity.Set(intensity);
        public void SetIntensity(int intensity) => this.intensity.Set(intensity);
        public int GetIntensity() => intensity.Get();
        public Boolean IntensityIsChanged() => intensity.IsChanged();
        public Boolean HasIntensity() => (intensity != null);

        private class Mod
        {
            private int mod;
            private Boolean isChanged;
            public Mod(string mod)
            {
                this.mod = int.Parse(mod);
                isChanged = false;
            }
            public Mod(int mod)
            {
                this.mod = mod;
                isChanged = false;
            }
            public void Set(string mod) { this.mod = int.Parse(mod); isChanged = true; }
            public void Set(int mod) { this.mod = mod; isChanged = true; }
            public int Get() => mod;
            public Boolean IsChanged() => isChanged;
        }
        public void InitMod(string mod) => this.mod = new Mod(mod);
        public void InitMod(int mod) => this.mod = new Mod(mod);
        public void SetMod(string mod) => this.mod.Set(mod);
        public void SetMod(int mod) => this.mod.Set(mod);
        public int GetMod() => mod.Get();
        public Boolean ModIsChanged() => mod.IsChanged();
        public Boolean HasMod() => (mod != null);


        private class Flags
        {
            private string flags;
            private Boolean isChanged;
            public Flags(string flags)
            {
                this.flags = flags;
                isChanged = false;
            }
            public void Set(string flags) { this.flags = flags; isChanged = true; }
            public string Get() => flags;
            public Boolean IsChanged() => isChanged;

        }
        public void InitFlags(string flags) => this.flags = new Flags(flags);
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

        private class PbStart
        {
            private float pbStart;
            private Boolean isChanged;

            public PbStart(string pbStart)
            {
                this.pbStart = float.Parse(pbStart);
                isChanged = false;
            }
            public PbStart(int pbStart)
            {
                this.pbStart = (float)pbStart;
                isChanged = false;
            }
            public PbStart(float pbStart)
            {
                this.pbStart = pbStart;
                isChanged = false;
            }
            public void Set(string pbStart) { this.pbStart = float.Parse(pbStart); isChanged = true; }
            public void Set(int pbStart) { this.pbStart = pbStart; isChanged = true; }
            public void Set(float pbStart) { this.pbStart = pbStart; isChanged = true; }
            public float Get() => pbStart;
            public Boolean IsChanged() => isChanged;
        }
        public void InitPbStart(string pbStart) => this.pbStart = new PbStart(pbStart);
        public void InitPbStart(int pbStart) => this.pbStart = new PbStart(pbStart);
        public void InitPbStart(float pbStart) => this.pbStart = new PbStart(pbStart);
        public void SetPbStart(string pbStart) => this.pbStart.Set(pbStart);
        public void SetPbStart(int pbStart) => this.pbStart.Set(pbStart);
        public void SetPbStart(float pbStart) => this.pbStart.Set(pbStart);
        public float GetPbStart() => pbStart.Get();
        public Boolean PbStartIsChanged() => pbStart.IsChanged();
        public Boolean HasPbStart() => (pbStart != null);

        private class PbType
        {
            private string pbType;
            private Boolean isChanged;
            public PbType(string pbType)
            {
                this.pbType = pbType;
                isChanged = false;
            }
            public void Set(string pbType) { this.pbType = pbType; isChanged = true; }
            public string Get() => pbType;
            public Boolean IsChanged() => isChanged;

        }
        public void InitPbType(string pbType) => this.pbType = new PbType(pbType);
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

        private class Label
        {
            private string label;
            private Boolean isChanged;
            public Label(string label)
            {
                this.label = label;
                isChanged = false;
            }
            public void Set(string label) { this.label = label; isChanged = true; }
            public string Get() => label;
            public Boolean IsChanged() => isChanged;

        }
        public void InitLabel(string label) => this.label = new Label(label);
        public void SetLabel(string label) => this.label.Set(label);
        public string GetLabel() => label.Get();
        public Boolean LabelIsChanged() => label.IsChanged();
        public Boolean HasLabel() => (label != null);

        private class Direct
        {
            private Boolean direct;
            private Boolean isChanged;

            public Direct(Boolean direct)
            {
                this.direct = direct;
                isChanged = false;
            }
            public Direct(string direct)
            {
                this.direct = Convert.ToBoolean(direct);
                isChanged = false;
            }
            public void Set(Boolean direct)
            {
                this.direct = direct;
                isChanged = true;
            }
            public void Set(string direct)
            {
                this.direct = Convert.ToBoolean(direct);
                isChanged = true;
            }
            public Boolean Get() => direct;
            public Boolean IsChanged() => isChanged;
        }
        public void InitDirect(Boolean direct) => this.direct = new Direct(direct);
        public void InitDirect(string direct) => this.direct = new Direct(direct);
        public void SetDirect(Boolean direct) => this.direct.Set(direct);
        public void SetDirect(string direct) => this.direct.Set(direct);
        public Boolean GetDirect() => this.direct.Get();
        public Boolean DirectIsChanged() => direct.IsChanged();
        public Boolean HasDirect() => (direct != null);

        private class Region
        {
            private string region;
            private Boolean isChanged;
            public Region(string region)
            {
                this.region = region;
                isChanged = false;
            }
            public void Set(string region) { this.region = region; isChanged = true; }
            public string Get() => region;
            public Boolean IsChanged() => isChanged;

        }
        public void InitRegion(string region) => this.region = new Region(region);
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
        public void InitRegionEnd(string regionEnd) => this.regionEnd = new RegionEnd(regionEnd);
        public void SetRegionEnd(string regionEnd) => this.regionEnd.Set(regionEnd);
        public string GetRegionEnd() => regionEnd.Get();
        public Boolean RegionEndIsChanged() => regionEnd.IsChanged();
        public Boolean HasRegionEnd() => (regionEnd != null);

    }
}
