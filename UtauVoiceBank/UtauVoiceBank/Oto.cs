using System;
using Wave;
using System.IO;

namespace UtauVoiceBank
{
    public class Oto
    {
        private string dirPath;
        private string fileName;
        private string alias;
        private float offset;
        private float pre;
        private float ove;
        private float vel;
        private float blank;
        private int wavLength;
        private Boolean hasWavLength;

        public string DirPath { get => dirPath; set => dirPath = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public string Alias { get => alias; set => alias = value; }
        public float Offset { get => offset; set => offset = value; }
        public float Pre { get => pre; set => pre = value; }
        public float Ove { get => ove; set => ove = value; }
        public float Vel { get => vel; set => vel = value; }
        public float Blank { get => blank; set => blank = value; }
        public int WavLength { get => wavLength; set => wavLength = value; }

        public Oto()
        {
            DirPath = "";
            FileName = "";
            Alias = "";
            Offset = 0;
            Pre = 0;
            Ove = 0;
            Vel = 0;
            Blank = 0;
            hasWavLength = false;
        }

        public Oto(string dirPath,string fileName,string alias,float offset,float pre, float ove,float vel,float blank)
        {
            DirPath = dirPath;
            FileName = fileName;
            Alias = alias;
            Offset = offset;
            Pre = pre;
            Ove = ove;
            Vel = vel;
            Blank = blank;
            hasWavLength = false;
        }

        public int GetWavLength()
        {
            if (!hasWavLength)
            {
                Wave.Wave wav = new Wave.Wave(Path.Combine(dirPath, fileName));
                wav.Read();
                WavLength = wav.PlayTime;
                hasWavLength = true;
            }
            return WavLength;
        }
        
        public float GetInverseBlank()
        {
            if(Blank<0) { return GetWavLength() - Offset + Blank; }
            else { return Blank - GetWavLength() + Offset; }
        }
    }
}
