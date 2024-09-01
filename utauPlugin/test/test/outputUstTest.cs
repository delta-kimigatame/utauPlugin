using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtauPlugin;

namespace outputUstTest.cs
{
    [TestClass]
    public class outputUstTest
    {
        UtauPlugin.UtauPlugin UtauPlugin;

        [TestInitialize()]
        public void testInitialize()
        {
            UtauPlugin = new UtauPlugin.UtauPlugin();

        }
        [TestMethod]
        public void testv119()
        {
            UtauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test119.tmp";
            UtauPlugin.Input();
            UtauPlugin.FilePath ="..\\..\\..\\test\\outputData\\out119.tmp";
            UtauPlugin.Output();
        }
        [TestMethod]
        public void testv119Insert()
        {
            UtauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test119.tmp";
            UtauPlugin.Input();
            for(int i = 0; i < UtauPlugin.note.Count; i++)
            {
                UtauPlugin.note[i].SetNum("INSERT");
            }
            UtauPlugin.FilePath ="..\\..\\..\\test\\outputData\\out119Insert.tmp";
            UtauPlugin.Output();
        }
        [TestMethod]
        public void testv119_SetLength()
        {
            UtauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test119.tmp";
            UtauPlugin.Input();
            UtauPlugin.note[2].SetLength(120);
            UtauPlugin.FilePath ="..\\..\\..\\test\\outputData\\out119_Length.tmp";
            UtauPlugin.Output();
        }
        [TestMethod]
        public void testv119_SetDirect()
        {
            UtauPlugin.FilePath = "..\\..\\..\\test\\inputData\\test119.tmp";
            UtauPlugin.Input();
            UtauPlugin.note[2].SetDirect(false);
            UtauPlugin.FilePath = "..\\..\\..\\test\\outputData\\out119_Direct.tmp";
            UtauPlugin.Output();
        }
        [TestMethod()]
        public void InitOriginalEntryOutputTest()
        {
            UtauPlugin = new UtauPlugin.UtauPlugin();
            UtauPlugin.FilePath = "..\\..\\..\\test\\inputData\\originalEntry.tmp";
            UtauPlugin.InitOriginalEntry("myEntry", "ccc");
            UtauPlugin.InitOriginalEntry("myEntry2", "");
            UtauPlugin.Input();
            UtauPlugin.FilePath = "..\\..\\..\\test\\outputData\\original.tmp";
            UtauPlugin.note[1].SetOriginalEntry("myEntry","ddd");

            UtauPlugin.Output();

        }
        [TestMethod()]
        public void InitOriginalEntryInsertTest()
        {
            UtauPlugin = new UtauPlugin.UtauPlugin();
            UtauPlugin.FilePath = "..\\..\\..\\test\\inputData\\originalEntry.tmp";
            UtauPlugin.InitOriginalEntry("myEntry", "ccc");
            UtauPlugin.InitOriginalEntry("myEntry2", "");
            UtauPlugin.Input();
            UtauPlugin.FilePath = "..\\..\\..\\test\\outputData\\originalInsert.tmp";
            for (int i = 0; i < UtauPlugin.note.Count; i++)
            {
                UtauPlugin.note[i].SetNum("INSERT");
            }

            UtauPlugin.Output();

        }
        [TestMethod]
        public void testNoBody()
        {
            UtauPlugin.FilePath = "..\\..\\..\\test\\inputData\\nobody.tmp";
            UtauPlugin.Input();
            UtauPlugin.FilePath = "..\\..\\..\\test\\outputData\\nobody.tmp";
            UtauPlugin.Output();
        }
    }
}
