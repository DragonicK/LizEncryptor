using System.Collections.Generic;

namespace LizEncryptor {
    public sealed class FileList {
        public string InputFolder { get; set; }
        public string OutputFolder { get; set; }
        public string OutputExtension { get; set; }

        private readonly Queue<FileInfo> files;

        public FileList() {
            files = new Queue<FileInfo>();
        }

        public void Add(string safeName, string fileName) {
            files.Enqueue(new FileInfo(safeName, fileName));       
        }

        public void Clear() {
            InputFolder = string.Empty;
            OutputFolder = string.Empty;
            OutputExtension = string.Empty;

            files.Clear();
        }

        public int Count() {
            return files.Count;
        }

        public FileInfo GetNextFile() {
            return files.Dequeue();
        }
    }
}