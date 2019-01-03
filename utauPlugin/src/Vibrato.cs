using System;
//ビブラートデータを扱うためのクラスです．
//詳細はvibratoTest.csを参照
namespace utauPlugin
{
    
    public class Vibrato
    {
        private float length;
        private float cycle;
        private float depth;
        private float fadeInTime;
        private float fadeOutTime;
        private float phase;
        private float height;
        private Boolean isChanged;

        public Vibrato()
        {
            length = 0;
            cycle = 0;
            depth = 0.0f;
            fadeInTime = 0.0f;
            fadeOutTime = 0.0f;
            phase = 0.0f;
            height = 0.0f;
            isChanged = false;
        }
        public Vibrato(string value)
        {
            Set(value);
            isChanged = false;
        }
        public void Set(string value)
        {
            string[] tmp = value.Split(',');
            length = float.Parse(tmp[0]);
            cycle = float.Parse(tmp[1]);
            depth = float.Parse(tmp[2]);
            fadeInTime = float.Parse(tmp[3]);
            fadeOutTime = float.Parse(tmp[4]);
            phase = float.Parse(tmp[5]);
            height = float.Parse(tmp[6]);
            isChanged = true;

        }
        public string Get()
        {
            return string.Join(",", length.ToString(), cycle.ToString(), depth.ToString(), fadeInTime.ToString(), fadeOutTime.ToString(), phase.ToString(), height.ToString(),"0");
        }

        public void SetLength(float length)
        {
            this.length = length;
            isChanged = true;
        }

        public void SetLength(string length)
        {
            this.length = int.Parse(length);
            isChanged = true;
        }

        public float GetLength() => length;
        public void SetCycle(float cycle)
        {
            this.cycle = cycle;
            isChanged = true;
        }

        public void SetCycle(string cycle)
        {
            this.cycle = int.Parse(cycle);
            isChanged = true;
        }

        public float GetCycle() => cycle;
        public void SetDepth(float depth)
        {
            this.depth = depth;
            isChanged = true;
        }

        public void SetDepth(int depth)
        {
            this.depth = depth;
            isChanged = true;
        }

        public void SetDepth(string depth)
        {
            this.depth = float.Parse(depth);
            isChanged = true;
        }

        public float GetDepth() => depth;
        public void SetFadeInTime(int fadeInTime)
        {
            this.fadeInTime = fadeInTime;
            isChanged = true;
        }

        public void SetFadeInTime(float fadeInTime)
        {
            this.fadeInTime = fadeInTime;
            isChanged = true;
        }

        public void SetFadeInTime(string fadeInTime)
        {
            this.fadeInTime = float.Parse(fadeInTime);
            isChanged = true;
        }

        public float GetFadeInTime() => fadeInTime;
        public void SetFadeOutTime(int fadeOutTime)
        {
            this.fadeOutTime = fadeOutTime;
            isChanged = true;
        }

        public void SetFadeOutTime(float fadeOutTime)
        {
            this.fadeOutTime = fadeOutTime;
            isChanged = true;
        }

        public void SetFadeOutTime(string fadeOutTime)
        {
            this.fadeOutTime = float.Parse(fadeOutTime);
            isChanged = true;
        }

        public float GetFadeOutTime() => fadeOutTime;
        public void SetPhase(int phase)
        {
            this.phase = phase;
            isChanged = true;
        }

        public void SetPhase(float phase)
        {
            this.phase = phase;
            isChanged = true;
        }

        public void SetPhase(string phase)
        {
            this.phase = float.Parse(phase);
            isChanged = true;
        }

        public float GetPhase() => phase;
        public void SetHeight(int height)
        {
            this.height = height;
            isChanged = true;
        }

        public void SetHeight(float height)
        {
            this.height = height;
            isChanged = true;
        }

        public void SetHeight(string height)
        {
            this.height = float.Parse(height);
            isChanged = true;
        }

        public float GetHeight() => height;
        public Boolean IsChanged() => isChanged;
    }
}
