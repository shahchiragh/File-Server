namespace FileServerClient
{
    partial class fileSeverClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.downloadFileTB = new System.Windows.Forms.TextBox();
            this.ipAddress = new System.Windows.Forms.Label();
            this.portNumber = new System.Windows.Forms.TextBox();
            this.portNo = new System.Windows.Forms.Label();
            this.uploadFileButton = new System.Windows.Forms.Button();
            this.checkFile = new System.Windows.Forms.Button();
            this.downloadFile = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.clientMessage = new System.Windows.Forms.Label();
            this.messageOutput = new System.Windows.Forms.Label();
            this.messageText = new System.Windows.Forms.RichTextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // downloadFileTB
            // 
            this.downloadFileTB.Location = new System.Drawing.Point(339, 69);
            this.downloadFileTB.Name = "downloadFileTB";
            this.downloadFileTB.Size = new System.Drawing.Size(114, 20);
            this.downloadFileTB.TabIndex = 0;
            // 
            // ipAddress
            // 
            this.ipAddress.AutoSize = true;
            this.ipAddress.Location = new System.Drawing.Point(265, 72);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(68, 15);
            this.ipAddress.TabIndex = 1;
            this.ipAddress.Text = "File Name\"";
            this.ipAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // portNumber
            // 
            this.portNumber.Location = new System.Drawing.Point(152, 20);
            this.portNumber.Name = "portNumber";
            this.portNumber.Size = new System.Drawing.Size(100, 20);
            this.portNumber.TabIndex = 2;
            // 
            // portNo
            // 
            this.portNo.AutoSize = true;
            this.portNo.Location = new System.Drawing.Point(31, 20);
            this.portNo.Name = "portNo";
            this.portNo.Size = new System.Drawing.Size(80, 15);
            this.portNo.TabIndex = 3;
            this.portNo.Text = "Port Number:";
            // 
            // uploadFileButton
            // 
            this.uploadFileButton.Location = new System.Drawing.Point(15, 67);
            this.uploadFileButton.Name = "uploadFileButton";
            this.uploadFileButton.Size = new System.Drawing.Size(96, 23);
            this.uploadFileButton.TabIndex = 5;
            this.uploadFileButton.Text = "Upload File";
            this.uploadFileButton.UseVisualStyleBackColor = true;
            this.uploadFileButton.Click += new System.EventHandler(this.uploadFile_Click);
            // 
            // checkFile
            // 
            this.checkFile.Location = new System.Drawing.Point(15, 108);
            this.checkFile.Name = "checkFile";
            this.checkFile.Size = new System.Drawing.Size(96, 23);
            this.checkFile.TabIndex = 6;
            this.checkFile.Text = "Check Files";
            this.checkFile.UseVisualStyleBackColor = true;
            this.checkFile.Click += new System.EventHandler(this.checkFile_Click);
            // 
            // downloadFile
            // 
            this.downloadFile.Location = new System.Drawing.Point(152, 67);
            this.downloadFile.Name = "downloadFile";
            this.downloadFile.Size = new System.Drawing.Size(104, 23);
            this.downloadFile.TabIndex = 7;
            this.downloadFile.Text = "Download File";
            this.downloadFile.UseVisualStyleBackColor = true;
            this.downloadFile.Click += new System.EventHandler(this.downloadFile_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(152, 108);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(104, 23);
            this.disconnectButton.TabIndex = 8;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // clientMessage
            // 
            this.clientMessage.AutoSize = true;
            this.clientMessage.Location = new System.Drawing.Point(24, 169);
            this.clientMessage.Name = "clientMessage";
            this.clientMessage.Size = new System.Drawing.Size(61, 15);
            this.clientMessage.TabIndex = 9;
            this.clientMessage.Text = "Message:";
            // 
            // messageOutput
            // 
            this.messageOutput.AutoSize = true;
            this.messageOutput.Location = new System.Drawing.Point(107, 169);
            this.messageOutput.Name = "messageOutput";
            this.messageOutput.Size = new System.Drawing.Size(0, 15);
            this.messageOutput.TabIndex = 10;
            // 
            // messageText
            // 
            this.messageText.Location = new System.Drawing.Point(110, 156);
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(240, 96);
            this.messageText.TabIndex = 11;
            this.messageText.Text = "";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(275, 20);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 12;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // fileSeverClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 253);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.messageOutput);
            this.Controls.Add(this.clientMessage);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.downloadFile);
            this.Controls.Add(this.checkFile);
            this.Controls.Add(this.uploadFileButton);
            this.Controls.Add(this.portNo);
            this.Controls.Add(this.portNumber);
            this.Controls.Add(this.ipAddress);
            this.Controls.Add(this.downloadFileTB);
            this.Name = "fileSeverClientForm";
            this.Text = "File Server (Client)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox downloadFileTB;
        private System.Windows.Forms.Label ipAddress;
        private System.Windows.Forms.TextBox portNumber;
        private System.Windows.Forms.Label portNo;
        private System.Windows.Forms.Button uploadFileButton;
        private System.Windows.Forms.Button checkFile;
        private System.Windows.Forms.Button downloadFile;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Label clientMessage;
        private System.Windows.Forms.Label messageOutput;
        private System.Windows.Forms.RichTextBox messageText;
        private System.Windows.Forms.Button connectButton;
    }
}

