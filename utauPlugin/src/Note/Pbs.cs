using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// pbsの初期値
        /// </summary>
        private const string DEFAULT_PBS = "-25";
        /// <summary>
        /// pbsTimeの初期値
        /// </summary>
        private const float DEFAULT_PBS_TIME = -25f;
        /// <summary>
        /// pbsHeightの初期値
        /// </summary>
        private const float DEFAULT_PBS_HEIGHT = 0f;

        /// <summary>
        /// pbsの初期化
        /// </summary>
        /// <param name="pbs">pbsに変換可能な文字列。以下のいずれかのフォーマット
        /// <list type="bullet">
        /// <item>pbsTime;pbsHeight</item>
        /// <item>pbsTime,pbsHeight</item>
        /// <item>pbsTime</item>
        /// </list>
        /// </param>
        public void InitPbs(string pbs) => mode2Pitch.InitPbs(pbs);
        /// <summary>
        /// pbsの変更
        /// </summary>
        /// <param name="pbs">pbsに変換可能な文字列。以下のいずれかのフォーマット
        /// <list type="bullet">
        /// <item>pbsTime;pbsHeight</item>
        /// <item>pbsTime,pbsHeight</item>
        /// <item>pbsTime</item>
        /// </list>
        /// </param>
        public void SetPbs(string pbs)
        {
            if (HasMode2Pitch()) { mode2Pitch.SetPbs(pbs); }
            else
            {
                mode2Pitch = new Mode2Pitch();
                mode2Pitch.SetPbs(pbs);
            }
        }

        /// <summary>
        /// pbs値の取得
        /// </summary>
        /// <returns></returns>
        public string GetPbs() => HasMode2Pitch() ? mode2Pitch.GetPbs() : DEFAULT_PBS;
        /// <summary>
        /// pbsの時間部分の取得
        /// </summary>
        /// <returns></returns>
        public float GetPbsTime() => HasMode2Pitch() ? mode2Pitch.GetPbsTime() : DEFAULT_PBS_TIME;
        /// <summary>
        /// pbsの音高部分の取得
        /// </summary>
        /// <returns></returns>
        public float GetPbsHeight() => HasMode2Pitch() ? mode2Pitch.GetPbsHeight() : DEFAULT_PBS_HEIGHT;
        /// <summary>
        /// pbsが変更済みであればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean PbsIsChanged() => (HasMode2Pitch() && mode2Pitch.PbsIsChanged());

    }
}
