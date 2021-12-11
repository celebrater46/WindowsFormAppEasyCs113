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

namespace WindowsFormsAppEasyCs113
{
    public partial class Form1 : Form
    {
        public static string HOST = "localhost";
        public static int PORT = 10000;

        public Form1()
        { 
            InitializeComponent();
            IPHostEntry ih = Dns.GetHostEntry(HOST);

            TcpListener tl = new TcpListener(ih.AddressList[0], PORT);
            tl.Start();
            
            Console.WriteLine("Waiting...");
            while (true)
            {
                TcpClient tc = tl.AcceptTcpClient();
                StreamWriter sw = new StreamWriter(tc.GetStream());
                sw.WriteLine("I am the server.");

                sw.Flush();
                sw.Close();
                tc.Close();
                break;
            }
        }
    }
}