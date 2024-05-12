using System;
using System.Collections.Generic;

namespace UtauPlugin
{
    public class Ust
    {
        private string filePath;
        private string version;
        private string projectName;
        private string voiceDir;
        private string cacheDir;
        private string outputFile;
        private float tempo;
        private string tool1Path;
        private string tool2Path;
        private string flags;
        private Boolean mode2;
        private Boolean utf8;
        public List<Note> note;

        public string FilePath { get => filePath; set => filePath = value; }
        public string Version { get => version; set => version = value; }
        public string ProjectName { get => projectName; set => projectName = value; }
        public string VoiceDir { get => voiceDir; set => voiceDir = value; }
        public string CacheDir { get => cacheDir; set => cacheDir = value; }
        public string OutputFile { get => outputFile; set => outputFile = value; }
        public float Tempo { get => tempo; set => tempo = value; }
        public string Tool1Path { get => tool1Path; set => tool1Path = value; }
        public string Tool2Path { get => tool2Path; set => tool2Path = value; }
        public string Flags { get => flags; set => flags = value; }
        public bool Mode2 { get => mode2; set => mode2 = value; }
        public bool Utf8 { get => utf8; set => utf8 = value; }

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

        //public void SetFilePath(string filePath) => this.FilePath = filePath;
        //public string GetFilePath() => FilePath;
        //public void SetVersion(float version) => this.Version = version;
        //public void SetVersion(string version) => this.Version = float.Parse(version);
        //public float GetVersion() => Version;
        //public void SetProjectName(string projectName) => this.ProjectName = projectName;
        //public string GetProjectName() => ProjectName;
        //public void SetVoiceDir(string voiceDir) => this.VoiceDir = voiceDir;
        //public string GetVoiceDir() => VoiceDir;
        //public void SetCacheDir(string cacheDir) => this.CacheDir = cacheDir;
        //public string GetCacheDir() => CacheDir;
        //public void SetOutputFile(string outputFile) => this.OutputFile = outputFile;
        //public string GetOutputFile() => OutputFile;
        //public void SetTempo(float tempo) => this.Tempo = tempo;
        //public void SetTempo(string tempo) => this.Tempo = float.Parse(tempo);
        //public float GetTempo() => Tempo;
        //public void SetTool1Path(string tool1Path) => this.Tool1Path = tool1Path;
        //public string GetTool1Pathe() => Tool1Path;
        //public void SetTool2Path(string tool2Path) => this.Tool2Path = tool2Path;
        //public string GetTool2Path() => Tool2Path;
        //public void SetFlags(string flags) => this.Flags = flags;
        //public string GetFlags() => Flags;
        //public void SetMode2(Boolean mode2) => this.Mode2 = mode2;
        //public void SetMode2(String mode2) => this.Mode2 = Boolean.Parse(mode2);
        //public Boolean IsMode2() => Mode2;
        //public void SetUtf8(Boolean utf8) => this.Utf8 = utf8;
        //public void SetUtf8(String utf8) => this.Utf8 = Boolean.Parse(utf8);
        //public Boolean IsUtf8() => Utf8;


    }
}
