﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            File.Copy("C:\\Windows\\7toxp\\ico\\shell32.dll", "C:\\Windows\\system32\\shell32.dll");
            File.Copy("C:\\Windows\\7toxp\\ico\\imageres.dll", "C:\\Windows\\system32\\imageres.dll");
            label1.Text = "Patching complete, rebooting...";
            RegistryKey SetupKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\Setup", true);
            if (SetupKey != null)
            {
                SetupKey.SetValue("CmdLine", null, RegistryValueKind.String);
                SetupKey.SetValue("OOBEInProgress", "0'", RegistryValueKind.DWord);
                SetupKey.SetValue("SetupPhase", "0", RegistryValueKind.DWord);
                SetupKey.SetValue("SetupSupported", "1", RegistryValueKind.DWord);
                SetupKey.SetValue("SetupType", "0", RegistryValueKind.DWord);
                SetupKey.SetValue("SystemSetupInProgress", "0", RegistryValueKind.DWord);
                SetupKey.Close();
                SetupKey.Flush();
            }
            Process.Start("shutdown.exe", "-r -t 0");

        }
    }
}
