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
            utauPlugin.SetFilePath("..\\..\\..\\test\\inputData\\test119.tmp");
            utauPlugin.Input();
            utauPlugin.SetFilePath("..\\..\\..\\test\\outputData\\out119.tmp");
            utauPlugin.Output();
        }
        [TestMethod]
        public void testv119Insert()
        {
            utauPlugin.SetFilePath("..\\..\\..\\test\\inputData\\test119.tmp");
            utauPlugin.Input();
            for(int i = 0; i < utauPlugin.note.Count; i++)
            {
                utauPlugin.note[i].SetNum("INSERT");
            }
            utauPlugin.SetFilePath("..\\..\\..\\test\\outputData\\out119Insert.tmp");
            utauPlugin.Output();
        }
        [TestMethod]
        public void testv119_SetLength()
        {
            utauPlugin.SetFilePath("..\\..\\..\\test\\inputData\\test119.tmp");
            utauPlugin.Input();
            utauPlugin.note[2].SetLength(120);
            utauPlugin.SetFilePath("..\\..\\..\\test\\outputData\\out119_Length.tmp");
            utauPlugin.Output();
        }
    }
}
