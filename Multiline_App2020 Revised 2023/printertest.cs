using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Configuration;
using ZXing;

namespace Multiline_App2020_Revised_2023
{
    public partial class printertest : Form
    {
        public printertest()
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
            string pname = chooseprter.pname;
            MyPrinters.SetDefaultPrinter(pname);
            PrintDocument pd = new PrintDocument();
            int number3;
            int number4;
            int index = 0, count = 0;
            if (textBox2.Text == "") 
            {
                MessageBox.Show("Part Number can not be empty,Please input again!");
                textBox2.Text = "";
                textBox2.Focus();
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Qty to Print can not be empty!");
                textBox1.Text = "";
                textBox1.Focus();
                return;
            }
            else if (int.TryParse(textBox1.Text, out number3) == false)
            {
                MessageBox.Show("Qty to Print must be numeric,Please input again!");
                textBox1.Text = "";
                textBox1.Focus();
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("The Unit Qty Can not be empty!");
                textBox4.Text = "";
                textBox4.Focus();
                return;
            }
            else if (int.TryParse(textBox4.Text, out number4) == false)
            {
                MessageBox.Show("The Unit Qty must be numeric,Please input again!");
                textBox4.Text = "";
                textBox4.Focus();
                return;
            }

            string desc1 = "";
            string desc2 = "";
            string size = "";
            string loc = "";
            string desc = "";

            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            string id = textBox2.Text.ToUpper();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                string query1 = "SELECT TOP 1 1 FROM [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.product_lookup WHERE prlkp_prod_id = ('" + id + "')";

                string query2 = "select prlkp_lang1_2_desc from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.product_lookup where prlkp_prod_id = ('" + id + "')";

                string query3 = "select prlkp_lang1_1_desc from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.product_lookup where prlkp_prod_id = ('" + id + "')";

                string query4 = "select pw_bin_location1 from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.prod_warehouse where pw_prod_id = ('" + id + "')";

                string query5 = "select pw_bin_location2 from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.prod_warehouse where pw_prod_id = ('" + id + "')";

                SqlCommand cncmd1 = new SqlCommand(query1, conn);

                if (cncmd1.ExecuteScalar() == null)
                {
                    MessageBox.Show("Id does not exist please try again");
                    textBox2.Text = "";
                    textBox2.Focus();
                    return;
                }
                else
                {
                    string cn = cncmd1.ExecuteScalar().ToString();
                    SqlCommand cncmd2 = new SqlCommand(query2, conn);
                    size = (string)cncmd2.ExecuteScalar();
                    SqlCommand cncmd3 = new SqlCommand(query3, conn);
                    desc = (string)cncmd3.ExecuteScalar();
                    string[] descar = desc.Split(' ');
                    SqlCommand cncmd4 = new SqlCommand(query4, conn);
                    string loc1 = (string)cncmd4.ExecuteScalar();
                    SqlCommand cncmd5 = new SqlCommand(query5, conn);
                    string loc2 = (string)cncmd5.ExecuteScalar();
                    loc = loc1 + " " + loc2;

                    int fh = descar.Length / 2;
                    for (int i = 0; i < fh; i++)
                    {
                        desc1 += descar[i];
                    }
                    for (int j = fh; j < descar.Length; j++)
                    {
                        desc2 += descar[j];
                    }
                }
                conn.Close();
            }

            pd.BeginPrint += (s, ev) =>
            {
                // find page count from form label
                count = int.Parse(textBox1.Text);
            };
            pd.PrintPage += (s, ev) =>
            {
                
                // for each page
                index++;
                //// get form size
                //var size = this.Size;
                //// create bitmap of same size
                //var bmp = new Bitmap(size.Width, size.Height);
                //// draw form into bitmap
                //this.DrawToBitmap(bmp, new Rectangle(Point.Empty, size));
                //// draw bitmap into graphics, resize to fit paper margins
                //ev.Graphics.DrawImage(bmp, new Rectangle(ev.MarginBounds.Location, ev.MarginBounds.Size));
                //// create a font and draw on graphics the page number
                ////using (var font = new Font(FontFamily.GenericSansSerif, 16f))
                ////{
                ////    ev.Graphics.DrawString(index.ToString(), font, Brushes.Black, ev.MarginBounds.Location);
                ////}
                //ev.Graphics.DrawString("Hello\nBarcode\nHello", new Font("Times New Roman", 25, FontStyle.Bold), Brushes.Black, new PointF(30, 0));
                //var stringSize = graphics.MeasureString(title, arialFont).Width;
                //var titleLocation = new PointF((250 - stringSize) / 2.0f, 30f);

                Image img;
                Image img1;
                Image img2;
                Image img3;

                if (radioButton1.Checked == true && radioButton2.Checked == false)
                {
                    BarcodeWriter barcode = new BarcodeWriter()
                    {
                        Format = BarcodeFormat.CODE_128
                    };
                    //pictureBox1.Image = barcode.Write(id);
                    img = barcode.Write(id);

                    BarcodeWriter barcode2 = new BarcodeWriter()
                    {
                        Format = BarcodeFormat.CODE_128
                    };
                    img2 = barcode2.Write(textBox4.Text);

                    if (textBox3.Text != "")
                    {
                        BarcodeWriter barcode1 = new BarcodeWriter()
                        {
                            Format = BarcodeFormat.CODE_128
                        };
                        //pictureBox2.Image = barcode1.Write(textBox3.Text);
                        img1 = barcode1.Write(textBox3.Text);
                        ev.Graphics.DrawImage(img1, 35, 230, 90, 16);
                    }

                    BarcodeWriter barcode3 = new BarcodeWriter()
                    {
                        Format = BarcodeFormat.CODE_128
                    };
                    img3 = barcode3.Write(DateTime.Today.ToString("MM-dd-yy"));

                    //Image img1 = (Image)(new Bitmap(img, new Size(70,42)));
                    //var stringsize = ev.Graphics.MeasureString("PART NO", new Font("Times New Roman", 7, FontStyle.Bold));
                    //ev.Graphics.DrawString("PART NO", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF((250 - stringsize.Width) / 2.0f, 60));
                    ev.Graphics.DrawString("PART NO", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(7, 60));
                    var stringsize1 = ev.Graphics.MeasureString(id, new Font("Franklin Gothic Medium", 20, FontStyle.Bold));
                    ev.Graphics.DrawString(id, new Font("Franklin Gothic Medium", 20, FontStyle.Bold), Brushes.Black, new PointF((250 - stringsize1.Width) / 2.0f, 55));
                    //ev.Graphics.DrawString(textBox2.Text, new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new PointF(40, 60));
                    ev.Graphics.DrawImage(img, 40, 90, 180, 25);
                    ev.Graphics.DrawString("SIZE:---------------------------------------------------------", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(10, 110));
                    var stringsize2 = ev.Graphics.MeasureString(size, new Font("Franklin Gothic Medium", 15, FontStyle.Bold));
                    ev.Graphics.DrawString(size, new Font("Franklin Gothic Medium", 15, FontStyle.Bold), Brushes.Black, new PointF((250 - stringsize2.Width) / 2.0f, 120));
                    //ev.Graphics.DrawString("M12X1.25X35", new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new PointF(40, 115));
                    ev.Graphics.DrawString("DESC:--------------------------------------------------------", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(10, 135));
                    var stringsize3 = ev.Graphics.MeasureString(desc1, new Font("Franklin Gothic Medium", 13, FontStyle.Bold));
                    ev.Graphics.DrawString(desc1, new Font("Franklin Gothic Medium", 13, FontStyle.Bold), Brushes.Black, new PointF((250 - stringsize3.Width) / 2.0f, 145));
                    //ev.Graphics.DrawString("METRIC JIS FLANGE", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(10, 145));
                    var stringsize4 = ev.Graphics.MeasureString(desc2, new Font("Franklin Gothic Medium", 13, FontStyle.Bold));
                    ev.Graphics.DrawString(desc2, new Font("Franklin Gothic Medium", 13, FontStyle.Bold), Brushes.Black, new PointF((250 - stringsize4.Width) / 2.0f, 165));
                    //ev.Graphics.DrawString("BOLTS 8.8 ZI", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(40, 165));
                    ev.Graphics.DrawString("LOC:----------------------------------------------------------", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(10, 180));
                    ev.Graphics.DrawString(loc, new Font("Franklin Gothic Medium", 13, FontStyle.Bold), Brushes.Black, new PointF(40, 185));
                    //ev.Graphics.DrawString("MC", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(180, 187));
                    //ev.Graphics.DrawString(DateTime.Today.ToString("MM-dd-yy"), new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(180, 195));
                    //ev.Graphics.DrawImage(img3, 110, 190, 120, 18);
                    ev.Graphics.DrawString("QTY:----------------------------------------------------------", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(10, 200));
                    ev.Graphics.DrawString(textBox4.Text, new Font("Franklin Gothic Medium", 12, FontStyle.Bold), Brushes.Black, new PointF(40, 205));
                    //ev.Graphics.DrawString(textBox3.Text, new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(40, 225));
                    ev.Graphics.DrawImage(img2, 150, 210, 95, 16);
                    ev.Graphics.DrawString("PO NO:--------------------------------------------------------", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(10, 220));
                    
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
                    MessageBox.Show("You have to choose only one of the label format! Please try again!");
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
            

            //pd.DefaultPageSettings.PrinterSettings.PrinterName = "Datamax I-4208_157";
            //pd.PrinterSettings.PrinterName = "Datamax I-4208_157";
            //pd.Print();

            //PrintDialog pp = new PrintDialog();
            //PrintServer ps = Warehouse;
            //PrintQueue printQueue = ps.PrintServer.GetPrintQueue("Datamax I-4208_157");
        }

        private void printertest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
