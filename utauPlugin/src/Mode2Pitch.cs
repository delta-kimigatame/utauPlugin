using System;
using System.Collections.Generic;

//mode2のピッチを扱うためのクラスです．
//詳細の仕様はmode2PitcheTest.csを参照．
namespace utauPlugin
{
    public class Mode2Pitch
    {
        private string inputPbs;
        private int pbsTime, pbsHeight;
        private List<float> pbw;
        private List<string> pbm;
        private List<float> pby;
        private Boolean pbsIsChanged, pbwIsChanged, pbmIsChanged, pbyIsChanged;

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
                pbsTime = int.Parse(tmp[0]);
                pbsHeight = int.Parse(tmp[1]);
            }
            else if (inputPbs.Contains(","))
            {
                string[] tmp = inputPbs.Split(',');
                pbsTime = int.Parse(tmp[0]);
                pbsHeight = int.Parse(tmp[1]);
            }
            else
            {
                pbsTime = int.Parse(inputPbs);
                pbsHeight = 0;
            }
            pbsIsChanged = true;
        }
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
        public int GetPbsTime() => pbsTime;
        public int GetPbsHeight() => pbsHeight;
        public Boolean PbsIsChanged() => pbsIsChanged;

        //引数が1つの場合文字列をとる．
        //文字列がカンマ区切りの場合分割してpbwに，単一の数値の場合そのままpbwに
        //元のpbwの値は消す
        public void InitPbw(string pbw)
        {
            SetPbw(pbw);
            pbwIsChanged = false;
        }
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
            foreach(string x in tmpPbw)
            {
                this.pbw.Add(float.Parse(x));
            }
            pbwIsChanged = true;
        }
        //指定したインデックスのpbw要素の差し替え
        public void SetPbw(String pbw,int point)
        {
            this.pbw.RemoveAt(point);
            this.pbw.Insert(point, float.Parse(pbw));
            pbwIsChanged = true;
        }
        public void SetPbw(int pbw, int point)
        {
            this.pbw.RemoveAt(point);
            this.pbw.Insert(point, pbw);
            pbwIsChanged = true;
        }
        public void SetPbw(float pbw, int point)
        {
            this.pbw.RemoveAt(point);
            this.pbw.Insert(point, pbw);
            pbwIsChanged = true;
        }
        //そもそもリストを渡す
        public void SetPbw(List<float> pbw)
        {
            this.pbw.Clear();
            this.pbw.AddRange(pbw);
            pbwIsChanged = true;
        }
        public List<float> GetPbw() => pbw;
        public Boolean PbwIsChanged() => pbwIsChanged;

        public void InitPby(string pby)
        {
            SetPby(pby);
            pbyIsChanged = false;
        }
        //引数が1つの場合文字列をとる．
        //文字列がカンマ区切りの場合分割してpbyに，単一の数値の場合そのままpbyに
        //元のpbyの値は消す
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
        //指定したインデックスのpby要素の差し替え
        public void SetPby(String pby, int point)
        {
            this.pby.RemoveAt(point);
            this.pby.Insert(point, float.Parse(pby));
            pbyIsChanged = true;
        }
        public void SetPby(int pby, int point)
        {
            this.pby.RemoveAt(point);
            this.pby.Insert(point, pby);
            pbyIsChanged = true;
        }
        public void SetPby(float pby, int point)
        {
            this.pby.RemoveAt(point);
            this.pby.Insert(point, pby);
            pbyIsChanged = true;
        }
        //そもそもリストを渡す
        public void SetPby(List<float> pby)
        {
            this.pby.Clear();
            this.pby.AddRange(pby);
            pbyIsChanged = true;
        }
        public List<float> GetPby() => pby;
        public Boolean PbyIsChanged() => pbyIsChanged;

        public void InitPbm(string pbm)
        {
            SetPbm(pbm);
            pbmIsChanged = false;
        }
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
        //指定したインデックスのpbm要素の差し替え
        public void SetPbm(String pbm, int point)
        {
            this.pbm.RemoveAt(point);
            this.pbm.Insert(point, pbm);
            pbmIsChanged = true;
        }
        //そもそもリストを渡す
        public void SetPbm(List<string> pbm)
        {
            this.pbm.Clear();
            this.pbm.AddRange(pbm);
            pbmIsChanged = true;
        }
        public List<string> GetPbm() => pbm;
        public Boolean PbmIsChanged() => pbmIsChanged;

    }
}
