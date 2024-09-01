using System;

namespace UtauPlugin
{
    public partial class Note
    {
        /// <summary>
        /// 選択範囲に名前を付けるの始点の初期値
        /// </summary>
        private const string DEFAULT_REGION = "";
        /// <summary>
        /// 選択範囲に名前を付けるの始点の初期化
        /// </summary>
        /// <param name="region"></param>
        public void InitRegion(string region) => this.region = new Entry<string>(region);
        /// <summary>
        /// 選択範囲に名前を付けるの始点の変更
        /// </summary>
        /// <param name="region"></param>
        public void SetRegion(string region)
        {
            if (HasRegion()) { this.region.Set(region); }
            else
            {
                this.region = new Entry<string>("");
                this.region.Set(region);
            }
        }
        /// <summary>
        /// 選択範囲に名前を付けるの始点の取得
        /// </summary>
        /// <returns></returns>
        public string GetRegion() => HasRegion() ? region.Get() : DEFAULT_REGION;
        /// <summary>
        /// 選択範囲に名前を付けるの始点が変更済みならtrue
        /// </summary>
        /// <returns></returns>
        public Boolean RegionIsChanged() => (HasRegion() && region.IsChanged());
        /// <summary>
        /// 選択範囲に名前を付けるの始点の値があればtrue
        /// </summary>
        /// <returns></returns>
        public Boolean HasRegion() => (region != null);
    }
}
