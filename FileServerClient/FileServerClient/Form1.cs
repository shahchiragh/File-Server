//Author:Shah Chirag Hareshkumar
//UID: 1001558824
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileServerClient
{
    public partial class fileSeverClientForm : Form
    {
        IPEndPoint ipEnd = null;
        Socket clientSock = null;
        public IPAddress ipAddress1 = null;
        public static string receivedPath = "E:\\FTDownload";
        public fileSeverClientForm()
        {
            InitializeComponent();
        }

        private void uploadFile_Click(object sender, EventArgs e)
        {
            FileDialog fDg = new OpenFileDialog();

            if (fDg.ShowDialog() == DialogResult.OK)
            {
                uploadFile(fDg.FileName);
            }
        }

        private void uploadFile(string fileName)
        {
            try
            {
                string filePath = "";
                fileName = fileName.Replace("\\", "/");
                while (fileName.IndexOf("/") > -1)
                {
                    filePath += fileName.Substring(0, fileName.IndexOf("/") + 1);
                    fileName = fileName.Substring(fileName.IndexOf("/") + 1);
                }

                byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);
                //Console.WriteLine("getting" + fileNameByte);
                if (fileNameByte.Length > 850 * 1024)
                {
                    messageText.Text = "File size is more than 850kb, please try with small file.\n";
                    return;
                }
                //messageText.AppendText("Buffering ...\n");
                byte[] fileData = File.ReadAllBytes(filePath + fileName);
                byte[] clientData = new byte[2 + 4 + fileNameByte.Length + fileData.Length];
                byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);

                fileNameLen.CopyTo(clientData, 0);
                fileNameByte.CopyTo(clientData, 4);
                fileData.CopyTo(clientData, 4 + fileNameByte.Length);

                messageText.AppendText("File sending...\n");
                clientSock.Send(clientData);
                messageText.AppendText(fileName + " > > File uploaded at the server!\n");

            }
            catch (Exception ex)
            {
                if (ex.Message == "No connection could be made because the target machine actively refused it")
                    messageText.Text = "File Sending fail. Because server not running.\n";
                else
                    messageText.Text = "File Sending fail.\n" + ex.Message;
            }

        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            messageText.AppendText("Disconnecting client from the server...\n");
            clientSock.Close();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (portNumber.Text != "" )
            {
                messageText.AppendText("Trying to connect to the server...\n");
                IPHostEntry ipHostInfo = Dns.Resolve("localhost");
                ipAddress1 = ipHostInfo.AddressList[0];
                ipEnd = new IPEndPoint(ipAddress1, Int32.Parse(portNumber.Text));
                clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSock.Connect(ipEnd);
                messageText.AppendText("Connected to the server...\n");
            }
            else
            {
                MessageBox.Show("Please enter port number to connect to server.");
            }
        }

        private void checkFile_Click(object sender, EventArgs e)
        {
            try
            {
                //now here we make request to server to send us the files which it has..
                byte[] clientData = new byte[1024];
                string opertionName = "GET";
                clientData = Encoding.ASCII.GetBytes(opertionName);
                clientSock.Send(clientData);
                byte[] serverData = new byte[1024];
                int receivedBytesLen = clientSock.Receive(serverData);
                string responseName = Encoding.ASCII.GetString(serverData, 0, receivedBytesLen);
                // Console.WriteLine("I am getting some response..:" + responseName);
                messageText.AppendText("---> Available files on server are: <---\n");
                string[] fileNames = responseName.Split(':');
                foreach (string name in fileNames)
                {
                    messageText.AppendText(name + "\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while checking files at server.."+ex.Message);
            }

        }

        private void downloadFile_Click(object sender, EventArgs e)
        {
            if (downloadFileTB.Text != "")
            {
                try
                {
                    string filename = downloadFileTB.Text.Trim();
                    byte[] clientData = new byte[1024];
                    string opertionName = "DOWNLOAD" + filename;
                    clientData = Encoding.ASCII.GetBytes(opertionName);
                    clientSock.Send(clientData);

                    byte[] requestedData = new byte[1024 * 5000];
                    int receivedBytesLen = clientSock.Receive(clientData);

                    int fileNameLen = BitConverter.ToInt32(clientData, 0);
                    string fileName = Encoding.ASCII.GetString(clientData, 4, fileNameLen);

                    BinaryWriter bWrite = new BinaryWriter(File.Open(receivedPath + "/" + fileName, FileMode.Append));
                    bWrite.Write(clientData, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);

                    //closing the write operations..
                    bWrite.Close();
                    messageText.AppendText("Downloaded file to " + receivedPath + "\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while downloading file at server."+ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Enter File Name which you want to download from available files..");
                try
                {
                    byte[] clientData = new byte[1024];
                    string opertionName = "CHECK";
                    clientData = Encoding.ASCII.GetBytes(opertionName);
                    clientSock.Send(clientData);
                    byte[] serverData = new byte[1024];
                    int receivedBytesLen = clientSock.Receive(serverData);
                    string responseName = Encoding.ASCII.GetString(serverData, 0, receivedBytesLen);
                    // Console.WriteLine("I am getting some response..:" + responseName);
                    messageText.AppendText("---> Available files on server are: <---\n");
                    string[] fileNames = responseName.Split(':');
                    foreach (string name in fileNames)
                    {
                        messageText.AppendText(name + "\n");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while showing available files at server." + ex.Message);
                }
            }
        }

    }


}
