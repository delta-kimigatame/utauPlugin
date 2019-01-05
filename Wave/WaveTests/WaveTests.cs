using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wave.Tests
{
    [TestClass()]
    public class WaveTests
    {
        [TestMethod()]
        public void ReadTest()
        {
            Wave wav = new Wave("..\\..\\testWav\\test1.wav");
            wav.Read();
            Assert.IsTrue(wav.GetHeader().Channel==1);
            Assert.IsTrue(wav.GetHeader().SampleRate == 44100);
            Assert.IsTrue(wav.GetHeader().BitPerSample == 16);
            Assert.IsTrue(wav.PlayTime == 5944);
        }
    }
}