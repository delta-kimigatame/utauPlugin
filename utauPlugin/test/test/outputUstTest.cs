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
    }
}
