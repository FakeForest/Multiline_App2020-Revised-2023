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
    public partial class ChangePrintQty : Form
    {
        public ChangePrintQty()
        {
            InitializeComponent();
        }

        public string qty = "";
        

        private void button1_Click(object sender, EventArgs e)
        {
            int number2 = 0;
            if (int.TryParse(textBox1.Text, out number2) == false && number2 > 0) 
            {
                MessageBox.Show("You have to input a positive integer! \n Please try again!");
            }
            qty = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
