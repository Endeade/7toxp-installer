using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace _7toXP_Phase2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            patching();
        }

        private void patching()
        {
            Process.Start("C:\\Windows\\7toxp\\iconpack.exe");
            label1.Text = "Please use the patcher that opened to apply icons, after icons are applied, click on the button.";
            RegistryKey SetupKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\Setup", true);
            if (SetupKey != null)
            {
                SetupKey.SetValue("CmdLine", "cmd.exe", RegistryValueKind.String);
                SetupKey.SetValue("OOBEInProgress", 0x0000000, RegistryValueKind.DWord);
                SetupKey.SetValue("RestartSetup", 0x0000000, RegistryValueKind.DWord);
                SetupKey.SetValue("SetupPhase", 0x0000000, RegistryValueKind.DWord);
                SetupKey.SetValue("SetupType", 0x0000000, RegistryValueKind.DWord);
                SetupKey.Close();
                SetupKey.Flush();
            }

            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown.exe", "-r -t 0");
        }
    }
}
