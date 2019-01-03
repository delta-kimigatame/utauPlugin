using Microsoft.VisualStudio.TestTools.UnitTesting;
using utauPlugin;
using System;
using System.Globalization;
using System.Threading;
namespace inputUstTest
{
    [TestClass]
    public class inputUstTest
    {
        UtauPlugin utauPlugin;

        [TestInitialize()]
        public void testInitialize()
        {
            utauPlugin = new UtauPlugin();
            utauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test119.tmp";
            utauPlugin.Input();

        }
        [TestMethod]
        public void SetUstVersion()
        {
            utauPlugin.Version="3.0";
            Assert.IsTrue(utauPlugin.Version == "3.0");
        }
        [TestMethod]
        public void SetUstVoiceDir()
        {
            utauPlugin.VoiceDir="C:\\Program Files (x86)\\UTAU\voice\\utau";
            Assert.IsTrue(utauPlugin.VoiceDir == "C:\\Program Files (x86)\\UTAU\voice\\utau");
        }
        //[TestMethod]
        //public void TestIsHeader()
        //{
        //    Assert.IsTrue(utauPlugin.IsHeader("[#SETTING]"));
        //    Assert.IsTrue(utauPlugin.IsHeader("UstVersion=1.19"));
        //    Assert.IsFalse(utauPlugin.IsHeader("[#0000]"));
        //    Assert.IsFalse(utauPlugin.IsHeader("[#PREV]"));
        //    Assert.IsFalse(utauPlugin.IsHeader("[#NEXT]"));
        //}
        [TestMethod]
        public void TestUstVersion()
        {
            Assert.IsTrue(utauPlugin.Version == "1.19");
        }
        [TestMethod]
        public void TestUstVersionV120()
        {
            utauPlugin = new UtauPlugin();
            utauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test120.tmp";
            utauPlugin.Input();
            Assert.IsTrue(utauPlugin.Version == "1.20");
        }
        [TestMethod]
        public void TestTempo()
        {
            Assert.IsTrue(utauPlugin.Tempo == 150.0f);
        }
        [TestMethod]
        public void TestNotePrev()
        {
            Assert.IsTrue(utauPlugin.note[0].GetNum() =="PREV");
            Assert.IsTrue(utauPlugin.note[0].GetLength() == 480);
            Assert.IsTrue(utauPlugin.note[0].GetLyric() == "あ");
            Assert.IsTrue(utauPlugin.note[0].GetNoteNum() == 60);
            Assert.IsTrue(utauPlugin.note[0].GetIntensity() == 100);
            Assert.IsTrue(utauPlugin.note[0].GetMod() == 0);
            Assert.IsTrue(utauPlugin.note[0].GetPbStart() == 0.0f);
            Assert.IsTrue(utauPlugin.note[0].GetPitches().Count == 97, utauPlugin.note[0].GetPitches().Count.ToString());
            Assert.IsTrue(utauPlugin.note[0].GetPitches()[utauPlugin.note[0].GetPitches().Count -1] == 0, utauPlugin.note[0].GetPitches()[utauPlugin.note[0].GetPitches().Count - 1].ToString());
            Assert.IsTrue(utauPlugin.note[0].GetAtPre() == 0.0f);
            Assert.IsTrue(utauPlugin.note[0].GetAtOve() == 0.0f);
            Assert.IsTrue(utauPlugin.note[0].GetAtStp() == 0.0f);
            Assert.IsTrue(utauPlugin.note[0].GetAtFileName() == "あ.wav");
            Assert.IsTrue(utauPlugin.note[0].GetAtAlias() == "あ");
        }
        [TestMethod]
        public void TestNote()
        {
            Assert.IsTrue(utauPlugin.note[1].GetNum() == "0002");
            Assert.IsTrue(utauPlugin.note[1].GetLength() == 480);
            Assert.IsTrue(utauPlugin.note[1].GetLyric() == "い");
            Assert.IsTrue(utauPlugin.note[1].GetNoteNum() == 60);
            Assert.IsTrue(utauPlugin.note[1].GetIntensity() == 100);
            Assert.IsTrue(utauPlugin.note[1].GetMod() == 0);
            Assert.IsTrue(utauPlugin.note[1].GetPbStart() == 0.0f);
            Assert.IsTrue(utauPlugin.note[1].GetPitches().Count == 98, utauPlugin.note[1].GetPitches().Count.ToString());
            Assert.IsTrue(utauPlugin.note[1].GetPitches()[utauPlugin.note[1].GetPitches().Count - 1] == 263, utauPlugin.note[1].GetPitches()[utauPlugin.note[1].GetPitches().Count - 1].ToString());
            Assert.IsTrue(utauPlugin.note[1].GetPbsTime() == -40);
            Assert.IsTrue(utauPlugin.note[1].GetPbsHeight() == 0);
            Assert.IsTrue(utauPlugin.note[1].GetPbw()[0] == 80f);
            Assert.IsTrue(utauPlugin.note[1].GetEnvelope() == "0,5,41,0,100,100,0", utauPlugin.note[1].GetEnvelope());
            Assert.IsTrue(utauPlugin.note[1].GetPbw().Count == 1);
            Assert.IsTrue(utauPlugin.note[1].GetAtPre() == 0.0f);
            Assert.IsTrue(utauPlugin.note[1].GetAtOve() == 0.0f);
            Assert.IsTrue(utauPlugin.note[1].GetAtStp() == 0.0f);
            Assert.IsTrue(utauPlugin.note[1].GetAtFileName() == "い.wav");
            Assert.IsTrue(utauPlugin.note[1].GetAtAlias() == "い");
        }
        [TestMethod]
        public void TestNote2()
        {
            Assert.IsTrue(utauPlugin.note[2].GetNum() == "0003");
            Assert.IsTrue(utauPlugin.note[2].GetLength() == 240);
            Assert.IsTrue(utauPlugin.note[2].GetLyric() == "う");
            Assert.IsTrue(utauPlugin.note[2].GetNoteNum() == 64);
            Assert.IsTrue(utauPlugin.note[2].GetPre() == 1.0f);
            Assert.IsTrue(utauPlugin.note[2].GetOve() == 2.0f);
            Assert.IsTrue(utauPlugin.note[2].GetVelocity() == 3);
            Assert.IsTrue(utauPlugin.note[2].GetIntensity() == 50);
            Assert.IsTrue(utauPlugin.note[2].GetMod() == 10);
            Assert.IsTrue(utauPlugin.note[2].GetPbStart() == -9.794f);
            Assert.IsTrue(utauPlugin.note[2].GetPitches().Count == 99, utauPlugin.note[2].GetPitches().Count.ToString());
            Assert.IsTrue(utauPlugin.note[2].GetPitches()[utauPlugin.note[2].GetPitches().Count - 1] == -211, utauPlugin.note[2].GetPitches()[utauPlugin.note[2].GetPitches().Count - 1].ToString());
            Assert.IsTrue(utauPlugin.note[2].GetPbsTime() == -212);
            Assert.IsTrue(utauPlugin.note[2].GetPbsHeight() == -40);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[0] == 180.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[1] == 180.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[2] == 147f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[3] == 148.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw().Count == 4);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[0] == -20f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[1] == 0f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[2] == -10.7f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[3] == -0f);
            Assert.IsTrue(utauPlugin.note[2].GetPby().Count == 4);
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[0] == "s");
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[1] == "r");
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[2] == "j");
            Assert.IsTrue(utauPlugin.note[2].GetPbm().Count == 3);
            Assert.IsTrue(utauPlugin.note[2].GetVibrato() == "65,180,35,20,20,0,0,0", utauPlugin.note[2].GetVibrato());
            Assert.IsTrue(utauPlugin.note[2].GetEnvelope() == "0,5,35,0,100,100,0,%,0,26,84", utauPlugin.note[2].GetEnvelope());
            Assert.IsTrue(utauPlugin.note[2].GetTempo() == 125.0f);
            Assert.IsTrue(utauPlugin.note[2].GetLabel() == "label");
            Assert.IsTrue(utauPlugin.note[2].GetRegion() == "region");
            Assert.IsTrue(utauPlugin.note[2].GetDirect());
            Assert.IsTrue(utauPlugin.note[2].GetStp() == 4.0f);
            Assert.IsTrue(utauPlugin.note[2].GetAtPre() == 1.958841f);
            Assert.IsTrue(utauPlugin.note[2].GetAtOve() == 3.917681f);
            Assert.IsTrue(utauPlugin.note[2].GetAtStp() == 4.0f);
            Assert.IsTrue(utauPlugin.note[2].GetAtFileName() == "う.wav");
            Assert.IsTrue(utauPlugin.note[2].GetAtAlias() == "う");
        }
        [TestMethod]
        public void TestNote3()
        {
            Assert.IsTrue(utauPlugin.note[3].GetNum() == "0004");
            Assert.IsTrue(utauPlugin.note[3].GetTempo() == 125.0f);
            Assert.IsTrue(utauPlugin.note[3].GetRegionEnd() == "region");
        }
        [TestMethod]
        public void TestNote2V120()
        {
            utauPlugin = new UtauPlugin();
            utauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test120.tmp";
            utauPlugin.Input();
            Assert.IsTrue(utauPlugin.note[2].GetNum() == "0003");
            Assert.IsTrue(utauPlugin.note[2].GetLength() == 240);
            Assert.IsTrue(utauPlugin.note[2].GetLyric() == "う");
            Assert.IsTrue(utauPlugin.note[2].GetNoteNum() == 64);
            Assert.IsTrue(utauPlugin.note[2].GetPre() == 1.0f);
            Assert.IsTrue(utauPlugin.note[2].GetOve() == 2.0f);
            Assert.IsTrue(utauPlugin.note[2].GetVelocity() == 3);
            Assert.IsTrue(utauPlugin.note[2].GetIntensity() == 50);
            Assert.IsTrue(utauPlugin.note[2].GetMod() == 10);
            Assert.IsTrue(utauPlugin.note[2].GetPbStart() == -9.794f);
            Assert.IsTrue(utauPlugin.note[2].GetPitches().Count == 99, utauPlugin.note[2].GetPitches().Count.ToString());
            Assert.IsTrue(utauPlugin.note[2].GetPitches()[utauPlugin.note[2].GetPitches().Count - 1] == -211, utauPlugin.note[2].GetPitches()[utauPlugin.note[2].GetPitches().Count - 1].ToString());
            Assert.IsTrue(utauPlugin.note[2].GetPbsTime() == -212);
            Assert.IsTrue(utauPlugin.note[2].GetPbsHeight() == -40);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[0] == 180.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[1] == 180.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[2] == 147f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[3] == 148.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw().Count == 4);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[0] == -20f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[1] == 0f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[2] == -10.7f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[3] == -0f);
            Assert.IsTrue(utauPlugin.note[2].GetPby().Count == 4);
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[0] == "s");
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[1] == "r");
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[2] == "j");
            Assert.IsTrue(utauPlugin.note[2].GetPbm().Count == 3);
            Assert.IsTrue(utauPlugin.note[2].GetVibrato() == "65,180,35,20,20,0,0,0", utauPlugin.note[2].GetVibrato());
            Assert.IsTrue(utauPlugin.note[2].GetEnvelope() == "0,5,35,0,100,100,0,%,0,26,84", utauPlugin.note[2].GetEnvelope());
            Assert.IsTrue(utauPlugin.note[2].GetTempo() == 125.0f);
            Assert.IsTrue(utauPlugin.note[2].GetLabel() == "label");
            Assert.IsTrue(utauPlugin.note[2].GetRegion() == "region");
            Assert.IsTrue(utauPlugin.note[2].GetDirect());
            Assert.IsTrue(utauPlugin.note[2].GetStp() == 4.0f);
            Assert.IsTrue(utauPlugin.note[2].GetAtPre() == 1.958841f);
            Assert.IsTrue(utauPlugin.note[2].GetAtOve() == 3.917681f);
            Assert.IsTrue(utauPlugin.note[2].GetAtStp() == 4.0f);
            Assert.IsTrue(utauPlugin.note[2].GetAtFileName() == "う.wav");
            Assert.IsTrue(utauPlugin.note[2].GetAtAlias() == "う");
        }
        [TestMethod]
        public void TestNote2V111()
        {
            utauPlugin = new UtauPlugin();
            utauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test111.tmp";
            utauPlugin.Input();
            Assert.IsTrue(utauPlugin.note[2].GetNum() == "0003");
            Assert.IsTrue(utauPlugin.note[2].GetLength() == 240);
            Assert.IsTrue(utauPlugin.note[2].GetLyric() == "う");
            Assert.IsTrue(utauPlugin.note[2].GetNoteNum() == 64);
            Assert.IsTrue(utauPlugin.note[2].GetPre() == 1.0f);
            Assert.IsTrue(utauPlugin.note[2].GetOve() == 2.0f);
            Assert.IsTrue(utauPlugin.note[2].GetVelocity() == 3);
            Assert.IsTrue(utauPlugin.note[2].GetIntensity() == 50);
            Assert.IsTrue(utauPlugin.note[2].GetMod() == 10);
            Assert.IsTrue(utauPlugin.note[2].GetPbStart() == -9.794f);
            Assert.IsTrue(utauPlugin.note[2].GetPitches().Count == 99, utauPlugin.note[2].GetPitches().Count.ToString());
            Assert.IsTrue(utauPlugin.note[2].GetPitches()[utauPlugin.note[2].GetPitches().Count - 1] == -211, utauPlugin.note[2].GetPitches()[utauPlugin.note[2].GetPitches().Count - 1].ToString());
            Assert.IsTrue(utauPlugin.note[2].GetPbsTime() == -212);
            Assert.IsTrue(utauPlugin.note[2].GetPbsHeight() == -40);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[0] == 180.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[1] == 180.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[2] == 147f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[3] == 148.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw().Count == 4);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[0] == -20f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[1] == 0f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[2] == -10.7f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[3] == -0f);
            Assert.IsTrue(utauPlugin.note[2].GetPby().Count == 4);
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[0] == "s");
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[1] == "r");
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[2] == "j");
            Assert.IsTrue(utauPlugin.note[2].GetPbm().Count == 3);
            Assert.IsTrue(utauPlugin.note[2].GetVibrato() == "65,180,35,20,20,0,0,0", utauPlugin.note[2].GetVibrato());
            Assert.IsTrue(utauPlugin.note[2].GetEnvelope() == "0,5,35,0,100,100,0,%,0,26,84", utauPlugin.note[2].GetEnvelope());
            Assert.IsTrue(utauPlugin.note[2].GetTempo() == 125.0f);
            Assert.IsTrue(utauPlugin.note[2].GetLabel() == "label");
            Assert.IsTrue(utauPlugin.note[2].GetRegion() == "region");
            Assert.IsTrue(utauPlugin.note[2].GetDirect());
            Assert.IsTrue(utauPlugin.note[2].GetStp() == 4.0f);
            Assert.IsTrue(utauPlugin.note[2].GetAtPre() == 1.958841f);
            Assert.IsTrue(utauPlugin.note[2].GetAtOve() == 3.917681f);
            Assert.IsTrue(utauPlugin.note[2].GetAtStp() == 4.0f);
            Assert.IsTrue(utauPlugin.note[2].GetAtFileName() == "う.wav");
            Assert.IsTrue(utauPlugin.note[2].GetAtAlias() == "う");
        }
        [TestMethod]
        public void TestNote2V101()
        {
            utauPlugin = new UtauPlugin();
            utauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test101.tmp";
            utauPlugin.Input();
            Assert.IsTrue(utauPlugin.note[2].GetNum() == "0003");
            Assert.IsTrue(utauPlugin.note[2].GetLength() == 240);
            Assert.IsTrue(utauPlugin.note[2].GetLyric() == "う");
            Assert.IsTrue(utauPlugin.note[2].GetNoteNum() == 64);
            Assert.IsTrue(utauPlugin.note[2].GetPre() == 1.0f);
            Assert.IsTrue(utauPlugin.note[2].GetOve() == 2.0f);
            Assert.IsTrue(utauPlugin.note[2].GetVelocity() == 3);
            Assert.IsTrue(utauPlugin.note[2].GetIntensity() == 50);
            Assert.IsTrue(utauPlugin.note[2].GetMod() == 10);
            Assert.IsTrue(utauPlugin.note[2].GetPbStart() == -9.794f);
            Assert.IsTrue(utauPlugin.note[2].GetPitches().Count == 99, utauPlugin.note[2].GetPitches().Count.ToString());
            Assert.IsTrue(utauPlugin.note[2].GetPitches()[utauPlugin.note[2].GetPitches().Count - 1] == -211, utauPlugin.note[2].GetPitches()[utauPlugin.note[2].GetPitches().Count - 1].ToString());
            Assert.IsTrue(utauPlugin.note[2].GetPbsTime() == -212);
            Assert.IsTrue(utauPlugin.note[2].GetPbsHeight() == -40);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[0] == 180.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[1] == 180.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[2] == 147f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[3] == 148.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw().Count == 4);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[0] == -20f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[1] == 0f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[2] == -10.7f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[3] == -0f);
            Assert.IsTrue(utauPlugin.note[2].GetPby().Count == 4);
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[0] == "s");
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[1] == "r");
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[2] == "j");
            Assert.IsTrue(utauPlugin.note[2].GetPbm().Count == 3);
            Assert.IsTrue(utauPlugin.note[2].GetVibrato() == "65,180,35,20,20,0,0,0", utauPlugin.note[2].GetVibrato());
            Assert.IsTrue(utauPlugin.note[2].GetEnvelope() == "0,5,35,0,100,100,0,%,0,26,84", utauPlugin.note[2].GetEnvelope());
            Assert.IsTrue(utauPlugin.note[2].GetTempo() == 125.0f);
            Assert.IsTrue(utauPlugin.note[2].GetLabel() == "label");
            Assert.IsTrue(utauPlugin.note[2].GetRegion() == "region");
            Assert.IsTrue(utauPlugin.note[2].GetDirect());
            Assert.IsTrue(utauPlugin.note[2].GetStp() == 4.0f);
            Assert.IsTrue(utauPlugin.note[2].GetAtPre() == 1.958841f);
            Assert.IsTrue(utauPlugin.note[2].GetAtOve() == 3.917681f);
            Assert.IsTrue(utauPlugin.note[2].GetAtStp() == 4.0f);
            Assert.IsTrue(utauPlugin.note[2].GetAtFileName() == "う.wav");
            Assert.IsTrue(utauPlugin.note[2].GetAtAlias() == "う");
        }
        [TestMethod]
        public void TestNote2V100()
        {
            //UTAU0276仕様
            //atパラメーターはない
            //PBStartもない
            utauPlugin = new UtauPlugin();
            utauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test100.tmp";
            utauPlugin.Input();
            Assert.IsTrue(utauPlugin.note[2].GetNum() == "0003");
            Assert.IsTrue(utauPlugin.note[2].GetLength() == 240);
            Assert.IsTrue(utauPlugin.note[2].GetLyric() == "う");
            Assert.IsTrue(utauPlugin.note[2].GetNoteNum() == 64);
            Assert.IsTrue(utauPlugin.note[2].GetPre() == 1.0f);
            Assert.IsTrue(utauPlugin.note[2].GetOve() == 2.0f);
            Assert.IsTrue(utauPlugin.note[2].GetVelocity() == 3);
            Assert.IsTrue(utauPlugin.note[2].GetIntensity() == 50);
            Assert.IsTrue(utauPlugin.note[2].GetMod() == 10);
            //Assert.IsTrue(utauPlugin.note[2].GetPbStart() == -9.794f);
            //末尾に0が付くらしく，utau0416出力とピッチ数列の長さが違う
            Assert.IsTrue(utauPlugin.note[2].GetPitches().Count == 100, utauPlugin.note[2].GetPitches().Count.ToString());
            Assert.IsTrue(utauPlugin.note[2].GetPitches()[utauPlugin.note[2].GetPitches().Count - 1] == 0, utauPlugin.note[2].GetPitches()[utauPlugin.note[2].GetPitches().Count - 1].ToString());
            Assert.IsTrue(utauPlugin.note[2].GetPbsTime() == -212);
            Assert.IsTrue(utauPlugin.note[2].GetPbsHeight() == -40);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[0] == 180.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[1] == 180.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[2] == 147f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw()[3] == 148.5f);
            Assert.IsTrue(utauPlugin.note[2].GetPbw().Count == 4);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[0] == -20f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[1] == 0f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[2] == -10.7f);
            Assert.IsTrue(utauPlugin.note[2].GetPby()[3] == -0f);
            Assert.IsTrue(utauPlugin.note[2].GetPby().Count == 4);
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[0] == "s");
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[1] == "r");
            Assert.IsTrue(utauPlugin.note[2].GetPbm()[2] == "j");
            Assert.IsTrue(utauPlugin.note[2].GetPbm().Count == 3);
            Assert.IsTrue(utauPlugin.note[2].GetVibrato() == "65,180,35,20,20,0,0,0", utauPlugin.note[2].GetVibrato());
            Assert.IsTrue(utauPlugin.note[2].GetEnvelope() == "0,5,35,0,100,100,0,%,0,26,84", utauPlugin.note[2].GetEnvelope());
            Assert.IsTrue(utauPlugin.note[2].GetTempo() == 125.0f);
            //utau0276ではlabelが予約語?なのか勝手にLabelに変換された．
            //Label=testの時はTestにならずtestのまま出てくる．なぞ．
            Assert.IsTrue(utauPlugin.note[2].GetLabel() == "Label", utauPlugin.note[2].GetLabel());
            Assert.IsTrue(utauPlugin.note[2].GetRegion() == "region");
            Assert.IsTrue(utauPlugin.note[2].GetDirect());
            Assert.IsTrue(utauPlugin.note[2].GetStp() == 4.0f);
            //Assert.IsTrue(utauPlugin.note[2].GetAtPre() == 1.958841f);
            //Assert.IsTrue(utauPlugin.note[2].GetAtOve() == 3.917681f);
            //Assert.IsTrue(utauPlugin.note[2].GetAtStp() == 4.0f);
            //Assert.IsTrue(utauPlugin.note[2].GetAtFileName() == "う.wav");
            //Assert.IsTrue(utauPlugin.note[2].GetAtAlias() == "う");
        }
        [TestMethod]
        public void TestLocale()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-TW");
            utauPlugin = new UtauPlugin();
            utauPlugin.FilePath = "..\\..\\..\\test\\inputData\\locale.tmp";
            utauPlugin.Input();
        }
    }
}
