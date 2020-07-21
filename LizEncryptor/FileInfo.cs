using System.IO;

namespace LizEncryptor {
    public class FileInfo {
        public string FileName { get; set; }
        public string SafeName { get; set; }

        private string OutputPath;

        public FileInfo(string safeName, string fileName) {
            SafeName = safeName;
            FileName = fileName;
        }
        
        public byte[] GetData() {      
            return File.ReadAllBytes(FileName);
        }

        public void SaveData(byte[] data) {
            File.WriteAllBytes(OutputPath, data);
        }

        public void CreateOutputPath(string inputFolder, string outputFolder, string outputExtension) {
            var path = FileName.Replace(SafeName, string.Empty);
            path = path.Replace(inputFolder, outputFolder);

            var directory = new DirectoryInfo(path);

            if (!directory.Exists) {
                directory.Create();
            }

            var name = SafeName.Split('.');
            OutputPath = path + '\\' + name[0] + "." + outputExtension;
        }
    }
}