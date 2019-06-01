using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utauPlugin;

namespace InsertNote
{
    class InsertNote
    {
        static void Main(string[] args)
        {
            UtauPlugin utauPlugin = new UtauPlugin(args[0]);
            utauPlugin.Input();
            utauPlugin.InputVoiceBank();//oto.iniとprefix.mapの読込
            utauPlugin.InitAtParam();//@つきの5パラメータをいい感じに計算
            for(int i = 0; i < utauPlugin.note.Count(); i++)
            {
                if(utauPlugin.note[i].GetNum()=="PREV" || utauPlugin.note[i].GetNum() == "NEXT")
                {
                    continue;
                }
                if (utauPlugin.note[i].GetLyric() == "R")
                {
                    continue;
                }
                utauPlugin.note[i].SetLength(utauPlugin.note[i].GetLength() / 2);
                utauPlugin.InsertNote(i);
                utauPlugin.note[i].SetLength(utauPlugin.note[i].Next.GetLength());
                utauPlugin.note[i].SetLyric("r");
                i++;
                
            }
            utauPlugin.Output();
        }
    }
}
