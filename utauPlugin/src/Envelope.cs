using System;
using System.Collections.Generic;

//ust形式のエンベロープを扱うためのクラスです．
//詳細の仕様はenvelopeTest.cs参照
namespace utauPlugin
{
    public class Envelope
    {
        private List<float> p;
        private List<int> v;
        private Boolean isChanged;

        public Envelope()
        {
            p = new List<float>();
            v = new List<int>();
            isChanged = false;
        }

        public Envelope(string value)
        {
            p = new List<float>();
            v = new List<int>();
            Set(value);
            isChanged = false;
        }

        public void Set(string value)
        {
            List<string> tmp = new List<string>();
            tmp.AddRange(value.Split(','));
            while (tmp.Count < 3)
            {
                tmp.Add("0");
            }
            while (tmp.Count < 7)
            {
                tmp.Add("100");
            }
            p.Add(float.Parse(tmp[0]));
            p.Add(float.Parse(tmp[1]));
            p.Add(float.Parse(tmp[2]));
            v.Add(int.Parse(tmp[3]));
            v.Add(int.Parse(tmp[4]));
            v.Add(int.Parse(tmp[5]));
            v.Add(int.Parse(tmp[6]));
            
            if (tmp.Count > 8)
            {
                p.Add(float.Parse(tmp[8]));
            }
            if (tmp.Count > 9)
            {
                p.Add(float.Parse(tmp[9]));
            }
            if (tmp.Count > 10)
            {
                v.Add(int.Parse(tmp[10]));
            }
            isChanged = true;
        }

        public string Get()
        {
            List<string> tmp = new List<string>();
            tmp.Add(p[0].ToString());
            tmp.Add(p[1].ToString());
            tmp.Add(p[2].ToString());
            tmp.Add(v[0].ToString());
            tmp.Add(v[1].ToString());
            tmp.Add(v[2].ToString());
            tmp.Add(v[3].ToString());
            if (p.Count >= 4)
            {
                tmp.Add("%");
                tmp.Add(p[3].ToString());
            }
            if (p.Count == 5)
            {
                tmp.Add(p[4].ToString());
                tmp.Add(v[4].ToString());
            }
            return String.Join(",", tmp);
        }

        public void SetP(float p,int point)
        {
            this.p.RemoveAt(point);
            this.p.Insert(point, p);
            isChanged = true;
        }
        public void SetP(int p, int point)
        {
            this.p.RemoveAt(point);
            this.p.Insert(point, p);
            isChanged = true;
        }
        public void SetP(string p, int point)
        {
            this.p.RemoveAt(point);
            this.p.Insert(point, float.Parse(p));
            isChanged = true;
        }
        public void SetV(int v, int point)
        {
            this.v.RemoveAt(point);
            this.v.Insert(point, v);
            isChanged = true;
        }
        public void SetV(string v, int point)
        {
            this.v.RemoveAt(point);
            this.v.Insert(point, int.Parse(v));
            isChanged = true;
        }

        public List<float> GetP() => p;
        public float GetP(int point) => p[point];
        public List<int> GetV() => v;
        public int GetV(int point) => v[point];
        public Boolean IsChanged() => isChanged;
    }
}
