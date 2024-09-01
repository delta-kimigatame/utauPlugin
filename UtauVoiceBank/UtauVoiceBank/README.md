## UtauVoiceBank
UtauVoiceBankはUTAU プラグインの開発に必要となるUTAU音源関係の読込機能を提供します。

### Usage
```CSharp
using System.IO;
using UtauVoiceBank;

namespace UtauVoiceBankSample
{
    internal class Sample
    {
        static void Main(string[] args)
        {
            string voiceDir = "C:\voice\ongen";
            VoiceBank vb = new VoiceBank(VoiceDir);
            vb.InputPrefixMap();
            vb.InputOtoAll(recursive);
        }
    }
}
```
### Dependencies
https://www.nuget.org/packages/UtauWave/1.0.0

### Link
https://github.com/delta-kimigatame/utauPlugin/tree/master/UtauVoiceBank