using System;
using System.Collections.Generic;

//mode2のピッチを扱うためのクラスです．
//詳細の仕様はmode2PitcheTest.csを参照．
namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// mode2関連のピッチの値があればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasMode2Pitch() => (mode2Pitch != null);
        /// <summary>
        /// mode2関連ピッチ値の初期化
        /// </summary>
        public void InitMode2Pitch() => mode2Pitch = new Mode2Pitch();
        /// <summary>
        /// mode2に関連するピッチの値、pbs,pbw,pbm,pbyを一括して扱う
        /// </summary>
        public class Mode2Pitch
        {
            /// <summary>
            /// UTAUから与えらえるpbsの文字列
            /// </summary>
            private string inputPbs;
            /// <summary>
            /// pbsを分解したmode2の開始時間
            /// </summary>
            private float pbsTime;
            /// <summary>
            /// pbsを分解したmode2の音高
            /// </summary>
            private float pbsHeight;
            /// <summary>
            /// mode2制御点間の長さms
            /// </summary>
            private List<float> pbw;
            /// <summary>
            /// mode2制御点間の補間方法
            /// </summary>
            private List<string> pbm;
            /// <summary>
            /// mode2各制御点の音高
            /// </summary>
            private List<float> pby;
            /// <summary>
            /// pbsが変更されたか
            /// </summary>
            private Boolean pbsIsChanged;
            /// <summary>
            /// pbwが変更されたか
            /// </summary>
            private Boolean pbwIsChanged;
            /// <summary>
            /// pbmが変更されたか
            /// </summary>
            private Boolean pbmIsChanged;
            /// <summary>
            /// pbyが変更されたか
            /// </summary>
            private Boolean pbyIsChanged;

            /// <summary>
            /// mode2の初期化
            /// </summary>
            public Mode2Pitch()
            {
                pbsTime = 0;
                pbsHeight = 0;
                pbw = new List<float>();
                pbw.Add(0);
                pbm = new List<string>();
                pby = new List<float>();
                pbsIsChanged = false;
                pbwIsChanged = false;
                pbmIsChanged = false;
                pbyIsChanged = false;
            }

            /// <summary>
            /// pbsの初期化
            /// </summary>
            /// <param name="inputPbs">pbsに変換可能な文字列。以下のいずれかのフォーマット
            /// <list type="bullet">
            /// <item>pbsTime;pbsHeight</item>
            /// <item>pbsTime,pbsHeight</item>
            /// <item>pbsTime</item>
            /// </list>
            /// </param>
            public void InitPbs(string inputPbs)
            {
                SetPbs(inputPbs);
                pbsIsChanged = false;
            }
            public void SetPbs(string inputPbs)
            {
                this.inputPbs = inputPbs;
                if (inputPbs.Contains(";"))
                {
                    string[] tmp = inputPbs.Split(';');

                    if (tmp[0] != "")
                    {
                        pbsTime = float.Parse(tmp[0]);
                    }
                    else
                    {
                        pbsTime = 0;

                    }
                    if (tmp[1] != "")
                    {
                        pbsHeight = float.Parse(tmp[1]);
                    }
                    else
                    {
                        pbsHeight = 0;
                    }
                }
                else if (inputPbs.Contains(","))
                {
                    string[] tmp = inputPbs.Split(',');
                    if (tmp[0] != "")
                    {
                        pbsTime = float.Parse(tmp[0]);
                    }
                    else
                    {
                        pbsTime = 0;

                    }
                    if (tmp[1] != "")
                    {
                        pbsHeight = float.Parse(tmp[1]);
                    }
                    else
                    {
                        pbsHeight = 0;
                    }
                }
                else
                {
                    pbsTime = float.Parse(inputPbs);
                    pbsHeight = 0.0f;
                }
                pbsIsChanged = true;
            }
            /// <summary>
            /// pbs値の取得
            /// </summary>
            /// <returns>pbsTime;pbsHeightの文字列</returns>
            public string GetPbs()
            {
                if (pbsHeight == 0)
                {
                    return pbsTime.ToString();
                }
                else
                {
                    return pbsTime.ToString() + ";" + pbsHeight.ToString();
                }
            }
            /// <summary>
            /// pbsTimeの取得
            /// </summary>
            /// <returns></returns>
            public float GetPbsTime() => pbsTime;
            /// <summary>
            /// pbsHeightの取得
            /// </summary>
            /// <returns></returns>
            public float GetPbsHeight() => pbsHeight;
            /// <summary>
            /// pbsが変更されればtrue
            /// </summary>
            /// <returns></returns>
            public Boolean PbsIsChanged() => pbsIsChanged;

            /// <summary>
            /// pbwの初期化
            /// </summary>
            /// <param name="pbw">,で区切られたfloatに変換可能な文字列</param>
            public void InitPbw(string pbw)
            {
                SetPbw(pbw);
                pbwIsChanged = false;
            }
            /// <summary>
            /// pbwの変更
            /// </summary>
            /// <param name="pbw">,で区切られたfloatに変換可能な文字列</param>
            public void SetPbw(string pbw)
            {
                List<string> tmpPbw = new List<string>();
                if (pbw.Contains(","))
                {
                    tmpPbw.AddRange(pbw.Split(','));
                }
                else
                {
                    tmpPbw.Add(pbw);
                }
                this.pbw.Clear();
                foreach (string x in tmpPbw)
                {
                    if (x != "")
                    {
                        this.pbw.Add(float.Parse(x));
                    }
                    else
                    {
                        this.pbw.Add(0);
                    }
                }
                pbwIsChanged = true;
            }
            /// <summary>
            /// 指定したindexのpbw値の変更
            /// </summary>
            /// <param name="pbw">floatに変更可能な文字列</param>
            /// <param name="point">index</param>
            public void SetPbw(String pbw, int point)
            {
                this.pbw.RemoveAt(point);
                this.pbw.Insert(point, float.Parse(pbw));
                pbwIsChanged = true;
            }
            /// <summary>
            /// 指定したindexのpbw値の変更
            /// </summary>
            /// <param name="pbw"></param>
            /// <param name="point">index</param>
            public void SetPbw(int pbw, int point)
            {
                this.pbw.RemoveAt(point);
                this.pbw.Insert(point, pbw);
                pbwIsChanged = true;
            }
            /// <summary>
            /// 指定したindexのpbw値の変更
            /// </summary>
            /// <param name="pbw"></param>
            /// <param name="point">index</param>
            public void SetPbw(float pbw, int point)
            {
                this.pbw.RemoveAt(point);
                this.pbw.Insert(point, pbw);
                pbwIsChanged = true;
            }
            /// <summary>
            /// 渡されたlistでpbwを更新する
            /// </summary>
            /// <param name="pbw"></param>
            public void SetPbw(List<float> pbw)
            {
                this.pbw.Clear();
                this.pbw.AddRange(pbw);
                pbwIsChanged = true;
            }
            /// <summary>
            /// pbw値の取得
            /// </summary>
            /// <returns></returns>
            public List<float> GetPbw() => new List<float>(pbw);
            /// <summary>
            /// pbwが変更済みならtrue
            /// </summary>
            /// <returns></returns>
            public Boolean PbwIsChanged() => pbwIsChanged;

            /// <summary>
            /// pbyの初期化
            /// </summary>
            /// <param name="pbw">,で区切られたfloatに変換可能な文字列</param>
            public void InitPby(string pby)
            {
                SetPby(pby);
                pbyIsChanged = false;
            }
            /// <summary>
            /// pbyの変更
            /// </summary>
            /// <param name="pby">,で区切られたfloatに変換可能な文字列</param>
            public void SetPby(string pby)
            {
                List<string> tmpPby = new List<string>();
                if (pby.Contains(","))
                {
                    tmpPby.AddRange(pby.Split(','));
                }
                else
                {
                    tmpPby.Add(pby);
                }
                this.pby.Clear();
                foreach (string x in tmpPby)
                {
                    if (x == "")
                    {
                        this.pby.Add(0);
                    }
                    else
                    {
                        this.pby.Add(float.Parse(x));
                    }
                }
                pbyIsChanged = true;
            }
            /// <summary>
            /// 指定したindexのpby値の変更
            /// </summary>
            /// <param name="pby">floatに変換可能な文字列</param>
            /// <param name="point">index</param>
            public void SetPby(String pby, int point)
            {
                this.pby.RemoveAt(point);
                this.pby.Insert(point, float.Parse(pby));
                pbyIsChanged = true;
            }
            /// <summary>
            /// 指定したindexのpby値の変更
            /// </summary>
            /// <param name="pby"></param>
            /// <param name="point">index</param>
            public void SetPby(int pby, int point)
            {
                this.pby.RemoveAt(point);
                this.pby.Insert(point, pby);
                pbyIsChanged = true;
            }
            /// <summary>
            /// 指定したindexのpby値の変更
            /// </summary>
            /// <param name="pby"></param>
            /// <param name="point">index</param>
            public void SetPby(float pby, int point)
            {
                this.pby.RemoveAt(point);
                this.pby.Insert(point, pby);
                pbyIsChanged = true;
            }
            /// <summary>
            /// 渡されたlistでpbyを更新する
            /// </summary>
            /// <param name="pby"></param>
            public void SetPby(List<float> pby)
            {
                this.pby.Clear();
                this.pby.AddRange(pby);
                pbyIsChanged = true;
            }
            /// <summary>
            /// pby値の取得
            /// </summary>
            /// <returns></returns>
            public List<float> GetPby() => new List<float>(pby);
            /// <summary>
            /// pbyが変更済みならtrue
            /// </summary>
            /// <returns></returns>
            public Boolean PbyIsChanged() => pbyIsChanged;

            /// <summary>
            /// pbmの取得
            /// </summary>
            /// <param name="pbm">,で区切られた文字列"","s","j","r"の4種類</param>
            public void InitPbm(string pbm)
            {
                SetPbm(pbm);
                pbmIsChanged = false;
            }
            /// <summary>
            /// pbmの変更
            /// </summary>
            /// <param name="pbm">,で区切られた文字列"","s","j","r"の4種類</param>
            public void SetPbm(string pbm)
            {
                this.pbm.Clear();
                if (pbm.Contains(","))
                {
                    this.pbm.AddRange(pbm.Split(','));
                }
                else
                {
                    this.pbm.Add(pbm);
                }
                pbmIsChanged = true;
            }
            /// <summary>
            /// 指定したindexのpbm値の変更
            /// </summary>
            /// <param name="pbm">"","s","j","r"の4種類</param>
            /// <param name="point">index</param>
            public void SetPbm(String pbm, int point)
            {
                this.pbm.RemoveAt(point);
                this.pbm.Insert(point, pbm);
                pbmIsChanged = true;
            }
            /// <summary>
            /// 渡されたlistでpbmを更新する
            /// </summary>
            /// <param name="pbm"></param>
            public void SetPbm(List<string> pbm)
            {
                this.pbm.Clear();
                this.pbm.AddRange(pbm);
                pbmIsChanged = true;
            }
            /// <summary>
            /// pbm値の取得
            /// </summary>
            /// <returns></returns>
            public List<string> GetPbm() => new List<string>(pbm);
            /// <summary>
            /// pbm値が変更済みならtrue
            /// </summary>
            /// <returns></returns>
            public Boolean PbmIsChanged() => pbmIsChanged;

        }
    }
}