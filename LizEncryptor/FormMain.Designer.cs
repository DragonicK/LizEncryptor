namespace LizEncryptor {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.GroupEncrypt = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextOutputExtension = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextInputExtension = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextPassword = new System.Windows.Forms.TextBox();
            this.LabelProcess = new System.Windows.Forms.Label();
            this.ButtonOutput = new System.Windows.Forms.Button();
            this.ButtonInput = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TextOuputFolder = new System.Windows.Forms.TextBox();
            this.LabelInput = new System.Windows.Forms.Label();
            this.TextInput = new System.Windows.Forms.TextBox();
            this.ButtonDecrypt = new System.Windows.Forms.Button();
            this.ButtonEncrypt = new System.Windows.Forms.Button();
            this.MenuMain = new System.Windows.Forms.MenuStrip();
            this.MenuEncryptType = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupEncrypt.SuspendLayout();
            this.MenuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupEncrypt
            // 
            this.GroupEncrypt.Controls.Add(this.label4);
            this.GroupEncrypt.Controls.Add(this.TextOutputExtension);
            this.GroupEncrypt.Controls.Add(this.label3);
            this.GroupEncrypt.Controls.Add(this.TextInputExtension);
            this.GroupEncrypt.Controls.Add(this.label5);
            this.GroupEncrypt.Controls.Add(this.TextPassword);
            this.GroupEncrypt.Controls.Add(this.LabelProcess);
            this.GroupEncrypt.Controls.Add(this.ButtonOutput);
            this.GroupEncrypt.Controls.Add(this.ButtonInput);
            this.GroupEncrypt.Controls.Add(this.label2);
            this.GroupEncrypt.Controls.Add(this.TextOuputFolder);
            this.GroupEncrypt.Controls.Add(this.LabelInput);
            this.GroupEncrypt.Controls.Add(this.TextInput);
            this.GroupEncrypt.Controls.Add(this.ButtonDecrypt);
            this.GroupEncrypt.Controls.Add(this.ButtonEncrypt);
            this.GroupEncrypt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupEncrypt.Location = new System.Drawing.Point(15, 36);
            this.GroupEncrypt.Name = "GroupEncrypt";
            this.GroupEncrypt.Size = new System.Drawing.Size(369, 325);
            this.GroupEncrypt.TabIndex = 0;
            this.GroupEncrypt.TabStop = false;
            this.GroupEncrypt.Text = "File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Output Extension:";
            // 
            // TextOutputExtension
            // 
            this.TextOutputExtension.Location = new System.Drawing.Point(16, 215);
            this.TextOutputExtension.Name = "TextOutputExtension";
            this.TextOutputExtension.Size = new System.Drawing.Size(337, 21);
            this.TextOutputExtension.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Input Extension:";
            // 
            // TextInputExtension
            // 
            this.TextInputExtension.Enabled = false;
            this.TextInputExtension.Location = new System.Drawing.Point(16, 170);
            this.TextInputExtension.Name = "TextInputExtension";
            this.TextInputExtension.Size = new System.Drawing.Size(337, 21);
            this.TextInputExtension.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Password:";
            // 
            // TextPassword
            // 
            this.TextPassword.Location = new System.Drawing.Point(16, 126);
            this.TextPassword.Name = "TextPassword";
            this.TextPassword.Size = new System.Drawing.Size(337, 21);
            this.TextPassword.TabIndex = 13;
            // 
            // LabelProcess
            // 
            this.LabelProcess.Location = new System.Drawing.Point(16, 250);
            this.LabelProcess.Name = "LabelProcess";
            this.LabelProcess.Size = new System.Drawing.Size(337, 15);
            this.LabelProcess.TabIndex = 8;
            this.LabelProcess.Text = "Process: None";
            this.LabelProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonOutput
            // 
            this.ButtonOutput.Location = new System.Drawing.Point(323, 83);
            this.ButtonOutput.Name = "ButtonOutput";
            this.ButtonOutput.Size = new System.Drawing.Size(30, 21);
            this.ButtonOutput.TabIndex = 7;
            this.ButtonOutput.Text = "...";
            this.ButtonOutput.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ButtonOutput.UseVisualStyleBackColor = true;
            this.ButtonOutput.Click += new System.EventHandler(this.ButtonOutput_Click);
            // 
            // ButtonInput
            // 
            this.ButtonInput.Location = new System.Drawing.Point(323, 40);
            this.ButtonInput.Name = "ButtonInput";
            this.ButtonInput.Size = new System.Drawing.Size(30, 21);
            this.ButtonInput.TabIndex = 6;
            this.ButtonInput.Text = "...";
            this.ButtonInput.UseVisualStyleBackColor = true;
            this.ButtonInput.Click += new System.EventHandler(this.ButtonInput_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output Folder:";
            // 
            // TextOuputFolder
            // 
            this.TextOuputFolder.Location = new System.Drawing.Point(16, 83);
            this.TextOuputFolder.Name = "TextOuputFolder";
            this.TextOuputFolder.Size = new System.Drawing.Size(299, 21);
            this.TextOuputFolder.TabIndex = 4;
            // 
            // LabelInput
            // 
            this.LabelInput.AutoSize = true;
            this.LabelInput.Location = new System.Drawing.Point(13, 22);
            this.LabelInput.Name = "LabelInput";
            this.LabelInput.Size = new System.Drawing.Size(69, 13);
            this.LabelInput.TabIndex = 3;
            this.LabelInput.Text = "Input File: ";
            // 
            // TextInput
            // 
            this.TextInput.Location = new System.Drawing.Point(16, 40);
            this.TextInput.Name = "TextInput";
            this.TextInput.Size = new System.Drawing.Size(299, 21);
            this.TextInput.TabIndex = 2;
            // 
            // ButtonDecrypt
            // 
            this.ButtonDecrypt.Location = new System.Drawing.Point(205, 278);
            this.ButtonDecrypt.Name = "ButtonDecrypt";
            this.ButtonDecrypt.Size = new System.Drawing.Size(148, 25);
            this.ButtonDecrypt.TabIndex = 1;
            this.ButtonDecrypt.Text = "Decrypt";
            this.ButtonDecrypt.UseVisualStyleBackColor = true;
            this.ButtonDecrypt.Click += new System.EventHandler(this.ButtonDecrypt_Click);
            // 
            // ButtonEncrypt
            // 
            this.ButtonEncrypt.Location = new System.Drawing.Point(16, 278);
            this.ButtonEncrypt.Name = "ButtonEncrypt";
            this.ButtonEncrypt.Size = new System.Drawing.Size(148, 25);
            this.ButtonEncrypt.TabIndex = 0;
            this.ButtonEncrypt.Text = "Encrypt";
            this.ButtonEncrypt.UseVisualStyleBackColor = true;
            this.ButtonEncrypt.Click += new System.EventHandler(this.ButtonEncrypt_Click);
            // 
            // MenuMain
            // 
            this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEncryptType});
            this.MenuMain.Location = new System.Drawing.Point(0, 0);
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(400, 24);
            this.MenuMain.TabIndex = 1;
            this.MenuMain.Text = "menuStrip1";
            // 
            // MenuEncryptType
            // 
            this.MenuEncryptType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile,
            this.MenuItemFolder,
            this.MenuItemExit});
            this.MenuEncryptType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuEncryptType.Name = "MenuEncryptType";
            this.MenuEncryptType.Size = new System.Drawing.Size(93, 20);
            this.MenuEncryptType.Text = "Encrypt Type";
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.Checked = true;
            this.MenuItemFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(109, 22);
            this.MenuItemFile.Text = "File";
            this.MenuItemFile.Click += new System.EventHandler(this.MenuItemFile_Click);
            // 
            // MenuItemFolder
            // 
            this.MenuItemFolder.Name = "MenuItemFolder";
            this.MenuItemFolder.Size = new System.Drawing.Size(109, 22);
            this.MenuItemFolder.Text = "Folder";
            this.MenuItemFolder.Click += new System.EventHandler(this.MenuItemFolder_Click);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.Size = new System.Drawing.Size(109, 22);
            this.MenuItemExit.Text = "Exit";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 376);
            this.Controls.Add(this.GroupEncrypt);
            this.Controls.Add(this.MenuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuMain;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liz Encryptor";
            this.GroupEncrypt.ResumeLayout(false);
            this.GroupEncrypt.PerformLayout();
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupEncrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextOuputFolder;
        private System.Windows.Forms.Label LabelInput;
        private System.Windows.Forms.TextBox TextInput;
        private System.Windows.Forms.Button ButtonDecrypt;
        private System.Windows.Forms.Button ButtonEncrypt;
        private System.Windows.Forms.Button ButtonOutput;
        private System.Windows.Forms.Button ButtonInput;
        private System.Windows.Forms.Label LabelProcess;
        private System.Windows.Forms.MenuStrip MenuMain;
        private System.Windows.Forms.ToolStripMenuItem MenuEncryptType;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextOutputExtension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextInputExtension;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
    }
}

