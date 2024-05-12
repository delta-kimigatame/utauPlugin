using System;
using System.Collections.Generic;

namespace UtauPlugin
{
    public partial class Note
    {
        private IReadOnlyList<float> DEFAULT_PBY = new List<float>() { }.AsReadOnly();

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

        public void SetPby(float pby, int point)
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
    }
}
