using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtauPlugin;
using System.Collections.Generic;

namespace errorTest.cs
{
    [TestClass]
    public class errorTest
    {
        UtauPlugin.UtauPlugin UtauPlugin;

        [TestInitialize()]
        public void testInitialize()
        {
            UtauPlugin = new UtauPlugin.UtauPlugin();

        }
        [TestMethod]
        public void testMode2AddPitch()
        {
            UtauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test119.tmp";
            UtauPlugin.Input();
            Note note = UtauPlugin.note[2];
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
            pby.Insert(1, nextY);
            pbm.Insert(1, "");
            pbw[2] = ave;
            note.SetPbw(pbw);
            note.SetPby(pby);
            note.SetPbm(pbm);
            //Assert.IsTrue(pby[0] == -20f);
            //Assert.IsTrue(pby[1] == 0f);
            //Assert.IsTrue(pby[2] == -10.7f);
            //Assert.IsTrue(pby[3] == 0f);
            //Assert.IsTrue(4 == pby.Count);
            Assert.IsTrue(6 == pbw.Count);
            UtauPlugin.FilePath ="..\\..\\..\\test\\outputData\\Mode2AddPitch.tmp";
            UtauPlugin.Output();
        }
    }
}
