using System;
using System.Collections.Generic;

namespace UtauPlugin
{

    public partial class Note
    {
        /// <summary>
        /// mode1ピッチ列の初期値
        /// </summary>
        private IReadOnlyList<int> DEFAULT_PITCHES = new List<int>() { }.AsReadOnly();
        /// <summary>
        /// mode1ピッチ列の初期化
        /// </summary>
        /// <param name="pitches">,で区切られたdoubleに変換可能な文字列</param>
        public void InitPitches(string pitches) => this.pitches = new Pitches(pitches);
        /// <summary>
        /// mode1ピッチ列の変更
        /// </summary>
        /// <param name="pitches">,で区切られた文字列</param>
        public void SetPitches(string pitches)
        {
            if (HasPitches()) { this.pitches.Set(pitches); }
            else
            {
                this.pitches = new Pitches("");
                this.pitches.Set(pitches);
            }
        }

        /// <summary>
        /// 渡されたリストからmode1ピッチ列を変更する。
        /// </summary>
        /// <param name="pitches"></param>
        public void SetPitches(List<int> pitches)
        {
            if (HasPitches()) { this.pitches.Set(pitches); }
            else
            {
                this.pitches = new Pitches("");
                this.pitches.Set(pitches);
            }
        }
        /// <summary>
        /// mode1ピッチ列の取得
        /// </summary>
        /// <returns></returns>
        public List<int> GetPitches() => HasPitches() ? pitches.Get() : new List<int>(DEFAULT_PITCHES);
        /// <summary>
        /// mode1ピッチ列が変更されていればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean PitchesIsChanged() => (HasPitches() && pitches.IsChanged());
        /// <summary>
        /// mode1ピッチ列の値を持っていればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasPitches() => (pitches != null);

        /// <summary>
        /// mode1ピッチ列
        /// </summary>
        /// <remarks>
        /// 5tickもしくはPBTypeで指定された通りの間隔の音高列
        /// </remarks>
        private class Pitches
        {
            /// <summary>
            /// 音高
            /// </summary>
            private List<int> pitches;
            /// <summary>
            /// 変更済みフラグ
            /// </summary>
            private Boolean isChanged;
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="pitches">,で区切られたdoubleに変換可能な文字列</param>
            public Pitches(string pitches)
            {
                this.pitches = new List<int>();
                foreach (string x in pitches.Split(','))
                {
                    if (x != "") { this.pitches.Add((int)Math.Round(double.Parse(x))); }
                    else { this.pitches.Add(0); }
                    
                }
            }
            /// <summary>
            /// セッタ
            /// </summary>
            /// <param name="pitches">,で区切られたdoubleに変換可能な文字列</param>
            public void Set(string pitches)
            {
                this.pitches.Clear();
                foreach (string x in pitches.Split(','))
                {
                    if (x != "") { this.pitches.Add(int.Parse(x)); }
                    else { this.pitches.Add(0); }
                }
                isChanged = true;
            }
            /// <summary>
            /// セッタ
            /// </summary>
            /// <param name="pitches">ピッチ列</param>
            public void Set(List<int> pitches)
            {
                this.pitches.Clear();
                this.pitches.AddRange(pitches);
                isChanged = true;
            }
            /// <summary>
            /// ピッチ列の取得
            /// </summary>
            /// <returns></returns>
            public List<int> Get() => pitches;
            /// <summary>
            /// ピッチ列が変更済みならtrue
            /// </summary>
            /// <returns></returns>
            public Boolean IsChanged() => isChanged;

        }



    }
}
