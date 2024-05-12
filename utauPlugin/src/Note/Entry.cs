using System;
using System.Collections.Generic;

namespace UtauPlugin
{

    public partial class Note
    {
        static public Dictionary<string, Object> originalEntriesDefaultValue;

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
        public static void InitOriginalEntryDefault(string key,Object value)
        {
            if(originalEntriesDefaultValue == null)
            {
                originalEntriesDefaultValue = new Dictionary<string, Object>();
            }

            if (originalEntriesDefaultValue.ContainsKey(key))
            {
                originalEntriesDefaultValue[key] = value;
            }
            else
            {
                originalEntriesDefaultValue.Add(key, value);
            }
        }



        public void InitOriginalEntry(string key, Object value)
        {
            if(originalEntries == null)
            {
                originalEntries = new Dictionary<string, Entry<Object>>();
            }
            if (originalEntries.ContainsKey(key))
            {
                originalEntries[key] = new Entry<Object>(value);
            }
            else
            {
                originalEntries.Add(key, new Entry<Object>(value));
            }
        }

        public void SetOriginalEntry(string key, Object value)
        {
            if (!HasOriginalEntry(key))
            {
                InitOriginalEntry(key, value);
            }
            originalEntries[key].Set(value);

        }

        public Object GetOriginalEntry(string key)
        {
            if (HasOriginalEntry(key))
            {
                return originalEntries[key].Get();
            }
            else
            {
                return originalEntriesDefaultValue[key];
            }
        }


        public Boolean HasOriginalEntry(string key)
        {
            if(originalEntries == null)
            {
                return false;
            }
            else if (originalEntries.ContainsKey(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean OriginalEntryIsChanged(string key)
        {
            if (HasOriginalEntry(key))
            {
                return originalEntries[key].IsChanged();
            }
            else
            {
                return false;
            }
        }
    }
}
