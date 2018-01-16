using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UDP_Server
{
    public partial class Server : Form
    {
        private const int ListenPort = 11000;
        private string name = "Ismail";
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        public delegate void ControlStringConsumer(Control control, string text);
        UdpClient listener;
        bool ISent;

        public Server()
        {
            InitializeComponent();
        }

        void Listener()
        {
            listener = new UdpClient(ListenPort);
            try
            {
                while (true)
                {
                    IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, ListenPort);
                    byte[] bytes = listener.Receive(ref groupEP);
                    string message = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                    if (ISent)
                    {
                        AddText(Console, DateTime.Now + " You: " + message);
                        ISent = false;
                    }
                    else
                    {
                        AddText(Console, DateTime.Now + ": " + message);
                    }
                    
                }
            }
            catch (SocketException e)
            {
                //AddText(Console, e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }
        
        void AddText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new ControlStringConsumer(AddText), new object[] { control, text });
            }
            else
            {
                control.Text += text + "\n";
            }
        }
        
        void SetText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new ControlStringConsumer(SetText), new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            Thread ListenThread = new Thread(Listener);
            ListenThread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ISent = true;
            socket.EnableBroadcast = true;
            IPEndPoint ep = new IPEndPoint(IPAddress.Broadcast, 11000);
            string msg = string.Format("[{0}]: {1}", name, TextMessage.Text);
            byte[] sendbuf = Encoding.UTF8.GetBytes(msg);
            socket.SendTo(sendbuf, ep);
            Thread.Sleep(200);
        }
        
        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            listener.Close();
        }
        
        private void TextMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1.PerformClick();
                TextMessage.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            name = NameText.Text;
        }

        private void NameText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button2.PerformClick();
            }
        }
    }
}
