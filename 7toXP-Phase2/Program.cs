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

namespace _7toXP_Phase2
{
    static class Program
    {
        
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Environment.OSVersion.Version.Build < 7600 || Environment.OSVersion.Version.Build > 7601)
            {
                if (args.Length != 0 && args[0].ToLower() == "-allow")
                {
                    Application.Run(new Form1());
                }
                else
                {
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
                    TaskDialog.Show(text: "You must be running at least Windows 10 build 21343 or higher in order to install Rectify11.",
                    instruction: "Compatibility Error",
                    title: "Rectify11 Setup",
                    buttons: TaskDialogButtons.OK,
                    icon: TaskDialogStandardIcon.SecurityErrorRedBar);
                    return;
                }
            }
        }
         
    }
}
