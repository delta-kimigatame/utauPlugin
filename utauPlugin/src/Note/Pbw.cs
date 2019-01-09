using System;
using System.Collections.Generic;

namespace utauPlugin
{
    public partial class Note
    {
        private IReadOnlyList<float> DEFAULT_PBW = new List<float>() { 50 }.AsReadOnly();
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

        public void SetPbw(float pbw, int point)
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
    }
}
