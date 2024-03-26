using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TCPChat
{
    public partial class TCPClient : Form
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;

        public TCPClient()
        {
            InitializeComponent();
        }
        private void Receive()
        {
            try
            {
                while (true)
                {
                    string message = reader.ReadLine();
                    if (message != null)
                    {
                        Invoke((MethodInvoker)delegate {
                           tbWaiting.AppendText("Server: " + message + Environment.NewLine);
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string serverIP = tbIPAddress.Text;
            int port;
            if (!int.TryParse(tbPort.Text, out port))
            {
                MessageBox.Show("Invalid port number!");
                return;
            }

            try
            {
                client = new TcpClient(serverIP, port);
                reader = new StreamReader(client.GetStream());
                writer = new StreamWriter(client.GetStream());
                writer.AutoFlush = true;
                tbWaiting.AppendText("Connected to server." + Environment.NewLine);


                Thread receiveThread = new Thread(new ThreadStart(Receive));
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                writer.WriteLine(tbMessages.Text);
                tbWaiting.AppendText("Client: " + tbMessages.Text + Environment.NewLine);
                tbMessages.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
