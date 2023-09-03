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
    public partial class PkgLabelPrint_Main : Form
    {
        public PkgLabelPrint_Main()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                PkgLabelPrint_157 Form_157 = new PkgLabelPrint_157();
                Form_157.ShowDialog();
                //this.Hide();

            };

            if (radioButton2.Checked)
            {

                PkgLabelPrint_154 Form_154 = new PkgLabelPrint_154();
                Form_154.ShowDialog();
                //this.Hide();
            }

            if (radioButton3.Checked)
            {
                PkgLabelPrint_158 Form_158 = new PkgLabelPrint_158();
                Form_158.Show();
                //this.Hide();

            };

            if (radioButton4.Checked)
            {
                PkgLabelPrint_156 Form_156 = new PkgLabelPrint_156();
                Form_156.ShowDialog();
                //this.Hide();


            }

            if (radioButton5.Checked)
            {
                PkgLabelPrint_159 Form_159 = new PkgLabelPrint_159();
                Form_159.ShowDialog();
                //this.Hide();

            };

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
