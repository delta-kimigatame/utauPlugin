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
            Note.Vibrato vbr = new Note.Vibrato("7,1,2,3.1,4.2,5.3,6.4");
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
            Note.Vibrato vbr = new Note.Vibrato();
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
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetLength(7);
            Assert.IsTrue(7 == vbr.GetLength());
        }
        [TestMethod]
        public void SetVbrLengthStr()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetLength("7");
            Assert.IsTrue(7 == vbr.GetLength());
        }
        [TestMethod]
        public void SetVbrCycleInt()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetCycle(7);
            Assert.IsTrue(7 == vbr.GetCycle());
        }
        [TestMethod]
        public void SetVbrCycleStr()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetCycle("7");
            Assert.IsTrue(7 == vbr.GetCycle());
        }
        [TestMethod]
        public void SetVbrDepthInt()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetDepth(7);
            Assert.IsTrue(7 == vbr.GetDepth());
        }
        [TestMethod]
        public void SetVbrDepthStr()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetDepth("7");
            Assert.IsTrue(7 == vbr.GetDepth());
        }
        [TestMethod]
        public void SetVbrFadeInTimeFloat()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetFadeInTime(7.0f);
            Assert.IsTrue(7.0f == vbr.GetFadeInTime());
        }
        [TestMethod]
        public void SetVbrFadeInTimeInt()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetFadeInTime(7);
            Assert.IsTrue(7.0f == vbr.GetFadeInTime());
        }
        [TestMethod]
        public void SetVbrFadeInTimeStr()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetFadeInTime("7");
            Assert.IsTrue(7.0f == vbr.GetFadeInTime());
        }
        [TestMethod]
        public void SetVbrFadeOutTimeFloat()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetFadeOutTime(7.0f);
            Assert.IsTrue(7.0f == vbr.GetFadeOutTime());
        }
        [TestMethod]
        public void SetVbrFadeOutTimeInt()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetFadeOutTime(7);
            Assert.IsTrue(7.0f == vbr.GetFadeOutTime());
        }
        [TestMethod]
        public void SetVbrFadeOutTimeStr()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetFadeOutTime("7");
            Assert.IsTrue(7.0f == vbr.GetFadeOutTime());
        }
        [TestMethod]
        public void SetVbrPhaseFloat()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetPhase(7.0f);
            Assert.IsTrue(7.0f == vbr.GetPhase());
        }
        [TestMethod]
        public void SetVbrPhaseInt()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetPhase(7);
            Assert.IsTrue(7.0f == vbr.GetPhase());
        }
        [TestMethod]
        public void SetVbrPhaseStr()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetPhase("7");
            Assert.IsTrue(7.0f == vbr.GetPhase());
        }
        [TestMethod]
        public void SetVbrHeightFloat()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetHeight(7.0f);
            Assert.IsTrue(7.0f == vbr.GetHeight());
        }
        [TestMethod]
        public void SetVbrHeightInt()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetHeight(7);
            Assert.IsTrue(7.0f == vbr.GetHeight());
        }
        [TestMethod]
        public void SetVbrHeightStr()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.SetHeight("7");
            Assert.IsTrue(7.0f == vbr.GetHeight());
        }
    }
}
