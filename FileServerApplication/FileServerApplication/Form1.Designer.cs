namespace FileServerApplication
{
    partial class fileServerForm
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
            this.startServer = new System.Windows.Forms.Button();
            this.stopServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.serverOutput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // startServer
            // 
            this.startServer.Location = new System.Drawing.Point(12, 12);
            this.startServer.Name = "startServer";
            this.startServer.Size = new System.Drawing.Size(92, 23);
            this.startServer.TabIndex = 0;
            this.startServer.Text = "Start Server";
            this.startServer.UseVisualStyleBackColor = true;
            this.startServer.Click += new System.EventHandler(this.startServer_Click);
            // 
            // stopServer
            // 
            this.stopServer.Location = new System.Drawing.Point(122, 12);
            this.stopServer.Name = "stopServer";
            this.stopServer.Size = new System.Drawing.Size(92, 23);
            this.stopServer.TabIndex = 2;
            this.stopServer.Text = "Stop Server";
            this.stopServer.UseVisualStyleBackColor = true;
            this.stopServer.Click += new System.EventHandler(this.stopServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server Output:";
            // 
            // serverOutput
            // 
            this.serverOutput.Location = new System.Drawing.Point(12, 87);
            this.serverOutput.Name = "serverOutput";
            this.serverOutput.Size = new System.Drawing.Size(374, 130);
            this.serverOutput.TabIndex = 6;
            this.serverOutput.Text = "";
            // 
            // fileServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 253);
            this.Controls.Add(this.serverOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopServer);
            this.Controls.Add(this.startServer);
            this.Name = "fileServerForm";
            this.Text = "File Server Application (Server)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startServer;
        private System.Windows.Forms.Button stopServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox serverOutput;
    }
}

