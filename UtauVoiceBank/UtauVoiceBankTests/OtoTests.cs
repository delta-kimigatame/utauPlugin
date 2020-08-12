using UtauVoiceBank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtauVoiceBank.Tests
{
    [TestClass()]
    public class OtoTests
    {
        [TestMethod()]
        public void GetInverseBlankTest()
        {
            Oto oto = new Oto();
            oto.DirPath = "..\\..\\testWav";
            oto.FileName = "test1.wav";
            oto.Alias = "あ";
            oto.Offset = 100;
            oto.Pre = 300;
            oto.Ove = 100;
            oto.Vel = 450;
            oto.Blank = -600;
            Assert.IsTrue(oto.GetInverseBlank() == 5244);
            oto.Blank = 5244;
            Assert.IsTrue(oto.GetInverseBlank() == -600);

        }

        [TestMethod()]
        public void GetWavLengthTest()
        {
            Oto oto = new Oto();
            oto.DirPath = "..\\..\\testWav";
            oto.FileName = "test1.wav";
            oto.Alias = "あ";
            oto.Offset = 100;
            oto.Pre = 300;
            oto.Ove = 100;
            oto.Vel = 450;
            oto.Blank = -600;
            Assert.IsTrue(oto.GetWavLength() == 5944);
        }

        [TestMethod()]
        public void InputOtoTest()
        {
            VoiceBank vb = new VoiceBank("..\\..\\testDir");
            vb.InputOto();
            Assert.IsTrue(vb.oto["あ"].DirPath == "");
            Assert.IsTrue(vb.oto["あ"].Alias == "あ");
            Assert.IsTrue(vb.oto["あ"].Offset == 0f);
            Assert.IsTrue(vb.oto["あ"].Vel == 1f);
            Assert.IsTrue(vb.oto["あ"].Blank == 2f);
            Assert.IsTrue(vb.oto["あ"].Pre == 3f);
            Assert.IsTrue(vb.oto["あ"].Ove == 4f);
            Assert.IsTrue(vb.oto["い"].DirPath == "");
            Assert.IsTrue(vb.oto["い"].Alias == "い");

        }

        [TestMethod()]
        public void InputOtoAllTest()
        {
            VoiceBank vb = new VoiceBank("..\\..\\testDir");
            vb.InputOtoAll();
            Assert.IsTrue(vb.oto["あ"].DirPath == "");
            Assert.IsTrue(vb.oto["あ"].Alias == "あ");
            Assert.IsTrue(vb.oto["あ"].Offset == 0f);
            Assert.IsTrue(vb.oto["あ"].Vel == 1f);
            Assert.IsTrue(vb.oto["あ"].Blank == 2f);
            Assert.IsTrue(vb.oto["あ"].Pre == 3f);
            Assert.IsTrue(vb.oto["あ"].Ove == 4f);
            Assert.IsTrue(vb.oto["い"].DirPath == "");
            Assert.IsTrue(vb.oto["い"].Alias == "い");
            Assert.IsTrue(vb.oto["う"].DirPath == "あ");
            Assert.IsTrue(vb.oto["う"].Alias == "う");
            Assert.IsTrue(vb.oto["あ\\え"].DirPath == "あ");
            Assert.IsTrue(vb.oto["あ\\え"].Alias == "あ\\え");
            Assert.IsFalse(vb.oto.ContainsKey("え"));
            Assert.IsFalse(vb.oto.ContainsKey("お"));

        }
        [TestMethod()]
        public void InputOtoAllTestRecursive()
        {
            VoiceBank vb = new VoiceBank("..\\..\\testDir");
            vb.InputOtoAll(true);
            Assert.IsTrue(vb.oto["あ"].DirPath == "");
            Assert.IsTrue(vb.oto["あ"].Alias == "あ");
            Assert.IsTrue(vb.oto["あ"].Offset == 0f);
            Assert.IsTrue(vb.oto["あ"].Vel == 1f);
            Assert.IsTrue(vb.oto["あ"].Blank == 2f);
            Assert.IsTrue(vb.oto["あ"].Pre == 3f);
            Assert.IsTrue(vb.oto["あ"].Ove == 4f);
            Assert.IsTrue(vb.oto["い"].DirPath == "");
            Assert.IsTrue(vb.oto["い"].Alias == "い");
            Assert.IsTrue(vb.oto["う"].DirPath == "あ");
            Assert.IsTrue(vb.oto["う"].Alias == "う");
            Assert.IsTrue(vb.oto["あ\\え"].DirPath == "あ");
            Assert.IsTrue(vb.oto["あ\\え"].Alias == "あ\\え");
            Assert.IsFalse(vb.oto.ContainsKey("え"));
            Assert.IsTrue(vb.oto["お"].DirPath == "あ\\あ");
            Assert.IsTrue(vb.oto["お"].Alias == "お");

        }
        [TestMethod()]
        public void InputOtoAllTestNoRootOto()
        {
            VoiceBank vb = new VoiceBank("..\\..\\testDirNoRootOto");
            vb.InputOtoAll();
            Assert.IsTrue(vb.oto["う"].DirPath == "あ");
            Assert.IsTrue(vb.oto["う"].Alias == "う");
            Assert.IsTrue(vb.oto["あ\\え"].DirPath == "あ");
            Assert.IsTrue(vb.oto["あ\\え"].Alias == "あ\\え");
            Assert.IsFalse(vb.oto.ContainsKey("え"));
            Assert.IsFalse(vb.oto.ContainsKey("お"));

        }
        [TestMethod()]
        public void InputOtoAllTestRecursiveNoRootOto()
        {
            VoiceBank vb = new VoiceBank("..\\..\\testDirNoRootOto");
            vb.InputOtoAll(true);
            Assert.IsTrue(vb.oto["う"].DirPath == "あ");
            Assert.IsTrue(vb.oto["う"].Alias == "う");
            Assert.IsTrue(vb.oto["あ\\え"].DirPath == "あ");
            Assert.IsTrue(vb.oto["あ\\え"].Alias == "あ\\え");
            Assert.IsFalse(vb.oto.ContainsKey("え"));
            Assert.IsTrue(vb.oto["お"].DirPath == "あ\\あ");
            Assert.IsTrue(vb.oto["お"].Alias == "お");

        }
    }
}