using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtauPlugin;
using System;
using System.Globalization;
using System.Threading;
namespace inputUstTest
{
    [TestClass]
    public class inputUstTest
    {
        UtauPlugin.UtauPlugin UtauPlugin;

        [TestInitialize()]
        public void testInitialize()
        {
            UtauPlugin = new UtauPlugin.UtauPlugin();
            UtauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test119.tmp";
            UtauPlugin.Input();

        }
        [TestMethod]
        public void SetUstVersion()
        {
            UtauPlugin.Version="3.0";
            Assert.IsTrue(UtauPlugin.Version == "3.0");
        }
        [TestMethod]
        public void SetUstVoiceDir()
        {
            UtauPlugin.VoiceDir="C:\\Program Files (x86)\\UTAU\voice\\utau";
            Assert.IsTrue(UtauPlugin.VoiceDir == "C:\\Program Files (x86)\\UTAU\voice\\utau");
        }
        //[TestMethod]
        //public void TestIsHeader()
        //{
        //    Assert.IsTrue(UtauPlugin.IsHeader("[#SETTING]"));
        //    Assert.IsTrue(UtauPlugin.IsHeader("UstVersion=1.19"));
        //    Assert.IsFalse(UtauPlugin.IsHeader("[#0000]"));
        //    Assert.IsFalse(UtauPlugin.IsHeader("[#PREV]"));
        //    Assert.IsFalse(UtauPlugin.IsHeader("[#NEXT]"));
        //}
        [TestMethod]
        public void TestUstVersion()
        {
            Assert.IsTrue(UtauPlugin.Version == "1.19");
        }
        [TestMethod]
        public void TestUstVersionV120()
        {
            UtauPlugin = new UtauPlugin.UtauPlugin();
            UtauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test120.tmp";
            UtauPlugin.Input();
            Assert.IsTrue(UtauPlugin.Version == "1.20");
        }
        [TestMethod]
        public void TestTempo()
        {
            Assert.IsTrue(UtauPlugin.Tempo == 150.0f);
        }
        [TestMethod]
        public void TestNotePrev()
        {
            Assert.IsTrue(UtauPlugin.note[0].GetNum() =="PREV");
            Assert.IsTrue(UtauPlugin.note[0].GetLength() == 480);
            Assert.IsTrue(UtauPlugin.note[0].GetLyric() == "あ");
            Assert.IsTrue(UtauPlugin.note[0].GetNoteNum() == 60);
            Assert.IsTrue(UtauPlugin.note[0].GetIntensity() == 100);
            Assert.IsTrue(UtauPlugin.note[0].GetMod() == 0);
            Assert.IsTrue(UtauPlugin.note[0].GetPbStart() == 0.0f);
            Assert.IsTrue(UtauPlugin.note[0].GetPitches().Count == 97, UtauPlugin.note[0].GetPitches().Count.ToString());
            Assert.IsTrue(UtauPlugin.note[0].GetPitches()[UtauPlugin.note[0].GetPitches().Count -1] == 0, UtauPlugin.note[0].GetPitches()[UtauPlugin.note[0].GetPitches().Count - 1].ToString());
            Assert.IsTrue(UtauPlugin.note[0].GetAtPre() == 0.0f);
            Assert.IsTrue(UtauPlugin.note[0].GetAtOve() == 0.0f);
            Assert.IsTrue(UtauPlugin.note[0].GetAtStp() == 0.0f);
            Assert.IsTrue(UtauPlugin.note[0].GetAtFileName() == "あ.wav");
            Assert.IsTrue(UtauPlugin.note[0].GetAtAlias() == "あ");
        }
        [TestMethod]
        public void TestNote()
        {
            Assert.IsTrue(UtauPlugin.note[1].GetNum() == "0002");
            Assert.IsTrue(UtauPlugin.note[1].GetLength() == 480);
            Assert.IsTrue(UtauPlugin.note[1].GetLyric() == "い");
            Assert.IsTrue(UtauPlugin.note[1].GetNoteNum() == 60);
            Assert.IsTrue(UtauPlugin.note[1].GetIntensity() == 100);
            Assert.IsTrue(UtauPlugin.note[1].GetMod() == 0);
            Assert.IsTrue(UtauPlugin.note[1].GetPbStart() == 0.0f);
            Assert.IsTrue(UtauPlugin.note[1].GetPitches().Count == 98, UtauPlugin.note[1].GetPitches().Count.ToString());
            Assert.IsTrue(UtauPlugin.note[1].GetPitches()[UtauPlugin.note[1].GetPitches().Count - 1] == 263, UtauPlugin.note[1].GetPitches()[UtauPlugin.note[1].GetPitches().Count - 1].ToString());
            Assert.IsTrue(UtauPlugin.note[1].GetPbsTime() == -40);
            Assert.IsTrue(UtauPlugin.note[1].GetPbsHeight() == 0);
            Assert.IsTrue(UtauPlugin.note[1].GetPbw()[0] == 80f);
            Assert.IsTrue(UtauPlugin.note[1].GetEnvelope() == "0,5,41,0,100,100,0", UtauPlugin.note[1].GetEnvelope());
            Assert.IsTrue(UtauPlugin.note[1].GetPbw().Count == 1);
            Assert.IsTrue(UtauPlugin.note[1].GetAtPre() == 0.0f);
            Assert.IsTrue(UtauPlugin.note[1].GetAtOve() == 0.0f);
            Assert.IsTrue(UtauPlugin.note[1].GetAtStp() == 0.0f);
            Assert.IsTrue(UtauPlugin.note[1].GetAtFileName() == "い.wav");
            Assert.IsTrue(UtauPlugin.note[1].GetAtAlias() == "い");
        }
        [TestMethod]
        public void TestNote2()
        {
            Assert.IsTrue(UtauPlugin.note[2].GetNum() == "0003");
            Assert.IsTrue(UtauPlugin.note[2].GetLength() == 240);
            Assert.IsTrue(UtauPlugin.note[2].GetLyric() == "う");
            Assert.IsTrue(UtauPlugin.note[2].GetNoteNum() == 64);
            Assert.IsTrue(UtauPlugin.note[2].GetPre() == 1.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetOve() == 2.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetVelocity() == 3);
            Assert.IsTrue(UtauPlugin.note[2].GetIntensity() == 50);
            Assert.IsTrue(UtauPlugin.note[2].GetMod() == 10);
            Assert.IsTrue(UtauPlugin.note[2].GetPbStart() == -9.794f);
            Assert.IsTrue(UtauPlugin.note[2].GetPitches().Count == 99, UtauPlugin.note[2].GetPitches().Count.ToString());
            Assert.IsTrue(UtauPlugin.note[2].GetPitches()[UtauPlugin.note[2].GetPitches().Count - 1] == -211, UtauPlugin.note[2].GetPitches()[UtauPlugin.note[2].GetPitches().Count - 1].ToString());
            Assert.IsTrue(UtauPlugin.note[2].GetPbsTime() == -212);
            Assert.IsTrue(UtauPlugin.note[2].GetPbsHeight() == -40);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[0] == 180.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[1] == 180.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[2] == 147f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[3] == 148.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw().Count == 4);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[0] == -20f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[1] == 0f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[2] == -10.7f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[3] == -0f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby().Count == 4);
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[0] == "s");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[1] == "r");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[2] == "j");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm().Count == 3);
            Assert.IsTrue(UtauPlugin.note[2].GetVibrato() == "65,180,35,20,20,0,0,0", UtauPlugin.note[2].GetVibrato());
            Assert.IsTrue(UtauPlugin.note[2].GetEnvelope() == "0,5,35,0,100,100,0,%,0,26,84", UtauPlugin.note[2].GetEnvelope());
            Assert.IsTrue(UtauPlugin.note[2].GetTempo() == 125.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetLabel() == "label");
            Assert.IsTrue(UtauPlugin.note[2].GetRegion() == "region");
            Assert.IsTrue(UtauPlugin.note[2].GetDirect());
            Assert.IsTrue(UtauPlugin.note[2].GetStp() == 4.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtPre() == 1.958841f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtOve() == 3.917681f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtStp() == 4.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtFileName() == "う.wav");
            Assert.IsTrue(UtauPlugin.note[2].GetAtAlias() == "う");
        }
        [TestMethod]
        public void TestNote3()
        {
            Assert.IsTrue(UtauPlugin.note[3].GetNum() == "0004");
            Assert.IsTrue(UtauPlugin.note[3].GetTempo() == 125.0f);
            Assert.IsTrue(UtauPlugin.note[3].GetRegionEnd() == "region");
        }
        [TestMethod]
        public void TestNote2V120()
        {
            UtauPlugin = new UtauPlugin.UtauPlugin();
            UtauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test120.tmp";
            UtauPlugin.Input();
            Assert.IsTrue(UtauPlugin.note[2].GetNum() == "0003");
            Assert.IsTrue(UtauPlugin.note[2].GetLength() == 240);
            Assert.IsTrue(UtauPlugin.note[2].GetLyric() == "う");
            Assert.IsTrue(UtauPlugin.note[2].GetNoteNum() == 64);
            Assert.IsTrue(UtauPlugin.note[2].GetPre() == 1.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetOve() == 2.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetVelocity() == 3);
            Assert.IsTrue(UtauPlugin.note[2].GetIntensity() == 50);
            Assert.IsTrue(UtauPlugin.note[2].GetMod() == 10);
            Assert.IsTrue(UtauPlugin.note[2].GetPbStart() == -9.794f);
            Assert.IsTrue(UtauPlugin.note[2].GetPitches().Count == 99, UtauPlugin.note[2].GetPitches().Count.ToString());
            Assert.IsTrue(UtauPlugin.note[2].GetPitches()[UtauPlugin.note[2].GetPitches().Count - 1] == -211, UtauPlugin.note[2].GetPitches()[UtauPlugin.note[2].GetPitches().Count - 1].ToString());
            Assert.IsTrue(UtauPlugin.note[2].GetPbsTime() == -212);
            Assert.IsTrue(UtauPlugin.note[2].GetPbsHeight() == -40);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[0] == 180.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[1] == 180.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[2] == 147f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[3] == 148.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw().Count == 4);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[0] == -20f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[1] == 0f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[2] == -10.7f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[3] == -0f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby().Count == 4);
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[0] == "s");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[1] == "r");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[2] == "j");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm().Count == 3);
            Assert.IsTrue(UtauPlugin.note[2].GetVibrato() == "65,180,35,20,20,0,0,0", UtauPlugin.note[2].GetVibrato());
            Assert.IsTrue(UtauPlugin.note[2].GetEnvelope() == "0,5,35,0,100,100,0,%,0,26,84", UtauPlugin.note[2].GetEnvelope());
            Assert.IsTrue(UtauPlugin.note[2].GetTempo() == 125.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetLabel() == "label");
            Assert.IsTrue(UtauPlugin.note[2].GetRegion() == "region");
            Assert.IsTrue(UtauPlugin.note[2].GetDirect());
            Assert.IsTrue(UtauPlugin.note[2].GetStp() == 4.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtPre() == 1.958841f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtOve() == 3.917681f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtStp() == 4.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtFileName() == "う.wav");
            Assert.IsTrue(UtauPlugin.note[2].GetAtAlias() == "う");
        }
        [TestMethod]
        public void TestNote2V111()
        {
            UtauPlugin = new UtauPlugin.UtauPlugin();
            UtauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test111.tmp";
            UtauPlugin.Input();
            Assert.IsTrue(UtauPlugin.note[2].GetNum() == "0003");
            Assert.IsTrue(UtauPlugin.note[2].GetLength() == 240);
            Assert.IsTrue(UtauPlugin.note[2].GetLyric() == "う");
            Assert.IsTrue(UtauPlugin.note[2].GetNoteNum() == 64);
            Assert.IsTrue(UtauPlugin.note[2].GetPre() == 1.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetOve() == 2.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetVelocity() == 3);
            Assert.IsTrue(UtauPlugin.note[2].GetIntensity() == 50);
            Assert.IsTrue(UtauPlugin.note[2].GetMod() == 10);
            Assert.IsTrue(UtauPlugin.note[2].GetPbStart() == -9.794f);
            Assert.IsTrue(UtauPlugin.note[2].GetPitches().Count == 99, UtauPlugin.note[2].GetPitches().Count.ToString());
            Assert.IsTrue(UtauPlugin.note[2].GetPitches()[UtauPlugin.note[2].GetPitches().Count - 1] == -211, UtauPlugin.note[2].GetPitches()[UtauPlugin.note[2].GetPitches().Count - 1].ToString());
            Assert.IsTrue(UtauPlugin.note[2].GetPbsTime() == -212);
            Assert.IsTrue(UtauPlugin.note[2].GetPbsHeight() == -40);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[0] == 180.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[1] == 180.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[2] == 147f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[3] == 148.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw().Count == 4);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[0] == -20f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[1] == 0f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[2] == -10.7f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[3] == -0f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby().Count == 4);
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[0] == "s");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[1] == "r");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[2] == "j");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm().Count == 3);
            Assert.IsTrue(UtauPlugin.note[2].GetVibrato() == "65,180,35,20,20,0,0,0", UtauPlugin.note[2].GetVibrato());
            Assert.IsTrue(UtauPlugin.note[2].GetEnvelope() == "0,5,35,0,100,100,0,%,0,26,84", UtauPlugin.note[2].GetEnvelope());
            Assert.IsTrue(UtauPlugin.note[2].GetTempo() == 125.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetLabel() == "label");
            Assert.IsTrue(UtauPlugin.note[2].GetRegion() == "region");
            Assert.IsTrue(UtauPlugin.note[2].GetDirect());
            Assert.IsTrue(UtauPlugin.note[2].GetStp() == 4.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtPre() == 1.958841f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtOve() == 3.917681f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtStp() == 4.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtFileName() == "う.wav");
            Assert.IsTrue(UtauPlugin.note[2].GetAtAlias() == "う");
        }
        [TestMethod]
        public void TestNote2V101()
        {
            UtauPlugin = new UtauPlugin.UtauPlugin();
            UtauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test101.tmp";
            UtauPlugin.Input();
            Assert.IsTrue(UtauPlugin.note[2].GetNum() == "0003");
            Assert.IsTrue(UtauPlugin.note[2].GetLength() == 240);
            Assert.IsTrue(UtauPlugin.note[2].GetLyric() == "う");
            Assert.IsTrue(UtauPlugin.note[2].GetNoteNum() == 64);
            Assert.IsTrue(UtauPlugin.note[2].GetPre() == 1.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetOve() == 2.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetVelocity() == 3);
            Assert.IsTrue(UtauPlugin.note[2].GetIntensity() == 50);
            Assert.IsTrue(UtauPlugin.note[2].GetMod() == 10);
            Assert.IsTrue(UtauPlugin.note[2].GetPbStart() == -9.794f);
            Assert.IsTrue(UtauPlugin.note[2].GetPitches().Count == 99, UtauPlugin.note[2].GetPitches().Count.ToString());
            Assert.IsTrue(UtauPlugin.note[2].GetPitches()[UtauPlugin.note[2].GetPitches().Count - 1] == -211, UtauPlugin.note[2].GetPitches()[UtauPlugin.note[2].GetPitches().Count - 1].ToString());
            Assert.IsTrue(UtauPlugin.note[2].GetPbsTime() == -212);
            Assert.IsTrue(UtauPlugin.note[2].GetPbsHeight() == -40);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[0] == 180.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[1] == 180.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[2] == 147f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[3] == 148.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw().Count == 4);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[0] == -20f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[1] == 0f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[2] == -10.7f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[3] == -0f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby().Count == 4);
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[0] == "s");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[1] == "r");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[2] == "j");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm().Count == 3);
            Assert.IsTrue(UtauPlugin.note[2].GetVibrato() == "65,180,35,20,20,0,0,0", UtauPlugin.note[2].GetVibrato());
            Assert.IsTrue(UtauPlugin.note[2].GetEnvelope() == "0,5,35,0,100,100,0,%,0,26,84", UtauPlugin.note[2].GetEnvelope());
            Assert.IsTrue(UtauPlugin.note[2].GetTempo() == 125.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetLabel() == "label");
            Assert.IsTrue(UtauPlugin.note[2].GetRegion() == "region");
            Assert.IsTrue(UtauPlugin.note[2].GetDirect());
            Assert.IsTrue(UtauPlugin.note[2].GetStp() == 4.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtPre() == 1.958841f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtOve() == 3.917681f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtStp() == 4.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtFileName() == "う.wav");
            Assert.IsTrue(UtauPlugin.note[2].GetAtAlias() == "う");
        }
        [TestMethod]
        public void TestNote2V100()
        {
            //UTAU0276仕様
            //atパラメーターはない
            //PBStartもない
            UtauPlugin = new UtauPlugin.UtauPlugin();
            UtauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test100.tmp";
            UtauPlugin.Input();
            Assert.IsTrue(UtauPlugin.note[2].GetNum() == "0003");
            Assert.IsTrue(UtauPlugin.note[2].GetLength() == 240);
            Assert.IsTrue(UtauPlugin.note[2].GetLyric() == "う");
            Assert.IsTrue(UtauPlugin.note[2].GetNoteNum() == 64);
            Assert.IsTrue(UtauPlugin.note[2].GetPre() == 1.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetOve() == 2.0f);
            Assert.IsTrue(UtauPlugin.note[2].GetVelocity() == 3);
            Assert.IsTrue(UtauPlugin.note[2].GetIntensity() == 50);
            Assert.IsTrue(UtauPlugin.note[2].GetMod() == 10);
            //Assert.IsTrue(UtauPlugin.note[2].GetPbStart() == -9.794f);
            //末尾に0が付くらしく，utau0416出力とピッチ数列の長さが違う
            Assert.IsTrue(UtauPlugin.note[2].GetPitches().Count == 100, UtauPlugin.note[2].GetPitches().Count.ToString());
            Assert.IsTrue(UtauPlugin.note[2].GetPitches()[UtauPlugin.note[2].GetPitches().Count - 1] == 0, UtauPlugin.note[2].GetPitches()[UtauPlugin.note[2].GetPitches().Count - 1].ToString());
            Assert.IsTrue(UtauPlugin.note[2].GetPbsTime() == -212);
            Assert.IsTrue(UtauPlugin.note[2].GetPbsHeight() == -40);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[0] == 180.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[1] == 180.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[2] == 147f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw()[3] == 148.5f);
            Assert.IsTrue(UtauPlugin.note[2].GetPbw().Count == 4);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[0] == -20f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[1] == 0f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[2] == -10.7f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby()[3] == -0f);
            Assert.IsTrue(UtauPlugin.note[2].GetPby().Count == 4);
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[0] == "s");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[1] == "r");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm()[2] == "j");
            Assert.IsTrue(UtauPlugin.note[2].GetPbm().Count == 3);
            Assert.IsTrue(UtauPlugin.note[2].GetVibrato() == "65,180,35,20,20,0,0,0", UtauPlugin.note[2].GetVibrato());
            Assert.IsTrue(UtauPlugin.note[2].GetEnvelope() == "0,5,35,0,100,100,0,%,0,26,84", UtauPlugin.note[2].GetEnvelope());
            Assert.IsTrue(UtauPlugin.note[2].GetTempo() == 125.0f);
            //utau0276ではlabelが予約語?なのか勝手にLabelに変換された．
            //Label=testの時はTestにならずtestのまま出てくる．なぞ．
            Assert.IsTrue(UtauPlugin.note[2].GetLabel() == "Label", UtauPlugin.note[2].GetLabel());
            Assert.IsTrue(UtauPlugin.note[2].GetRegion() == "region");
            Assert.IsTrue(UtauPlugin.note[2].GetDirect());
            Assert.IsTrue(UtauPlugin.note[2].GetStp() == 4.0f);
            //Assert.IsTrue(UtauPlugin.note[2].GetAtPre() == 1.958841f);
            //Assert.IsTrue(UtauPlugin.note[2].GetAtOve() == 3.917681f);
            //Assert.IsTrue(UtauPlugin.note[2].GetAtStp() == 4.0f);
            //Assert.IsTrue(UtauPlugin.note[2].GetAtFileName() == "う.wav");
            //Assert.IsTrue(UtauPlugin.note[2].GetAtAlias() == "う");
        }
        [TestMethod]
        public void TestLocale()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-TW");
            UtauPlugin = new UtauPlugin.UtauPlugin();
            UtauPlugin.FilePath = "..\\..\\..\\test\\inputData\\locale.tmp";
            UtauPlugin.Input();
        }
        [TestMethod]
        public void Error20190103()
        {
            UtauPlugin = new UtauPlugin.UtauPlugin();
            UtauPlugin.FilePath = "..\\..\\..\\test\\inputData\\20190103Error.txt";
            UtauPlugin.Input();
        }
        [TestMethod()]
        public void InitOriginalEntryTest()
        {
            UtauPlugin = new UtauPlugin.UtauPlugin();
            UtauPlugin.FilePath = "..\\..\\..\\test\\inputData\\originalEntry.tmp";
            UtauPlugin.InitOriginalEntry("myEntry", "ccc");
            UtauPlugin.InitOriginalEntry("myEntry2", "");
            UtauPlugin.Input();
            Assert.IsTrue("hoge"==UtauPlugin.note[2].GetOriginalEntry("myEntry").ToString());
            Assert.IsTrue("fuga"==UtauPlugin.note[2].GetOriginalEntry("myEntry2").ToString());
            UtauPlugin.note[3].InitOriginalEntry("myEntry", "aaa");
            Assert.IsTrue("aaa" == UtauPlugin.note[3].GetOriginalEntry("myEntry").ToString());
            UtauPlugin.note[1].SetOriginalEntry("myEntry2", "bbb");
            Assert.IsTrue("bbb" == UtauPlugin.note[1].GetOriginalEntry("myEntry2").ToString());
            Assert.IsTrue("ccc" == UtauPlugin.note[1].GetOriginalEntry("myEntry").ToString());

        }
        [TestMethod]
        public void Error20190110()
        {
            UtauPlugin = new UtauPlugin.UtauPlugin();
            UtauPlugin.FilePath = "..\\..\\..\\test\\inputData\\error20190110.txt";
            UtauPlugin.Input();
        }
        [TestMethod]
        public void TestNotePrevNext()
        {
            Assert.IsTrue(UtauPlugin.note[1].GetNum() == "0002");
            Assert.IsTrue(UtauPlugin.note[1].Next.GetNum() == "0003");
            Assert.IsTrue(UtauPlugin.note[2].Prev.GetNum() == "0002");
        }
        [TestMethod]
        public void TestNoteInsert()
        {
            UtauPlugin.InsertNote(2);
            Assert.IsTrue(UtauPlugin.note[1].GetNum() == "0002");
            Assert.IsTrue(UtauPlugin.note[1].Next.GetNum() == "INSERT");
            Assert.IsTrue(UtauPlugin.note[2].Prev.GetNum() == "0002");
            Assert.IsTrue(UtauPlugin.note[2].Next.GetNum() == "0003");
            Assert.IsTrue(UtauPlugin.note[3].Prev.GetNum() == "INSERT");
        }
        [TestMethod]
        public void TestNoteInsertFirst()
        {
            UtauPlugin.InsertNote(0);
            Assert.IsTrue(UtauPlugin.note[0].GetNum() == "INSERT");
            Assert.IsTrue(UtauPlugin.note[0].Next.GetNum() == "PREV");
            Assert.IsTrue(UtauPlugin.note[1].Prev.GetNum() == "INSERT");
        }
        [TestMethod]
        public void TestNoteInsertLast()
        {
            UtauPlugin.InsertNote(UtauPlugin.note.Count);
            Assert.IsTrue(UtauPlugin.note[UtauPlugin.note.Count - 1].GetNum() == "INSERT");
            Assert.IsTrue(UtauPlugin.note[UtauPlugin.note.Count - 1].Prev.GetNum() == "NEXT");
            Assert.IsTrue(UtauPlugin.note[UtauPlugin.note.Count - 2].Next.GetNum() == "INSERT");
        }
        [TestMethod]
        public void TestNoteDelete()
        {
            UtauPlugin.DeleteNote(2);
            Assert.IsTrue(UtauPlugin.note[2].GetNum() == "DELETE");
            Assert.IsTrue(UtauPlugin.note[1].Next.GetNum() == "0004");
            Assert.IsTrue(UtauPlugin.note[3].Prev.GetNum() == "0002");
        }
        [TestMethod]
        public void TestNoteDeleteInsert()
        {
            UtauPlugin.DeleteNote(2);
            UtauPlugin.InsertNote(3);
            Assert.IsTrue(UtauPlugin.note[2].GetNum() == "DELETE");
            Assert.IsTrue(UtauPlugin.note[3].GetNum() == "INSERT");
            Assert.IsTrue(UtauPlugin.note[1].Next.GetNum() == "INSERT");
            Assert.IsTrue(UtauPlugin.note[3].Prev.GetNum() == "0002");
            Assert.IsTrue(UtauPlugin.note[3].Next.GetNum() == "0004");
            Assert.IsTrue(UtauPlugin.note[4].Prev.GetNum() == "INSERT");
        }
        [TestMethod]
        public void TestApplyOto()
        {
            UtauPlugin.InsertNote(2);
            UtauPlugin.note[2].SetLyric("さ");
            UtauPlugin.note[2].SetNoteNum(60);
            UtauPlugin.InputVoiceBank();
            UtauPlugin.ApplyOto();
            Assert.IsTrue(UtauPlugin.note[2].GetPre() == 141f);
            Assert.IsTrue(UtauPlugin.note[2].GetOve() == 36);
        }

        [TestMethod]
        public void TestInitAtParam()
        {
            UtauPlugin.InsertNote(2);
            UtauPlugin.note[2].SetLyric("さ");
            UtauPlugin.note[2].SetNoteNum(60);
            UtauPlugin.note[2].SetPre(300);
            UtauPlugin.note[2].SetOve(100);
            UtauPlugin.note[2].SetStp(50);
            UtauPlugin.InputVoiceBank();
            UtauPlugin.InitAtParam();
            Assert.IsTrue(UtauPlugin.note[2].GetAtFileName() == "さ.wav");
            Assert.IsTrue(UtauPlugin.note[2].GetAtAlias() == "さ");
            Assert.IsTrue(UtauPlugin.note[2].GetAtPre() == 300f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtOve() == 100f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtStp() == 50f);
        }
        [TestMethod]
        public void TestInitAtParamApplyVelocity200()
        {
            UtauPlugin.InsertNote(2);
            UtauPlugin.note[2].SetLyric("さ");
            UtauPlugin.note[2].SetNoteNum(60);
            UtauPlugin.note[2].SetPre(300);
            UtauPlugin.note[2].SetOve(100);
            UtauPlugin.note[2].SetStp(50);
            UtauPlugin.note[2].SetVelocity(200);
            UtauPlugin.InputVoiceBank();
            UtauPlugin.InitAtParam();
            Assert.IsTrue(UtauPlugin.note[2].GetAtFileName() == "さ.wav");
            Assert.IsTrue(UtauPlugin.note[2].GetAtAlias() == "さ");
            Assert.IsTrue(UtauPlugin.note[2].GetAtPre() == 150f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtOve() == 50f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtStp() == 50f);
        }
        [TestMethod]
        public void TestInitAtParamApplyVelocity0()
        {
            UtauPlugin.InsertNote(2);
            UtauPlugin.note[2].SetLyric("さ");
            UtauPlugin.note[2].SetNoteNum(60);
            UtauPlugin.note[2].SetPre(150);
            UtauPlugin.note[2].SetOve(50);
            UtauPlugin.note[2].SetStp(50);
            UtauPlugin.note[2].SetVelocity(0);
            UtauPlugin.InputVoiceBank();
            UtauPlugin.InitAtParam();
            Assert.IsTrue(UtauPlugin.note[2].GetAtFileName() == "さ.wav");
            Assert.IsTrue(UtauPlugin.note[2].GetAtAlias() == "さ");
            Assert.IsTrue(UtauPlugin.note[2].GetAtPre() == 300f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtOve() == 100f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtStp() == 50f);
        }
        [TestMethod]
        public void TestInitAtParamAutoFit()
        {
            UtauPlugin.InsertNote(2);
            UtauPlugin.note[2].SetLyric("さ");
            UtauPlugin.note[2].SetNoteNum(60);
            UtauPlugin.note[2].SetPre(750);
            UtauPlugin.note[2].SetOve(250);
            UtauPlugin.note[2].SetStp(50);
            UtauPlugin.note[2].Prev.SetTempo(120);
            UtauPlugin.note[2].Prev.SetLength(480);//半分は250ms
            UtauPlugin.InputVoiceBank();
            UtauPlugin.InitAtParam();
            Assert.IsTrue(UtauPlugin.note[2].GetAtFileName() == "さ.wav");
            Assert.IsTrue(UtauPlugin.note[2].GetAtAlias() == "さ");
            Assert.IsTrue(UtauPlugin.note[2].GetAtPre() == 375f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtOve() == 125f);
            Assert.IsTrue(UtauPlugin.note[2].GetAtStp() == 425f);
        }
        [TestMethod]
        public void TestNoBodyInput()
        {
            UtauPlugin = new UtauPlugin.UtauPlugin();
            UtauPlugin.FilePath = "..\\..\\..\\test\\inputData\\nobody.tmp";
            UtauPlugin.Input();
            Assert.IsTrue(UtauPlugin.Version == "1.19");
        }
        //[TestMethod]
        //public void ErrorCheck()
        //{
        //    UtauPlugin = new UtauPlugin.UtauPlugin();
        //    UtauPlugin.FilePath = "..\\..\\..\\test\\inputData\\error.txt";
        //    UtauPlugin.Input();
        //}
    }
}
