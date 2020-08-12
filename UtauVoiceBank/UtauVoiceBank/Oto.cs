using System;
using System.Collections.Generic;
using System.Text;
using Wave;
using System.IO;

namespace UtauVoiceBank
{
    public partial class VoiceBank
    {
        public void InputOtoAll(Boolean Recursive = false)
        {
            InputOto();
            SearchOto(Recursive);
        }

        private void SearchOto(Boolean Recursive,string subDirPath = "")
        {
            foreach (string fileName in Directory.GetDirectories(Path.Combine(DirPath,subDirPath)))
            {
                if (!File.Exists(Path.Combine(fileName, "oto.ini")))
                {
                    if (subDirPath == "" && Directory.GetDirectories(fileName).Length != 0)
                    {
                        SearchOto(Recursive, Path.Combine(subDirPath, Path.GetFileName(fileName)));
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    if (inputData != null)
                    {
                        inputData.Clear();
                    }
                    else
                    {
                        inputData = new List<string>();
                    }
                    inputData.AddRange(File.ReadAllLines(Path.Combine(fileName, "oto.ini"), Encoding.GetEncoding("Shift_JIS")));
                    ParseOto(oto, inputData, Path.Combine(subDirPath, Path.GetFileName(fileName)));
                    if(Directory.GetDirectories(fileName).Length != 0 && Recursive)
                    {
                        SearchOto(Recursive, Path.Combine(subDirPath, Path.GetFileName(fileName)));
                    }

                }
            }
        }

        public void InputOto()
        {
            if( oto == null)
            {
                oto = new Dictionary<string, Oto>();
            }
            if (File.Exists(Path.Combine(DirPath, "oto.ini")))
            {
                inputData = new List<string>();
                inputData.AddRange(File.ReadAllLines(Path.Combine(DirPath, "oto.ini"), Encoding.GetEncoding("Shift_JIS")));
                ParseOto(oto, inputData);
            }
        }
        public void ParseOto(Dictionary<string, Oto> oto, List<string> inputData,string subDirPath ="")
        {
            foreach (string x in inputData)
            {
                if(!x.Contains("="))
                {
                    continue;
                }
                string[] tmp = x.Split('=');
                string[] splitData = tmp[1].Split(',');
                //ファイル名でエイリアス追加
                AddOto(oto, Path.Combine(subDirPath,tmp[0].Replace(".wav","")), subDirPath, tmp[0], splitData);
                //エイリアスがあればエイリアス通り追加
                if (splitData[0] != "")
                {
                    AddOto(oto, splitData[0], subDirPath, tmp[0], splitData);
                }

            }
        }

        private void AddOto(Dictionary<string, Oto> oto,string alias,string subDirPath,string fileName,string[] splitData)
        {
            if (oto.ContainsKey(alias))
            {
                return;
            }
            oto.Add(alias, new Oto());
            oto[alias].DirPath = subDirPath;
            oto[alias].FileName = fileName;
            oto[alias].Alias = alias;
            try
            {
                oto[alias].Offset = float.Parse(splitData[1]);
            }
            catch
            {
                oto[alias].Offset = 0f;
            }
            try
            {
                oto[alias].Vel = float.Parse(splitData[2]);
            }
            catch
            {
                oto[alias].Vel = 0f;
            }
            try
            {
                oto[alias].Blank = float.Parse(splitData[3]);
            }
            catch
            {
                oto[alias].Blank = 0f;
            }
            try
            {
                oto[alias].Pre = float.Parse(splitData[4]);
            }
            catch
            {
                oto[alias].Pre = 0f;
            }
            try
            {
                oto[alias].Ove = float.Parse(splitData[5]);
            }
            catch
            {
                oto[alias].Ove = 0f;
            }

        }

    }
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
