using System;
using System.IO;
using System.Text;

namespace Wave
{
    public class Wave
    {
        private BinaryReader binaryReader;
        private Header header;
        private string filePath;
        private int playTime;

        public string FilePath { get => filePath; set => filePath = value; }
        public int PlayTime { get => playTime; set => playTime = value; }

        public Wave()
        {
            FilePath = "";
            header = new Header();
            
        }
        public Wave(string filePath)
        {
            FilePath = filePath;
            header = new Header();
        }
        public Header GetHeader() => header;
        public void Read()
        {
            binaryReader = new BinaryReader(new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read));
            header.RiffHead = Encoding.GetEncoding(20127).GetString(binaryReader.ReadBytes(4));
            header.FileSize = BitConverter.ToInt32(binaryReader.ReadBytes(4),0);
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
                    header.DataChunkSize= BitConverter.ToInt32(binaryReader.ReadBytes(4), 0);
                    PlayTime = (int)(1000 * (double)header.DataChunkSize/(double)(header.SampleRate * header.BlookSize));
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
        
        public class Header
        {
            private string riffHead;
            private int fileSize;
            private string waveHead;
            private string formatChunk;
            private int formatChunkSize;
            private int formatId;
            private int channel;
            private int sampleRate;
            private int bytePerSec;
            private int blookSize;
            private int bitPerSample;
            private string dataChunk;
            private int dataChunkSize;

            public string RiffHead { get => riffHead; set => riffHead = value; }
            public int FileSize { get => fileSize; set => fileSize = value; }
            public string WaveHead { get => waveHead; set => waveHead = value; }
            public string FormatChunk { get => formatChunk; set => formatChunk = value; }
            public int FormatChunkSize { get => formatChunkSize; set => formatChunkSize = value; }
            public int FormatId { get => formatId; set => formatId = value; }
            public int Channel { get => channel; set => channel = value; }
            public int SampleRate { get => sampleRate; set => sampleRate = value; }
            public int BytePerSec { get => bytePerSec; set => bytePerSec = value; }
            public int BlookSize { get => blookSize; set => blookSize = value; }
            public int BitPerSample { get => bitPerSample; set => bitPerSample = value; }
            public string DataChunk { get => dataChunk; set => dataChunk = value; }
            public int DataChunkSize { get => dataChunkSize; set => dataChunkSize = value; }

            public Header() { }
        }
    }
}
