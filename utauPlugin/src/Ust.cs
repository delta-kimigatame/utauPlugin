using System;
using System.Collections.Generic;

namespace utauPlugin
{
    public class Ust
    {
        private string filePath;
        private float version;
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

        public Ust()
        {
            filePath = "";
            version = 1.0f;
            projectName = "新規プロジェクト";
            voiceDir = "";
            cacheDir = "";
            outputFile = "";
            tempo = 120.0f;
            tool1Path = "";
            tool2Path = "";
            flags = "";
            mode2 = true;
            note = new List<Note>();
            utf8 = false;
        }
        public Ust(string filePath)
        {
            this.filePath = filePath;
            version = 1.0f;
            projectName = "新規プロジェクト";
            voiceDir = "";
            cacheDir = "";
            outputFile = "";
            tempo = 120.0f;
            tool1Path = "";
            tool2Path = "";
            flags = "";
            mode2 = true;
            note = new List<Note>();
            utf8 = false;
        }

        public void SetFilePath(string filePath) => this.filePath = filePath;
        public string GetFilePath() => filePath;
        public void SetVersion(float version) => this.version = version;
        public void SetVersion(string version) => this.version = float.Parse(version);
        public float GetVersion() => version;
        public void SetProjectName(string projectName) => this.projectName = projectName;
        public string GetProjectName() => projectName;
        public void SetVoiceDir(string voiceDir) => this.voiceDir = voiceDir;
        public string GetVoiceDir() => voiceDir;
        public void SetCacheDir(string cacheDir) => this.cacheDir = cacheDir;
        public string GetCacheDir() => cacheDir;
        public void SetOutputFile(string outputFile) => this.outputFile = outputFile;
        public string GetOutputFile() => outputFile;
        public void SetTempo(float tempo) => this.tempo = tempo;
        public void SetTempo(string tempo) => this.tempo = float.Parse(tempo);
        public float GetTempo() => tempo;
        public void SetTool1Path(string tool1Path) => this.tool1Path = tool1Path;
        public string GetTool1Pathe() => tool1Path;
        public void SetTool2Path(string tool2Path) => this.tool2Path = tool2Path;
        public string GetTool2Path() => tool2Path;
        public void SetFlags(string flags) => this.flags = flags;
        public string GetFlags() => flags;
        public void SetMode2(Boolean mode2) => this.mode2 = mode2;
        public void SetMode2(String mode2) => this.mode2 = Boolean.Parse(mode2);
        public Boolean IsMode2() => mode2;
        public void SetUtf8(Boolean utf8) => this.utf8 = utf8;
        public void SetUtf8(String utf8) => this.utf8 = Boolean.Parse(utf8);
        public Boolean IsUtf8() => utf8;


    }
}
