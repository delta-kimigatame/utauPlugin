using System;

namespace utauPlugin
{

    public partial class Note
    {
        private class Pre
        {
            private float pre;
            private Boolean hasValue;
            private Boolean isChanged;

            public Pre(string pre)
            {
                if (pre == "")
                {
                    this.pre = 0.0f;
                    isChanged = false;
                    hasValue = false;
                }
                else
                {
                    this.pre = float.Parse(pre);
                    isChanged = false;
                    hasValue = true;
                }
            }
            public Pre(int pre)
            {
                this.pre = (float)pre;
                hasValue = true;
                isChanged = false;
            }
            public Pre(float pre)
            {
                this.pre = pre;
                hasValue = true;
                isChanged = false;
            }
            public void Set(string pre) { this.pre = float.Parse(pre); isChanged = true; hasValue = true; }
            public void Set(int pre) { this.pre = pre; isChanged = true; hasValue = true; }
            public void Set(float pre) { this.pre = pre; isChanged = true; }
            public float Get() => pre;
            public Boolean IsChanged() => isChanged;
            public Boolean HasValue() => hasValue;
        }

    }
}
