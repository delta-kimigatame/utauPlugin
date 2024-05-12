namespace UtauPlugin
{
    public partial class Note
    {
        private const string DEFAULT_NUM = "";
        public void InitNum(string num) => this.num = new Entry<string>(num);
        public void SetNum(string num) => this.num.Set(num);
        public string GetNum() => num.Get();
    }
}
