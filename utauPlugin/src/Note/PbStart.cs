using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// pbstartの初期値
        /// </summary>
        private const float DEFAULT_PBSTART = 0f;
        /// <summary>
        /// pbstartの初期化
        /// </summary>
        /// <param name="pbStart">floatに変換可能な文字列</param>
        public void InitPbStart(string pbStart) => this.pbStart = new Entry<float>(float.Parse(pbStart));
        /// <summary>
        /// pbstartの初期化
        /// </summary>
        /// <param name="pbStart"></param>
        public void InitPbStart(float pbStart) => this.pbStart = new Entry<float>(pbStart);
        /// <summary>
        /// pbstartの変更
        /// </summary>
        /// <param name="pbStart">floatに変換可能な文字列</param>
        public void SetPbStart(string pbStart)
        {
            if (HasPbStart()) { this.pbStart.Set(float.Parse(pbStart)); }
            else
            {
                this.pbStart = new Entry<float>(0);
                this.pbStart.Set(float.Parse(pbStart));
            }
        }
        /// <summary>
        /// pbstartの変更
        /// </summary>
        /// <param name="pbStart"></param>
        public void SetPbStart(float pbStart)
        {
            if (HasPbStart()) { this.pbStart.Set(pbStart); }
            else
            {
                this.pbStart = new Entry<float>(0);
                this.pbStart.Set(pbStart);
            }
        }

        /// <summary>
        /// pbstartの取得
        /// </summary>
        /// <returns></returns>
        public float GetPbStart() => HasPbStart() ? pbStart.Get() : DEFAULT_PBSTART;
        /// <summary>
        /// pbstartが変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean PbStartIsChanged() => (HasPbStart() && pbStart.IsChanged());
        /// <summary>
        /// pbstartの値を持っていればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasPbStart() => (pbStart != null);
    }
}
