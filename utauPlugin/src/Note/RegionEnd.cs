using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// 選択範囲に名前を付けるの終点の初期値
        /// </summary>
        private const string DEFAULT_REGIONEND = "";
        /// <summary>
        /// 選択範囲に名前を付けるの終点の初期化
        /// </summary>
        /// <param name="regionEnd"></param>
        public void InitRegionEnd(string regionEnd) => this.regionEnd = new Entry<string>(regionEnd);
        /// <summary>
        /// 選択範囲に名前を付けるの終点の変更
        /// </summary>
        /// <param name="regionEnd"></param>
        public void SetRegionEnd(string regionEnd)
        {
            if (HasRegionEnd()) { this.regionEnd.Set(regionEnd); }
            else
            {
                this.regionEnd = new Entry<string>("");
                this.regionEnd.Set(regionEnd);
            }
        }
        /// <summary>
        /// 選択範囲に名前を付けるの終点の取得
        /// </summary>
        /// <returns></returns>
        public string GetRegionEnd() => HasRegionEnd() ? regionEnd.Get() : DEFAULT_REGIONEND;
        /// <summary>
        /// 選択範囲に名前を付けるの終点を変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean RegionEndIsChanged() => (HasRegionEnd() && regionEnd.IsChanged());
        /// <summary>
        /// 選択範囲に名前を付けるの終点の値があればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasRegionEnd() => (regionEnd != null);
    }
}
