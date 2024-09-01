using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// stpの初期値
        /// </summary>
        private const float DEFAULT_STP = 0f;
        /// <summary>
        /// stpの初期化
        /// </summary>
        /// <param name="stp">floatに変換可能な文字列</param>
        public void InitStp(string stp) => this.stp = new Entry<float>(float.Parse(stp));
        /// <summary>
        /// stpの初期化
        /// </summary>
        /// <param name="stp"></param>
        public void InitStp(float stp) => this.stp = new Entry<float>(stp);
        /// <summary>
        /// stpの変更
        /// </summary>
        /// <param name="stp">floatに変換可能な文字列</param>
        public void SetStp(string stp)
        {
            if (HasStp()) { this.stp.Set(float.Parse(stp)); }
            else
            {
                this.stp = new Entry<float>(0);
                this.stp.Set(float.Parse(stp));
            }
        }
        /// <summary>
        /// stpの変更
        /// </summary>
        /// <param name="stp"></param>
        public void SetStp(float stp)
        {
            if (HasStp()) { this.stp.Set(stp); }
            else
            {
                this.stp = new Entry<float>(0);
                this.stp.Set(stp);
            }
        }
        /// <summary>
        /// stpの取得
        /// </summary>
        /// <returns></returns>
        public float GetStp() => HasStp() ? stp.Get() : DEFAULT_STP;
        /// <summary>
        /// stpが変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean StpIsChanged() => (HasStp() && stp.IsChanged());
        /// <summary>
        /// stp値を持っていればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasStp() => (stp != null);
    }
}
