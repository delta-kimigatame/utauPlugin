# utauPlugin
飴屋／菖蒲氏によって公開されている，Windows向けに作成された歌声合成ソフトウェア「UTAU」の，
プラグイン作成のためのC#(.Net Framework 4.5)クラスライブラリです．
visual studioでの使用を想定しています．

UTAU公式サイト(http://utau2008.web.fc2.com/)
UTAUプラグインの仕様(https://www20.atwiki.jp/utaou/pages/64.html)

~~Shift-Jis以外の2バイト文字がヘッダに含まれていると落ちます．~~
多分外国の2バイト環境でも動きます．
本家がutf-8になりそうなので，当面様子見の予定です．

## 導入方法
画像付きチュートリアルはコチラ(https://ch.nicovideo.jp/delta_kimigatame/blomaga/ar1716787)
1. Clone or downloadからzipをダウンロードし，適当な場所に解凍する．
1. [ファイル]-[新規作成]-[プロジェクト]より.Net Frameworkのプロジェクトを作成する．
1. [ファイル]-[追加]-[既存のプロジェクト]より，utauPlugin-master\utauPlugin\utauPlugin.slnを開く．
1. [ソリューションエクスプローラー]-[参照]を右クリックし、[参照の追加]を選ぶ．
1. [プロジェクト]-[ソリューション]よりutauPluginにチェックする．

## 使い方
```CSharp
using utauPlugin;

namespace sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            UtauPlugin utauPlugin = new UtauPlugin(args[0]);
            utauPlugin.Input();
            //
            //具体的な処理
            //
            utauPlugin.Output();
        }
    }
}
```
## 具体的な使用例
UTAU界隈おなじみの半音上げプラグイン(コンソール)の場合
```CSharp
using utauPlugin;

namespace sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            UtauPlugin utauPlugin = new UtauPlugin(args[0]);
            utauPlugin.Input();
            foreach(Note note in utauPlugin.note)
            {
                note.SetNoteNum(note.GetNoteNum() + 1);
            }
            utauPlugin.Output();
        }
    }
}
```


## 簡易APIマニュアル
### `UtauPlugin(base Ust)`
#### `UtauPlugin()`
#### `UtauPlugin(string filePath)`
パラメータはUstと同じのため詳細略

#### `void Input()`
`UtauPlugin.filePath`のファイルをshift_Jisで開き，内容を解析します．

ustのヘッダ情報は`UtauPlugin UtauPlugin`に，ノートの情報は`List UtauPlugin.note`に格納されます．

#### `void Output()`
`UtauPlugin.filePath`のファイルに編集内容を上書きします．

UTAUプラグインの仕様に則り，書き出し内容は最小限です．

|要素|書出有無|
|:-------|:-------|
|ヘッダ情報|無|
|[PREV][NEXT]|無|
|[#DELETE]|[#DELETE]だけ書き出す(内容は書き出さない)|
|[#INSERT]|すべてのエントリを書き出す|
|その他|変更があったもののみ書き出す|

ただし@つきのパラメータは`readonly`なので書き出しません．

#### `InitOriginalEntry(string entryName, Object defaultValue)`
ファイル読み書きの際に独自エントリの扱いを設定します．
初期値`hoge`の`MyEntry`を宣言する場合，

```CSharp
using utauPlugin

UtauPlugin utauPlugin = new UtauPlugin(filePath);
utauPlugin.InitOriginalEntry("MyEntry", "hoge");
utauPlugin.Input()
```

とします．

#### `InputVoiceBank()`
UtauPlugin.VoiceDirを参照し，oto.iniとprefix.mapを読込ます．

oto.iniは `Dictionary <string, Oto > UtauPlugin.vb.oto`に，

prefix.mapは `Dictionary <string, MapValue > UtauPlugin.vb.map`に格納されます．

#### `ApplyOto()`
`UtauPlugin.note`のうちpreとoveが定義されていないものを，`UtauPlugin.vb.map`と`UtauPlugin.vb.oto`に基づいて補完します．
なお，Outputには反映されません．

#### `InitAtParam`
`UtauPlugin.note`のうち@filename,@alias,@pre,@pve,@stpが定義されていないものを，他のパラメータに基づいて補完します．
pre/oveが定義されていない場合自動的に`ApplyOto`も呼ばれます．

#### `DeleteNote(int index)`
index番目のnote.numをDELETEに変更し，前後のノートをprev/nextで繋ぎます．

#### `InsertNote(int index)`
index番目にnoteを追加します．追加されたノートはnote.num=INSERT以外未定義となります．

### `Ust`
#### `Ust()`
#### `Ust(string filePath)`
初期化．ファイルパスは宣言時でもあとからSetしても同じです．

#### `void SetFilePath(string filePath)`
読み書きするファイルを変更できます．

#### `string GetFilePath()`
filePathはprivate要素なので，こちらのメソッドで情報取得してください．

他のパラメータについても同様にSetとGetができます．

|パラメータ|説明|
|:-------|:-------|
|String FilePath|tempファイルのフルパス|
|float Version|プラグインのバージョン|
|String ProjectName|プロジェクト名|
|String VoiceDir|音源ライブラリのフルパス|
|String CacheDir|キャッシュファイルのフルパス|
|Float Tempo|USTのテンポ|
|String Tool1Path|ツール1(append)のフルパス|
|String Tool2Path|ツール2(resamp)のフルパス|
|String Flags|UST全体のフラグ|
|Boolean Mode2|Mode2使用の有無|
|Boolean utf8|utf8形式かのチェック(現在使用していません)|


### `Note`
#### `Note()`
各ノートに必ずある，セクションNo,ノート長,歌詞，音高，先行発声を初期化して持っています．

#### `void InitOve(string ove)`
#### `void InitOve(float ove)`
#### `void InitOve(int ove)`
オーバーラップ値をoveで初期化します．

#### `void SetOve(string ove)`
#### `void SetOve(float ove)`
#### `void SetOve(int ove)`
オーバーラップ値をoveに変更し，`UtauPlugin.Output()`時書き出すようフラグを立てます．

#### `Boolean OveIsChanged()`
1度でもオーバーラップをSetしていればtrueを，していなければfalseを返します．

初期化されていない場合もfalseを返します．

#### `Boolean HasOve()`
オーバーラップを初期化していればtrueを，していなければfalseを返します． 

#### `float GetOve()`
オーバーラップ値を取得します．

初期化をしていない場合初期値を返します．


他のパラメータも同様にInit,Has,Set,Get,IsChangedが使えます． 

ただし，セクションNo,ノート長,歌詞，音高，先行発声はノート初期化時に必ずInitされるためHasはありません． 

~~テンポ情報は数値計算上の利便性を考慮して，'UtauPlugin.Input()'時に必ずInitされるためHasはありません．~~
NoteをINSERTした時必要になるので実装しました．

|エントリ名|説明|type|Init|Has|Set|Get|IsChanged|初期値|
|:-------|:-------|:-------|:-------|:-------|:-------|:-------|:-------|:-------|
|[#0000]|セクションNo.|string|InitNum|-|SetNum|GetNum|-|""|
|Length=|ノートの長さ|int|InitLength|-|SetLength|GetLength|LengthIsChanged|480|
|Lyric=|入力された歌詞|string|InitLyric|-|SetLyric|GetLyric|LyricIsChanged|""|
|Tempo=|テンポ|float|InitTempo|HasTempo|SetTempo|GetTempo|TempoIsChanged|120f|
|PreUtterance=|先行発声値|float|InitPre|-|SetPre|GetPre|PreIsChanged|0f|
|VoiceOverlap=|オーバーラップ値|float|InitOve|HasOve|SetOve|GetOve|OveIsChanged|0f|
|StartPoint=|STP値|float|InitStp|HasStp|SetStp|GetStp|StpIsChanged|0f|
|Velocity=|子音速度|int|InitVelocity|HasVelocity|SetVelocity|GetVelocity|VelocityIsChanged|100|
|Intensity=|音量|int|InitIntensity|HasIntensity|SetIntensity|GetIntensity|IntensityIsChanged|100|
|Modulation=|モジュレーション|int|InitMod|HasMod|SetMod|GetMod|ModIsChanged|100|
|Moduration=|モジュレーション|int|InitMod|HasMod|SetMod|GetMod|ModIsChanged|100|
|Envelope=|エンベロープ|Envelope|InitEnvelope|HasEnvelope|SetEnvelope|GetEnvelope|EnvelopeIsChanged|"0,5,35,0,100,100,0"|
|VBR=|ビブラート|Vibrato|InitVibrato|HasVibrato|SetVibrato|GetVibrato|VibratoIsChanged|"65,180,35,20,20,0,0,0"|
|Flags=|フラグ|string|InitFlags|HasFlags|SetFlags|GetFlags|FlagsIsChanged|""|
|label=|ラベル|string|InitLabel|HasLabel|SetLabel|GetLabel|LabelIsChanged|""|
|$region=|選択範囲の始め|string|InitRegion|HasRegion|SetRegion|GetRegion|RegionIsChanged|""|
|$region_end=|選択範囲の終わり|string|InitRegionEnd|HasRegionEnd|SetRegionEnd|GetRegionEnd|RegionEndIsChanged|""|

ピッチ(mode1用)

|エントリ名|説明|type|Init|Has|Set|Get|IsChanged|初期値|
|:-------|:-------|:-------|:-------|:-------|:-------|:-------|:-------|:-------|
|Piches=|mode1用ピッチ数列|List&lt;int&gt;|InitPitches|HasPitches|SetPitches|GetPitches|PitchesIsChanged|空のList<int>|
|Pitches=|mode1用ピッチ数列|List&lt;int&gt;|InitPitches|HasPitches|SetPitches|GetPitches|PitchesIsChanged|空のList<int>|
|PitchBend=|mode1用ピッチ数列|List&lt;int&gt;|InitPitches|HasPitches|SetPitches|GetPitches|PitchesIsChanged|空のList<int>|
|PBStart=|mode1用ピッチ数列の開始位置|float|InitPbStart|HasPbStart|SetPbStart|GetPbStart|PbStartIsChanged|0.0f|
|PBType=|mode1用ピッチベンドの種類|string|InitPbType|HasPbType|SetPbType|GetPbType|PbTypeIsChanged|"5"|

ピッチ(mode2用)
mode2用のピッチのパラメータは内部的には一括で宣言され，各パラメータのInitはプラグインに書き出ししない値の登録のために使用されます．

|エントリ名|説明|type|Init|Has|Set|Get|IsChanged|初期値|
|:-------|:-------|:-------|:-------|:-------|:-------|:-------|:-------|:-------|
|PBS=|mode2用ピッチの開始位置|string|InitPbs|HasMode2Pitch|SetPbs|GetPbs|PbsIsChanged|"-50"|
|PBW=|mode2用ポルタメントの間隔|List&lt;float&gt;|InitPbw|HasMode2Pitch|SetPbw|GetPbw|PbwIsChanged|空のList<float>|
|PBY=|mode2用ポルタメントの音高|List&lt;float&gt;|InitPby|HasMode2Pitch|SetPby|GetPby|PbyIsChanged|空のList<float>|
|PBM=|mode2用ピッチベンドの種類|List&lt;string&gt;|InitPbm|HasMode2Pitch|SetPbm|GetPbm|PbmIsChanged|空のList<string>|

読み取り専用のパラメータ

|エントリ名|説明|type|Init|Has|Set|Get|IsChanged|初期値|
|:-------|:-------|:-------|:-------|:-------|:-------|:-------|:-------|:-------|
|@preuttr=|自動調整後の先行発声値|float|InitAtPre|HasAtPre|SetAtPre|GetAtPre|AtPreIsChanged|0.0f|
|@overlap=|自動調整後のオーバーラップ値|float|InitAtOve|HasAtOve|SetAtOve|GetAtOve|AtOveIsChanged|0.0f|
|@stpoint=|自動調整後のstp値|float|InitAtStp|HasAtStp|SetAtStp|GetAtStp|AtStpIsChanged|0.0f|
|@alias=|自動調整後/prefix.map適用後の歌詞|string|InitAtAlias|HasAtAlias|SetAtAlias|GetAtAlias|AtAliasIsChanged|""|
|@filename=|使用するwavのvoiceDirからの相対パス|string|InitAtFileName|HasAtFileName|SetAtFileName|GetAtFileName|AtFileNameIsChanged|""|

独自エントリ

|種類|
|:------------|
|void InitOriginalEntry(string entryName, Object value)|
|void SetOriginalEntry(string entryName, Object value)|
|Object GetOriginalEntry(string entryName)|
|Boolean HasOriginalEntry(string entryName)|
|Boolean OriginalEntryIsChanged(string entryName)|


その他特殊な操作

|メソッド|説明|
|:-------|:-------|
|Boolean PreHasValue()|先行発声は""で初期化される場合があります．""で初期化している場合trueを返します．|
|string GetNoteNumName()|音高名(C4,C#4,D4...)を返します．|
|string GetKey()|音名(C,C#,D...)を返します．|
|float GetPbsTime()|mode2のピッチ開始の時間を返します．宣言されていない場合，-50fを返します．|
|float GetPbsHeight()|mode2のピッチ開始の音高を返します．宣言されていない場合，0fを返します．|
|void SetPbw(int pbw, int point)|'point'個目(0スタート)のPBW値を'pbw'に変更します．|
|void SetPby(int pby, int point)|'point'個目(0スタート)のPBY値を'pby'に変更します．|
|void SetPbm(string pbm, int point)|'point'個目(0スタート)のPBY値を'pbm'に変更します．|
|void ApplyOto(Dictionary&lt;string,MapValue&gt; map, Dictionary&lt;string, Oto&gt; oto)|pre/oveをoto,mapに基づいて初期化します．|
|void InitAtParam(Dictionary&lt;string,MapValue&gt; map, Dictionary&lt;string, Oto&gt; oto)|@パラメータをoto,mapに基づいて初期化します．|
    
### `NoteNum`
必要な操作は全て`Note`からできるため説明略

### `Mode2Pitch`
必要な操作は全て`Note`からできるため説明略

### `Envelope`
`Note`から直接できない操作のみ説明
`Note.envelope`が`Envelope型`なので，'Note.envelope.GetP()'のような使い方を想定しています．

|メソッド|説明|
|:-------|:-------|
|void SetP(float p,int point)|'point'個目(0スタート)のエンベロープのpを変更します．|
|void SetV(int p,int point)|'point'個目(0スタート)のエンベロープのvを変更します．|
|List<float> GetP()|エンベロープのpを取得|
|List<int> GetV()|エンベロープのvを取得|
    

### `Vibrato`
`Note`から直接できない操作のみ説明
`Note.vibrato`が`Vibrato型`なので，~~`Note.vibrato.GetLength()`のような使い方を想定しています．~~
~~以下の通り各パラメータのSetとGetができます．~~

プロパティに変更しました．`Note.vibrato.Length`のようにそのままアクセスできます．

|パラメータ|type|説明|
|:-------|:-------|:-------|
|Length|float|ノート長に対するビブラート長|
|Cycle|float|ビブラートの周期|
|Depth|float|ビブラートの深さ|
|FadeInTime|float|ビブラート長に対するフェードインの割合|
|FadeoutTime|float|ビブラート長に対するフェードアウトの割合|
|Phase|float|ビブラートの初期位相のずれ|
|Height|float|ビブラートの音程オフセット|


### `UtauVoiceBank.VoiceBank`
#### `VoiceBank(string dirPath)`
#### `VoiceBank()`
要素としてstring DirPathを持ちます．

#### `InputPrefixMap`
dirPathのルートにあるprefix.mapを`Dictionary <string, MapValue> VoiceBank.prefixMap`に格納します．

keyはNote.GetNoteNumNameで取得できる音高名です．

#### `InputPrefixMapsAll`
`Dictionary <string, Dictionary <string, MapValue>> VoiceBank.prefixMaps`にprefix.mapを格納します．

dirPathのルートは`prefixMaps[""]`に，
サブフォルダのprefix.mapが`prefixMaps["dirName"]`に格納されます．

#### `InputOto`
dirPathのルートにあるoto.iniを`Dictionary <string, Oto> VoiceBank.oto`に格納します．

keyは原音設定のエイリアスとファイル名が設定されます．

同一のキーがある場合先に読み込まれた内容が適用されます．

#### `InputOtoAll(Boolean Recursive = false)`
dirPath以下サブフォルダ内のoto.iniを`Dictionary <string, Oto> VoiceBank.oto`に格納します．

標準ではdirPathの子フォルダまでですが，Recursive=trueとすると，再帰的に子フォルダからoto.iniを探します．

### `MapValue`
string Preとstring Su を持ちます．

### `Oto`

|パラメータ|説明|
|:----------|:----------|
|string DirPath|ルートフォルダからの相対パス|
|string fileName|ファイル名|
|string alias|エイリアス|
|float Offset|左ブランク|
|float Vel|固定範囲|
|float Blank|右ブランク|
|float Pre|先行発声|
|float Ove|オーバーラップ|
|int WavLength|wavファイルの長さ(ms)|

#### `int GetWavLength()`
WavLength値を返します．不明な場合，wavファイルにアクセスしてファイル長を求めます．

#### `float GetInverseBlank()`
UTAUにはBlankが正の場合(wav末尾からの時間)と負の場合(Offsetからの時間の-1倍)の2種類の書式があります．

Blankの正負を逆にした値を計算し返します．




