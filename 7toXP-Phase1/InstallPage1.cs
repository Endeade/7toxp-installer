using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7toXP_Phase1
{
    public partial class InstallPage1 : Form
    {
        public InstallPage1()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox1.AutoCheck = false;
            checkBox2.AutoCheck = false;
            checkBox3.AutoCheck = false;
            checkBox4.AutoCheck = false;
            checkBox5.AutoCheck = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Base1 Base1 = new Base1();
            Hide();
            Base1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdvancedInstall AdvancedInstall = new AdvancedInstall();
            Hide();
            AdvancedInstall.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
