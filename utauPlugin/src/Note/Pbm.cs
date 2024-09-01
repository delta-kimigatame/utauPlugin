using System;
using System.Collections.Generic;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// pbmの初期値
        /// </summary>
        private IReadOnlyList<string> DEFAULT_PBM = new List<string>() { }.AsReadOnly();

        /// <summary>
        /// pbm値の初期化
        /// </summary>
        /// <param name="pbm">,で区切られた文字列"","s","j","r"の4種類</param>
        public void InitPbm(string pbm) => mode2Pitch.InitPbm(pbm); public void SetPbm(string pbm)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbm(pbm); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbm(pbm);
            }
        }

        /// <summary>
        /// 指定したindexのpbm値の変更
        /// </summary>
        /// <param name="pbm">"","s","j","r"の4種類</param>
        /// <param name="point">index</param>
        public void SetPbm(string pbm, int point)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbm(pbm, point); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbm(pbm, point);
            }
        }

        /// <summary>
        /// 渡したリストでpbm値を更新する
        /// </summary>
        /// <param name="pbm"></param>
        public void SetPbm(List<string> pbm)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbm(pbm); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbm(pbm);
            }
        }
        /// <summary>
        /// pbm値の取得
        /// </summary>
        /// <returns></returns>
        public List<string> GetPbm() => HasMode2Pitch() ? mode2Pitch.GetPbm() : new List<string>(DEFAULT_PBM);
        /// <summary>
        /// pbm値が変更済みであればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean PbmIsChanged() => (HasMode2Pitch() && mode2Pitch.PbmIsChanged());

    }
}
