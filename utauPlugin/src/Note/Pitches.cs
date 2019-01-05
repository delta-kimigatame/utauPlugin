using System;
using System.Collections.Generic;

namespace utauPlugin
{

    public partial class Note
    {
        private IReadOnlyList<int> DEFAULT_PITCHES = new List<int>() { }.AsReadOnly();
        public void InitPitches(string pitches) => this.pitches = new Pitches(pitches);
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



    }
}
