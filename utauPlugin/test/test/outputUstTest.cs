using Microsoft.VisualStudio.TestTools.UnitTesting;
using utauPlugin;

namespace outputUstTest.cs
{
    [TestClass]
    public class outputUstTest
    {
        UtauPlugin utauPlugin;

        [TestInitialize()]
        public void testInitialize()
        {
            utauPlugin = new UtauPlugin();

        }
        [TestMethod]
        public void testv119()
        {
            utauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test119.tmp";
            utauPlugin.Input();
            utauPlugin.FilePath ="..\\..\\..\\test\\outputData\\out119.tmp";
            utauPlugin.Output();
        }
        [TestMethod]
        public void testv119Insert()
        {
            utauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test119.tmp";
            utauPlugin.Input();
            for(int i = 0; i < utauPlugin.note.Count; i++)
            {
                utauPlugin.note[i].SetNum("INSERT");
            }
            utauPlugin.FilePath ="..\\..\\..\\test\\outputData\\out119Insert.tmp";
            utauPlugin.Output();
        }
        [TestMethod]
        public void testv119_SetLength()
        {
            utauPlugin.FilePath ="..\\..\\..\\test\\inputData\\test119.tmp";
            utauPlugin.Input();
            utauPlugin.note[2].SetLength(120);
            utauPlugin.FilePath ="..\\..\\..\\test\\outputData\\out119_Length.tmp";
            utauPlugin.Output();
        }
        [TestMethod]
        public void testv119_SetDirect()
        {
            utauPlugin.FilePath = "..\\..\\..\\test\\inputData\\test119.tmp";
            utauPlugin.Input();
            utauPlugin.note[2].SetDirect(false);
            utauPlugin.FilePath = "..\\..\\..\\test\\outputData\\out119_Direct.tmp";
            utauPlugin.Output();
        }
        [TestMethod()]
        public void InitOriginalEntryOutputTest()
        {
            utauPlugin = new UtauPlugin();
            utauPlugin.FilePath = "..\\..\\..\\test\\inputData\\originalEntry.tmp";
            utauPlugin.InitOriginalEntry("myEntry", "ccc");
            utauPlugin.InitOriginalEntry("myEntry2", "");
            utauPlugin.Input();
            utauPlugin.FilePath = "..\\..\\..\\test\\outputData\\original.tmp";
            utauPlugin.note[1].SetOriginalEntry("myEntry","ddd");

            utauPlugin.Output();

        }
        [TestMethod()]
        public void InitOriginalEntryInsertTest()
        {
            utauPlugin = new UtauPlugin();
            utauPlugin.FilePath = "..\\..\\..\\test\\inputData\\originalEntry.tmp";
            utauPlugin.InitOriginalEntry("myEntry", "ccc");
            utauPlugin.InitOriginalEntry("myEntry2", "");
            utauPlugin.Input();
            utauPlugin.FilePath = "..\\..\\..\\test\\outputData\\originalInsert.tmp";
            for (int i = 0; i < utauPlugin.note.Count; i++)
            {
                utauPlugin.note[i].SetNum("INSERT");
            }

            utauPlugin.Output();

        }
        [TestMethod]
        public void testNoBody()
        {
            utauPlugin.FilePath = "..\\..\\..\\test\\inputData\\nobody.tmp";
            utauPlugin.Input();
            utauPlugin.FilePath = "..\\..\\..\\test\\outputData\\nobody.tmp";
            utauPlugin.Output();
        }
    }
}
