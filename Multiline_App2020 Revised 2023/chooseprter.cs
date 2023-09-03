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
    public partial class chooseprter : Form
    {
        public chooseprter()
        {
            InitializeComponent();
            soq = MainMenu.soq;
        }

        public static string printer = "";
        public static string pname = "";
        public static string soq = "";
    
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && radioButton2.Checked == false && radioButton4.Checked == false && radioButton5.Checked == false && radioButton3.Checked == false)
            {
                printer = "Martis";
                pname = "Datamax I-4208_157";
            }
            else if (radioButton2.Checked == true && radioButton1.Checked == false && radioButton4.Checked == false && radioButton5.Checked == false && radioButton3.Checked == false)
            {
                printer = "Dylan";
                pname = "Datamax I-4208_158";
            }
            else if (radioButton4.Checked == true && radioButton1.Checked == false && radioButton2.Checked == false && radioButton5.Checked == false && radioButton3.Checked == false)
            {
                printer = "Matthew";
                pname = "Datamax I-4208_156";
            }
            else if (radioButton5.Checked == true && radioButton1.Checked == false && radioButton4.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                printer = "Jonathan";
                pname = "Datamax I-4208_159";
            }
            else if (radioButton3.Checked == true && radioButton1.Checked == false && radioButton4.Checked == false && radioButton2.Checked == false && radioButton5.Checked == false)
            {
                printer = "new";
                pname = "Datamax I-4310e MarkII_154";
            }
            else
            {
                return;
            }
            if (MainMenu.soq == "single")
            {
                printertest pi = new printertest();
                pi.ShowDialog();
            }
            else if (MainMenu.soq == "OorQ")
            {
                orderprint op = new orderprint();
                op.ShowDialog();
            }
            else if (MainMenu.soq == "tlp")
            {
                typedlstprint tp = new typedlstprint();
                tp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Something Went Wrong!");
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
