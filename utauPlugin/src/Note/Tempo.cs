using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// bpmの初期値
        /// </summary>
        private const float DEFAULT_TEMPO = 120.0f;
        /// <summary>
        /// bpmの初期化
        /// </summary>
        /// <param name="tempo">floatに変換可能な文字列</param>
        public void InitTempo(string tempo) => this.tempo = new Entry<float>(float.Parse(tempo));
        /// <summary>
        /// bpmの初期化
        /// </summary>
        /// <param name="tempo"></param>
        public void InitTempo(float tempo) => this.tempo = new Entry<float>(tempo);
        /// <summary>
        /// bpmの変更
        /// </summary>
        /// <param name="tempo">floatに変換可能な文字列</param>
        public void SetTempo(string tempo) => this.tempo.Set(float.Parse(tempo));
        /// <summary>
        /// bpmの変更
        /// </summary>
        /// <param name="tempo"></param>
        public void SetTempo(int tempo) => this.tempo.Set(tempo);
        /// <summary>
        /// bpmの変更
        /// </summary>
        /// <param name="tempo"></param>
        public void SetTempo(float tempo) => this.tempo.Set(tempo);
        /// <summary>
        /// bpmの取得
        /// </summary>
        /// <returns></returns>
        public float GetTempo() => HasTempo() ? tempo.Get() : DEFAULT_TEMPO;
        /// <summary>
        /// bpmが変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean TempoIsChanged() => tempo.IsChanged();
        /// <summary>
        /// bpmの値を持っていればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasTempo() => (tempo != null);
    }
}
