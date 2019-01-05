using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtauVoiceBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtauVoiceBank.Tests
{
    [TestClass()]
    public class MapTests
    {
        [TestMethod()]
        public void InputPrefixMapTest()
        {
            VoiceBank vb = new VoiceBank("..\\..\\testDir");
            vb.InputPrefixMap();
            Assert.IsTrue(vb.prefixMap["B3"].Su == "B3");
            Assert.IsTrue(vb.prefixMap["A#3"].Su == "");
        }

        [TestMethod()]
        public void InputPrefixMapsAllTest()
        {
            VoiceBank vb = new VoiceBank("..\\..\\testDir");
            vb.InputPrefixMapsAll();
            Assert.IsTrue(vb.prefixMaps[""]["B3"].Su == "B3");
            Assert.IsTrue(vb.prefixMaps[""]["A#3"].Su == "");
            Assert.IsTrue(vb.prefixMaps["あ"]["A#3"].Su == "G#3");

        }
    }
}