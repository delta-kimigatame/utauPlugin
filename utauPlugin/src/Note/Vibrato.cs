using System;
//ビブラートデータを扱うためのクラスです．
//詳細はvibratoTest.csを参照
namespace UtauPlugin
{

    public partial class Note
    {
        private const string DEFAULT_VIBRATO = "65,180,35,20,20,0,0,0";

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

        public class Vibrato
        {
            private float length;
            private float cycle;
            private float depth;
            private float fadeInTime;
            private float fadeOutTime;
            private float phase;
            private float height;
            private Boolean isChanged;

            public float Length
            {
                get => length;
                set
                {
                    length = value;
                    isChanged = true;
                }
            }

            public float Cycle
            {
                get => cycle;
                set
                {
                    cycle = value;
                    isChanged = true;
                }
            }

            public float Depth
            {
                get => depth;
                set
                {
                    depth = value;
                    isChanged = true;
                }
            }

            public float FadeInTime
            {
                get => fadeInTime;
                set
                {
                    fadeInTime = value;
                    isChanged = true;
                }
            }

            public float FadeOutTime
            {
                get => fadeOutTime;
                set
                {
                    fadeOutTime = value;
                    isChanged = true;
                }
            }

            public float Phase
            {
                get => phase;
                set
                {
                    phase = value;
                    isChanged = true;
                }
            }

            public float Height
            {
                get => height;
                set
                {
                    height = value;
                    isChanged = true;
                }
            }

            public Vibrato()
            {
                Length = 0;
                Cycle = 0;
                Depth = 0.0f;
                FadeInTime = 0.0f;
                FadeOutTime = 0.0f;
                Phase = 0.0f;
                Height = 0.0f;
                isChanged = false;
            }
            public Vibrato(string value)
            {
                Set(value);
                isChanged = false;
            }
            public void Set(string value)
            {
                string[] tmp = value.Split(',');
                Length = float.Parse(tmp[0]);
                Cycle = float.Parse(tmp[1]);
                Depth = float.Parse(tmp[2]);
                FadeInTime = float.Parse(tmp[3]);
                FadeOutTime = float.Parse(tmp[4]);
                Phase = float.Parse(tmp[5]);
                Height = float.Parse(tmp[6]);
                isChanged = true;
            }
            public string Get()
            {
                return string.Join(",", Length.ToString(), Cycle.ToString(), Depth.ToString(), FadeInTime.ToString(), FadeOutTime.ToString(), Phase.ToString(), Height.ToString(), "0");
            }
            
            public Boolean IsChanged() => isChanged;
        }
    }
}