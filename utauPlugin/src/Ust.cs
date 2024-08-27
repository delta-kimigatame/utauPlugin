using System;
using System.Collections.Generic;

namespace UtauPlugin
{
    /// <summary>
    /// UST(UTAU Sequence Text)ファイルを扱います。
    /// </summary>
    public class Ust
    {
        /// <summary>
        /// ustファイルのフルパス
        /// </summary>
        private string filePath;
        /// <summary>
        /// ustのバージョン
        /// </summary>
        private string version;
        /// <summary>
        /// プロジェクト名
        /// </summary>
        private string projectName;
        /// <summary>
        /// 音源フォルダのルート
        /// </summary>
        private string voiceDir;
        /// <summary>
        /// キャッシュフォルダ
        /// </summary>
        private string cacheDir;
        /// <summary>
        /// 出力するwavファイルのパス
        /// </summary>
        private string outputFile;
        /// <summary>
        /// プロジェクトのBPM
        /// </summary>
        private float tempo;
        /// <summary>
        /// tool1(wavtool)のパス
        /// </summary>
        private string tool1Path;
        /// <summary>
        /// tool2(resamp)のパス
        /// </summary>
        private string tool2Path;
        /// <summary>
        /// プロジェクトのフラグ
        /// </summary>
        private string flags;
        /// <summary>
        /// mode2使用の有無
        /// </summary>
        private Boolean mode2;
        /// <summary>
        /// ustの文字コードがutf8の場合true、ANSIの場合false
        /// </summary>
        private Boolean utf8;
        /// <summary>
        /// ノートのリスト
        /// </summary>
        public List<Note> note;

        /// <summary>
        /// ustファイルのフルパス
        /// </summary>
        public string FilePath { get => filePath; set => filePath = value; }
        /// <summary>
        /// プロジェクト名
        /// </summary>
        public string Version { get => version; set => version = value; }
        /// <summary>
        /// ustのバージョン
        /// </summary>
        public string ProjectName { get => projectName; set => projectName = value; }
        /// <summary>
        /// 音源フォルダのルート
        /// </summary>
        public string VoiceDir { get => voiceDir; set => voiceDir = value; }
        /// <summary>
        /// キャッシュフォルダ
        /// </summary>
        public string CacheDir { get => cacheDir; set => cacheDir = value; }
        /// <summary>
        /// 出力するwavファイルのパス
        /// </summary>
        public string OutputFile { get => outputFile; set => outputFile = value; }
        /// <summary>
        /// プロジェクトのBPM
        /// </summary>
        public float Tempo { get => tempo; set => tempo = value; }
        /// <summary>
        /// tool1(wavtool)のパス
        /// </summary>
        public string Tool1Path { get => tool1Path; set => tool1Path = value; }
        /// <summary>
        /// tool2(resamp)のパス
        /// </summary>
        public string Tool2Path { get => tool2Path; set => tool2Path = value; }
        /// <summary>
        /// プロジェクトのフラグ
        /// </summary>
        public string Flags { get => flags; set => flags = value; }
        /// <summary>
        /// mode2使用の有無
        /// </summary>
        public bool Mode2 { get => mode2; set => mode2 = value; }
        /// <summary>
        /// ustの文字コードがutf8の場合true、ANSIの場合false
        /// </summary>
        public bool Utf8 { get => utf8; set => utf8 = value; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Ust()
        {
            FilePath = "";
            Version = "";
            ProjectName = "新規プロジェクト";
            VoiceDir = "";
            CacheDir = "";
            OutputFile = "";
            Tempo = 120.0f;
            Tool1Path = "";
            Tool2Path = "";
            Flags = "";
            Mode2 = true;
            note = new List<Note>();
            Utf8 = false;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 引数<c>filePath</c>は、コンストラクタ時点では使用されず<c>Ust.filePath</c>に格納されます。
        /// </remarks>
        /// <value>
        /// <c>filePath</c>はwavファイルまでの絶対パス
        /// </value>
        public Ust(string filePath)
        {
            this.FilePath = filePath;
            Version = "1.0";
            ProjectName = "新規プロジェクト";
            VoiceDir = "";
            CacheDir = "";
            OutputFile = "";
            Tempo = 120.0f;
            Tool1Path = "";
            Tool2Path = "";
            Flags = "";
            Mode2 = true;
            note = new List<Note>();
            Utf8 = false;
        }

    }
}
