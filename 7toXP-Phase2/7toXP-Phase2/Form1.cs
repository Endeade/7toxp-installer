﻿using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            Process.Start("C:\\Windows\\system32\\cmd.exe");
            label1.Text = "Please type \"shutdown -r -t 0\" into \nthe command prompt";
        }
    }
}