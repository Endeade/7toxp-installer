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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox1.AutoCheck = false;
            checkBox2.AutoCheck = false;
            checkBox3.AutoCheck = false;
            checkBox4.AutoCheck = false;
            checkBox5.AutoCheck = false;

        }
        
        private void button1_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Choosing this option will install the 7toXP TP";
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Choosing this option will uninstall the 7toXP TP";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InstallPage1 InstallPage1 = new InstallPage1();
            Hide();
            InstallPage1.ShowDialog();
        }
    }
}
