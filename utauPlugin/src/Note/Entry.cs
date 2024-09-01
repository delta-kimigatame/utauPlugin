using System;
using System.Collections.Generic;

namespace UtauPlugin
{

    public partial class Note
    {
        /// <summary>
        /// プラグインで独自エントリーを設定するための初期値の辞書
        /// </summary>
        static public Dictionary<string, Object> originalEntriesDefaultValue;

        /// <summary>
        /// エントリー。値とその値が変更されたかを管理する。
        /// </summary>
        /// <typeparam name="Type">string|float|integer|boolean</typeparam>
        public class Entry<Type>
        {
            /// <summary>
            /// 値
            /// </summary>
            private Type value;
            /// <summary>
            /// この値が変更されたか管理する。
            /// </summary>
            /// <remarks>
            /// プラグインでは、変更された値のみが出力される
            /// </remarks>
            private Boolean isChanged;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="value">初期値</param>
            public Entry(Type value)
            {
                this.value = value;
                isChanged = false;
            }
            
            /// <summary>
            /// セッタ。値を更新し、変更済みとする。
            /// </summary>
            /// <param name="value">新しい値</param>
            public void Set(Type value)
            {
                this.value = value;
                isChanged = true;
            }
            /// <summary>
            /// 値を返す
            /// </summary>
            /// <returns></returns>
            public Type Get() => value;
            /// <summary>
            /// 変更済みかどうかを返す
            /// </summary>
            /// <returns></returns>
            public Boolean IsChanged() => isChanged;

        }

        /// <summary>
        /// 独自エントリー辞書を初期化する
        /// </summary>
        /// <param name="key">エントリ名</param>
        /// <param name="value">初期値</param>
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


        /// <summary>
        /// 独自エントリーを初期化する
        /// </summary>
        /// <param name="key">エントリ名</param>
        /// <param name="value">値</param>
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

        /// <summary>
        /// 独自エントリーを変更する。
        /// </summary>
        /// <param name="key">エントリ名</param>
        /// <param name="value">新しい値</param>
        public void SetOriginalEntry(string key, Object value)
        {
            if (!HasOriginalEntry(key))
            {
                InitOriginalEntry(key, value);
            }
            originalEntries[key].Set(value);

        }

        /// <summary>
        /// 独自エントリーを取得する。
        /// </summary>
        /// <param name="key">エントリ名</param>
        /// <returns>値</returns>
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

        /// <summary>
        /// このノートが指定した独自エントリーを所持しているか確認する。
        /// </summary>
        /// <param name="key">エントリ名</param>
        /// <returns>値を持っていればtrue</returns>
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

        /// <summary>
        /// 独自エントリーが変更済みか
        /// </summary>
        /// <param name="key">エントリ名</param>
        /// <returns>変更済みであればtrue</returns>
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
