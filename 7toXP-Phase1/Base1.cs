using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Runtime.InteropServices;

namespace _7toXP_Phase1
{
    public partial class Base1 : Form
    {
        public Base1()
        {
            InitializeComponent();
        }

        
        private void Base1_Load(object sender, EventArgs e)
        {
            basepatching();
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox1.AutoCheck = false;
            checkBox2.AutoCheck = false;
            checkBox3.AutoCheck = false;
            checkBox4.AutoCheck = false;
            checkBox5.AutoCheck = false;
        }

        private void basepatching()
        {
            Directory.CreateDirectory("C:\\Windows\\7toxp");
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 25;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (var client = new WebClient())
            {
                client.DownloadFile("https://github.com/Endeade/7toxp-installer/raw/main/packs/base/ThemePatcher.exe", "C:\\Windows\\7toxp\\themepatcher.exe");
                client.DownloadFile("https://github.com/Endeade/7toxp-installer/raw/main/packs/base/luna-theme.zip", "C:\\Windows\\7toxp\\luna-theme.zip");
            }
            progressBar1.Value = 50;
            ZipFile.ExtractToDirectory("C:\\Windows\\7toxp\\luna-theme.zip", "C:\\Windows\\7toxp\\");
            progressBar1.Value = 70;
            Process.Start("C:\\Windows\\7toxp\\themepatcher.exe");
            progressBar1.Value = 80;
            Directory.CreateDirectory("C:\\Windows\\Resources\\Themes\\Luna");
            Directory.CreateDirectory("C:\\Windows\\Resources\\Themes\\Luna\\en-US");
            Directory.CreateDirectory("C:\\Windows\\Resources\\Themes\\Luna\\Shell");
            Directory.CreateDirectory("C:\\Windows\\Resources\\Themes\\Luna\\Shell\\NormalColor");
            Directory.CreateDirectory("C:\\Windows\\Resources\\Themes\\Luna\\Shell\\NormalColor\\en-US");
            progressBar1.Value = 90;
            File.Copy("C:\\Windows\\7toxp\\luna-theme\\Luna\\en-US\\luna.msstyles.mui", "C:\\Windows\\Resources\\Themes\\Luna\\en-US\\luna.msstyles.mui");
            File.Copy("C:\\Windows\\7toxp\\luna-theme\\Luna\\Shell\\NormalColor\\shellstyle.dll", "C:\\Windows\\Resources\\Themes\\Luna\\Shell\\NormalColor\\shellstyle.dll");
            File.Copy("C:\\Windows\\7toxp\\luna-theme\\Luna\\Shell\\NormalColor\\en-US\\shellstyle.dll.mui", "C:\\Windows\\Resources\\Themes\\Luna\\Shell\\NormalColor\\en-US\\shellstyle.dll.mui");
            File.Copy("C:\\Windows\\7toxp\\luna-theme\\Luna\\blisshd.jpg", "C:\\Windows\\Resources\\Themes\\Luna\\blisshd.jpg");
            File.Copy("C:\\Windows\\7toxp\\luna-theme\\Luna\\Luna.msstyles", "C:\\Windows\\Resources\\Themes\\Luna\\Luna.msstyles");
            File.Copy("C:\\Windows\\7toxp\\luna-theme\\Luna\\Thumbs.db", "C:\\Windows\\Resources\\Themes\\Luna\\Thumbs.db");
            File.Copy("C:\\Windows\\7toxp\\luna-theme\\Luna.theme", "C:\\Windows\\Resources\\Themes\\Luna.theme");
            progressBar1.Value = 100;
            Process.Start("C:\\Windows\\Resources\\Themes\\Luna.theme");
            BaseRestart BaseRestart = new BaseRestart();
            this.Hide();
            BaseRestart.ShowDialog();
        }
        
        
    }
}
