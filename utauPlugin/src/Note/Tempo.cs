using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtauPlugin
{
    public partial class Note
    {
        private const float DEFAULT_TEMPO = 120.0f;
        public void InitTempo(string tempo) => this.tempo = new Entry<float>(float.Parse(tempo));
        public void InitTempo(float tempo) => this.tempo = new Entry<float>(tempo);
        public void SetTempo(string tempo) => this.tempo.Set(float.Parse(tempo));
        public void SetTempo(int tempo) => this.tempo.Set(tempo);
        public void SetTempo(float tempo) => this.tempo.Set(tempo);
        public float GetTempo() => HasTempo() ? tempo.Get() : DEFAULT_TEMPO;
        public Boolean TempoIsChanged() => tempo.IsChanged();
        public Boolean HasTempo() => (tempo != null);
    }
}
