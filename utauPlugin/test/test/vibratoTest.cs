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
            Assert.IsTrue(7==vbr.Length);
            Assert.IsTrue(1 == vbr.Cycle);
            Assert.IsTrue(2 == vbr.Depth);
            Assert.IsTrue(3.1f == vbr.FadeInTime);
            Assert.IsTrue(4.2f == vbr.FadeOutTime);
            Assert.IsTrue(5.3f == vbr.Phase);
            Assert.IsTrue(6.4f == vbr.Height);
            Assert.IsTrue("7,1,2,3.1,4.2,5.3,6.4,0" == vbr.Get());
        }
        //使い方2 引数無しで宣言し，Setでビブラートの各パラメータをカンマで結合した文字列を渡します
        [TestMethod]
        public void SetVbrParam()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.Set("7,1,2,3.1,4.2,5.3,6.4");
            Assert.IsTrue(7 == vbr.Length);
            Assert.IsTrue(1 == vbr.Cycle);
            Assert.IsTrue(2 == vbr.Depth);
            Assert.IsTrue(3.1f == vbr.FadeInTime);
            Assert.IsTrue(4.2f == vbr.FadeOutTime);
            Assert.IsTrue(5.3f == vbr.Phase);
            Assert.IsTrue(6.4f == vbr.Height);
            Assert.IsTrue("7,1,2,3.1,4.2,5.3,6.4,0" == vbr.Get());
        }
        [TestMethod]
        public void SetVbrLength()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.Length=7.0f;
            Assert.IsTrue(7.0f == vbr.Length);
        }
        [TestMethod]
        public void SetVbrCycle()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.Cycle=7.0f;
            Assert.IsTrue(7.0f == vbr.Cycle);
        }
        [TestMethod]
        public void SetVbrDepth()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.Depth=7.0f;
            Assert.IsTrue(7.0f == vbr.Depth);
        }
        [TestMethod]
        public void SetVbrFadeInTime()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.FadeInTime=7.0f;
            Assert.IsTrue(7.0f == vbr.FadeInTime);
        }
        [TestMethod]
        public void SetVbrFadeOutTime()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.FadeOutTime=7.0f;
            Assert.IsTrue(7.0f == vbr.FadeOutTime);
        }
        [TestMethod]
        public void SetVbrPhase()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.Phase=7.0f;
            Assert.IsTrue(7.0f == vbr.Phase);
        }
        [TestMethod]
        public void SetVbrHeight()
        {
            Note.Vibrato vbr = new Note.Vibrato();
            vbr.Height=7.0f;
            Assert.IsTrue(7.0f == vbr.Height);
        }
    }
}
