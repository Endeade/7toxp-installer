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

namespace _7toXP_Phase1
{
    public partial class AdvancedInstall : Form
    {
        public AdvancedInstall()
        {
            InitializeComponent();
        }
        private void AdvancedInstall_Load(object sender, EventArgs e)
        {
            fullpatching();
        }

        private void fullpatching()
        {
            Directory.CreateDirectory("C:\\Windows\\7toxp");
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 25;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (var client = new WebClient())
            {
                client.DownloadFile("https://github.com/Endeade/7toxp-basepack/raw/main/ThemePatcher.exe", "C:\\Windows\\7toxp\\themepatcher.exe");
                client.DownloadFile("https://github.com/Endeade/7toxp-basepack/raw/main/luna-theme.zip", "C:\\Windows\\7toxp\\luna-theme.zip");
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
            AdvancedRestart AdvancedRestart = new AdvancedRestart();
            this.Hide();
            AdvancedRestart.ShowDialog();
        }


    }
}
