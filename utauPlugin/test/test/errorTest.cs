using Microsoft.VisualStudio.TestTools.UnitTesting;
using utauPlugin;
using System.Collections.Generic;

namespace errorTest.cs
{
    [TestClass]
    public class errorTest
    {
        UtauPlugin utauPlugin;

        [TestInitialize()]
        public void testInitialize()
        {
            utauPlugin = new UtauPlugin();

        }
        [TestMethod]
        public void testMode2AddPitch()
        {
            utauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test119.tmp";
            utauPlugin.Input();
            Note note = utauPlugin.note[2];
            List<float> pbw = note.GetPbw();
            List<float> pby = note.GetPby();
            List<string> pbm = note.GetPbm();
            Assert.IsTrue(4 == pbw.Count);

            float ave = pbw[0] / 2;
            float nextY = pby[0];
            pbw.Insert(0, ave);
            pby.Insert(0, note.GetPbsHeight());
            pbm.Insert(0, "");
            pbw.Insert(1, 0);
            Assert.IsTrue(6 == pbw.Count);
            pby.Insert(1, nextY);
            pbm.Insert(1, "");
            pbw[2] = ave;
            Assert.IsTrue(6 == pbw.Count);
            note.SetPbw(pbw);
            Assert.IsTrue(6 == note.GetPbw().Count);
            //note.SetPby(pby);
            //note.SetPbm(pbm);
            //Assert.IsTrue(pby[0] == -20f);
            //Assert.IsTrue(pby[1] == 0f);
            //Assert.IsTrue(pby[2] == -10.7f);
            //Assert.IsTrue(pby[3] == 0f);
            //Assert.IsTrue(4 == pby.Count);
            Assert.IsTrue(6 == pbw.Count);
            utauPlugin.FilePath ="..\\..\\..\\test\\outputData\\Mode2AddPitch.tmp";
            utauPlugin.Output();
        }
    }
}
