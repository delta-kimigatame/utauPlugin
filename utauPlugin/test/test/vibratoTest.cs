using Microsoft.VisualStudio.TestTools.UnitTesting;
using utauPlugin;

namespace vibratoTest
{
    [TestClass]
    public class vibratoTest
    {

        //
        //ビブラート関係のテスト
        //

        //使い方1 ビブラートの各パラメータをカンマで結合した文字列を引数にして
        //宣言する．
        //ビブラート配列は
        //1：ビブラートの長さ(ノート長に対する割合)(整数)
        //2：ビブラートの周期(整数)
        //3：ビブラートの深さ(cent単位)(整数)
        //4：ビブラートのフェードインの長さ(ビブラート長長に対する割合)(小数)
        //5：ビブラートのフェードアウト長さ(ノート長に対する割合)(小数)
        //6：ビブラートの初期位相(小数)
        //7：ビブラートの上下オフセット(小数)
        //    100にすると，ビブラートの下端が本来のノートの音程になります．
        //    -100にすると，ビブラートの上端が本来のノートの音程になります．
        [TestMethod]
        public void SetVbrInit()
        {
            Vibrato vbr = new Vibrato("7,1,2,3.1,4.2,5.3,6.4");
            Assert.IsTrue(7==vbr.GetLength());
            Assert.IsTrue(1 == vbr.GetCycle());
            Assert.IsTrue(2 == vbr.GetDepth());
            Assert.IsTrue(3.1f == vbr.GetFadeInTime());
            Assert.IsTrue(4.2f == vbr.GetFadeOutTime());
            Assert.IsTrue(5.3f == vbr.GetPhase());
            Assert.IsTrue(6.4f == vbr.GetHeight());
            Assert.IsTrue("7,1,2,3.1,4.2,5.3,6.4,0" == vbr.Get());
        }
        //使い方2 引数無しで宣言し，Setでビブラートの各パラメータをカンマで結合した文字列を渡します
        [TestMethod]
        public void SetVbrParam()
        {
            Vibrato vbr = new Vibrato();
            vbr.Set("7,1,2,3.1,4.2,5.3,6.4");
            Assert.IsTrue(7 == vbr.GetLength());
            Assert.IsTrue(1 == vbr.GetCycle());
            Assert.IsTrue(2 == vbr.GetDepth());
            Assert.IsTrue(3.1f == vbr.GetFadeInTime());
            Assert.IsTrue(4.2f == vbr.GetFadeOutTime());
            Assert.IsTrue(5.3f == vbr.GetPhase());
            Assert.IsTrue(6.4f == vbr.GetHeight());
            Assert.IsTrue("7,1,2,3.1,4.2,5.3,6.4,0" == vbr.Get());
        }
        [TestMethod]
        public void SetVbrLengthInt()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetLength(7);
            Assert.IsTrue(7 == vbr.GetLength());
        }
        [TestMethod]
        public void SetVbrLengthStr()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetLength("7");
            Assert.IsTrue(7 == vbr.GetLength());
        }
        [TestMethod]
        public void SetVbrCycleInt()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetCycle(7);
            Assert.IsTrue(7 == vbr.GetCycle());
        }
        [TestMethod]
        public void SetVbrCycleStr()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetCycle("7");
            Assert.IsTrue(7 == vbr.GetCycle());
        }
        [TestMethod]
        public void SetVbrDepthInt()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetDepth(7);
            Assert.IsTrue(7 == vbr.GetDepth());
        }
        [TestMethod]
        public void SetVbrDepthStr()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetDepth("7");
            Assert.IsTrue(7 == vbr.GetDepth());
        }
        [TestMethod]
        public void SetVbrFadeInTimeFloat()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetFadeInTime(7.0f);
            Assert.IsTrue(7.0f == vbr.GetFadeInTime());
        }
        [TestMethod]
        public void SetVbrFadeInTimeInt()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetFadeInTime(7);
            Assert.IsTrue(7.0f == vbr.GetFadeInTime());
        }
        [TestMethod]
        public void SetVbrFadeInTimeStr()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetFadeInTime("7");
            Assert.IsTrue(7.0f == vbr.GetFadeInTime());
        }
        [TestMethod]
        public void SetVbrFadeOutTimeFloat()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetFadeOutTime(7.0f);
            Assert.IsTrue(7.0f == vbr.GetFadeOutTime());
        }
        [TestMethod]
        public void SetVbrFadeOutTimeInt()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetFadeOutTime(7);
            Assert.IsTrue(7.0f == vbr.GetFadeOutTime());
        }
        [TestMethod]
        public void SetVbrFadeOutTimeStr()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetFadeOutTime("7");
            Assert.IsTrue(7.0f == vbr.GetFadeOutTime());
        }
        [TestMethod]
        public void SetVbrPhaseFloat()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetPhase(7.0f);
            Assert.IsTrue(7.0f == vbr.GetPhase());
        }
        [TestMethod]
        public void SetVbrPhaseInt()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetPhase(7);
            Assert.IsTrue(7.0f == vbr.GetPhase());
        }
        [TestMethod]
        public void SetVbrPhaseStr()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetPhase("7");
            Assert.IsTrue(7.0f == vbr.GetPhase());
        }
        [TestMethod]
        public void SetVbrHeightFloat()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetHeight(7.0f);
            Assert.IsTrue(7.0f == vbr.GetHeight());
        }
        [TestMethod]
        public void SetVbrHeightInt()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetHeight(7);
            Assert.IsTrue(7.0f == vbr.GetHeight());
        }
        [TestMethod]
        public void SetVbrHeightStr()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetHeight("7");
            Assert.IsTrue(7.0f == vbr.GetHeight());
        }
    }
}
