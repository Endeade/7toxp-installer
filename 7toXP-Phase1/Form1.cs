using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Environment;
using Microsoft.Win32;
using System.Runtime;
using System.Threading;
using KPreisser.UI;

namespace _7toXP_Phase1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox1.AutoCheck = false;
            checkBox2.AutoCheck = false;
            checkBox3.AutoCheck = false;
            checkBox4.AutoCheck = false;
            checkBox5.AutoCheck = false;
            Console.Write(Directory.Exists("C:\\Windows\\7toxp"));
            if (Directory.Exists("C:\\Windows\\7toxp"))
            {
                Process.Start("cmd", "/c rd C:\\Windows\\7toxp /s /q");
            }
            
            Directory.CreateDirectory("C:\\Windows\\7toxp");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (var client = new WebClient())
            {
                client.DownloadFile("https://github.com/Endeade/7toxp-installer/raw/main/packs/base/ThemePatcher.exe", "C:\\Windows\\7toxp\\themepatcher.exe");
                client.DownloadFile("https://github.com/Endeade/7toxp-installer/raw/main/packs/base/luna-theme.zip", "C:\\Windows\\7toxp\\luna-theme.zip");
                client.DownloadFile("https://github.com/Endeade/7toxp-installer/raw/main/7toXP-Phase2/bin/Release/7toXP-Phase2.exe", "C:\\Windows\\7toxp\\patcher.exe");
                client.DownloadFile("https://github.com/Endeade/7toxp-installer/raw/main/packs/advanced/iconpack.exe", "C:\\Windows\\7toxp\\iconpack.exe");
            }
        }
        
        private void button1_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Choosing this option will install the 7toXP TP";
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Choosing this option will uninstall the 7toXP TP";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InstallPage1 InstallPage1 = new InstallPage1();
            Hide();
            InstallPage1.ShowDialog();
        }
    }
}
