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
            oto.DirPath= "..\\..\\testWav";
            oto.FileName = "test1.wav";
            oto.Alias = "あ";
            oto.Offset = 100;
            oto.Pre = 300;
            oto.Ove = 100;
            oto.Vel = 450;
            oto.Blank = -600;
            Assert.IsTrue(oto.GetWavLength() == 5944);
        }
    }
}