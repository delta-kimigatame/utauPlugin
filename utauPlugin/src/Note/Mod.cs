using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// モジュレーションの初期値
        /// </summary>
        private const int DEFAULT_MOD = 0;
        /// <summary>
        /// モジュレーションの初期化
        /// </summary>
        /// <param name="mod">intに変換可能な文字列</param>
        public void InitMod(string mod) => this.mod = new Entry<int>(int.Parse(mod));
        /// <summary>
        /// モジュレーションの初期化
        /// </summary>
        /// <param name="mod"></param>
        public void InitMod(int mod) => this.mod = new Entry<int>(mod);
        /// <summary>
        /// モジュレーションの変更
        /// </summary>
        /// <param name="mod">intに変換可能な文字列</param>
        public void SetMod(string mod)
        {
            if (HasMod()) { this.mod.Set(int.Parse(mod)); }
            else
            {
                this.mod = new Entry<int>(0);
                this.mod.Set(int.Parse(mod));
            }
        }
        /// <summary>
        /// モジュレーションの変更
        /// </summary>
        /// <param name="mod"></param>
        public void SetMod(int mod)
        {
            if (HasMod()) { this.mod.Set(mod); }
            else
            {
                this.mod = new Entry<int>(0);
                this.mod.Set(mod);
            }
        }
        /// <summary>
        /// モジュレーションの取得
        /// </summary>
        /// <returns></returns>
        public int GetMod() => HasMod() ? mod.Get() : DEFAULT_MOD;
        /// <summary>
        /// モジュレーションが変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean ModIsChanged() => (HasMod() && mod.IsChanged());
        /// <summary>
        /// モジュレーションの値があればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasMod() => (mod != null);
    }
}

