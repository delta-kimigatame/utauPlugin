using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtauPlugin;

namespace vibratoTest
{
    [TestClass]
    public class vibratoTest
    {

        //
        //�r�u���[�g�֌W�̃e�X�g
        //

        //�g����1 �r�u���[�g�̊e�p�����[�^���J���}�Ō�������������������ɂ���
        //�錾����D
        //�r�u���[�g�z���
        //1�F�r�u���[�g�̒���(�m�[�g���ɑ΂��銄��)(����)
        //2�F�r�u���[�g�̎���(����)
        //3�F�r�u���[�g�̐[��(cent�P��)(����)
        //4�F�r�u���[�g�̃t�F�[�h�C���̒���(�r�u���[�g�����ɑ΂��銄��)(����)
        //5�F�r�u���[�g�̃t�F�[�h�A�E�g����(�m�[�g���ɑ΂��銄��)(����)
        //6�F�r�u���[�g�̏����ʑ�(����)
        //7�F�r�u���[�g�̏㉺�I�t�Z�b�g(����)
        //    100�ɂ���ƁC�r�u���[�g�̉��[���{���̃m�[�g�̉����ɂȂ�܂��D
        //    -100�ɂ���ƁC�r�u���[�g�̏�[���{���̃m�[�g�̉����ɂȂ�܂��D
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
        //�g����2 ���������Ő錾���CSet�Ńr�u���[�g�̊e�p�����[�^���J���}�Ō��������������n���܂�
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
