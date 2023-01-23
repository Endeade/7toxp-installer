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

namespace _7toXP_Phase1
{
    internal static class Program
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
					Directory.Delete("C:\\Windows\\7toxp");
					Directory.CreateDirectory("C:\\Windows\\7toxp");
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
					using (var client = new WebClient())
					{
						client.DownloadFile("https://github.com/Endeade/7toxp-installer/raw/main/packs/base/ThemePatcher.exe", "C:\\Windows\\7toxp\\themepatcher.exe");
						client.DownloadFile("https://github.com/Endeade/7toxp-installer/raw/main/packs/base/luna-theme.zip", "C:\\Windows\\7toxp\\luna-theme.zip");
						client.DownloadFile("https://github.com/Endeade/7toxp-installer/raw/main/7toXP-Phase2/bin/Release/7toXP-Phase2.exe", "C:\\Windows\\7toxp\\patcher.exe");
						client.DownloadFile("https://github.com/Endeade/7toxp-installer/raw/main/packs/base/luna-theme.zip", "C:\\Windows\\7toxp\\rh.exe");
					}
					Application.Run(new Form1());
				}
				else
				{
					TaskDialog.Show(text: "You must be running atleast Windows 7 build 7600 or 7601 in order to install 7toXP TP.",
					instruction: "Compatibility error",
					title: "7toXP Setup",
					buttons: TaskDialogButtons.OK,
					icon: TaskDialogStandardIcon.SecurityErrorRedBar);
					return;
				}
			}
		}
    }
}
