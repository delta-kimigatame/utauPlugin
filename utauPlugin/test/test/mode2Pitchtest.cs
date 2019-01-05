using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using utauPlugin;

namespace mode2PitchTest
{
    [TestClass]
    public class mode2Pitchtest
    {
        //
        //mode2ピッチ関係のテスト
        //

        [TestMethod]
        public void SetMode2PitchPbsSemiColon()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPbs("50;30");
            Assert.IsTrue(50.0f == mode2Pitch.GetPbsTime());
            Assert.IsTrue(30.0f == mode2Pitch.GetPbsHeight());
            Assert.IsTrue("50;30" == mode2Pitch.GetPbs());
        }
        [TestMethod]
        public void SetMode2PitchPbsComma()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPbs("50,30");
            Assert.IsTrue(50.0f == mode2Pitch.GetPbsTime());
            Assert.IsTrue(30.0f == mode2Pitch.GetPbsHeight());
            Assert.IsTrue("50;30" == mode2Pitch.GetPbs());
        }
        [TestMethod]
        public void SetMode2PitchPbs()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPbs("50");
            Assert.IsTrue(50.0f == mode2Pitch.GetPbsTime());
            Assert.IsTrue(0.0f == mode2Pitch.GetPbsHeight());
            Assert.IsTrue("50" == mode2Pitch.GetPbs());
        }
        [TestMethod]
        public void SetMode2PitchPbw()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPbw("50");
            Assert.IsTrue(50f == mode2Pitch.GetPbw()[0]);
        }
        [TestMethod]
        public void SetMode2PitchPbwStr()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPbw("50,30,20");
            Assert.IsTrue(50f == mode2Pitch.GetPbw()[0]);
            Assert.IsTrue(30f == mode2Pitch.GetPbw()[1]);
            Assert.IsTrue(20f == mode2Pitch.GetPbw()[2]);
            Assert.IsTrue(3 == mode2Pitch.GetPbw().Count);
        }
        [TestMethod]
        public void ChangeMode2PitchPbwStr()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPbw("50,30,20");
            mode2Pitch.SetPbw("40", 1);
            Assert.IsTrue(50f == mode2Pitch.GetPbw()[0]);
            Assert.IsTrue(40f == mode2Pitch.GetPbw()[1]);
            Assert.IsTrue(20f == mode2Pitch.GetPbw()[2]);
            Assert.IsTrue(3 == mode2Pitch.GetPbw().Count);
        }
        [TestMethod]
        public void ChangeMode2PitchPbwInt()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPbw("50,30,20");
            mode2Pitch.SetPbw(40, 1);
            Assert.IsTrue(50f == mode2Pitch.GetPbw()[0]);
            Assert.IsTrue(40f == mode2Pitch.GetPbw()[1]);
            Assert.IsTrue(20f == mode2Pitch.GetPbw()[2]);
            Assert.IsTrue(3 == mode2Pitch.GetPbw().Count);
        }
        [TestMethod]
        public void ChangeMode2PitchPbwList()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPbw("50,30,20");
            mode2Pitch.SetPbw(new List<float> { 15f, 25f });
            Assert.IsTrue(15f == mode2Pitch.GetPbw()[0]);
            Assert.IsTrue(25f == mode2Pitch.GetPbw()[1]);
            Assert.IsTrue(2 == mode2Pitch.GetPbw().Count);
        }
        [TestMethod]
        public void SetMode2PitchPby()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPby("50");
            Assert.IsTrue(50f == mode2Pitch.GetPby()[0]);
        }
        [TestMethod]
        public void SetMode2PitchPbyStr()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPby("50,30,20");
            Assert.IsTrue(50f == mode2Pitch.GetPby()[0]);
            Assert.IsTrue(30f == mode2Pitch.GetPby()[1]);
            Assert.IsTrue(20f == mode2Pitch.GetPby()[2]);
            Assert.IsTrue(3 == mode2Pitch.GetPby().Count);
        }
        [TestMethod]
        public void ChangeMode2PitchPbyStr()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPby("50,30,20");
            mode2Pitch.SetPby("40", 1);
            Assert.IsTrue(50f == mode2Pitch.GetPby()[0]);
            Assert.IsTrue(40f == mode2Pitch.GetPby()[1]);
            Assert.IsTrue(20f == mode2Pitch.GetPby()[2]);
            Assert.IsTrue(3 == mode2Pitch.GetPby().Count);
        }
        [TestMethod]
        public void ChangeMode2PitchPbyInt()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPby("50,30,20");
            mode2Pitch.SetPby(40, 1);
            Assert.IsTrue(50f == mode2Pitch.GetPby()[0]);
            Assert.IsTrue(40f == mode2Pitch.GetPby()[1]);
            Assert.IsTrue(20f == mode2Pitch.GetPby()[2]);
            Assert.IsTrue(3 == mode2Pitch.GetPby().Count);
        }
        [TestMethod]
        public void ChangeMode2PitchPbyList()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPby("50,30,20");
            mode2Pitch.SetPby(new List<float> { 15, 25 });
            Assert.IsTrue(15f == mode2Pitch.GetPby()[0]);
            Assert.IsTrue(25f == mode2Pitch.GetPby()[1]);
            Assert.IsTrue(2 == mode2Pitch.GetPby().Count);
        }
        [TestMethod]
        public void SetMode2PitchPbm()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPbm("r");
            Assert.IsTrue("r" == mode2Pitch.GetPbm()[0]);
        }
        [TestMethod]
        public void SetMode2PitchPbmStr()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPbm("r,,s");
            Assert.IsTrue("r" == mode2Pitch.GetPbm()[0]);
            Assert.IsTrue("" == mode2Pitch.GetPbm()[1]);
            Assert.IsTrue("s" == mode2Pitch.GetPbm()[2]);
            Assert.IsTrue(3 == mode2Pitch.GetPbm().Count);
        }
        [TestMethod]
        public void SetMode2PitchPbmList()
        {
            Note.Mode2Pitch mode2Pitch = new Note.Mode2Pitch();
            mode2Pitch.SetPbm("r,,s");
            mode2Pitch.SetPbm(new List<string> { "", "j" });
            Assert.IsTrue("" == mode2Pitch.GetPbm()[0]);
            Assert.IsTrue("j" == mode2Pitch.GetPbm()[1]);
            Assert.IsTrue(2 == mode2Pitch.GetPbm().Count);
        }
    }
}
