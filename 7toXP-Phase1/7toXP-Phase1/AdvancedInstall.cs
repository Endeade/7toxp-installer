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

namespace _7toXP_Phase1
{
    public partial class AdvancedInstall : Form
    {
        public AdvancedInstall()
        {
            InitializeComponent();
            fullpatching();
        }
        private void AdvancedInstall_Load(object sender, EventArgs e)
        {
            
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
                client.DownloadFile("https://github.com/Endeade/7toxp-installer/raw/main/7toXP-Phase2/7toXP-Phase2/bin/Debug/7toXP-Phase2.exe", "C:\\Windows\\7toxp\\patcher.exe");
                string osarch = System.Runtime.InteropServices.RuntimeInformation.OSArchitecture.ToString();
                if (osarch == "X64")
                {
                    client.DownloadFile("https://github.com/Endeade/7toxp-fullpack/raw/main/ico64.zip", "C:\\Windows\\7toxp\\ico64.zip");
                    ZipFile.ExtractToDirectory("C:\\Windows\\7toxp\\ico64.zip", "C:\\Windows\\7toxp\\ico\\");
                    
                } else if (osarch == "X86")
                {
                    client.DownloadFile("https://github.com/Endeade/7toxp-fullpack/raw/main/ico32.zip", "C:\\Windows\\7toxp\\ico32.zip");
                    ZipFile.ExtractToDirectory("C:\\Windows\\7toxp\\ico32.zip", "C:\\Windows\\7toxp\\ico\\");
                }
            }
            Directory.CreateDirectory("C:\\Windows\\7toxp\\backup");
            File.Copy("C:\\Windows\\system32\\shell32.dll", "C:\\Windows\\7toxp\\backup\\shell32.dll");
            File.Copy("C:\\Windows\\system32\\imageres.dll", "C:\\Windows\\7toxp\\backup\\imageres.dll");
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
            RegistryKey SetupKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\Setup", true);
            if (SetupKey != null)
            {
                SetupKey.SetValue("CmdLine", "C:\\Windows\\7toxp\\patcher.exe", RegistryValueKind.String);
                SetupKey.SetValue("OOBEInProgress", 0x0000001, RegistryValueKind.DWord);
                SetupKey.SetValue("RestartSetup", 0x0000001, RegistryValueKind.DWord);
                SetupKey.SetValue("SetupPhase", 0x0000001, RegistryValueKind.DWord);
                SetupKey.SetValue("SetupType", 0x0000001, RegistryValueKind.DWord);
                SetupKey.Close();
                SetupKey.Flush();
            }
            AdvancedRestart AdvancedRestart = new AdvancedRestart();
            this.Hide();
            AdvancedRestart.ShowDialog();
        }


    }
}
