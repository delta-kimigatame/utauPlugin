using System;
using System.Collections.Generic;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// pbyの初期値
        /// </summary>
        private IReadOnlyList<float> DEFAULT_PBY = new List<float>() { }.AsReadOnly();
        /// <summary>
        /// pbyの初期化
        /// </summary>
        /// <param name="pby">,で区切られたfloatに変換可能な文字列</param>
        public void InitPby(string pby) => mode2Pitch.InitPby(pby);
        /// <summary>
        /// pbyの変更
        /// </summary>
        /// <param name="pby">,で区切られたfloatに変換可能な文字列</param>
        public void SetPby(string pby)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPby(pby); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPby(pby);
            }
        }

        /// <summary>
        /// 指定したindexのpby値の変更
        /// </summary>
        /// <param name="pby">floatに変換可能な文字列</param>
        /// <param name="point">index</param>
        public void SetPby(string pby, int point)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPby(pby, point); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPby(pby, point);
            }
        }

        /// <summary>
        /// 指定したindexのpby値の変更
        /// </summary>
        /// <param name="pby"></param>
        /// <param name="point">index</param>
        public void SetPby(int pby, int point)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPby(pby, point); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPby(pby, point);
            }
        }

        /// <summary>
        /// 指定したindexのpby値の変更
        /// </summary>
        /// <param name="pby"></param>
        /// <param name="point">index</param>
        public void SetPby(float pby, int point)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPby(pby, point); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPby(pby, point);
            }
        }

        /// <summary>
        /// 渡されたlistでpbyを更新する
        /// </summary>
        /// <param name="pby"></param>
        public void SetPby(List<float> pby)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPby(pby); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPby(pby);
            }
        }
        /// <summary>
        /// pby値の取得
        /// </summary>
        /// <returns></returns>
        public List<float> GetPby() => HasMode2Pitch() ? mode2Pitch.GetPby() : new List<float>(DEFAULT_PBY);
        /// <summary>
        /// pbyが変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean PbyIsChanged() => (HasMode2Pitch() && mode2Pitch.PbyIsChanged());
    }
}
