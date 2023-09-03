using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Drawing.Printing;

namespace Multiline_App2020_Revised_2023
{
    public partial class typedlstprint : Form
    {
        public typedlstprint()
        {
            InitializeComponent();
        }

        public static class MyPrinters
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img;
            //Image img1;
            //Image img2;
            string pname = chooseprter.pname;
            MyPrinters.SetDefaultPrinter(pname);
            PrintDocument pd = new PrintDocument();
            int index = 0, count = 0;

            List<int> list1 = new List<int>();

            for (int k = 0; k < dataGridView1.Rows.Count -1 ; k ++)
            {
                int number3;
                //int number4;
                if (dataGridView1.Rows[k].Cells[1].Value == null)
                {
                    MessageBox.Show("Part Number can not be empty,Please input again!");
                    dataGridView1.Rows[k].Cells[1].Value = "";
                    return;
                }
                if (dataGridView1.Rows[k].Cells[0].Value == null)
                {
                    MessageBox.Show("Qty to Print can not be empty!");
                    dataGridView1.Rows[k].Cells[0].Value = "";
                    return;
                }
                else if (int.TryParse(dataGridView1.Rows[k].Cells[0].Value.ToString(), out number3) == false)
                {
                    MessageBox.Show("Qty to Print must be numeric,Please input again!");
                    dataGridView1.Rows[k].Cells[0].Value = "";
                    return;
                }
                //if (dataGridView1.Rows[k].Cells[2].Value == null)
                //{
                //    MessageBox.Show("The Unit Qty Can not be empty!");
                //    dataGridView1.Rows[k].Cells[2].Value = "";
                //    return;
                //}
                //else if (int.TryParse(dataGridView1.Rows[k].Cells[2].Value.ToString(), out number4) == false)
                //{
                //    MessageBox.Show("The Unit Qty must be numeric,Please input again!");
                //    dataGridView1.Rows[k].Cells[2].Value = "";
                //    return;
                //}

                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

                string id = dataGridView1.Rows[k].Cells[1].Value.ToString();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    string query1 = "SELECT TOP 1 1 FROM [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.product_lookup WHERE prlkp_prod_id = ('" + id + "')";

                    SqlCommand cncmd1 = new SqlCommand(query1, conn);

                    if (cncmd1.ExecuteScalar() == null)
                    {
                        MessageBox.Show("Id does not exist please try again");
                        dataGridView1.Rows[k].Cells[1].Value = "";
                        return;
                    }
                    conn.Close();
                }
            }


            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.ToString() != "0")
                {
                    for (int j = 0; j < int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()); j++)
                    {
                        list1.Add(i);
                    }
                }
            }

            pd.BeginPrint += (s, ev) =>
            {
                // find page count from form label
                count = list1.Count;
            };
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{

            //}

            pd.PrintPage += (s, ev) =>
            {
                string size = "";
                string desc = "";
                string desc1 = "";
                string desc2 = "";
                //string loc = "";
                string[] descar;
                int fh;

                //string dqty = dataGridView1.Rows[list1[index]].Cells[0].Value.ToString();

                string id = dataGridView1.Rows[list1[index]].Cells[1].Value.ToString().ToUpper();

                //string uqty = dataGridView1.Rows[list1[index]].Cells[2].Value.ToString();

                //string ponum = dataGridView1.Rows[list1[index]].Cells[3].Value.ToString();

                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    string query1 = "SELECT TOP 1 1 FROM [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.product_lookup WHERE prlkp_prod_id = ('" + id + "')";

                    string query2 = "select prlkp_lang1_2_desc from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.product_lookup where prlkp_prod_id = ('" + id + "')";

                    string query3 = "select prlkp_lang1_1_desc from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.product_lookup where prlkp_prod_id = ('" + id + "')";

                    SqlCommand cncmd2 = new SqlCommand(query2, con);
                    size = (string)cncmd2.ExecuteScalar();
                    SqlCommand cncmd3 = new SqlCommand(query3, con);
                    desc = (string)cncmd3.ExecuteScalar();
                    descar = desc.Split(' ');

                    fh = descar.Length / 2;
                    for (int i = 0; i < fh; i++)
                    {
                        desc1 += descar[i];
                    }
                    for (int j = fh; j < descar.Length; j++)
                    {
                        desc2 += descar[j];
                    }
                    
                    con.Close();
                }

                // for each page
                index++;
                if (radioButton1.Checked == true && radioButton2.Checked == false)
                {
                    BarcodeWriter barcode = new BarcodeWriter()
                    {
                        Format = BarcodeFormat.CODE_128
                    };
                    //pictureBox1.Image = barcode.Write(id);
                    img = barcode.Write(id);

                    ev.Graphics.DrawString("PART NO", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(7, 60));
                    var stringsize1 = ev.Graphics.MeasureString(id, new Font("Franklin Gothic Medium", 20));
                    ev.Graphics.DrawString(id, new Font("Franklin Gothic Medium", 20), Brushes.Black, new PointF((250 - stringsize1.Width) / 2.0f, 60));
                    //ev.Graphics.DrawString(textBox2.Text, new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new PointF(40, 60));
                    ev.Graphics.DrawImage(img, 40, 90, 180, 30);
                    ev.Graphics.DrawString("SIZE:---------------------------------------------------------", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(10, 110));
                    var stringsize2 = ev.Graphics.MeasureString(size, new Font("Franklin Gothic Medium", 16, FontStyle.Bold));
                    ev.Graphics.DrawString(size, new Font("Franklin Gothic Medium", 16, FontStyle.Bold), Brushes.Black, new PointF((250 - stringsize2.Width) / 2.0f, 125));
                    //ev.Graphics.DrawString("M12X1.25X35", new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new PointF(40, 115));
                    ev.Graphics.DrawString("DESC:--------------------------------------------------------", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(10, 145));
                    var stringsize3 = ev.Graphics.MeasureString(desc1, new Font("Franklin Gothic Medium", 15, FontStyle.Bold));
                    ev.Graphics.DrawString(desc1, new Font("Franklin Gothic Medium", 15, FontStyle.Bold), Brushes.Black, new PointF((250 - stringsize3.Width) / 2.0f, 155));
                    //ev.Graphics.DrawString("METRIC JIS FLANGE", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(10, 145));
                    var stringsize4 = ev.Graphics.MeasureString(desc2, new Font("Franklin Gothic Medium", 15, FontStyle.Bold));
                    ev.Graphics.DrawString(desc2, new Font("Franklin Gothic Medium", 15, FontStyle.Bold), Brushes.Black, new PointF((250 - stringsize4.Width) / 2.0f, 180));
                    //ev.Graphics.DrawString("BOLTS 8.8 ZI", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(40, 165));
                }
                else if (radioButton2.Checked == true && radioButton1.Checked == false)
                {
                    BarcodeWriter barcode = new BarcodeWriter()
                    {
                        Format = BarcodeFormat.CODE_128
                    };
                    img = barcode.Write(id);

                    var stringsize1 = ev.Graphics.MeasureString(id, new Font("Franklin Gothic Medium", 18));
                    ev.Graphics.DrawString(id, new Font("Franklin Gothic Medium", 18), Brushes.Black, new PointF((300 - stringsize1.Width) / 2.0f, 10));
                    ev.Graphics.DrawImage(img, 50, 35, 200, 25);
                    var stringsize2 = ev.Graphics.MeasureString(size, new Font("Franklin Gothic Medium", 12, FontStyle.Bold));
                    ev.Graphics.DrawString(size, new Font("Franklin Gothic Medium", 12, FontStyle.Bold), Brushes.Black, new PointF((300 - stringsize2.Width) / 2.0f, 60));
                    var stringsize3 = ev.Graphics.MeasureString(desc, new Font("Franklin Gothic Medium", 11, FontStyle.Bold));
                    ev.Graphics.DrawString(desc, new Font("Franklin Gothic Medium", 11, FontStyle.Bold), Brushes.Black, new PointF((300 - stringsize3.Width) / 2.0f, 78));
                }
                else
                {
                    MessageBox.Show("Please choose only one label format to continue!");
                    return;
                }


                // check for final page
                ev.HasMorePages = index < count;

            };

            pd.EndPrint += (s, ev) =>
            {
                // reset count and index
                index = 0;
                count = 0;
            };
            if (radioButton1.Checked == true && radioButton2.Checked == false)
            {
                PaperSize paper = new PaperSize("MyCustomSize", 250, 250);
                paper.RawKind = (int)PaperKind.Custom;
                // set paper size
                pd.DefaultPageSettings.PaperSize = paper;
                // set paper margins appropriately
                //pd.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

                // call up the print preview dialog to see results
                PrintPreviewDialog dlg = new PrintPreviewDialog();

                dlg.Document = pd;
                dlg.ShowDialog();
            }
            else if (radioButton2.Checked == true && radioButton1.Checked == false)
            {
                PaperSize paper = new PaperSize("MyCustomSize", 300, 100);
                paper.RawKind = (int)PaperKind.Custom;
                // set paper size
                pd.DefaultPageSettings.PaperSize = paper;
                // set paper margins appropriately
                //pd.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

                // call up the print preview dialog to see results
                PrintPreviewDialog dlg = new PrintPreviewDialog();

                dlg.Document = pd;
                dlg.ShowDialog();
            }
        }
    }
}
