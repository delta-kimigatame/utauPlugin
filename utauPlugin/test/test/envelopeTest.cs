using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using utauPlugin;


namespace envelopeTest
{
    [TestClass]
    public class envelopeTest
    {
        //
        //エンベロープ関係のテスト
        //

        [TestMethod]
        public void SetEnvInit()
        {
            Note.Envelope env = new Note.Envelope("0,5,30,1,2,3,4");
            Assert.IsTrue(0.0f == env.GetP()[0]);
            Assert.IsTrue(5.0f == env.GetP()[1]);
            Assert.IsTrue(30.0f == env.GetP()[2]);
            Assert.IsTrue(1 == env.GetV()[0]);
            Assert.IsTrue(2 == env.GetV()[1]);
            Assert.IsTrue(3 == env.GetV()[2]);
            Assert.IsTrue(4 == env.GetV()[3]);
            Assert.IsTrue("0,5,30,1,2,3,4" == env.Get());
        }
        [TestMethod]
        public void SetEnv()
        {
            Note.Envelope env = new Note.Envelope();
            env.Set("0,5,30,1,2,3,4");
            Assert.IsTrue(0.0f == env.GetP()[0]);
            Assert.IsTrue(5.0f == env.GetP()[1]);
            Assert.IsTrue(30.0f == env.GetP()[2]);
            Assert.IsTrue(1 == env.GetV()[0]);
            Assert.IsTrue(2 == env.GetV()[1]);
            Assert.IsTrue(3 == env.GetV()[2]);
            Assert.IsTrue(4 == env.GetV()[3]);
        }
        [TestMethod]
        public void SetEnv2()
        {
            Note.Envelope env = new Note.Envelope();
            env.Set("0,0");
            Assert.IsTrue(0.0f == env.GetP()[0]);
            Assert.IsTrue(0.0f == env.GetP()[1]);
            Assert.IsTrue(0.0f == env.GetP()[2]);
            Assert.IsTrue(100 == env.GetV()[0]);
            Assert.IsTrue(100 == env.GetV()[1]);
            Assert.IsTrue(100 == env.GetV()[2]);
            Assert.IsTrue(100 == env.GetV()[3]);
        }
        [TestMethod]
        public void SetEnv8()
        {
            Note.Envelope env = new Note.Envelope();
            env.Set("0,5,30,1,2,3,4,%,15");
            Assert.IsTrue(0.0f == env.GetP()[0]);
            Assert.IsTrue(5.0f == env.GetP()[1]);
            Assert.IsTrue(30.0f == env.GetP()[2]);
            Assert.IsTrue(15.0f == env.GetP()[3]);
            Assert.IsTrue(1 == env.GetV()[0]);
            Assert.IsTrue(2 == env.GetV()[1]);
            Assert.IsTrue(3 == env.GetV()[2]);
            Assert.IsTrue(4 == env.GetV()[3]);
            Assert.IsTrue("0,5,30,1,2,3,4,%,15" == env.Get());
        }
        [TestMethod]
        public void SetEnv10()
        {
            Note.Envelope env = new Note.Envelope();
            env.Set("0,5,30,1,2,3,4,%,15,7.1,5");
            Assert.IsTrue(0.0f == env.GetP()[0]);
            Assert.IsTrue(5.0f == env.GetP()[1]);
            Assert.IsTrue(30.0f == env.GetP()[2]);
            Assert.IsTrue(15.0f == env.GetP()[3]);
            Assert.IsTrue(7.1f == env.GetP()[4]);
            Assert.IsTrue(1 == env.GetV()[0]);
            Assert.IsTrue(2 == env.GetV()[1]);
            Assert.IsTrue(3 == env.GetV()[2]);
            Assert.IsTrue(4 == env.GetV()[3]);
            Assert.IsTrue(5 == env.GetV()[4]);
            Assert.IsTrue("0,5,30,1,2,3,4,%,15,7.1,5" == env.Get());
        }
        [TestMethod]
        public void SetEnvPInt()
        {
            Note.Envelope env = new Note.Envelope();
            env.Set("0,0");
            env.SetP(5, 1);
            Assert.IsTrue(5.0f == env.GetP()[1]);
        }
        [TestMethod]
        public void SetEnvPFloat()
        {
            Note.Envelope env = new Note.Envelope();
            env.Set("0,0");
            env.SetP(5.0f, 1);
            Assert.IsTrue(5.0f == env.GetP()[1]);
        }
        [TestMethod]
        public void SetEnvPStr()
        {
            Note.Envelope env = new Note.Envelope();
            env.Set("0,0");
            env.SetP("5", 1);
            Assert.IsTrue(5.0f == env.GetP()[1]);
        }
        [TestMethod]
        public void SetEnvVInt()
        {
            Note.Envelope env = new Note.Envelope();
            env.Set("0,0");
            env.SetV(5, 1);
            Assert.IsTrue(5.0f == env.GetV()[1]);
        }
        [TestMethod]
        public void SetEnvVStr()
        {
            Note.Envelope env = new Note.Envelope();
            env.Set("0,0");
            env.SetV("5", 1);
            Assert.IsTrue(5.0f == env.GetV()[1]);
        }
        [TestMethod]
        public void SetEnvRe8()
        {
            Note.Envelope env = new Note.Envelope();
            env.Set("0,0");
            env.Set("0,5,30,1,2,3,4,%,15");
            Assert.IsTrue(0.0f == env.GetP()[0]);
            Assert.IsTrue(5.0f == env.GetP()[1]);
            Assert.IsTrue(30.0f == env.GetP()[2]);
            Assert.IsTrue(15.0f == env.GetP()[3]);
            Assert.IsTrue(1 == env.GetV()[0]);
            Assert.IsTrue(2 == env.GetV()[1]);
            Assert.IsTrue(3 == env.GetV()[2]);
            Assert.IsTrue(4 == env.GetV()[3]);
            Assert.IsTrue("0,5,30,1,2,3,4,%,15" == env.Get());
        }
    }
}
