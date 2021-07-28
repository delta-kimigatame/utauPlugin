using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using utauPlugin;

namespace ConvertPitchTest
{
    [TestClass]
    public class SingleNoteInit
    {
        Note note;
        Note.ConvertPitch cp;
        [TestInitialize()]
        public void testInitialize()
        {
            note = new Note();
            note.SetLength("480");
            note.SetLyric("あ");
        }

        [TestMethod]
        public void InitParam()
        {
            note.InitTempo("120.0");
            cp = new Note.ConvertPitch(note);
            Assert.IsTrue(cp.MsLength == 500f);
            Assert.IsTrue(cp.FramePerPitch == 230);
            Assert.IsTrue(cp.PitchPerMs == 230 / 44100.0f * 1000);
            Assert.IsTrue(cp.PitchLength == 96);
        }
        [TestMethod]
        public void InitParam240()
        {
            note.InitTempo("240.0");
            cp = new Note.ConvertPitch(note);
            Assert.IsTrue(cp.MsLength == 250f);
            Assert.IsTrue(cp.FramePerPitch == 115);
            Assert.IsTrue(cp.PitchPerMs == 115 / 44100.0f * 1000);
            Assert.IsTrue(cp.PitchLength == 96);
        }
        [TestMethod]
        public void InitParamWithPre()
        {
            note.InitTempo("120.0");
            note.SetAtPre(500);
            cp = new Note.ConvertPitch(note);
            Assert.IsTrue(cp.MsLength == 1000f);
            Assert.IsTrue(cp.PitchLength == (int)(1000 / 1000 * 44100f / 230f) + 1);
        }
        [TestMethod]
        public void InitParamWithStp()
        {
            note.InitTempo("120.0");
            note.SetAtStp(500);
            cp = new Note.ConvertPitch(note);
            Assert.IsTrue(cp.MsLength == 1000f);
            Assert.IsTrue(cp.PitchLength == (int)(1000 / 1000 * 44100f / 230f) + 1);
        }
    }
    [TestClass]
    public class MultiNoteInit
    {
        Note note1;
        Note note2;
        Note.ConvertPitch cp;
        [TestInitialize()]
        public void testInitialize()
        {
            note1 = new Note();
            note1.SetLength("480");
            note1.SetLyric("あ");
            note1.InitTempo(120);
            note2 = new Note();
            note2.SetLength("480");
            note2.SetLyric("あ");
            note2.InitTempo(120);
            note1.Next = note2;
            note2.Prev = note1;
        }
        [TestMethod]
        public void InitParam()
        {
            cp = new Note.ConvertPitch(note1);
            Assert.IsTrue(cp.MsLength == 500f);
            Assert.IsTrue(cp.FramePerPitch == 230);
            Assert.IsTrue(cp.PitchPerMs == 230 / 44100.0f * 1000);
            Assert.IsTrue(cp.PitchLength == 96);
            cp = new Note.ConvertPitch(note2);
            Assert.IsTrue(cp.MsLength == 500f);
            Assert.IsTrue(cp.FramePerPitch == 230);
            Assert.IsTrue(cp.PitchPerMs == 230 / 44100.0f * 1000);
            Assert.IsTrue(cp.PitchLength == 96);
        }
        [TestMethod]
        public void InitParamOtherTempo()
        {
            cp = new Note.ConvertPitch(note1);
            Assert.IsTrue(cp.MsLength == 500f);
            Assert.IsTrue(cp.FramePerPitch == 230);
            Assert.IsTrue(cp.PitchPerMs == 230 / 44100.0f * 1000);
            Assert.IsTrue(cp.PitchLength == 96);
            note2.SetTempo(240);
            cp = new Note.ConvertPitch(note2);
            Assert.IsTrue(cp.MsLength == 250f);
            Assert.IsTrue(cp.FramePerPitch == 115);
            Assert.IsTrue(cp.PitchPerMs == 115 / 44100.0f * 1000);
            Assert.IsTrue(cp.PitchLength == 96);
        }
        [TestMethod]
        public void InitParamWithNextPre()
        {
            note2.SetAtPre(250);
            cp = new Note.ConvertPitch(note1);
            Assert.IsTrue(cp.MsLength == 250f);
            Assert.IsTrue(cp.PitchLength == (int)(250 / 1000f * 44100f / 230f) + 1);
        }
        [TestMethod]
        public void InitParamWithNextOve()
        {
            note2.SetAtOve(250);
            cp = new Note.ConvertPitch(note1);
            Assert.IsTrue(cp.MsLength == 750f);
            Assert.IsTrue(cp.PitchLength == (int)(750 / 1000f * 44100f / 230f) + 1);
        }
        [TestMethod]
        public void InitParamWithNextPreAndOve()
        {
            note2.SetAtPre(250);
            note2.SetAtOve(250);
            cp = new Note.ConvertPitch(note1);
            Assert.IsTrue(cp.MsLength == 500f);
            Assert.IsTrue(cp.PitchLength == (int)(500 / 1000f * 44100f / 230f) + 1);
        }
    }
}
