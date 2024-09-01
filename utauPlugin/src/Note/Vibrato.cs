using System;
//ビブラートデータを扱うためのクラスです．
//詳細はvibratoTest.csを参照
namespace UtauPlugin
{

    public partial class Note
    {
        /// <summary>
        /// ビブラートの初期値
        /// </summary>
        private const string DEFAULT_VIBRATO = "65,180,35,20,20,0,0,0";

        /// <summary>
        /// ビブラートの初期化
        /// </summary>
        public void InitVibrato() => vibrato = new Vibrato();
        /// <summary>
        /// ビブラートの初期化
        /// </summary>
        /// <param name="vibrato">,で区切られた8つの数値列でそれぞれの意味は下記の通り
        /// <list type="bullet">
        /// <item>ビブラートの長さ(ノート長に対する%)</item>
        /// <item>ビブラートの周期(ms)</item>
        /// <item>ビブラートの深さ(cent)</item>
        /// <item>フェードインの長さ(ビブラート長に対する%)</item>
        /// <item>フェードアウトの長さ(ビブラート長に対する%)</item>
        /// <item>位相ずれ(%)</item>
        /// <item>高さ(%)</item>
        /// <item>現在使われていないパラメータ</item>
        /// </list>
        /// </param>
        public void InitVibrato(string vibrato) => this.vibrato = new Vibrato(vibrato);
        /// <summary>
        /// ビブラートの変更
        /// </summary>
        /// <param name="vibrato">,で区切られた8つの数値列でそれぞれの意味は下記の通り
        /// <list type="bullet">
        /// <item>ビブラートの長さ(ノート長に対する%)</item>
        /// <item>ビブラートの周期(ms)</item>
        /// <item>ビブラートの深さ(cent)</item>
        /// <item>フェードインの長さ(ビブラート長に対する%)</item>
        /// <item>フェードアウトの長さ(ビブラート長に対する%)</item>
        /// <item>位相ずれ(%)</item>
        /// <item>高さ(%)</item>
        /// <item>現在使われていないパラメータ</item>
        /// </list>
        /// </param>
        public void SetVibrato(string vibrato)
        {
            if (HasVibrato()) { this.vibrato.Set(vibrato); }
            else
            {
                this.vibrato = new Vibrato();
                this.vibrato.Set(vibrato);
            }
        }
        /// <summary>
        /// ビブラートの取得
        /// </summary>
        /// <returns>,で区切られた文字列</returns>
        public string GetVibrato() => HasVibrato() ? vibrato.Get() : DEFAULT_VIBRATO;
        /// <summary>
        /// ビブラートが変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean VibratoIsChanged() => (HasVibrato() && vibrato.IsChanged());
        /// <summary>
        /// ビブラート値を持っていればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasVibrato() => (vibrato != null);

        /// <summary>
        /// ビブラートのパラメータを扱う
        /// </summary>
        public class Vibrato
        {
            /// <summary>
            /// ビブラート長(ノート長に対する%)
            /// </summary>
            private float length;
            /// <summary>
            /// ビブラートの周期(ms)
            /// </summary>
            private float cycle;
            /// <summary>
            /// ビブラートの深さ(cent)
            /// </summary>
            private float depth;
            /// <summary>
            /// フェードインの長さ(ビブラート長に対する%)
            /// </summary>
            private float fadeInTime;
            /// <summary>
            /// フェードアウトの長さ(ビブラート長に対する%)
            /// </summary>
            private float fadeOutTime;
            /// <summary>
            /// 位相(%)
            /// </summary>
            private float phase;
            /// <summary>
            /// 高さ(%)
            /// </summary>
            private float height;
            /// <summary>
            /// 変更済みか判断するフラグ
            /// </summary>
            private Boolean isChanged;

            /// <summary>
            /// ビブラート長(ノート長に対する%)
            /// </summary>
            public float Length
            {
                get => length;
                set
                {
                    length = value;
                    isChanged = true;
                }
            }

            /// <summary>
            /// ビブラートの周期(ms)
            /// </summary>
            public float Cycle
            {
                get => cycle;
                set
                {
                    cycle = value;
                    isChanged = true;
                }
            }
            /// <summary>
            /// ビブラートの深さ(cent)
            /// </summary>
            public float Depth
            {
                get => depth;
                set
                {
                    depth = value;
                    isChanged = true;
                }
            }
            /// <summary>
            /// フェードインの長さ(ビブラート長に対する%)
            /// </summary>
            public float FadeInTime
            {
                get => fadeInTime;
                set
                {
                    fadeInTime = value;
                    isChanged = true;
                }
            }
            /// <summary>
            /// フェードアウトの長さ(ビブラート長に対する%)
            /// </summary>
            public float FadeOutTime
            {
                get => fadeOutTime;
                set
                {
                    fadeOutTime = value;
                    isChanged = true;
                }
            }
            /// <summary>
            /// 位相(%)
            /// </summary>
            public float Phase
            {
                get => phase;
                set
                {
                    phase = value;
                    isChanged = true;
                }
            }
            /// <summary>
            /// 高さ(%)
            /// </summary>
            public float Height
            {
                get => height;
                set
                {
                    height = value;
                    isChanged = true;
                }
            }

            /// <summary>
            /// 初期化
            /// </summary>
            public Vibrato()
            {
                Length = 0;
                Cycle = 0;
                Depth = 0.0f;
                FadeInTime = 0.0f;
                FadeOutTime = 0.0f;
                Phase = 0.0f;
                Height = 0.0f;
                isChanged = false;
            }

            /// <summary>
            /// 初期化
            /// </summary>
            /// <param name="value">,で区切られた8つの数値列でそれぞれの意味は下記の通り
            /// <list type="bullet">
            /// <item>ビブラートの長さ(ノート長に対する%)</item>
            /// <item>ビブラートの周期(ms)</item>
            /// <item>ビブラートの深さ(cent)</item>
            /// <item>フェードインの長さ(ビブラート長に対する%)</item>
            /// <item>フェードアウトの長さ(ビブラート長に対する%)</item>
            /// <item>位相ずれ(%)</item>
            /// <item>高さ(%)</item>
            /// <item>現在使われていないパラメータ</item>
            /// </list>
            /// </param>
            public Vibrato(string value)
            {
                Set(value);
                isChanged = false;
            }
            /// <summary>
            /// 変更
            /// </summary>
            /// <param name="value">,で区切られた8つの数値列でそれぞれの意味は下記の通り
            /// <list type="bullet">
            /// <item>ビブラートの長さ(ノート長に対する%)</item>
            /// <item>ビブラートの周期(ms)</item>
            /// <item>ビブラートの深さ(cent)</item>
            /// <item>フェードインの長さ(ビブラート長に対する%)</item>
            /// <item>フェードアウトの長さ(ビブラート長に対する%)</item>
            /// <item>位相ずれ(%)</item>
            /// <item>高さ(%)</item>
            /// <item>現在使われていないパラメータ</item>
            /// </list>
            /// </param>
            public void Set(string value)
            {
                string[] tmp = value.Split(',');
                Length = float.Parse(tmp[0]);
                Cycle = float.Parse(tmp[1]);
                Depth = float.Parse(tmp[2]);
                FadeInTime = float.Parse(tmp[3]);
                FadeOutTime = float.Parse(tmp[4]);
                Phase = float.Parse(tmp[5]);
                Height = float.Parse(tmp[6]);
                isChanged = true;
            }
            /// <summary>
            /// ビブラートのパラメータを結合した文字列の取得
            /// </summary>
            /// <returns></returns>
            public string Get()
            {
                return string.Join(",", Length.ToString(), Cycle.ToString(), Depth.ToString(), FadeInTime.ToString(), FadeOutTime.ToString(), Phase.ToString(), Height.ToString(), "0");
            }
            /// <summary>
            /// 変更済みならtrue
            /// </summary>
            /// <returns></returns>
            public Boolean IsChanged() => isChanged;
        }
    }
}