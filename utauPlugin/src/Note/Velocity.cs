using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// 子音速度の初期値
        /// </summary>
        private const int DEFAULT_VELOCITY = 100;
        /// <summary>
        /// 子音速度の初期化
        /// </summary>
        /// <param name="velocity">intに変換可能な文字列。0～200</param>
        public void InitVelocity(string velocity) => this.velocity = new Entry<int>(int.Parse(velocity));
        /// <summary>
        /// 子音速度の初期化
        /// </summary>
        /// <param name="velocity">0～200</param>
        public void InitVelocity(int velocity) => this.velocity = new Entry<int>(velocity);
        /// <summary>
        /// 子音速度の変更
        /// </summary>
        /// <param name="velocity">intに変換可能な文字列。0～200</param>
        public void SetVelocity(string velocity)
        {
            if (HasVelocity()) { this.velocity.Set(int.Parse(velocity)); }
            else
            {
                this.velocity = new Entry<int>(0);
                this.velocity.Set(int.Parse(velocity));
            }
        }

        /// <summary>
        /// 子音速度の変更
        /// </summary>
        /// <param name="velocity">0～200</param>
        public void SetVelocity(int velocity)
        {
            if (HasVelocity()) { this.velocity.Set(velocity); }
            else
            {
                this.velocity = new Entry<int>(0);
                this.velocity.Set(velocity);
            }
        }
        /// <summary>
        /// 子音速度の取得
        /// </summary>
        /// <returns></returns>
        public int GetVelocity() => HasVelocity() ? velocity.Get() : DEFAULT_VELOCITY;
        /// <summary>
        /// 子音速度が変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean VelocityIsChanged() => (HasVelocity() && velocity.IsChanged());
        /// <summary>
        /// 子音速度の値があればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasVelocity() => (velocity != null);

    }
}
