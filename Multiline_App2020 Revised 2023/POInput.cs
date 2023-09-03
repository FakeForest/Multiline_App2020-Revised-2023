using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;



namespace Multiline_App2020_Revised_2023

{


    public partial class POInput : Form
    {
        public POInput()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Test Empty String in txtPO
            if (string.IsNullOrEmpty(txtPO.Text))
            {
                MessageBox.Show("Please enter a PO Number");
                txtPO.Focus();
                return;
            }

            //Test string in txtPO is numeric

            int num = -1;
            if (!int.TryParse(txtPO.Text, out num))
            {
                MessageBox.Show("PO number must be numeric, please input again");
                txtPO.Clear();
                txtPO.Focus();
                return;
            }

            //Open POInputResult form, passing txtPO.Text as parameter
            POInputResult fmPOInputResult = new POInputResult(txtPO.Text);
            fmPOInputResult.Visible = true;



        }
    }
}
