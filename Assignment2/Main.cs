using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Main : Form
    {
        private static string canID = "";

        public Main()
        {
            InitializeComponent();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            canID = txtCanNo.Text;
            Form1 form1 = new Form1();
            Hide();
            form1.Show();
        }

        public string getCanID()
        {
            return canID;
        }
    }
}
