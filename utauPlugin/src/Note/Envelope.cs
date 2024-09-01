using System;
using System.Collections.Generic;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// エンベロープの初期値に相当する文字列
        /// </summary>
        /// <remarks>p1:0,p2:5,p3:35,v1:0,v2:100,v3:100,v4:0</remarks>
        private const string DEFAULT_ENVELOPE = "0,5,35,0,100,100,0";
        /// <summary>
        /// エンベロープの初期化
        /// </summary>
        public void InitEnvelope() => envelope = new Envelope();
        /// <summary>
        /// 文字列を与えてエンベロープを初期化
        /// </summary>
        /// <param name="envelope">以下のいずれかのフォーマットである必要がある。 
        /// <list type="bullet">
        /// <item>0,0</item>
        /// <item>p1,p2,p3,v1,v2,v3,v4</item>
        /// <item>p1,p2,p3,v1,v2,v3,v4,%,p4</item>
        /// <item>p1,p2,p3,v1,v2,v3,v4,%,p4,p5,v5</item>
        /// </list>
        /// なお、p*はfloatに、v*はintに変換できる必要がある。
        /// </param>
        public void InitEnvelope(string envelope) => this.envelope = new Envelope(envelope);
        /// <summary>
        /// 文字列を与えてエンベロープを変更する。
        /// </summary>
        /// <param name="envelope">以下のいずれかのフォーマットである必要がある。 
        /// <list type="bullet">
        /// <item>0,0</item>
        /// <item>p1,p2,p3,v1,v2,v3,v4</item>
        /// <item>p1,p2,p3,v1,v2,v3,v4,%,p4</item>
        /// <item>p1,p2,p3,v1,v2,v3,v4,%,p4,p5,v5</item>
        /// </list>
        /// なお、p*はfloatに、v*はintに変換できる必要がある。
        /// </param>
        public void SetEnvelope(string envelope)
        {
            if (HasEnvelope()) { this.envelope.Set(envelope); }
            else
            {
                this.envelope = new Envelope();
                this.envelope.Set(envelope);
            }
        }

        /// <summary>
        /// エンベロープ値を繋げた文字列を返す。
        /// </summary>
        /// <returns>戻り値は以下のいずれかのフォーマット文字列
        /// <list type="bullet">
        /// <item>0,0</item>
        /// <item>p1,p2,p3,v1,v2,v3,v4</item>
        /// <item>p1,p2,p3,v1,v2,v3,v4,%,p4</item>
        /// <item>p1,p2,p3,v1,v2,v3,v4,%,p4,p5,v5</item>
        /// </list>
        /// </returns>
        public string GetEnvelope() => HasEnvelope() ? envelope.Get() : DEFAULT_ENVELOPE;
        /// <summary>
        /// エンベロープが変更されたか
        /// </summary>
        /// <returns>変更済みならtrue</returns>
        public Boolean EnvelopeIsChanged() => (HasEnvelope() && envelope.IsChanged());
        /// <summary>
        /// このノートがエンベロープ値を持っているか
        /// </summary>
        /// <returns>持っていればtrue</returns>
        public Boolean HasEnvelope() => (envelope != null);

        /// <summary>
        /// エンベロープの値を扱う
        /// </summary>
        public class Envelope
        {
            /// <summary>
            /// エンベロープ点の時間のリスト
            /// </summary>
            /// <remarks>
            /// <list type="bullet">
            /// <item>p1:ノートの頭からの長さms</item>
            /// <item>p2:p1からの長さms</item>
            /// <item>p3:p4からの負の長さms</item>
            /// <item>p4:ノートの末尾からの負の長さms</item>
            /// <item>p5:p2からの長さms</item>
            /// </list>
            /// </remarks>
            private List<float> p;
            /// <summary>
            /// エンベロープの音量のリスト
            /// </summary>
            /// <remarks>0～200</remarks>
            private List<int> v;
            /// <summary>
            /// 変更されたか否かのフラグ
            /// </summary>
            private Boolean isChanged;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public Envelope()
            {
                p = new List<float>();
                v = new List<int>();
                isChanged = false;
            }

            /// <summary>
            /// コンストラクタ。文字列で初期化
            /// </summary>
            /// <param name="value">以下のいずれかのフォーマットである必要がある。 
            /// <list type="bullet">
            /// <item>0,0</item>
            /// <item>p1,p2,p3,v1,v2,v3,v4</item>
            /// <item>p1,p2,p3,v1,v2,v3,v4,%,p4</item>
            /// <item>p1,p2,p3,v1,v2,v3,v4,%,p4,p5,v5</item>
            /// </list>
            /// なお、p*はfloatに、v*はintに変換できる必要がある。</param>
            public Envelope(string value)
            {
                p = new List<float>();
                v = new List<int>();
                Set(value);
                isChanged = false;
            }

            /// <summary>
            /// エンベロープの変更
            /// </summary>
            /// <param name="value">以下のいずれかのフォーマットである必要がある。 
            /// <list type="bullet">
            /// <item>0,0</item>
            /// <item>p1,p2,p3,v1,v2,v3,v4</item>
            /// <item>p1,p2,p3,v1,v2,v3,v4,%,p4</item>
            /// <item>p1,p2,p3,v1,v2,v3,v4,%,p4,p5,v5</item>
            /// </list>
            /// なお、p*はfloatに、v*はintに変換できる必要がある。</param>
            public void Set(string value)
            {
                List<string> tmp = new List<string>();
                p = new List<float>();
                v = new List<int>();
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

            /// <summary>
            /// エンベロープ値を繋げた文字列を返す。
            /// </summary>
            /// <returns>戻り値は以下のいずれかのフォーマット文字列
            /// <list type="bullet">
            /// <item>0,0</item>
            /// <item>p1,p2,p3,v1,v2,v3,v4</item>
            /// <item>p1,p2,p3,v1,v2,v3,v4,%,p4</item>
            /// <item>p1,p2,p3,v1,v2,v3,v4,%,p4,p5,v5</item>
            /// </list>
            /// </returns>
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

            /// <summary>
            /// 指定した<c>point</c>のpの値を変更する
            /// </summary>
            /// <param name="p">変更後の値</param>
            /// <param name="point">0～4</param>
            public void SetP(float p, int point)
            {
                this.p.RemoveAt(point);
                this.p.Insert(point, p);
                isChanged = true;
            }
            /// <summary>
            /// 指定した<c>point</c>のpの値を変更する
            /// </summary>
            /// <param name="p">変更後の値</param>
            /// <param name="point">0～4</param>
            public void SetP(int p, int point)
            {
                this.p.RemoveAt(point);
                this.p.Insert(point, p);
                isChanged = true;
            }
            /// <summary>
            /// 指定した<c>point</c>のpの値を変更する
            /// </summary>
            /// <param name="p">変更後の値。数値に変換可能な文字列</param>
            /// <param name="point">0～4</param>
            public void SetP(string p, int point)
            {
                this.p.RemoveAt(point);
                this.p.Insert(point, float.Parse(p));
                isChanged = true;
            }
            /// <summary>
            /// 指定した<c>point</c>のvの値を変更する
            /// </summary>
            /// <param name="p">変更後の値</param>
            /// <param name="point">0～4</param>
            public void SetV(int v, int point)
            {
                this.v.RemoveAt(point);
                this.v.Insert(point, v);
                isChanged = true;
            }
            /// <summary>
            /// 指定した<c>point</c>のvの値を変更する
            /// </summary>
            /// <param name="p">変更後の値。intに変更可能な文字列</param>
            /// <param name="point">0～4</param>
            public void SetV(string v, int point)
            {
                this.v.RemoveAt(point);
                this.v.Insert(point, int.Parse(v));
                isChanged = true;
            }

            /// <summary>
            /// pのリストを返す
            /// </summary>
            /// <returns>pのリスト</returns>
            public List<float> GetP() => p;
            /// <summary>
            /// 指定したpの値を返す
            /// </summary>
            /// <param name="point">0～4のインデックス値</param>
            /// <returns></returns>
            public float GetP(int point) => p[point];
            /// <summary>
            /// vのリストを返す
            /// </summary>
            /// <returns>vのリスト</returns>
            public List<int> GetV() => v;
            /// <summary>
            /// 指定したvの値を返す
            /// </summary>
            /// <param name="point">0～4のインデックス値</param>
            /// <returns></returns>
            public int GetV(int point) => v[point];
            /// <summary>
            /// エンベロープが変更済みか
            /// </summary>
            /// <returns>変更済みの場合trueを返す</returns>
            public Boolean IsChanged() => isChanged;
        }
    }
}