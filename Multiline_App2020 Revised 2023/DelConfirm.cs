using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiline_App2020_Revised_2023
{
    public partial class DelConfirm : Form
    {
        public DelConfirm()
        {
            InitializeComponent();
        }

        public static string yon = "";

        private void button1_Click(object sender, EventArgs e)
        {
            yon = "yes";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
