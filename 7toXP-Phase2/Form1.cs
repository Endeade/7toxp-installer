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
            Process.Start("C:\\Windows\\7toxp\\rh.exe", "-open C:\\Windows\\7toxp\\backup\\shell32.dll -save C:\\Windows\\system32\\shell32.dll -resource C:\\Windows\\7toxp\\IcGr1.res -action addoverwrite -log NUL -mask ICONGROUP,1,");
            label1.Text = "Patching complete, rebooting...";
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
            Process.Start("shutdown.exe", "-r -t 0");

        }
    }
}
