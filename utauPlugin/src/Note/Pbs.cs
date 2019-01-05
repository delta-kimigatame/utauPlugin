using System;

namespace utauPlugin
{
    public partial class Note
    {
        private const string DEFAULT_PBS = "-25";
        private const float DEFAULT_PBS_TIME = -25f;
        private const float DEFAULT_PBS_HEIGHT = 0f;

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

    }
}
