using System;
using System.IO;
using System.Windows.Forms;
using LizEncryptor.Cryptography;

namespace LizEncryptor {
    public partial class FormMain : Form {
        EncryptionMethod MethodType = EncryptionMethod.File;

        // Arquivo selecionado para encriptação.
        string SelectedFilePath = string.Empty;
        string SelectedSafeName = string.Empty;

        // Lista de arquivos selecionados.
        readonly FileList files = new FileList();

        public FormMain() {
            InitializeComponent();
        }

        private void ChangeEncryptionType(EncryptionMethod methodType) {
            MethodType = methodType;

            if (methodType == EncryptionMethod.Folder) {
                GroupEncrypt.Text = "Folder";
                TextInputExtension.Enabled = true;
                MenuItemFile.Checked = false;
                MenuItemFolder.Checked = true;
                LabelInput.Text = "Input Folder:";
            }
            else if (methodType == EncryptionMethod.File) {
                GroupEncrypt.Text = "File";
                TextInputExtension.Enabled = false;
                MenuItemFile.Checked = true;
                MenuItemFolder.Checked = false;
                LabelInput.Text = "Input File:";
            }
        }

        private bool ValidateExtension() {
            var output = TextOutputExtension.Text.Trim();
            var input = TextInputExtension.Text.Trim();

            if (MethodType == EncryptionMethod.Folder) {
                if (string.IsNullOrEmpty(input)) {
                    MessageBox.Show("Input extension cannot be empty.");
                    return false;
                }
            }

            if (string.IsNullOrEmpty(output)) {
                MessageBox.Show("Output extension cannot be empty.");
                return false;
            }

            return true;
        }

        private bool ValidatePassword() {
            var password = TextPassword.Text.Trim();

            if (string.IsNullOrEmpty(password)) {
                MessageBox.Show("Password cannot be empty.");
                return false;
            }

            return true;
        }

        private bool ValidateInputFile() {
            var input = TextInput.Text.Trim();

            if (string.IsNullOrEmpty(input)) {
                MessageBox.Show("Input file cannot be empty.");
                return false;
            }

            if (!File.Exists(SelectedFilePath)) {
                MessageBox.Show("Input file does not exists.");
                return false;
            }

            return true;
        }

        private bool ValidateInputFolder() {
            var input = TextInput.Text.Trim();

            if (string.IsNullOrEmpty(input)) {
                MessageBox.Show("Input folder cannot be empty.");
                return false;
            }

            return true;
        }

        private bool ValidateOutputFolder() {
            var output = TextOuputFolder.Text.Trim();

            if (string.IsNullOrEmpty(output)) {
                MessageBox.Show("Output folder cannot be empty.");
                return false;
            }

            return true;
        }

        private void ButtonInput_Click(object sender, EventArgs e) {
            if (MethodType == EncryptionMethod.File) {
                var dialog = new OpenFileDialog() {
                    FilterIndex = 0,
                    Filter = "All Files (*.*)|*.*",
                    Multiselect = false,
                    CheckFileExists = true,
                    CheckPathExists = true,
                    InitialDirectory = Environment.CurrentDirectory                 
                };

                var result = dialog.ShowDialog();

                if (result == DialogResult.OK || result == DialogResult.Yes) {
                    SelectedFilePath = dialog.FileName;
                    SelectedSafeName = dialog.SafeFileName;

                    TextInput.Text = SelectedSafeName;
                }
            }
            else if (MethodType == EncryptionMethod.Folder) {
                var dialog = new FolderBrowserDialog() {
                    ShowNewFolderButton = true,
                    RootFolder = Environment.SpecialFolder.MyComputer
                };

                var result = dialog.ShowDialog();

                if (result == DialogResult.OK || result == DialogResult.Yes) {
                    TextInput.Text = dialog.SelectedPath;
                }
            }
        }

        private void ButtonOutput_Click(object sender, EventArgs e) {
            var dialog = new FolderBrowserDialog() {
                ShowNewFolderButton = true,
                RootFolder = Environment.SpecialFolder.MyComputer
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK || result == DialogResult.Yes) {
                TextOuputFolder.Text = dialog.SelectedPath;
            }
        }

        private void ButtonEncrypt_Click(object sender, EventArgs e) {
            SetButtonEnabled(false);

            StartProcessEncrypt();

            SetButtonEnabled(true);
        }

        private void ButtonDecrypt_Click(object sender, EventArgs e) {
            SetButtonEnabled(false);

            StartProcessDecrypt();

            SetButtonEnabled(true);
        }

        private void MenuItemFile_Click(object sender, EventArgs e) {
            ChangeEncryptionType(EncryptionMethod.File);
        }

        private void MenuItemFolder_Click(object sender, EventArgs e) {
            ChangeEncryptionType(EncryptionMethod.Folder);
        }

        private void MenuItemExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void SetButtonEnabled(bool enabled) {
            ButtonEncrypt.Enabled = enabled;
            ButtonDecrypt.Enabled = enabled;
        }

        private void StartProcessEncrypt() {
            bool exist = false;

            if (CanProcessFiles()) {
                files.Clear();

                files.OutputFolder = TextOuputFolder.Text.Trim();
                files.OutputExtension = TextOutputExtension.Text.Trim();

                SetStatus("Loading file names ...");

                if (MethodType == EncryptionMethod.File) {
                    exist = LoadFileName();
                    files.InputFolder = SelectedFilePath.Replace(SelectedSafeName, string.Empty);
                }
                else if (MethodType == EncryptionMethod.Folder) {
                    exist = LoadFolderFileNames();
                    files.InputFolder = TextInput.Text.Trim();
                }

                if (!exist) {
                    SetStatus("No file found ...");
                    return;
                }

                EncryptFiles();
            }
        }

        private void EncryptFiles() {
            CryptographyKey key = new CryptographyKey();

            if (key.CanCreateKey(TextPassword.Text.Trim())) {
                var done = false;
                var count = 0;

                EncryptionHandler handler = new EncryptionHandler(key);
                FileInfo file;

                byte[] encrypted;

                while (files.Count() > 0) {
                    file = files.GetNextFile();

                    SetStatus($"File - {file.SafeName}");

                    encrypted = handler.Encrypt(file.GetData(), out bool success);

                    if (success) {
                        file.CreateOutputPath(files.InputFolder, files.OutputFolder, files.OutputExtension);
                        file.SaveData(encrypted);

                        count++;
                        done = true;
                    }
                }

                SetFinishedStatus(done, count);
            }
            else {
                SetStatus("Failed to create password ...");
            }
        }

        private void StartProcessDecrypt() {
            bool exist = false;

            if (CanProcessFiles()) {
                files.Clear();

                files.OutputFolder = TextOuputFolder.Text.Trim();
                files.OutputExtension = TextOutputExtension.Text.Trim();

                SetStatus("Loading file names ...");

                if (MethodType == EncryptionMethod.File) {
                    exist = LoadFileName();
                    files.InputFolder = SelectedFilePath.Replace(SelectedSafeName, string.Empty);
                }
                else if (MethodType == EncryptionMethod.Folder) {
                    exist = LoadFolderFileNames();
                    files.InputFolder = TextInput.Text.Trim();
                }

                if (!exist) {
                    SetStatus("No file found ...");
                    return;
                }

                DecryptFile();
            }
        }

        private void DecryptFile() {
            CryptographyKey key = new CryptographyKey();

            if (key.CanCreateKey(TextPassword.Text.Trim())) {
                var done = false;
                var count = 0;

                EncryptionHandler handler = new EncryptionHandler(key);
                FileInfo file;

                byte[] encrypted;

                while (files.Count() > 0) {
                    file = files.GetNextFile();

                    SetStatus($"File - {file.SafeName}");

                    encrypted = handler.Decrypt(file.GetData(), out bool success);

                    if (success) {
                        file.CreateOutputPath(files.InputFolder, files.OutputFolder, files.OutputExtension);
                        file.SaveData(encrypted);

                        count++;
                        done = true;
                    }
                }

                SetFinishedStatus(done, count);
            }
            else {
                SetStatus("Failed to create password ...");
            }
        }

        private void SetFinishedStatus(bool done, int count) {
            if (done) {
                SetStatus($"Done, {count} files processed ...");
            }
            else {
                SetStatus($"0 files processed ...");
            }
        }

        private bool CanProcessFiles() { 
            if (MethodType == EncryptionMethod.File) {
                if (!ValidateInputFile()) {
                    return false;
                }
            }

            if (MethodType == EncryptionMethod.Folder) {
                if (!ValidateInputFolder()) {
                    return false;
                }
            }

            if (!ValidateOutputFolder()) {
                return false;
            }

            if (!ValidatePassword()) {
                return false;
            }
            
            if (!ValidateExtension()) {
                return false;
            }

            return true;
        }

        private bool LoadFileName() {
            if (File.Exists(SelectedFilePath)) {
                AddFile(SelectedSafeName, SelectedFilePath);

                return true;
            }

            return false;
        }

        private bool LoadFolderFileNames() {
            var directory = TextInput.Text.Trim();
            var extension = TextInputExtension.Text.Trim();

             try {
                var file = Directory.GetFiles(directory, "*." + extension, SearchOption.AllDirectories);

                if (file.Length > 0) {
                    for (var i = 0; i < file.Length; i++) {
                        AddFile(GetSafeFileName(file[i]), file[i]);
                    }

                    return true;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            return false;   
        }

        private string GetSafeFileName(string path) {
            var paths = path.Split('\\');
            var count = paths.GetUpperBound(0);

            return paths[count];
        }

        private void AddFile(string safe, string file) {
            files.Add(safe, file);
        }

        private void SetStatus(string text) {
            Application.DoEvents();

            LabelProcess.Text = "Process: " + text;
        }
    }
}