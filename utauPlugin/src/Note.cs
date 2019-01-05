using System;

namespace utauPlugin
{

    public partial class Note
    {
        private Entry<string> num;
        private Entry<int> length;
        private Entry<string> lyric;
        private NoteNum noteNum;
        private Entry<float> tempo;
        private Pre pre;
        private Entry<float> atPre;
        private Entry<string> atFileName;
        private Entry<string> atAlias;
        private Entry<float> ove;
        private Entry<float> atOve;
        private Entry<float> stp;
        private Entry<float> atStp;
        private Entry<int> velocity;
        private Entry<int> intensity;
        private Entry<int> mod;
        private Entry<string> flags;
        private Pitches pitches;
        private Entry<float> pbStart;
        private Entry<string> pbType;
        private Mode2Pitch mode2Pitch;
        public Envelope envelope;
        public Vibrato vibrato;
        private Entry<string> label;
        private Entry<Boolean> direct;
        private Entry<string> region;
        private Entry<string> regionEnd;

        //各エントリのデフォルト値，メソッドはNoteフォルダ内の各csファイルに記述されています．
        
        public Note()
        {
            num = new Entry<string>(DEFAULT_NUM);
            length = new Entry<int>(DEFAULT_LENGTH);
            lyric = new Entry<string>(DEFAULT_LYRIC);
            noteNum = new NoteNum(DEFAULT_NOTENUM);
            pre = new Pre(DEFAULT_PRE);
        }
        
    }
}
