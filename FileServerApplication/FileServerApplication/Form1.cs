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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileServerApplication
{
    public partial class fileServerForm : Form
    {
        IPEndPoint ipEnd;
        Socket sock;
        Socket clientSock;
        public static string receivedPath = "E:\\FT";
        BackgroundWorker backgroundWorker1;
        string userName = "";
        public static int ListenState;
        public static TcpListener ServerListener;
        public static int clientCount=0;

        public fileServerForm()
        {
            InitializeComponent();
            this.backgroundWorker1 = new BackgroundWorker();
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startServer_Click(object sender, EventArgs e)
        {
            if (receivedPath.Length > 0)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            //StartListening();
        }

        private void stopServer_Click(object sender, EventArgs e)
        {
            ListenState = 0;
            ServerListener.Stop();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //StartServer();
            this.Invoke(new MethodInvoker(delegate
            {
                serverOutput.AppendText("Starting Server at Port Number : 5666\n");
            }));

           // ipEnd = new IPEndPoint(IPAddress.Any, 5658);
           // sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            ServerListener = new TcpListener(IPAddress.Any, 5666);
            ServerListener.Start();
            ListenState = 1;
            Thread startThreads = new Thread(StartServer);
            startThreads.Start();
            //Console.WriteLine("Server is connected and listening..");
        }

        private void StartServer()
        {
            try
            {
                while(ListenState==1)
                {
                    clientSock = ServerListener.AcceptSocket();
                   // Console.WriteLine("Connections from:" + clientSock.RemoteEndPoint.ToString());
                    Thread clientSendReceiveThread = new Thread(clientOperations);
                    clientSendReceiveThread.Start();
                    //Console.WriteLine("Server is now accepting and starting new threads....");
                    clientCount += 1;
                    this.Invoke(new MethodInvoker(delegate
                    {
                        serverOutput.AppendText("Client: " + clientSock.RemoteEndPoint.ToString() + " is connecting\n");
                    }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Server stopped with exception : "+ex.Message);
            }
        }

        private void clientOperations()
        {
            //Console.WriteLine("Coming in client operations..");
            while (clientSock.Connected)
            {
                byte[] clientData = new byte[1024 * 5000];
                int receivedBytesLen = 0;

                try
                {
                    receivedBytesLen = clientSock.Receive(clientData);
                }
                catch (Exception ex)
                {
                  MessageBox.Show("Error when a server receives a connection: "+ex.Message);
                }
                string operationName = Encoding.ASCII.GetString(clientData, 0, receivedBytesLen);

                if (operationName.Contains("DOWNLOAD"))//means client wants to download..
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        serverOutput.AppendText("Client: " + clientSock.RemoteEndPoint.ToString() + " requesting to download a file...\n");
                    }));

                    try
                    {
                        string requestFile = operationName.Remove(0, 8);

                        string fileName = receivedPath + "\\" + requestFile;
                        //Console.WriteLine("I am getting filName:" + fileName);
                        string filePath = "";

                        fileName = fileName.Replace("\\", "/");
                        while (fileName.IndexOf("/") > -1)
                        {
                            filePath += fileName.Substring(0, fileName.IndexOf("/") + 1);
                            fileName = fileName.Substring(fileName.IndexOf("/") + 1);
                        }

                        // Console.WriteLine("I am getting filPath:" + filePath);
                        byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);

                        byte[] fileData = File.ReadAllBytes(filePath + fileName);
                        byte[] requestedData = new byte[4 + fileNameByte.Length + fileData.Length];
                        byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);

                        fileNameLen.CopyTo(requestedData, 0);
                        fileNameByte.CopyTo(requestedData, 4);
                        fileData.CopyTo(requestedData, 4 + fileNameByte.Length);

                        clientSock.Send(requestedData);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while downloading file:" + ex.Message);
                    }
                }

                else if (operationName.Contains("GET"))
                {
                   // string operationName = Encoding.ASCII.GetString(clientData, 0, receivedBytesLen);
                    //Console.WriteLine("I am getting operation: " + operationName);
                    this.Invoke(new MethodInvoker(delegate
                    {
                        serverOutput.AppendText("Client: " + clientSock.RemoteEndPoint.ToString() + " requesting to check available files...\n");
                    }));
                    try
                    {
                       // Console.WriteLine("I am trying to do some fileoperations..");
                        string[] arrays;
                        String sdira = receivedPath;
                        arrays = Directory.GetFiles(sdira, "*", SearchOption.AllDirectories).Select(x => Path.GetFileName(x)).ToArray();
                        string filesName = string.Join(":", arrays);
                        byte[] serverData = new byte[1024];
                        serverData = Encoding.ASCII.GetBytes(filesName);
                        clientSock.Send(serverData);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while fetching fileNames:" + ex.Message);
                    }
                }

                else
                {
                    if (receivedBytesLen > 5)
                    {
                        try
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                serverOutput.AppendText("Client: " + clientSock.RemoteEndPoint.ToString() + " is receiving file...\n");
                            }));
                            int fileNameLen = BitConverter.ToInt32(clientData, 0);
                            string fileName = Encoding.ASCII.GetString(clientData, 4, fileNameLen);

                            BinaryWriter bWrite = new BinaryWriter(File.Open(receivedPath + "/" + fileName, FileMode.Append));
                            bWrite.Write(clientData, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);

                            //closing the write operations..
                            bWrite.Close();
                            this.Invoke(new MethodInvoker(delegate
                            {
                                serverOutput.AppendText("Client: " + clientSock.RemoteEndPoint.ToString() + "'s file is Received & Saved at server" + "...\n");
                            }));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while uploading file:" + ex.Message);
                        }
                    }
                }
            }
        }
    }


}
