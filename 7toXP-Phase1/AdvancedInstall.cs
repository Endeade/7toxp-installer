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
            InitializeComponent();
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox1.AutoCheck = false;
            checkBox2.AutoCheck = false;
            checkBox3.AutoCheck = false;
            checkBox4.AutoCheck = false;
            checkBox5.AutoCheck = false;
        }

        private void fullpatching()
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 25;
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
                if (Environment.OSVersion.Version.Build < 7600 || Environment.OSVersion.Version.Build > 7601)
                {
                    SetupKey.SetValue("CmdLine", "C:\\Windows\\7toxp\\patcher.exe", RegistryValueKind.String);
                    SetupKey.SetValue("OOBEInProgress", 0x0000001, RegistryValueKind.DWord);
                    SetupKey.SetValue("RestartSetup", 0x0000001, RegistryValueKind.DWord);
                    SetupKey.SetValue("SetupPhase", 0x0000001, RegistryValueKind.DWord);
                    SetupKey.SetValue("SetupType", 0x0000001, RegistryValueKind.DWord);
                    SetupKey.Close();
                    SetupKey.Flush();
                }
                else
                {
                    SetupKey.SetValue("CmdLine", "C:\\Windows\\7toxp\\patcher.exe -allow", RegistryValueKind.String);
                    SetupKey.SetValue("OOBEInProgress", 0x0000001, RegistryValueKind.DWord);
                    SetupKey.SetValue("RestartSetup", 0x0000001, RegistryValueKind.DWord);
                    SetupKey.SetValue("SetupPhase", 0x0000001, RegistryValueKind.DWord);
                    SetupKey.SetValue("SetupType", 0x0000001, RegistryValueKind.DWord);
                    SetupKey.Close();
                    SetupKey.Flush();
                }
            }
            AdvancedRestart AdvancedRestart = new AdvancedRestart();
            this.Hide();
            AdvancedRestart.ShowDialog();
        }
    }
}
