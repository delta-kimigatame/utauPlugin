## UtauWave
UtauWaveはUTAU プラグインの開発に必要となるwaveファイルの読込機能を提供します。

### Usage
```CSharp
using System.IO;
using UtauWave;

namespace UtauWavSample
{
    internal class Sample
    {
        static void Main(string[] args)
        {
            string dirPath = "C:\";
            string fileName = "a.wav";
            Wave wav = new Wave(Path.Combine(dirPath, fileName));
            wav.Read();
        }
    }
}
```

### Link
https://github.com/delta-kimigatame/utauPlugin/tree/master/Wave