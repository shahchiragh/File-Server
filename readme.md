Name: Chirag Shah

Project:File Server

Programming Language: C# Windows Forms Application

Objectives:
1. Implementing two communication protocols for distributed processing, HyperText Transport Protocol - HTTP, and Sockets.
2. Implementing Uploading and Downloading of Files

Project Specification:
	Socket programming is so universal that you can probably find major portions of this part of the program with searching on Google. 
	A simple file exchange system consisting of one file server and three client processes. Each client process will connect to the server over a socket connection and provide a unique user name to be displayed at the server. The server will display the names of clients when the clients are connected.
	When a client connects to the server, it will offer four options (e.g. the “Default Menu”) to the user via a simple GUI (using the command line is not acceptable):
1. Upload a file;
2. Check for available files;
3. Download a file;
4. Disconnect.

The connection to the server will remain open until the client explicitly chooses to “Disconnect.” After the completion of any other option, the user will return to the default menu.
 - If the user chooses to “Upload a file,” the user will be presented with a simple GUI to select an arbitrary file placed in a static, pre-determined directory.  The file will be transferred to the server, and the user should be notified when the transfer is complete.
 - If the user chooses to “Check for available files,” the client will print the current list of files available at the server to a simple GUI. 
 - If other clients upload files to the server, their uploads will be dynamically added to this list.
 - If the user to chooses to “Download a file,” the user will be presented with a simple GUI that displays a list of available files at the server and prompted to select a file to download. The user will be notified when the file download is complete.

The server handles multiple socket connections simultaneously. However, uploading and downloading files may be serialized if necessary. Clients will not attempt to download the same file concurrently.
The file exchange may be performed using whatever mechanism is most convenient and does not need to utilize HTTP. All other commands will be encapsulated in HTTP – this includes listing the available files at the server.
The HTTP tags uses, at minimum, Host, User-Agent, Content-Type, Content-Length, and Date. If you are polling the server, use GET. If you are sending data to the server, use POST.
The server will print the full text of the HTTP message to a simple GUI for inspection. The clients should strip the HTTP metadata and display only relevant portions of the message.
The program operates independently of a browser. Time on the messages should be encoded according to HTTP.

Code Structure:
1. FileServerApplication is Multi-threaded TCP Server Application. The folder consists of FileServerApplication.sln file which
can be opened with a Visual Studio 2013+ versions. Also, it consists FileServeApplication folder which has Application
configurations, form properties, etc.
2. FileServerClient is TCP Client Application. The folder consists of FileServeClient.sln file which
can be opened with a Visual Studio 2013+ versions. Also, it consists FileServeApplication folder which has Application
configurations, form properties, etc.
3. Both applications has usage of Sockets to accomplish TCP connection and does not use and HTTP tags or mechanisms.
4. The FileServerApplication uses a hard coded path "E:\\FT" for getting the files uploaded. (E:// is a root source in my project, you can tweak this path according your folder structure)
5. The FileServerClient Application uses a hard coded path ""E:\\FTDownload" for downloading the files at clients location.
6. For above both applications, the path names can be changed at receivedPath for both the applications respectively inside Form1.cs. 



Run Code:
1. To directly run Server, go to path
	..\FileServerApplication\FileServerApplication\bin\Debug open FileServerApplication.exe

2. To directly run Client, go to path
	..\FileServerApplication\FileServerClient\bin\Debug open FileServerClient.exe

3. If exe's are not permitted to be executed then .sln files can be imported to Visual Studio and project solutions can be built 
and can be executed from Visual Studio.

