using System;
using System.Collections.Generic;

namespace utauPlugin
{
    public partial class Note
    {
        private IReadOnlyList<string> DEFAULT_PBM = new List<string>() { }.AsReadOnly();

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

    }
}
