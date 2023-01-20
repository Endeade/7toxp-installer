using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7toXP_Phase1
{
    public partial class AdvancedRestart : Form
    {
        public AdvancedRestart()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown.exe", "-r -t 0");
        }
    }
}
