using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Server
{
    public partial class Server : Form
    {
        private TcpListener server;
        private Thread listenThread;

        public Server()
        {
            InitializeComponent();
            server = new TcpListener(IPAddress.Any, 0);
            tbIPAddress.Text = GetLocalIPAddress();
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
        }
        private void ListenForClients()
        {
            server.Start();
            int port = ((IPEndPoint)server.LocalEndpoint).Port;
            tbPort.Text = port.ToString();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }
        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;
                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                string msg = Encoding.UTF8.GetString(message, 0, bytesRead);
                AppendMessage(msg);
            }

            tcpClient.Close();
        }
        private void AppendMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendMessage), message);
                return;
            }
            receivedMessages.AppendText(message + Environment.NewLine);
        }
        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Stop();
            Environment.Exit(0);
        }

        public string GetLocalIPAddress()
        {
            string ipAddress = "";
            try
            {
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress ip in localIPs)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        ipAddress = ip.ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting local IP address: " + ex.Message);
            }
            return ipAddress;
        }
    }
}
