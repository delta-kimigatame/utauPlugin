using System;

namespace utauPlugin
{

    public partial class Note
    {
        public class Entry<Type>
        {
            private Type value;
            private Boolean isChanged;

            public Entry(Type value)
            {
                this.value = value;
                isChanged = false;
            }
            
            public void Set(Type value)
            {
                this.value = value;
                isChanged = true;
            }
            public Type Get() => value;
            public Boolean IsChanged() => isChanged;
            
        }

    }
}
