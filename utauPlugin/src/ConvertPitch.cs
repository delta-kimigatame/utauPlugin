using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtauPlugin
{
    public partial class Note
    {
        public class ConvertPitch
        {
            private float msLength;
            private int framePerPitch;
            private float pitchPerMs;
            private int pitchLength;

            public float MsLength { get => msLength; }
            public int FramePerPitch { get => framePerPitch; }
            public float PitchPerMs { get => pitchPerMs; }
            public int PitchLength { get => pitchLength; }

            public ConvertPitch(Note note)
            {
                if (note.Next is null)
                {
                    msLength = note.GetMsLength() + note.GetAtPre() + note.GetAtStp();
                }
                else
                {
                    msLength = note.GetMsLength() + note.GetAtPre() + note.GetAtStp() + note.Next.GetAtOve() - note.Next.GetAtPre();
                }
                framePerPitch = (int)(60.0f / 96.0f / note.GetTempo() * 44100.0f + 0.5f);
                pitchPerMs = framePerPitch / 44100.0f * 1000;
                pitchLength = (int)(msLength / 1000f * 44100f / framePerPitch) + 1;
            }
            public List<int> Mode2Pitch2Mode1()
            {
                List<int> pitches = new List<int>();
                return (pitches);
            }

        }
    }
}
