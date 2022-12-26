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

namespace _7toXP_Phase1
{
    public partial class Base1 : Form
    {
        public Base1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Base1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("%windir%\\7toxp");
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 50;
            using (var client = new WebClient())
            {
                client.DownloadFile("https://github.com/Endeade/7toxp-basepack/raw/main/ThemePatcher.exe", "%windir%\\7toxp\\themepatcher.exe");
                client.DownloadFile("https://github.com/Endeade/7toxp-basepack/raw/main/luna-theme.zip", "%windir%\\7toxp\\luna-theme.zip");
            }
            progressBar1.Value = 75;
            ZipFile.ExtractToDirectory("%windir%\\7toxp\\luna-theme.zip", "%windir%\\7toxp\\");
            progressBar1.Value = 80;
            Process.Start("%windir%\\7toxp\\themepatcher.exe");
            progressBar1.Value = 90;
            Directory.CreateDirectory("%windir%\\Resources\\Themes\\Luna");
            Directory.CreateDirectory("%windir%\\Resources\\Themes\\Luna\\en-US");
            Directory.CreateDirectory("%windir%\\Resources\\Themes\\Luna\\Shell");
            Directory.CreateDirectory("%windir%\\Resources\\Themes\\Luna\\Shell\\NormalColor");
            Directory.CreateDirectory("%windir%\\Resources\\Themes\\Luna\\Shell\\NormalColor\\en-US");
            progressBar1.Value = 95;
            File.Copy("%windir%\\7toxp\\luna-theme\\Luna\\en-US\\luna.msstyles.mui", "%windir%\\Resources\\Themes\\Luna\\en-US\\luna.msstyles.mui");
            File.Copy("%windir%\\7toxp\\luna-theme\\Luna\\Shell\\NormalColor\\shellstyle.dll", "%windir%\\Resources\\Themes\\Luna\\Shell\\NormalColor\\shellstyle.dll");
            File.Copy("%windir%\\7toxp\\luna-theme\\Luna\\Shell\\NormalColor\\en-US\\shellstyle.dll.mui", "%windir%\\Resources\\Themes\\Luna\\Shell\\NormalColor\\en-US\\shellstyle.dll.mui");
            File.Copy("%windir%\\7toxp\\luna-theme\\Luna\\blisshd.jpg", "%windir%\\Resources\\Themes\\Luna\\blisshd.jpg");
            File.Copy("%windir%\\7toxp\\luna-theme\\Luna\\Luna.msstyles", "%windir%\\Resources\\Themes\\Luna\\Luna.msstyles");
            File.Copy("%windir%\\7toxp\\luna-theme\\Luna\\Thumbs.db", "%windir%\\Resources\\Themes\\Luna\\Thumbs.db");
            File.Copy("%windir%\\7toxp\\luna-theme\\Luna.theme", "%windir%\\Resources\\Themes\\Luna.theme");
            progressBar1.Value = 100;

        }
    }
}
