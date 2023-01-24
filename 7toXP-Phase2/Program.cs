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
                    TaskDialog.Show(text: "You must be running atleast Windows 7 build 7600 or 7601 in order to install 7toXP TP. Setup will now revert the registry changes, your OS may not be fully transformed.",
                    instruction: "Compatibility error",
                    title: "7toXP Setup",
                    buttons: TaskDialogButtons.OK,
                    icon: TaskDialogStandardIcon.SecurityErrorRedBar);
                    Process.Start("shutdown.exe", "-r -t 0");
                    return;
                }
            }
        }
         
    }
}
