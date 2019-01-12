using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using utauPlugin;

namespace UtauPluginNoteTest
{
    [TestClass]
    public class UtauPluginNoteTest
    {
        Note note;
        [TestInitialize()]
        public void testInitialize()
        {
            note = new Note();

        }
        [TestMethod]
        public void NoteInit()
        {
            Assert.IsTrue(note.GetNum() == "");
            Assert.IsTrue(note.GetLength() == 480);
            Assert.IsTrue(note.GetLyric() == "");
            Assert.IsTrue(note.GetNoteNum() == 60);
        }
        [TestMethod]
        public void SetNum()
        {
            note.SetNum("PREV");
            Assert.IsTrue(note.GetNum() == "PREV");
            note.SetNum("NEXT");
            Assert.IsTrue(note.GetNum() == "NEXT");
            note.SetNum("INSERT");
            Assert.IsTrue(note.GetNum() == "INSERT");
            note.SetNum("DELETE");
            Assert.IsTrue(note.GetNum() == "DELETE");
            note.SetNum("0000");
            Assert.IsTrue(note.GetNum() == "0000");
        }
        [TestMethod]
        public void SetLengthStr()
        {
            note.InitLength("480");
            Assert.IsTrue(note.GetLength() == 480);
            Assert.IsFalse(note.LengthIsChanged());
            note.SetLength("240");
            Assert.IsTrue(note.GetLength() == 240);
            Assert.IsTrue(note.LengthIsChanged());
        }
        [TestMethod]
        public void SetLengthInt()
        {
            note.InitLength(480);
            Assert.IsTrue(note.GetLength() == 480);
            Assert.IsFalse(note.LengthIsChanged());
            note.SetLength(240);
            Assert.IsTrue(note.GetLength() == 240);
            Assert.IsTrue(note.LengthIsChanged());
        }
        [TestMethod]
        public void SetLyric()
        {
            note.InitLyric("‚¢");
            Assert.IsTrue(note.GetLyric() == "‚¢");
            Assert.IsFalse(note.LyricIsChanged());
            note.SetLyric("‚ ");
            Assert.IsTrue(note.GetLyric() == "‚ ");
            Assert.IsTrue(note.LyricIsChanged());
        }
        [TestMethod]
        public void SetNoteNumStr()
        {
            note.InitNoteNum("61");
            Assert.IsTrue(note.GetNoteNum() == 61);
            Assert.IsTrue(note.GetNoteNumName() == "C#4");
            Assert.IsTrue(note.GetKey() == "C#");
            Assert.IsFalse(note.NoteNumIsChanged());
            note.SetNoteNum("62");
            Assert.IsTrue(note.GetNoteNum() == 62);
            Assert.IsTrue(note.GetNoteNumName() == "D4");
            Assert.IsTrue(note.GetKey() == "D");
            Assert.IsTrue(note.NoteNumIsChanged());
        }
        [TestMethod]
        public void SetNoteNumInt()
        {
            note.InitNoteNum(61);
            Assert.IsTrue(note.GetNoteNum() == 61);
            Assert.IsTrue(note.GetNoteNumName() == "C#4");
            Assert.IsTrue(note.GetKey() == "C#");
            Assert.IsFalse(note.NoteNumIsChanged());
            note.SetNoteNum(62);
            Assert.IsTrue(note.GetNoteNum() == 62);
            Assert.IsTrue(note.GetNoteNumName() == "D4");
            Assert.IsTrue(note.GetKey() == "D");
            Assert.IsTrue(note.NoteNumIsChanged());
        }
        [TestMethod]
        public void SetTempoStr()
        {
            note.InitTempo("120.0");
            Assert.IsTrue(note.GetTempo() == 120.0f);
            Assert.IsFalse(note.TempoIsChanged());
            note.SetTempo("121");
            Assert.IsTrue(note.GetTempo() == 121.0f);
            Assert.IsTrue(note.TempoIsChanged());
        }
        [TestMethod]
        public void SetTempoInt()
        {
            note.InitTempo(120);
            Assert.IsTrue(note.GetTempo() == 120.0f);
            Assert.IsFalse(note.TempoIsChanged());
            note.SetTempo(121);
            Assert.IsTrue(note.GetTempo() == 121.0f);
            Assert.IsTrue(note.TempoIsChanged());
        }
        [TestMethod]
        public void SetTempoFloat()
        {
            note.InitTempo(120.0f);
            Assert.IsTrue(note.GetTempo() == 120.0f);
            Assert.IsFalse(note.TempoIsChanged());
            note.SetTempo(121.0f);
            Assert.IsTrue(note.GetTempo() == 121.0f);
            Assert.IsTrue(note.TempoIsChanged());
        }
        [TestMethod]
        public void SetPreStr()
        {
            note.InitPre("120.0");
            Assert.IsTrue(note.GetPre() == 120.0f);
            Assert.IsFalse(note.PreIsChanged());
            Assert.IsTrue(note.PreHasValue());
            note.SetPre("121");
            Assert.IsTrue(note.GetPre() == 121.0f);
            Assert.IsTrue(note.PreIsChanged());
            Assert.IsTrue(note.PreHasValue());
        }
        [TestMethod]
        public void SetPreStrNone()
        {
            note.InitPre("");
            Assert.IsTrue(note.GetPre() == 0.0f);
            Assert.IsFalse(note.PreIsChanged());
            Assert.IsFalse(note.PreHasValue());
            note.SetPre("5");
            Assert.IsTrue(note.GetPre() == 5.0f);
            Assert.IsTrue(note.PreIsChanged());
            Assert.IsTrue(note.PreHasValue());
        }
        [TestMethod]
        public void SetPreInt()
        {
            note.InitPre(120);
            Assert.IsTrue(note.GetPre() == 120.0f);
            Assert.IsFalse(note.PreIsChanged());
            Assert.IsTrue(note.PreHasValue());
            note.SetPre(121);
            Assert.IsTrue(note.GetPre() == 121.0f);
            Assert.IsTrue(note.PreIsChanged());
            Assert.IsTrue(note.PreHasValue());
        }
        [TestMethod]
        public void SetPreFloat()
        {
            note.InitPre(120.0f);
            Assert.IsTrue(note.GetPre() == 120.0f);
            Assert.IsFalse(note.PreIsChanged());
            Assert.IsTrue(note.PreHasValue());
            note.SetPre(121.0f);
            Assert.IsTrue(note.GetPre() == 121.0f);
            Assert.IsTrue(note.PreIsChanged());
            Assert.IsTrue(note.PreHasValue());
        }


        [TestMethod]
        public void SetAtPreStr()
        {
            note.InitAtPre("120.0");
            Assert.IsTrue(note.GetAtPre() == 120.0f);
            Assert.IsFalse(note.AtPreIsChanged());
            note.SetAtPre("121");
            Assert.IsTrue(note.GetAtPre() == 121.0f);
            Assert.IsTrue(note.AtPreIsChanged());
        }
        [TestMethod]
        public void SetAtPreInt()
        {
            note.InitAtPre(120);
            Assert.IsTrue(note.GetAtPre() == 120.0f);
            Assert.IsFalse(note.AtPreIsChanged());
            note.SetAtPre(121);
            Assert.IsTrue(note.GetAtPre() == 121.0f);
            Assert.IsTrue(note.AtPreIsChanged());
        }
        [TestMethod]
        public void SetAtPreFloat()
        {
            note.InitAtPre(120.0f);
            Assert.IsTrue(note.GetAtPre() == 120.0f);
            Assert.IsFalse(note.AtPreIsChanged());
            note.SetAtPre(121.0f);
            Assert.IsTrue(note.GetAtPre() == 121.0f);
            Assert.IsTrue(note.AtPreIsChanged());
        }


        [TestMethod]
        public void SetAtFileName()
        {
            note.InitAtFileName("‚¢");
            Assert.IsTrue(note.GetAtFileName() == "‚¢");
            Assert.IsFalse(note.AtFileNameIsChanged());
            note.SetAtFileName("‚ ");
            Assert.IsTrue(note.GetAtFileName() == "‚ ");
            Assert.IsTrue(note.AtFileNameIsChanged());
        }


        [TestMethod]
        public void SetAtAlias()
        {
            note.InitAtAlias("‚¢");
            Assert.IsTrue(note.GetAtAlias() == "‚¢");
            Assert.IsFalse(note.AtAliasIsChanged());
            note.SetAtAlias("‚ ");
            Assert.IsTrue(note.GetAtAlias() == "‚ ");
            Assert.IsTrue(note.AtAliasIsChanged());
        }

        [TestMethod]
        public void SetOveStr()
        {
            note.InitOve("120.0");
            Assert.IsTrue(note.GetOve() == 120.0f);
            Assert.IsFalse(note.OveIsChanged());
            note.SetOve("121");
            Assert.IsTrue(note.GetOve() == 121.0f);
            Assert.IsTrue(note.OveIsChanged());
        }
        [TestMethod]
        public void SetOveInt()
        {
            note.InitOve(120);
            Assert.IsTrue(note.GetOve() == 120.0f);
            Assert.IsFalse(note.OveIsChanged());
            note.SetOve(121);
            Assert.IsTrue(note.GetOve() == 121.0f);
            Assert.IsTrue(note.OveIsChanged());
        }
        [TestMethod]
        public void SetOveFloat()
        {
            note.InitOve(120.0f);
            Assert.IsTrue(note.GetOve() == 120.0f);
            Assert.IsFalse(note.OveIsChanged());
            note.SetOve(121.0f);
            Assert.IsTrue(note.GetOve() == 121.0f);
            Assert.IsTrue(note.OveIsChanged());
        }


        [TestMethod]
        public void SetAtOveStr()
        {
            note.InitAtOve("120.0");
            Assert.IsTrue(note.GetAtOve() == 120.0f);
            Assert.IsFalse(note.AtOveIsChanged());
            note.SetAtOve("121");
            Assert.IsTrue(note.GetAtOve() == 121.0f);
            Assert.IsTrue(note.AtOveIsChanged());
        }
        [TestMethod]
        public void SetAtOveInt()
        {
            note.InitAtOve(120);
            Assert.IsTrue(note.GetAtOve() == 120.0f);
            Assert.IsFalse(note.AtOveIsChanged());
            note.SetAtOve(121);
            Assert.IsTrue(note.GetAtOve() == 121.0f);
            Assert.IsTrue(note.AtOveIsChanged());
        }
        [TestMethod]
        public void SetAtOveFloat()
        {
            note.InitAtOve(120.0f);
            Assert.IsTrue(note.GetAtOve() == 120.0f);
            Assert.IsFalse(note.AtOveIsChanged());
            note.SetAtOve(121.0f);
            Assert.IsTrue(note.GetAtOve() == 121.0f);
            Assert.IsTrue(note.AtOveIsChanged());
        }


        [TestMethod]
        public void SetStpStr()
        {
            note.InitStp("120.0");
            Assert.IsTrue(note.GetStp() == 120.0f);
            Assert.IsFalse(note.StpIsChanged());
            note.SetStp("121");
            Assert.IsTrue(note.GetStp() == 121.0f);
            Assert.IsTrue(note.StpIsChanged());
        }
        [TestMethod]
        public void SetStpInt()
        {
            note.InitStp(120);
            Assert.IsTrue(note.GetStp() == 120.0f);
            Assert.IsFalse(note.StpIsChanged());
            note.SetStp(121);
            Assert.IsTrue(note.GetStp() == 121.0f);
            Assert.IsTrue(note.StpIsChanged());
        }
        [TestMethod]
        public void SetStpFloat()
        {
            note.InitStp(120.0f);
            Assert.IsTrue(note.GetStp() == 120.0f);
            Assert.IsFalse(note.StpIsChanged());
            note.SetStp(121.0f);
            Assert.IsTrue(note.GetStp() == 121.0f);
            Assert.IsTrue(note.StpIsChanged());
        }


        [TestMethod]
        public void SetAtStpStr()
        {
            note.InitAtStp("120.0");
            Assert.IsTrue(note.GetAtStp() == 120.0f);
            Assert.IsFalse(note.AtStpIsChanged());
            note.SetAtStp("121");
            Assert.IsTrue(note.GetAtStp() == 121.0f);
            Assert.IsTrue(note.AtStpIsChanged());
        }
        [TestMethod]
        public void SetAtStpInt()
        {
            note.InitAtStp(120);
            Assert.IsTrue(note.GetAtStp() == 120.0f);
            Assert.IsFalse(note.AtStpIsChanged());
            note.SetAtStp(121);
            Assert.IsTrue(note.GetAtStp() == 121.0f);
            Assert.IsTrue(note.AtStpIsChanged());
        }
        [TestMethod]
        public void SetAtStpFloat()
        {
            note.InitAtStp(120.0f);
            Assert.IsTrue(note.GetAtStp() == 120.0f);
            Assert.IsFalse(note.AtStpIsChanged());
            note.SetAtStp(121.0f);
            Assert.IsTrue(note.GetAtStp() == 121.0f);
            Assert.IsTrue(note.AtStpIsChanged());
        }


        [TestMethod]
        public void SetVelocityStr()
        {
            note.InitVelocity("480");
            Assert.IsTrue(note.GetVelocity() == 480);
            Assert.IsFalse(note.VelocityIsChanged());
            note.SetVelocity("240");
            Assert.IsTrue(note.GetVelocity() == 240);
            Assert.IsTrue(note.VelocityIsChanged());
        }
        [TestMethod]
        public void SetVelocityInt()
        {
            note.InitVelocity(480);
            Assert.IsTrue(note.GetVelocity() == 480);
            Assert.IsFalse(note.VelocityIsChanged());
            note.SetVelocity(240);
            Assert.IsTrue(note.GetVelocity() == 240);
            Assert.IsTrue(note.VelocityIsChanged());
        }


        [TestMethod]
        public void SetIntensityStr()
        {
            note.InitIntensity("480");
            Assert.IsTrue(note.GetIntensity() == 480);
            Assert.IsFalse(note.IntensityIsChanged());
            note.SetIntensity("240");
            Assert.IsTrue(note.GetIntensity() == 240);
            Assert.IsTrue(note.IntensityIsChanged());
        }
        [TestMethod]
        public void SetIntensityInt()
        {
            note.InitIntensity(480);
            Assert.IsTrue(note.GetIntensity() == 480);
            Assert.IsFalse(note.IntensityIsChanged());
            note.SetIntensity(240);
            Assert.IsTrue(note.GetIntensity() == 240);
            Assert.IsTrue(note.IntensityIsChanged());
        }


        [TestMethod]
        public void SetModStr()
        {
            note.InitMod("480");
            Assert.IsTrue(note.GetMod() == 480);
            Assert.IsFalse(note.ModIsChanged());
            note.SetMod("240");
            Assert.IsTrue(note.GetMod() == 240);
            Assert.IsTrue(note.ModIsChanged());
        }
        [TestMethod]
        public void SetModInt()
        {
            note.InitMod(480);
            Assert.IsTrue(note.GetMod() == 480);
            Assert.IsFalse(note.ModIsChanged());
            note.SetMod(240);
            Assert.IsTrue(note.GetMod() == 240);
            Assert.IsTrue(note.ModIsChanged());
        }
        [TestMethod]
        public void SetFlags()
        {
            note.InitFlags("‚¢");
            Assert.IsTrue(note.GetFlags() == "‚¢");
            Assert.IsFalse(note.FlagsIsChanged());
            note.SetFlags("‚ ");
            Assert.IsTrue(note.GetFlags() == "‚ ");
            Assert.IsTrue(note.FlagsIsChanged());
        }

        [TestMethod]
        public void SetPitches()
        {
            note.InitPitches("0,1,2,3,4,5");
            Assert.IsTrue(note.GetPitches()[0] == 0);
            Assert.IsTrue(note.GetPitches()[1] == 1);
            Assert.IsTrue(note.GetPitches()[2] == 2);
            Assert.IsTrue(note.GetPitches()[3] == 3);
            Assert.IsTrue(note.GetPitches()[4] == 4);
            Assert.IsTrue(note.GetPitches()[5] == 5);
            Assert.IsTrue(note.GetPitches().Count == 6);
            Assert.IsFalse(note.PitchesIsChanged());
            note.SetPitches("6,7,8,9,10");
            Assert.IsTrue(note.GetPitches()[0] == 6);
            Assert.IsTrue(note.GetPitches()[1] == 7);
            Assert.IsTrue(note.GetPitches()[2] == 8);
            Assert.IsTrue(note.GetPitches()[3] == 9);
            Assert.IsTrue(note.GetPitches()[4] == 10);
            Assert.IsTrue(note.GetPitches().Count == 5);
            Assert.IsTrue(note.PitchesIsChanged());
        }
        [TestMethod]
        public void SetPbStartStr()
        {
            note.InitPbStart("120.0");
            Assert.IsTrue(note.GetPbStart() == 120.0f);
            Assert.IsFalse(note.PbStartIsChanged());
            note.SetPbStart("121");
            Assert.IsTrue(note.GetPbStart() == 121.0f);
            Assert.IsTrue(note.PbStartIsChanged());
        }
        [TestMethod]
        public void SetPbStartInt()
        {
            note.InitPbStart(120);
            Assert.IsTrue(note.GetPbStart() == 120.0f);
            Assert.IsFalse(note.PbStartIsChanged());
            note.SetPbStart(121);
            Assert.IsTrue(note.GetPbStart() == 121.0f);
            Assert.IsTrue(note.PbStartIsChanged());
        }
        [TestMethod]
        public void SetPbStartFloat()
        {
            note.InitPbStart(120.0f);
            Assert.IsTrue(note.GetPbStart() == 120.0f);
            Assert.IsFalse(note.PbStartIsChanged());
            note.SetPbStart(121.0f);
            Assert.IsTrue(note.GetPbStart() == 121.0f);
            Assert.IsTrue(note.PbStartIsChanged());
        }




        [TestMethod]
        public void SetPbs()
        {
            note.InitMode2Pitch();
            note.InitPbs("10;20");
            Assert.IsTrue(note.GetPbs() == "10;20");
            Assert.IsTrue(note.GetPbsTime() == 10);
            Assert.IsTrue(note.GetPbsHeight() == 20);
            Assert.IsFalse(note.PbsIsChanged());
            note.SetPbs("30;50");
            Assert.IsTrue(note.GetPbs() == "30;50");
            Assert.IsTrue(note.GetPbsTime() == 30);
            Assert.IsTrue(note.GetPbsHeight() == 50);
            Assert.IsTrue(note.PbsIsChanged());
        }
        [TestMethod]
        public void SetPbw()
        {
            note.InitMode2Pitch();
            note.InitPbw("0,1,2");
            Assert.IsTrue(note.GetPbw()[0] == 0);
            Assert.IsTrue(note.GetPbw()[1] == 1);
            Assert.IsTrue(note.GetPbw()[2] == 2);
            Assert.IsTrue(note.GetPbw().Count == 3);
            Assert.IsFalse(note.PbwIsChanged());
            note.SetPbw("2,3");
            Assert.IsTrue(note.GetPbw()[0] == 2);
            Assert.IsTrue(note.GetPbw()[1] == 3);
            Assert.IsTrue(note.GetPbw().Count == 2);
            Assert.IsTrue(note.PbwIsChanged());
        }
        [TestMethod]
        public void SetPby()
        {
            note.InitMode2Pitch();
            note.InitPby("0,1,2,");
            Assert.IsTrue(note.GetPby()[0] == 0);
            Assert.IsTrue(note.GetPby()[1] == 1);
            Assert.IsTrue(note.GetPby()[2] == 2);
            Assert.IsTrue(note.GetPby()[3] == 0);
            Assert.IsTrue(note.GetPby().Count == 4);
            Assert.IsFalse(note.PbyIsChanged());
            note.SetPby("2,3");
            Assert.IsTrue(note.GetPby()[0] == 2);
            Assert.IsTrue(note.GetPby()[1] == 3);
            Assert.IsTrue(note.GetPby().Count == 2);
            Assert.IsTrue(note.PbyIsChanged());
        }
        [TestMethod]
        public void SetPbm()
        {
            note.InitMode2Pitch();
            note.InitPbm(",r,j");
            Assert.IsTrue(note.GetPbm()[0] == "");
            Assert.IsTrue(note.GetPbm()[1] == "r");
            Assert.IsTrue(note.GetPbm()[2] == "j");
            Assert.IsTrue(note.GetPbm().Count == 3);
            Assert.IsFalse(note.PbmIsChanged());
            note.SetPbm("s,j");
            Assert.IsTrue(note.GetPbm()[0] == "s");
            Assert.IsTrue(note.GetPbm()[1] == "j");
            Assert.IsTrue(note.GetPbm().Count == 2);
            Assert.IsTrue(note.PbmIsChanged());
        }
        [TestMethod]
        public void SetEnvelope()
        {
            note.InitEnvelope();
            note.SetEnvelope("0,5,30,100,100,100,100");
            Assert.IsTrue(note.GetEnvelope() == "0,5,30,100,100,100,100");
            Assert.IsTrue(note.envelope.GetP(1) == 5.0f);
        }
        [TestMethod]
        public void SetVibrato()
        {
            note.InitVibrato();
            note.SetVibrato("0,1,2,30,30,30,30");
            Assert.IsTrue(note.GetVibrato() == "0,1,2,30,30,30,30,0");
            Assert.IsTrue(note.vibrato.Depth == 2);
        }
        [TestMethod]
        public void SetLabel()
        {
            note.InitLabel("‚¢");
            Assert.IsTrue(note.GetLabel() == "‚¢");
            Assert.IsFalse(note.LabelIsChanged());
            note.SetLabel("‚ ");
            Assert.IsTrue(note.GetLabel() == "‚ ");
            Assert.IsTrue(note.LabelIsChanged());
        }


        [TestMethod]
        public void SetDirectStr()
        {
            note.InitDirect("true");
            Assert.IsTrue(note.GetDirect());
            Assert.IsFalse(note.DirectIsChanged());
            note.SetDirect("false");
            Assert.IsFalse(note.GetDirect());
            Assert.IsTrue(note.DirectIsChanged());
            note.SetDirect("True");
            Assert.IsTrue(note.GetDirect());
            Assert.IsTrue(note.DirectIsChanged());
        }
        [TestMethod]
        public void SetDirect()
        {
            note.InitDirect(true);
            Assert.IsTrue(note.GetDirect());
            Assert.IsFalse(note.DirectIsChanged());
            note.SetDirect(false);
            Assert.IsFalse(note.GetDirect());
            Assert.IsTrue(note.DirectIsChanged());
        }
        [TestMethod]
        public void SetRegion()
        {
            note.InitRegion("‚¢");
            Assert.IsTrue(note.GetRegion() == "‚¢");
            Assert.IsFalse(note.RegionIsChanged());
            note.SetRegion("‚ ");
            Assert.IsTrue(note.GetRegion() == "‚ ");
            Assert.IsTrue(note.RegionIsChanged());
        }


        [TestMethod]
        public void SetRegionEnd()
        {
            note.InitRegionEnd("‚¢");
            Assert.IsTrue(note.GetRegionEnd() == "‚¢");
            Assert.IsFalse(note.RegionEndIsChanged());
            note.SetRegionEnd("‚ ");
            Assert.IsTrue(note.GetRegionEnd() == "‚ ");
            Assert.IsTrue(note.RegionEndIsChanged());
        }
        [TestMethod]
        public void NoInitSetPreStr()
        {
            note.SetPre("120.0");
            Assert.IsTrue(note.GetPre() == 120.0f);
            Assert.IsTrue(note.PreIsChanged());
            Assert.IsTrue(note.PreHasValue());
            note.SetPre("121");
            Assert.IsTrue(note.GetPre() == 121.0f);
            Assert.IsTrue(note.PreIsChanged());
            Assert.IsTrue(note.PreHasValue());
        }
        [TestMethod]
        public void NoInitSetPreInt()
        {
            note.SetPre(120);
            Assert.IsTrue(note.GetPre() == 120.0f);
            Assert.IsTrue(note.PreIsChanged());
            Assert.IsTrue(note.PreHasValue());
            note.SetPre(121);
            Assert.IsTrue(note.GetPre() == 121.0f);
            Assert.IsTrue(note.PreIsChanged());
            Assert.IsTrue(note.PreHasValue());
        }
        [TestMethod]
        public void NoInitSetPreFloat()
        {
            note.SetPre(120.0f);
            Assert.IsTrue(note.GetPre() == 120.0f);
            Assert.IsTrue(note.PreIsChanged());
            Assert.IsTrue(note.PreHasValue());
            note.SetPre(121.0f);
            Assert.IsTrue(note.GetPre() == 121.0f);
            Assert.IsTrue(note.PreIsChanged());
            Assert.IsTrue(note.PreHasValue());
        }


        [TestMethod]
        public void NoInitSetAtPreStr()
        {
            note.SetAtPre("120.0");
            Assert.IsTrue(note.GetAtPre() == 120.0f);
            Assert.IsTrue(note.AtPreIsChanged());
            note.SetAtPre("121");
            Assert.IsTrue(note.GetAtPre() == 121.0f);
            Assert.IsTrue(note.AtPreIsChanged());
        }
        [TestMethod]
        public void NoInitSetAtPreInt()
        {
            Assert.IsFalse(note.AtPreIsChanged());
            note.SetAtPre(120);
            Assert.IsTrue(note.GetAtPre() == 120.0f);
            Assert.IsTrue(note.AtPreIsChanged());
            note.SetAtPre(121);
            Assert.IsTrue(note.GetAtPre() == 121.0f);
            Assert.IsTrue(note.AtPreIsChanged());
        }
        [TestMethod]
        public void NoInitSetAtPreFloat()
        {
            Assert.IsFalse(note.AtPreIsChanged());
            note.SetAtPre(120.0f);
            Assert.IsTrue(note.GetAtPre() == 120.0f);
            Assert.IsTrue(note.AtPreIsChanged());
            note.SetAtPre(121.0f);
            Assert.IsTrue(note.GetAtPre() == 121.0f);
            Assert.IsTrue(note.AtPreIsChanged());
        }


        [TestMethod]
        public void NoInitSetAtFileName()
        {
            Assert.IsFalse(note.AtFileNameIsChanged());
            note.SetAtFileName("‚¢");
            Assert.IsTrue(note.GetAtFileName() == "‚¢");
            Assert.IsTrue(note.AtFileNameIsChanged());
            note.SetAtFileName("‚ ");
            Assert.IsTrue(note.GetAtFileName() == "‚ ");
            Assert.IsTrue(note.AtFileNameIsChanged());
        }


        [TestMethod]
        public void NoInitSetAtAlias()
        {
            Assert.IsFalse(note.AtAliasIsChanged());
            note.SetAtAlias("‚¢");
            Assert.IsTrue(note.GetAtAlias() == "‚¢");
            Assert.IsTrue(note.AtAliasIsChanged());
            note.SetAtAlias("‚ ");
            Assert.IsTrue(note.GetAtAlias() == "‚ ");
            Assert.IsTrue(note.AtAliasIsChanged());
        }

        [TestMethod]
        public void NoInitSetOveStr()
        {
            Assert.IsFalse(note.OveIsChanged());
            note.SetOve("120.0");
            Assert.IsTrue(note.GetOve() == 120.0f);
            Assert.IsTrue(note.OveIsChanged());
            note.SetOve("121");
            Assert.IsTrue(note.GetOve() == 121.0f);
            Assert.IsTrue(note.OveIsChanged());
        }
        [TestMethod]
        public void NoInitSetOveInt()
        {
            Assert.IsFalse(note.OveIsChanged());
            note.SetOve(120);
            Assert.IsTrue(note.GetOve() == 120.0f);
            Assert.IsTrue(note.OveIsChanged());
            note.SetOve(121);
            Assert.IsTrue(note.GetOve() == 121.0f);
            Assert.IsTrue(note.OveIsChanged());
        }
        [TestMethod]
        public void NoInitSetOveFloat()
        {
            Assert.IsFalse(note.OveIsChanged());
            note.SetOve(120.0f);
            Assert.IsTrue(note.GetOve() == 120.0f);
            Assert.IsTrue(note.OveIsChanged());
            note.SetOve(121.0f);
            Assert.IsTrue(note.GetOve() == 121.0f);
            Assert.IsTrue(note.OveIsChanged());
        }


        [TestMethod]
        public void NoInitSetAtOveStr()
        {
            Assert.IsFalse(note.AtOveIsChanged());
            note.SetAtOve("120.0");
            Assert.IsTrue(note.GetAtOve() == 120.0f);
            Assert.IsTrue(note.AtOveIsChanged());
            note.SetAtOve("121");
            Assert.IsTrue(note.GetAtOve() == 121.0f);
            Assert.IsTrue(note.AtOveIsChanged());
        }
        [TestMethod]
        public void NoInitSetAtOveInt()
        {
            Assert.IsFalse(note.AtOveIsChanged());
            note.SetAtOve(120);
            Assert.IsTrue(note.GetAtOve() == 120.0f);
            Assert.IsTrue(note.AtOveIsChanged());
            note.SetAtOve(121);
            Assert.IsTrue(note.GetAtOve() == 121.0f);
            Assert.IsTrue(note.AtOveIsChanged());
        }
        [TestMethod]
        public void NoInitSetAtOveFloat()
        {
            Assert.IsFalse(note.AtOveIsChanged());
            note.SetAtOve(120.0f);
            Assert.IsTrue(note.GetAtOve() == 120.0f);
            Assert.IsTrue(note.AtOveIsChanged());
            note.SetAtOve(121.0f);
            Assert.IsTrue(note.GetAtOve() == 121.0f);
            Assert.IsTrue(note.AtOveIsChanged());
        }


        [TestMethod]
        public void NoInitSetStpStr()
        {
            Assert.IsFalse(note.StpIsChanged());
            note.SetStp("120.0");
            Assert.IsTrue(note.GetStp() == 120.0f);
            Assert.IsTrue(note.StpIsChanged());
            note.SetStp("121");
            Assert.IsTrue(note.GetStp() == 121.0f);
            Assert.IsTrue(note.StpIsChanged());
        }
        [TestMethod]
        public void NoInitSetStpInt()
        {
            Assert.IsFalse(note.StpIsChanged());
            note.SetStp(120);
            Assert.IsTrue(note.GetStp() == 120.0f);
            Assert.IsTrue(note.StpIsChanged());
            note.SetStp(121);
            Assert.IsTrue(note.GetStp() == 121.0f);
            Assert.IsTrue(note.StpIsChanged());
        }
        [TestMethod]
        public void NoInitSetStpFloat()
        {
            Assert.IsFalse(note.StpIsChanged());
            note.SetStp(120.0f);
            Assert.IsTrue(note.GetStp() == 120.0f);
            Assert.IsTrue(note.StpIsChanged());
            note.SetStp(121.0f);
            Assert.IsTrue(note.GetStp() == 121.0f);
            Assert.IsTrue(note.StpIsChanged());
        }


        [TestMethod]
        public void NoInitSetAtStpStr()
        {
            Assert.IsFalse(note.AtStpIsChanged());
            note.SetAtStp("120.0");
            Assert.IsTrue(note.GetAtStp() == 120.0f);
            Assert.IsTrue(note.AtStpIsChanged());
            note.SetAtStp("121");
            Assert.IsTrue(note.GetAtStp() == 121.0f);
            Assert.IsTrue(note.AtStpIsChanged());
        }
        [TestMethod]
        public void NoInitSetAtStpInt()
        {
            Assert.IsFalse(note.AtStpIsChanged());
            note.SetAtStp(120);
            Assert.IsTrue(note.GetAtStp() == 120.0f);
            Assert.IsTrue(note.AtStpIsChanged());
            note.SetAtStp(121);
            Assert.IsTrue(note.GetAtStp() == 121.0f);
            Assert.IsTrue(note.AtStpIsChanged());
        }
        [TestMethod]
        public void NoInitSetAtStpFloat()
        {
            Assert.IsFalse(note.AtStpIsChanged());
            note.SetAtStp(120.0f);
            Assert.IsTrue(note.GetAtStp() == 120.0f);
            Assert.IsTrue(note.AtStpIsChanged());
            note.SetAtStp(121.0f);
            Assert.IsTrue(note.GetAtStp() == 121.0f);
            Assert.IsTrue(note.AtStpIsChanged());
        }


        [TestMethod]
        public void NoInitSetVelocityStr()
        {
            Assert.IsFalse(note.VelocityIsChanged());
            note.SetVelocity("480");
            Assert.IsTrue(note.GetVelocity() == 480);
            Assert.IsTrue(note.VelocityIsChanged());
            note.SetVelocity("240");
            Assert.IsTrue(note.GetVelocity() == 240);
            Assert.IsTrue(note.VelocityIsChanged());
        }
        [TestMethod]
        public void NoInitSetVelocityInt()
        {
            Assert.IsFalse(note.VelocityIsChanged());
            note.SetVelocity(480);
            Assert.IsTrue(note.GetVelocity() == 480);
            Assert.IsTrue(note.VelocityIsChanged());
            note.SetVelocity(240);
            Assert.IsTrue(note.GetVelocity() == 240);
            Assert.IsTrue(note.VelocityIsChanged());
        }


        [TestMethod]
        public void NoInitSetIntensityStr()
        {
            Assert.IsFalse(note.IntensityIsChanged());
            note.SetIntensity("480");
            Assert.IsTrue(note.GetIntensity() == 480);
            Assert.IsTrue(note.IntensityIsChanged());
            note.SetIntensity("240");
            Assert.IsTrue(note.GetIntensity() == 240);
            Assert.IsTrue(note.IntensityIsChanged());
        }
        [TestMethod]
        public void NoInitSetIntensityInt()
        {
            Assert.IsFalse(note.IntensityIsChanged());
            note.SetIntensity(480);
            Assert.IsTrue(note.GetIntensity() == 480);
            Assert.IsTrue(note.IntensityIsChanged());
            note.SetIntensity(240);
            Assert.IsTrue(note.GetIntensity() == 240);
            Assert.IsTrue(note.IntensityIsChanged());
        }


        [TestMethod]
        public void NoInitSetModStr()
        {
            Assert.IsFalse(note.ModIsChanged());
            note.SetMod("480");
            Assert.IsTrue(note.GetMod() == 480);
            Assert.IsTrue(note.ModIsChanged());
            note.SetMod("240");
            Assert.IsTrue(note.GetMod() == 240);
            Assert.IsTrue(note.ModIsChanged());
        }
        [TestMethod]
        public void NoInitSetModInt()
        {
            Assert.IsFalse(note.ModIsChanged());
            note.SetMod(480);
            Assert.IsTrue(note.GetMod() == 480);
            Assert.IsTrue(note.ModIsChanged());
            note.SetMod(240);
            Assert.IsTrue(note.GetMod() == 240);
            Assert.IsTrue(note.ModIsChanged());
        }
        [TestMethod]
        public void NoInitSetFlags()
        {
            Assert.IsFalse(note.FlagsIsChanged());
            note.SetFlags("‚¢");
            Assert.IsTrue(note.GetFlags() == "‚¢");
            Assert.IsTrue(note.FlagsIsChanged());
            note.SetFlags("‚ ");
            Assert.IsTrue(note.GetFlags() == "‚ ");
            Assert.IsTrue(note.FlagsIsChanged());
        }

        [TestMethod]
        public void NoInitSetPitches()
        {
            Assert.IsFalse(note.PitchesIsChanged());
            note.SetPitches("0,1,2,3,4,5");
            Assert.IsTrue(note.GetPitches()[0] == 0);
            Assert.IsTrue(note.GetPitches()[1] == 1);
            Assert.IsTrue(note.GetPitches()[2] == 2);
            Assert.IsTrue(note.GetPitches()[3] == 3);
            Assert.IsTrue(note.GetPitches()[4] == 4);
            Assert.IsTrue(note.GetPitches()[5] == 5);
            Assert.IsTrue(note.GetPitches().Count == 6);
            Assert.IsTrue(note.PitchesIsChanged());
            note.SetPitches("6,7,8,9,10");
            Assert.IsTrue(note.GetPitches()[0] == 6);
            Assert.IsTrue(note.GetPitches()[1] == 7);
            Assert.IsTrue(note.GetPitches()[2] == 8);
            Assert.IsTrue(note.GetPitches()[3] == 9);
            Assert.IsTrue(note.GetPitches()[4] == 10);
            Assert.IsTrue(note.GetPitches().Count == 5);
            Assert.IsTrue(note.PitchesIsChanged());
        }
        [TestMethod]
        public void NoInitSetPbStartStr()
        {
            Assert.IsFalse(note.PbStartIsChanged());
            note.SetPbStart("120.0");
            Assert.IsTrue(note.GetPbStart() == 120.0f);
            Assert.IsTrue(note.PbStartIsChanged());
            note.SetPbStart("121");
            Assert.IsTrue(note.GetPbStart() == 121.0f);
            Assert.IsTrue(note.PbStartIsChanged());
        }
        [TestMethod]
        public void NoInitSetPbStartInt()
        {
            Assert.IsFalse(note.PbStartIsChanged());
            note.SetPbStart(120);
            Assert.IsTrue(note.GetPbStart() == 120.0f);
            Assert.IsTrue(note.PbStartIsChanged());
            note.SetPbStart(121);
            Assert.IsTrue(note.GetPbStart() == 121.0f);
            Assert.IsTrue(note.PbStartIsChanged());
        }
        [TestMethod]
        public void NoInitSetPbStartFloat()
        {
            Assert.IsFalse(note.PbStartIsChanged());
            note.SetPbStart(120.0f);
            Assert.IsTrue(note.GetPbStart() == 120.0f);
            Assert.IsTrue(note.PbStartIsChanged());
            note.SetPbStart(121.0f);
            Assert.IsTrue(note.GetPbStart() == 121.0f);
            Assert.IsTrue(note.PbStartIsChanged());
        }

        [TestMethod]
        public void NoInitSetPbs()
        {
            Assert.IsFalse(note.PbsIsChanged());
            note.SetPbs("10;20");
            Assert.IsTrue(note.GetPbs() == "10;20");
            Assert.IsTrue(note.GetPbsTime() == 10);
            Assert.IsTrue(note.GetPbsHeight() == 20);
            Assert.IsTrue(note.PbsIsChanged());
            note.SetPbs("30;50");
            Assert.IsTrue(note.GetPbs() == "30;50");
            Assert.IsTrue(note.GetPbsTime() == 30);
            Assert.IsTrue(note.GetPbsHeight() == 50);
            Assert.IsTrue(note.PbsIsChanged());
        }
        [TestMethod]
        public void NoInitSetPbw()
        {
            Assert.IsFalse(note.PbwIsChanged());
            note.SetPbw("0,1,2");
            Assert.IsTrue(note.GetPbw()[0] == 0);
            Assert.IsTrue(note.GetPbw()[1] == 1);
            Assert.IsTrue(note.GetPbw()[2] == 2);
            Assert.IsTrue(note.GetPbw().Count == 3);
            Assert.IsTrue(note.PbwIsChanged());
            note.SetPbw("2,3");
            Assert.IsTrue(note.GetPbw()[0] == 2);
            Assert.IsTrue(note.GetPbw()[1] == 3);
            Assert.IsTrue(note.GetPbw().Count == 2);
            Assert.IsTrue(note.PbwIsChanged());
        }
        [TestMethod]
        public void NoInitSetPby()
        {
            Assert.IsFalse(note.PbyIsChanged());
            note.SetPby("0,1,2,");
            Assert.IsTrue(note.GetPby()[0] == 0);
            Assert.IsTrue(note.GetPby()[1] == 1);
            Assert.IsTrue(note.GetPby()[2] == 2);
            Assert.IsTrue(note.GetPby()[3] == 0);
            Assert.IsTrue(note.GetPby().Count == 4);
            Assert.IsTrue(note.PbyIsChanged());
            note.SetPby("2,3");
            Assert.IsTrue(note.GetPby()[0] == 2);
            Assert.IsTrue(note.GetPby()[1] == 3);
            Assert.IsTrue(note.GetPby().Count == 2);
            Assert.IsTrue(note.PbyIsChanged());
        }
        [TestMethod]
        public void NoInitSetPbm()
        {
            Assert.IsFalse(note.PbmIsChanged());
            note.SetPbm(",r,j");
            Assert.IsTrue(note.GetPbm()[0] == "");
            Assert.IsTrue(note.GetPbm()[1] == "r");
            Assert.IsTrue(note.GetPbm()[2] == "j");
            Assert.IsTrue(note.GetPbm().Count == 3);
            Assert.IsTrue(note.PbmIsChanged());
            note.SetPbm("s,j");
            Assert.IsTrue(note.GetPbm()[0] == "s");
            Assert.IsTrue(note.GetPbm()[1] == "j");
            Assert.IsTrue(note.GetPbm().Count == 2);
            Assert.IsTrue(note.PbmIsChanged());
        }
        [TestMethod]
        public void NoInitSetEnvelope()
        {
            Assert.IsFalse(note.EnvelopeIsChanged());
            note.SetEnvelope("0,5,30,100,100,100,100");
            Assert.IsTrue(note.GetEnvelope() == "0,5,30,100,100,100,100");
            Assert.IsTrue(note.envelope.GetP(1) == 5.0f);
        }
        [TestMethod]
        public void NoInitSetVibrato()
        {
            note.SetVibrato("0,1,2,30,30,30,30");
            Assert.IsTrue(note.GetVibrato() == "0,1,2,30,30,30,30,0");
            Assert.IsTrue(note.vibrato.Depth == 2);
        }
        [TestMethod]
        public void NoInitSetLabel()
        {
            Assert.IsFalse(note.LabelIsChanged());
            note.SetLabel("‚¢");
            Assert.IsTrue(note.GetLabel() == "‚¢");
            Assert.IsTrue(note.LabelIsChanged());
            note.SetLabel("‚ ");
            Assert.IsTrue(note.GetLabel() == "‚ ");
            Assert.IsTrue(note.LabelIsChanged());
        }


        [TestMethod]
        public void NoInitSetDirectStr()
        {
            Assert.IsFalse(note.DirectIsChanged());
            note.SetDirect("true");
            Assert.IsTrue(note.GetDirect());
            Assert.IsTrue(note.DirectIsChanged());
            note.SetDirect("false");
            Assert.IsFalse(note.GetDirect());
            Assert.IsTrue(note.DirectIsChanged());
            note.SetDirect("True");
            Assert.IsTrue(note.GetDirect());
            Assert.IsTrue(note.DirectIsChanged());
        }
        [TestMethod]
        public void NoInitSetDirect()
        {
            Assert.IsFalse(note.DirectIsChanged());
            note.SetDirect(true);
            Assert.IsTrue(note.GetDirect());
            Assert.IsTrue(note.DirectIsChanged());
            note.SetDirect(false);
            Assert.IsFalse(note.GetDirect());
            Assert.IsTrue(note.DirectIsChanged());
        }
        [TestMethod]
        public void NoInitSetRegion()
        {
            Assert.IsFalse(note.RegionIsChanged());
            note.SetRegion("‚¢");
            Assert.IsTrue(note.GetRegion() == "‚¢");
            Assert.IsTrue(note.RegionIsChanged());
            note.SetRegion("‚ ");
            Assert.IsTrue(note.GetRegion() == "‚ ");
            Assert.IsTrue(note.RegionIsChanged());
        }


        [TestMethod]
        public void NoInitSetRegionEnd()
        {
            Assert.IsFalse(note.RegionEndIsChanged());
            note.SetRegionEnd("‚¢");
            Assert.IsTrue(note.GetRegionEnd() == "‚¢");
            Assert.IsTrue(note.RegionEndIsChanged());
            note.SetRegionEnd("‚ ");
            Assert.IsTrue(note.GetRegionEnd() == "‚ ");
            Assert.IsTrue(note.RegionEndIsChanged());
        }
        [TestMethod]
        public void ChangeGetPbyTest()
        {
            note.SetPby("0,1,2,");
            note.GetPby()[0] = note.GetPby()[0] + 100;
            Assert.IsTrue(note.GetPby()[0] == 100f);
        }

        [TestMethod]
        public void ChangeGetPbyTest2()
        {
            note.SetPby("0,1,2,");
            note.GetPby()[0] = 100;
            Assert.IsTrue(note.GetPby()[0] == 100f);
        }

    }
}
