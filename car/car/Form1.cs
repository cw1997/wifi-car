using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace car
{
    public partial class Form1 : Form
    {
        Socket client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(textBox1.Text);
                IPEndPoint point = new IPEndPoint(ip, int.Parse(textBox2.Text));
                client.Connect(point);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
                MessageBox.Show(ex.Message);
                return;
                //throw;
            }
            //MessageBox.Show("connect success");
            toolStripStatusLabel1.Text = "connect success";
        }

        private void send(String text)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                client.Send(buffer);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
                return;
                // throw;
            }
            toolStripStatusLabel1.Text = "[" + text + "] send success";
            return;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            send("stop");
        }
        //接受服务端发送来的消息
        
        private void recvmsgs(Socket client)
        {
            try
            {
                byte[] buffer = new byte[1024 * 1024];
                int size = client.Receive(buffer);
                String recv = Encoding.UTF8.GetString(buffer, 0, size);
                toolStripStatusLabel1.Text = "\n" + recv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnFront_MouseDown(object sender, MouseEventArgs e)
        {
            //send("front");
        }

        private void btnFront_MouseUp(object sender, MouseEventArgs e)
        {
            //send("stop");
        }

        private void btnBack_MouseDown(object sender, MouseEventArgs e)
        {
            //send("back");
        }

        private void btnBack_MouseUp(object sender, MouseEventArgs e)
        {
            //send("stop");
        }

        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            //send("left");
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            //send("stop");
        }

        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            //send("right");
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            //send("stop");
        }

        private void btnFront_Click(object sender, EventArgs e)
        {
            send("front");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            send("back");
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            send("left");
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            send("right");
        }
    }
}
