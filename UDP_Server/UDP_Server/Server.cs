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
        public delegate void ControlStringConsumer(Control control, string text);
        UdpClient listener;

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
                    AddText(Console, "Received broadcast from " + groupEP.ToString() + " : " + Encoding.UTF8.GetString(bytes, 0, bytes.Length) + "\n");
                }
            }
            catch (Exception e)
            {
                AddText(Console, e.ToString() + "\n");
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
                control.Text += text;
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            Thread ListenThread = new Thread(Listener);
            ListenThread.Start();
            Thread.Sleep(1000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.EnableBroadcast = true;
            IPEndPoint ep = new IPEndPoint(IPAddress.Broadcast, 11000);
            Console.Text += ">";
            string msg = TextMessage.Text;

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
            }
        }
    }
}
