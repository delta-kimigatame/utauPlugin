using System;
//音階情報を扱うためのクラスです．
//詳細はmode2PitchTest.csを参照
namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// 音高番号の初期値。C4
        /// </summary>
        private static readonly int DEFAULT_NOTENUM = 60;
        /// <summary>
        /// 音高番号の初期化
        /// </summary>
        /// <param name="noteNum">intに変換可能な文字列。60がC4、72がC5</param>
        public void InitNoteNum(string noteNum) => this.noteNum = new NoteNum(noteNum);
        /// <summary>
        /// 音高番号の初期化
        /// </summary>
        /// <param name="noteNum">60がC4、72がC5</param>
        public void InitNoteNum(int noteNum) => this.noteNum = new NoteNum(noteNum);
        /// <summary>
        /// 音高番号の変更
        /// </summary>
        /// <param name="noteNum">intに変換可能な文字列。60がC4、72がC5</param>
        public void SetNoteNum(string noteNum) => this.noteNum.Set(noteNum);
        /// <summary>
        /// 音高番号の変更
        /// </summary>
        /// <param name="noteNum">60がC4、72がC5</param>
        public void SetNoteNum(int noteNum) => this.noteNum.Set(noteNum);
        /// <summary>
        /// 音高番号の取得
        /// </summary>
        /// <returns></returns>
        public int GetNoteNum() => noteNum.Get();
        /// <summary>
        /// 音高名の取得
        /// </summary>
        /// <returns>60がC4、61がC#4...72がC5</returns>
        public string GetNoteNumName() => noteNum.GetName();
        /// <summary>
        /// キーの取得
        /// </summary>
        /// <returns>60がC、61がC#...72がC</returns>
        public string GetKey() => noteNum.GetKey();
        /// <summary>
        /// 音高が変更されたならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean NoteNumIsChanged() => noteNum.IsChanged();
        /// <summary>
        /// 音高情報を扱う
        /// </summary>
        public class NoteNum
        {
            /// <summary>
            /// 音高番号。60がC4、61がC#4...72がC5
            /// </summary>
            private int num;
            /// <summary>
            /// 音高名
            /// </summary>
            private string name;
            /// <summary>
            /// 音高を音高名に変換のためのリスト
            /// </summary>
            private string[] NOTE_NUM_NAME;
            /// <summary>
            /// 変更済みか否かのフラグ
            /// </summary>
            private Boolean isChanged;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public NoteNum()
            {
                NOTE_NUM_NAME = new string[12] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
                num = 60;
                name = ToNoteName(num);
                isChanged = false;
            }
            /// <summary>
            /// 初期値付きコンストラクタ
            /// </summary>
            /// <param name="num"></param>
            public NoteNum(int num)
            {
                NOTE_NUM_NAME = new string[12] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
                this.num = num;
                name = ToNoteName(this.num);
                isChanged = false;
            }
            /// <summary>
            /// 初期値付きコンストラクタ
            /// </summary>
            /// <param name="num">intに変換可能な文字列</param>
            public NoteNum(string num)
            {
                NOTE_NUM_NAME = new string[12] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
                this.num = int.Parse(num);
                name = ToNoteName(this.num);
                isChanged = false;
            }

            /// <summary>
            /// 値を変更する
            /// </summary>
            /// <param name="num"></param>
            public void Set(int num)
            {
                this.num = num;
                name = ToNoteName(this.num);
                isChanged = true;
            }

            /// <summary>
            /// 値を変更する
            /// </summary>
            /// <param name="num">intに変換可能な文字列</param>
            public void Set(string num)
            {
                this.num = int.Parse(num);
                name = ToNoteName(this.num);
                isChanged = true;
            }
            /// <summary>
            /// 音高の取得
            /// </summary>
            /// <returns></returns>
            public int Get() => num;
            /// <summary>
            /// 音高名の取得
            /// </summary>
            /// <returns></returns>
            public string GetName() => name;
            /// <summary>
            /// キーの取得
            /// </summary>
            /// <returns></returns>
            public string GetKey() => NOTE_NUM_NAME[num % 12];
            /// <summary>
            /// 音高が変更済みならtrue
            /// </summary>
            /// <returns></returns>
            public Boolean IsChanged() => isChanged;

            /// <summary>
            /// 音高番号から音高名を求める
            /// </summary>
            /// <param name="num">音高番号。60がC4、61がC#4...72がC5</param>
            /// <returns>音高名</returns>
            private string ToNoteName(int num)
            {
                return NOTE_NUM_NAME[num % 12] + ((num - 24) / 12 + 1).ToString();
            }
        }
    }
}