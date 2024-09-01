using System;
using System.Collections.Generic;
using System.IO;
using UtauVoiceBank;

namespace UtauPlugin
{
    /// <summary>
    /// ustにおけるノート(音符)のデータを扱う
    /// </summary>
    public partial class Note
    {
        /// <summary>
        /// ustにおける何番目の音符かを表す連番
        /// </summary>
        /// <remarks>
        /// UtauPluginの場合、選択範囲の直前<c>PREV</c>、選択範囲の直後<c>NEXT</c>、追加されたノート<c>INSERT</c>、削除されたノート<c>DELETE</c>がある。
        /// </remarks>
        private Entry<string> num;
        /// <summary>
        /// ノート長
        /// </summary>
        /// <remarks>
        /// 480が4分音符
        /// </remarks>
        private Entry<int> length;
        /// <summary>
        /// 歌詞
        /// </summary>
        private Entry<string> lyric;
        /// <summary>
        /// 音高
        /// </summary>
        private NoteNum noteNum;
        /// <summary>
        /// bpm
        /// </summary>
        private Entry<float> tempo;
        /// <summary>
        /// 先行発声
        /// </summary>
        private Pre pre;
        /// <summary>
        /// 自動調整適用後の先行発声
        /// </summary>
        private Entry<float> atPre;
        /// <summary>
        /// 再生に使用するwavファイル
        /// </summary>
        private Entry<string> atFileName;
        /// <summary>
        /// prefix.mapや自動連続音モード適用後のエイリアス
        /// </summary>
        private Entry<string> atAlias;
        /// <summary>
        /// オーバーラップ
        /// </summary>
        private Entry<float> ove;
        /// <summary>
        /// 自動調整適用後のオーバーラップ
        /// </summary>
        private Entry<float> atOve;
        /// <summary>
        /// stp値
        /// </summary>
        private Entry<float> stp;
        /// <summary>
        /// 自動調整適用後のstp値
        /// </summary>
        private Entry<float> atStp;
        /// <summary>
        /// 子音速度
        /// </summary>
        private Entry<int> velocity;
        /// <summary>
        /// 音量
        /// </summary>
        /// <remarks>
        /// 100の時-6dB、0の時-inf、200の時0dB
        /// </remarks>
        private Entry<int> intensity;
        /// <summary>
        /// モジュレーション
        /// </summary>
        private Entry<int> mod;
        /// <summary>
        /// フラグ
        /// </summary>
        private Entry<string> flags;
        /// <summary>
        /// mode1におけるピッチ列
        /// </summary>
        private Pitches pitches;
        /// <summary>
        /// mode1におけるピッチ開始ms
        /// </summary>
        private Entry<float> pbStart;
        /// <summary>
        /// 古いresamplerにおけるmode1ピッチ列の間隔。標準は5
        /// </summary>
        private Entry<string> pbType;
        /// <summary>
        /// mode2におけるピッチのパラメータ
        /// </summary>
        private Mode2Pitch mode2Pitch;
        /// <summary>
        /// エンベロープ
        /// </summary>
        public Envelope envelope;
        /// <summary>
        /// ビブラート
        /// </summary>
        public Vibrato vibrato;
        /// <summary>
        /// ラベル
        /// </summary>
        private Entry<string> label;
        /// <summary>
        /// $direct=Trueのとき表示される
        /// </summary>
        private Entry<Boolean> direct;
        /// <summary>
        /// 選択範囲に名前を付ける機能の始点
        /// </summary>
        private Entry<string> region;
        /// <summary>
        /// 選択範囲に名前を付ける機能の終点
        /// </summary>
        private Entry<string> regionEnd;
        /// <summary>
        /// プラグイン独自エントリのためのエンドポイント
        /// </summary>
        private Dictionary<string,Entry<Object>> originalEntries;
        /// <summary>
        /// エイリアス
        /// </summary>
        private AliasData alias;
        /// <summary>
        /// 前のノートへのポインタ
        /// </summary>
        private Note prev;
        /// <summary>
        /// 次のノートへのポインタ
        /// </summary>
        private Note next;

        /// <summary>
        /// 前のノートへのポインタ
        /// </summary>
        public Note Prev { get => prev; set => prev = value; }
        /// <summary>
        /// 次のノートへのポインタ
        /// </summary>
        public Note Next { get => next; set => next = value; }

        //各エントリのデフォルト値，メソッドはNoteフォルダ内の各csファイルに記述されています．


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 必ずデータが必要な<c>num,length,lyric,noteNum,pre</c>を初期化する。
        /// </remarks>
        public Note()
        {
            num = new Entry<string>(DEFAULT_NUM);
            length = new Entry<int>(DEFAULT_LENGTH);
            lyric = new Entry<string>(DEFAULT_LYRIC);
            noteNum = new NoteNum(DEFAULT_NOTENUM);
            pre = new Pre(DEFAULT_PRE);
        }
        /// <summary>
        /// 先行発声とオーバーラップの値が無い場合、原音設定値から取得する。
        /// </summary>
        /// <param name="map">prefix.map</param>
        /// <param name="oto">原音設定データ</param>
        public void ApplyOto(Dictionary<string,MapValue> map, Dictionary<string, Oto> oto)
        {
            if(!HasAlias() && HasAtAlias())
            {
                InitAlias(GetAtAlias());
            }
            else if (!HasAlias())
            {
                InitAlias(GetLyric(),GetNoteNumName(),map);
            }
            ApplyOtoToPre(oto);
            ApplyOtoToOve(oto);
        }

        /// <summary>
        /// 先行発声値を持っていなければ原音設定データから取得する。
        /// </summary>
        /// <param name="oto">原音設定データ</param>
        private void ApplyOtoToPre(Dictionary<string, Oto> oto)
        {
            if (PreHasValue())
            {
                return;
            }
            if (oto.ContainsKey(GetAlias()))
            {
                InitPre(oto[GetAlias()].Pre);
            }
            else
            {
                InitPre(0);
            }
        }

        /// <summary>
        /// オーバーラップ値を持っていなければ原音設定データから取得する。
        /// </summary>
        /// <param name="oto">原音設定データ</param>
        private void ApplyOtoToOve(Dictionary<string, Oto> oto)
        {

            if (HasOve())
            {
                return;
            }
            if (oto.ContainsKey(GetAlias()))
            {
                InitOve(oto[GetAlias()].Ove);
            }
            else
            {
                InitOve(0);
            }
        }
        /// <summary>
        /// AtFileNameを原音設定データから取得する。
        /// </summary>
        /// <param name="oto">原音設定データ</param>
        private void ApplyOtoToAtFileName(Dictionary<string, Oto> oto)
        {
            if (oto.ContainsKey(GetAlias()))
            {
                InitAtFileName(Path.Combine(oto[GetAlias()].DirPath, oto[GetAlias()].FileName));
            }
            else
            {
                InitAtFileName("");
            }
        }

        /// <summary>
        /// UTAUの自動調整機能をエミュレートし、atalias,atfilename,atpre,atove,atstpを更新する。
        /// </summary>
        /// <param name="map">prefix.map</param>
        /// <param name="oto">原音設定データ</param>
        public void InitAtParam(Dictionary<string, MapValue> map, Dictionary<string, Oto> oto)
        {
            ApplyOto(map,oto);
            if (!HasAtAlias())
            {
                InitAtAlias(GetAlias());
            }
            if (!HasAtFileName())
            {
                ApplyOtoToAtFileName(oto);
            }
            if (!HasAtPre())
            {
                AutoFitAtParam();
            }
        }

        /// <summary>
        /// UTAUの自動調整機能をエミュレートし、atpre,atove,atstpを更新する。
        /// </summary>
        private void AutoFitAtParam()
        {
            float prevMsLength;
            float tmpVelocity = (float)Math.Pow(2.0f , (GetVelocity() / 100.0f) - 1.0f);
            float tmpPre = GetPre() / tmpVelocity;
            float tmpOve = GetOve() / tmpVelocity;
            float tmpStp = GetStp();
            if (prev!= null)
            {
                if(prev.GetLyric() == "R")
                {
                    prevMsLength = prev.GetMsLength();
                }
                else
                {
                    prevMsLength = prev.GetMsLength()/2;
                }
            }
            else
            {
                prevMsLength = float.MaxValue;
            }

            if( prevMsLength < tmpPre - tmpOve)
            {
                float fitPre = tmpPre - tmpOve;
                float oldPre = tmpPre;
                tmpPre = tmpPre / fitPre * prevMsLength;
                tmpOve = tmpOve / fitPre * prevMsLength;
                tmpStp = oldPre - tmpPre + tmpStp;
            }
            InitAtPre(tmpPre);
            InitAtOve(tmpOve);
            InitAtStp(tmpStp);
        }
        /// <summary>
        /// ノート長をmsに換算して返す
        /// </summary>
        /// <returns></returns>
        public int GetMsLength()
        {
            return (int)(60 / GetTempo() * GetLength() / 480 * 1000);
        }
    }
}
