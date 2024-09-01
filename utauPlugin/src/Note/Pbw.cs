using System;
using System.Collections.Generic;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// pbwの初期値
        /// </summary>
        private IReadOnlyList<float> DEFAULT_PBW = new List<float>() { 50 }.AsReadOnly();
        /// <summary>
        /// pbwの初期化
        /// </summary>
        /// <param name="pbw">,で区切られたfloatに変換可能な文字列</param>
        public void InitPbw(string pbw) => mode2Pitch.InitPbw(pbw);
        /// <summary>
        /// pbwの変更
        /// </summary>
        /// <param name="pbw">,で区切られたfloatに変換可能な文字列</param>
        public void SetPbw(string pbw)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbw(pbw); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbw(pbw);
            }
        }

        /// <summary>
        /// 指定したindexのpbw値の変更
        /// </summary>
        /// <param name="pbw">floatに変更可能な文字列</param>
        /// <param name="point">index</param>
        public void SetPbw(string pbw, int point)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbw(pbw, point); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbw(pbw, point);
            }
        }

        /// <summary>
        /// 指定したindexのpbw値の変更
        /// </summary>
        /// <param name="pbw"></param>
        /// <param name="point">index</param>
        public void SetPbw(int pbw, int point)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbw(pbw, point); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbw(pbw, point);
            }
        }

        /// <summary>
        /// 指定したindexのpbw値の変更
        /// </summary>
        /// <param name="pbw"></param>
        /// <param name="point">index</param>
        public void SetPbw(float pbw, int point)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbw(pbw, point); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbw(pbw, point);
            }
        }

        /// <summary>
        /// 渡されたlistでpbwを更新する
        /// </summary>
        /// <param name="pbw"></param>
        public void SetPbw(List<float> pbw)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbw(pbw); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbw(pbw);
            }
        }

        /// <summary>
        /// pbw値の取得
        /// </summary>
        /// <returns></returns>
        public List<float> GetPbw() => HasMode2Pitch() ? mode2Pitch.GetPbw() : new List<float>(DEFAULT_PBW);
        /// <summary>
        /// pbwが変更済みであればtrueを返す
        /// </summary>
        /// <returns></returns>
        public Boolean PbwIsChanged() => (HasMode2Pitch() && mode2Pitch.PbwIsChanged());
    }
}
