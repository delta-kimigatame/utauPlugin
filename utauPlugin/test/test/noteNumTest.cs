using Microsoft.VisualStudio.TestTools.UnitTesting;
using utauPlugin;

namespace noteNumTest
{
    [TestClass]
    public class noteNumTest
    {
        //
        //NoteNumŠÖŒW‚ÌƒeƒXƒg
        //

        [TestMethod]
        public void SetNoteNumInit()
        {
            Note.NoteNum noteNum = new Note.NoteNum();
            Assert.IsTrue(noteNum.Get() == 60);
            Assert.IsTrue(noteNum.GetName() == "C4");
            Assert.IsTrue(noteNum.GetKey() == "C");
        }
        [TestMethod]
        public void SetNoteNumInitStr()
        {
            Note.NoteNum noteNum = new Note.NoteNum("59");
            Assert.IsTrue(noteNum.Get() == 59);
            Assert.IsTrue(noteNum.GetName() == "B3");
            Assert.IsTrue(noteNum.GetKey() == "B");
        }
        [TestMethod]
        public void SetNoteNumInitInt()
        {
            Note.NoteNum noteNum = new Note.NoteNum("71");
            Assert.IsTrue(noteNum.Get() == 71);
            Assert.IsTrue(noteNum.GetName() == "B4");
            Assert.IsTrue(noteNum.GetKey() == "B");
        }
        [TestMethod]
        public void SetNoteNumStr()
        {
            Note.NoteNum noteNum = new Note.NoteNum();
            noteNum.Set("72");
            Assert.IsTrue(noteNum.Get() == 72);
            Assert.IsTrue(noteNum.GetName() == "C5");
            Assert.IsTrue(noteNum.GetKey() == "C");
        }
        [TestMethod]
        public void SetNoteNumInt()
        {
            Note.NoteNum noteNum = new Note.NoteNum();
            noteNum.Set(61);
            Assert.IsTrue(noteNum.Get() == 61);
            Assert.IsTrue(noteNum.GetName() == "C#4");
            Assert.IsTrue(noteNum.GetKey() == "C#");
        }
    }
}
