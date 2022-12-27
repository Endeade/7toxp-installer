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
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Base1 Base1 = new Base1();
            this.Hide();
            Base1.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            AdvancedInstall AdvancedInstall = new AdvancedInstall();
            this.Hide();
            AdvancedInstall.ShowDialog();
        }
    }
}
