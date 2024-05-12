using System;
//音階情報を扱うためのクラスです．
//詳細はmode2PitchTest.csを参照
namespace UtauPlugin
{
    public partial class Note
    {
        private static readonly int DEFAULT_NOTENUM = 60;
        public void InitNoteNum(string noteNum) => this.noteNum = new NoteNum(noteNum);
        public void InitNoteNum(int noteNum) => this.noteNum = new NoteNum(noteNum);
        public void SetNoteNum(string noteNum) => this.noteNum.Set(noteNum);
        public void SetNoteNum(int noteNum) => this.noteNum.Set(noteNum);
        public int GetNoteNum() => noteNum.Get();
        public string GetNoteNumName() => noteNum.GetName();
        public string GetKey() => noteNum.GetKey();
        public Boolean NoteNumIsChanged() => noteNum.IsChanged();
        public class NoteNum
        {
            private int num;
            private string name;
            private string[] NOTE_NUM_NAME;
            private Boolean isChanged;

            public NoteNum()
            {
                NOTE_NUM_NAME = new string[12] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
                num = 60;
                name = ToNoteName(num);
                isChanged = false;
            }
            public NoteNum(int num)
            {
                NOTE_NUM_NAME = new string[12] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
                this.num = num;
                name = ToNoteName(this.num);
                isChanged = false;
            }
            public NoteNum(string num)
            {
                NOTE_NUM_NAME = new string[12] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
                this.num = int.Parse(num);
                name = ToNoteName(this.num);
                isChanged = false;
            }

            public void Set(int num)
            {
                this.num = num;
                name = ToNoteName(this.num);
                isChanged = true;
            }

            public void Set(string num)
            {
                this.num = int.Parse(num);
                name = ToNoteName(this.num);
                isChanged = true;
            }
            public int Get() => num;
            public string GetName() => name;
            public string GetKey() => NOTE_NUM_NAME[num % 12];
            public Boolean IsChanged() => isChanged;


            private string ToNoteName(int num)
            {
                //C4が60
                //キー名は音高番号を12で割った余りを配列に適応して求める．(60 % 12 = 0 → 0ならC)
                //60～71の時4が帰るような感じ(端数切捨てになるため最後に1を足す)
                return NOTE_NUM_NAME[num % 12] + ((num - 24) / 12 + 1).ToString();
            }
        }
    }
}