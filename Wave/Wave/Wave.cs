using System;
using System.IO;
using System.Text;

namespace UtauWave
{
    /// <summary>
    /// Waveファイルの読込に関する機能を扱います。
    /// </summary>
    /// <remarks>
    /// Waveファイルの読込に関する機能を扱います。
    /// UTAU音源の解析に必要な機能しか提供されないため、主にヘッダ部分の読込しか実装されていません。
    /// </remarks>
    public class Wave
    {
        private BinaryReader binaryReader;
        /// <summary>
        /// wavヘッダの情報を格納します。
        /// </summary>
        private Header header;
        /// <summary>
        /// wavファイルまでの絶対パス
        /// </summary>
        private string filePath;
        /// <summary>
        /// wavファイルの長さ(ms)
        /// </summary>
        /// <remarks>
        /// <c>Wave.Read()</c>を実行した際に自動で計算されます。
        /// <c>(int)(1000 * (double)header.DataChunkSize/(double)(header.SampleRate * header.BlookSize))</c>
        /// </remarks>
        private int playTime;

        /// <summary>
        /// <c>FilePath</c>はwavファイルまでの絶対パス
        /// </summary>
        /// <remarks>
        /// <c>new Wave(filePath)</c>とした場合、<c>filePath</c>が格納されます。
        /// </remarks>
        /// <value>
        /// <c>FilePath</c>はwavファイルまでの絶対パス
        /// </value>
        public string FilePath { get => filePath; set => filePath = value; }
        /// <summary>
        /// <c>PlayTime</c>はwavファイルの長さ(ms)
        /// </summary>
        /// <value>
        /// <c>playTime</c>はwavファイルの長さ(ms)
        /// </value>
        /// <remarks>
        /// このプロパティは<c>Wave.Read()</c>を実行した際に自動で計算されます。
        /// <c>(int)(1000 * (double)header.DataChunkSize/(double)(header.SampleRate * header.BlookSize))</c>
        /// </remarks>
        public int PlayTime { get => playTime; set => playTime = value; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 引数として<c>filePath</c>を取らない場合、別途<c>Read()</c>するまでに<c>FilePath</c>を代入する必要があります。
        /// </remarks>
        public Wave()
        {
            FilePath = "";
            header = new Header();
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 引数<c>filePath</c>は、<c>Wave.FilePath</c>に格納され、<c>Read()</c>に使われます。
        /// </remarks>
        /// <value>
        /// <c>filePath</c>はwavファイルまでの絶対パス
        /// </value>
        public Wave(string filePath)
        {
            FilePath = filePath;
            header = new Header();
        }
        /// <summary>
        /// Waveヘッダを取得します。
        /// </summary>
        /// <remarks>
        /// 詳細はクラス<see cref="Wave.Header">Wave.Header</see>の定義を参照
        /// </remarks>
        public Header GetHeader() => header;
        /// <summary>
        /// waveファイルの読込
        /// </summary>
        /// <remarks>
        /// <para>
        /// バイナリを解析してwaveファイルを読み込み、<c>header</c>と<c>playTime</c>を更新します。
        /// </para>
        /// <para>
        /// 予め有効な<c>filePath</c>が設定されていない場合エラーが生じます。
        /// この命令では<c>filePath</c>の有効性は評価されません。
        /// </para>
        /// </remarks>
        public void Read()
        {
            binaryReader = new BinaryReader(new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read));
            header.RiffHead = Encoding.GetEncoding(20127).GetString(binaryReader.ReadBytes(4));
            header.FileSize = BitConverter.ToInt32(binaryReader.ReadBytes(4), 0);
            header.WaveHead = Encoding.GetEncoding(20127).GetString(binaryReader.ReadBytes(4));
            bool readFmtChunk = false;
            bool readDataChunk = false;

            while (!readFmtChunk || !readDataChunk)
            {
                string chunk = Encoding.GetEncoding(20127).GetString(binaryReader.ReadBytes(4));
                if (chunk.ToLower().CompareTo("fmt ") == 0)
                {
                    header.FormatChunk = chunk;
                    header.FormatChunkSize = BitConverter.ToInt32(binaryReader.ReadBytes(4), 0);
                    header.FormatId = BitConverter.ToInt16(binaryReader.ReadBytes(2), 0);
                    header.Channel = BitConverter.ToInt16(binaryReader.ReadBytes(2), 0);
                    header.SampleRate = BitConverter.ToInt32(binaryReader.ReadBytes(4), 0);
                    header.BytePerSec = BitConverter.ToInt32(binaryReader.ReadBytes(4), 0);
                    header.BlookSize = BitConverter.ToInt16(binaryReader.ReadBytes(2), 0);
                    header.BitPerSample = BitConverter.ToInt16(binaryReader.ReadBytes(2), 0);
                    readFmtChunk = true;
                }
                else if (chunk.ToLower().CompareTo("data") == 0)
                {
                    header.DataChunk = chunk;
                    header.DataChunkSize = BitConverter.ToInt32(binaryReader.ReadBytes(4), 0);
                    PlayTime = (int)(1000 * (double)header.DataChunkSize / (double)(header.SampleRate * header.BlookSize));
                    readDataChunk = true;
                }
                else
                {
                    Int32 size = BitConverter.ToInt32(binaryReader.ReadBytes(4), 0);
                    if (0 < size)
                    {
                        binaryReader.ReadBytes(size);
                    }
                }
            }
        }

        /// <summary>
        /// wavヘッダの情報を格納します。
        /// </summary>
        public class Header
        {
            /// <summary>
            /// "RIFF"と格納されます。
            /// </summary>
            /// <remarks>
            /// 読み込んだファイルがwaveファイルかどうかの判定に使用可能
            /// </remarks>
            private string riffHead;
            /// <summary>
            /// ファイルサイズ(byte)
            /// </summary>
            private int fileSize;
            /// <summary>
            /// "WAVE"と格納されます。
            /// </summary>
            private string waveHead;
            /// <summary>
            /// "fmt "と格納されます。
            /// </summary>
            /// <remarks>
            /// ヘッダの開始位置を特定するためのものであり、通常は読込完了後に使用することはありません。
            /// </remarks>
            private string formatChunk;
            /// <summary>
            /// ヘッダのバイト数(フォーマットチャンク)
            /// </summary>
            /// <remarks>
            /// 通常は16Byte固定
            /// </remarks>
            private int formatChunkSize;
            /// <summary>
            /// wavのフォーマット
            /// </summary>
            /// <remarks>
            /// 非圧縮は1。他のフォーマットもありますがこのライブラリでは対応していません。
            /// </remarks>
            private int formatId;
            /// <summary>
            /// チャンネル数
            /// </summary>
            /// <remarks>
            /// モノラルは1、ステレオは2
            /// </remarks>
            private int channel;
            /// <summary>
            /// サンプリング周波数
            /// </summary>
            /// <remarks>
            /// UTAU的には44100を想定。他の値でも問題なく動作します。
            /// </remarks>
            private int sampleRate;
            /// <summary>
            /// 1秒あたりのブロック数
            /// </summary>
            /// <remarks>
            /// サンプリング周波数 * ビット深度 * チャンネル数と等価
            /// </remarks>
            private int bytePerSec;
            /// <summary>
            /// ブロックサイズ
            /// </summary>
            /// <remarks>
            /// ビット深度 * チャンネル数と等価
            /// </remarks>
            private int blookSize;
            /// <summary>
            /// ビット深度
            /// </summary>
            /// <remarks>
            /// UTAU的には16を想定。他の値でも問題なく動作します。
            /// </remarks>
            private int bitPerSample;
            /// <summary>
            /// "data"と格納されます。
            /// </summary>
            /// <remarks>
            /// データ部の開始位置を特定するためのものであり、通常は読込完了後に使用することはありません。
            /// </remarks>
            private string dataChunk;
            /// <summary>
            /// データ部のサイズ
            /// </summary>
            /// <remarks>
            /// 通常はファイルサイズ - 126と等価
            /// </remarks>
            private int dataChunkSize;

            /// <summary>
            /// "RIFF"と格納されます。
            /// </summary>
            /// <remarks>
            /// 読み込んだファイルがwaveファイルかどうかの判定に使用可能
            /// </remarks>
            public string RiffHead { get => riffHead; set => riffHead = value; }
            /// <summary>
            /// ファイルサイズ(byte)
            /// </summary>
            public int FileSize { get => fileSize; set => fileSize = value; }
            /// <summary>
            /// "WAVE"と格納されます。
            /// </summary>
            public string WaveHead { get => waveHead; set => waveHead = value; }
            /// <summary>
            /// "fmt "と格納されます。
            /// </summary>
            /// <remarks>
            /// ヘッダの開始位置を特定するためのものであり、通常は読込完了後に使用することはありません。
            /// </remarks>
            public string FormatChunk { get => formatChunk; set => formatChunk = value; }
            /// <summary>
            /// ヘッダのバイト数(フォーマットチャンク)
            /// </summary>
            /// <remarks>
            /// 通常は16Byte固定
            /// </remarks>
            public int FormatChunkSize { get => formatChunkSize; set => formatChunkSize = value; }
            /// <summary>
            /// wavのフォーマット
            /// </summary>
            /// <remarks>
            /// 非圧縮は1。他のフォーマットもありますがこのライブラリでは対応していません。
            /// </remarks>
            public int FormatId { get => formatId; set => formatId = value; }
            /// <summary>
            /// サンプリング周波数
            /// </summary>
            /// <remarks>
            /// UTAU的には44100を想定。他の値でも問題なく動作します。
            /// </remarks>
            public int Channel { get => channel; set => channel = value; }
            /// <summary>
            /// サンプリング周波数
            /// </summary>
            /// <remarks>
            /// UTAU的には44100を想定。他の値でも問題なく動作します。
            /// </remarks>
            public int SampleRate { get => sampleRate; set => sampleRate = value; }
            /// <summary>
            /// 1秒あたりのブロック数
            /// </summary>
            /// <remarks>
            /// サンプリング周波数 * ビット深度 * チャンネル数と等価
            /// </remarks>
            public int BytePerSec { get => bytePerSec; set => bytePerSec = value; }
            /// <summary>
            /// ブロックサイズ
            /// </summary>
            /// <remarks>
            /// ビット深度 * チャンネル数と等価
            /// </remarks>
            public int BlookSize { get => blookSize; set => blookSize = value; }
            /// <summary>
            /// ビット深度
            /// </summary>
            /// <remarks>
            /// UTAU的には16を想定。他の値でも問題なく動作します。
            /// </remarks>
            public int BitPerSample { get => bitPerSample; set => bitPerSample = value; }
            /// <summary>
            /// "data"と格納されます。
            /// </summary>
            /// <remarks>
            /// データ部の開始位置を特定するためのものであり、通常は読込完了後に使用することはありません。
            /// </remarks>
            public string DataChunk { get => dataChunk; set => dataChunk = value; }
            /// <summary>
            /// データ部のサイズ
            /// </summary>
            /// <remarks>
            /// 通常はファイルサイズ - 126と等価
            /// </remarks>
            public int DataChunkSize { get => dataChunkSize; set => dataChunkSize = value; }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <remarks>
            /// 初期化のみで何も実行しません。
            /// </remarks>
            public Header() { }
        }
    }
}
