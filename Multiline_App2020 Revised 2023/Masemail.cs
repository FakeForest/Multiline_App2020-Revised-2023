using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;

namespace Multiline_App2020_Revised_2023
{
    public partial class Masemail : Form
    {
        public Masemail()
        {
            InitializeComponent();
        }

        public static string objects = "";
        public static string aorg = "";
        public Boolean checkflg = false;
        public static string att = "";


        private void button1_Click(object sender, EventArgs e)
        {
            //checkflg = true;
            //objects = "customer";
            if (checkflg == false)
            {
                MessageBox.Show("Please check the email info first before sending !");
                return;
            }
            else 
            {
                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    string query1 = "Select * from massemailtemp";

                    SqlCommand cmd1 = new SqlCommand(query1, conn);
                    cmd1.CommandType = CommandType.Text;
                    cmd1.ExecuteNonQuery();
                    using (SqlDataReader rdr = cmd1.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            using (SqlConnection con = new SqlConnection(cs))
                            {
                                con.Open();
                                SqlCommand cmd2 = new SqlCommand("insert into massemailtotal (idnumber, sendto, acctype, email, createdate, emailstate) values ('"+ rdr["id"].ToString() +"', '" + objects + "', '" + aorg + "', '" + rdr["email"].ToString() + "', '" + DateTime.Now + "', 'OPEN')", con);
                                cmd2.ExecuteNonQuery();
                                con.Close();
                            }
                            try
                            {
                                MailMessage mail = new MailMessage();
                                SmtpClient smtp = new SmtpClient("smtp.bellnet.ca");

                                mail.From = new MailAddress("email@multilinefasteners.com");
                                mail.To.Add(rdr["email"].ToString());
                                //mail.CC.Add(textBox3.Text);
                                //mail.Bcc.Add("");
                                mail.Subject = textBox5.Text;
                                mail.Body = textBox6.Text;
                                //mail.IsBodyHtml = true;

                                if (att == "yes")
                                {
                                    System.Net.Mail.Attachment attachment;
                                    attachment = new System.Net.Mail.Attachment(label7.Text);
                                    mail.Attachments.Add(attachment);
                                }
                                
                                smtp.Port = 25;
                                smtp.EnableSsl = false;

                                smtp.Send(mail);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                MailMessage mail = new MailMessage();
                                SmtpClient smtp = new SmtpClient("smtp.bellnet.ca");

                                mail.From = new MailAddress("email@multilinefasteners.com");
                                mail.To.Add("email@multilinefasteners.com");
                                mail.Subject = "Email sent Fail";
                                mail.Body = string.Format("This email does not exist: {0}", rdr["email"].ToString()) + "\n" + ex.ToString();

                                smtp.Port = 25;
                                smtp.EnableSsl = false;

                                smtp.Send(mail);
                            }

                            using (SqlConnection con1 = new SqlConnection(cs))
                            {
                                con1.Open();
                                string querysent = "update massemailtotal set emailstate='SENT' where email =('" + rdr["email"].ToString() + "')";
                                SqlCommand cmdx = new SqlCommand(querysent, con1);
                                cmdx.ExecuteNonQuery();
                                con1.Close();
                            }
                            
                        }
                    }

                    conn.Close();
                    MessageBox.Show("All emails have been sent!");

                }
                aorg = "";
                att = "";
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.ShowDialog();
            label7.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MainMenu.objects == "vendor")
            {
                objects = "vendor";
            }
            else if (MainMenu.objects == "customer")
            {
                objects = "customer";
            }
            else
            {
                MessageBox.Show("Error!");
            }

            if (checkBox1.Checked && checkBox2.Checked)
            {
                MessageBox.Show("You can not choose both at the same time, pls choose again");
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                aorg = "";
            }
            else if (checkBox1.Checked ==false && checkBox2.Checked == false)
            {
                MessageBox.Show("Please choose one of the option to generate relative emails to send!");
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                string query1 = " IF OBJECT_ID ('dbo.massemailtemp', 'U') IS NOT NULL TRUNCATE TABLE dbo.massemailtemp";

                string query2 = "insert into massemailtemp select cu_cust_id, cu_attention, cu_email_attention  from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.customers where cu_email_attention<>'' and cu_status_flg='A'";

                string query3 = "insert into massemailtemp select c.cuco_cust_id, c.cuco_contact_name, c.cuco_email, s.cu_status_flg from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.cust_contacts as c join [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.customers as s on c.cuco_cust_id=s.cu_cust_id where cuco_email<>'' and s.cu_status_flg='A'";

                string query5 = "insert into massemailtemp select su_supplier_id,su_attention_ap, su_ap_emailattention from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.suppliers where su_ap_emailattention<>'' and  su_active_log = '1'";

                string query4 = "select count(*) from massemailtemp";

                SqlCommand cmd = new SqlCommand(query1, conn);
                cmd.ExecuteNonQuery();

                if (objects == "customer" && aorg == "accounting")
                {
                    SqlCommand cmd1 = new SqlCommand(query2, conn);
                    cmd1.ExecuteNonQuery();
                }
                else if (objects == "customer" && aorg == "general")
                {
                    SqlCommand cmd2 = new SqlCommand(query3, conn);
                    cmd2.ExecuteNonQuery();
                }
                else if (objects == "vendor" && aorg == "genral")
                {
                    SqlCommand cmd4 = new SqlCommand(query5, conn);
                    cmd4.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Please try again!");
                    button2.Focus();
                    return;
                }
                SqlCommand cmd3 = new SqlCommand(query4, conn);
                int c = (int)cmd3.ExecuteScalar();

                MessageBox.Show(string.Format("Info checked, ready to send to {1}, type: {2},total count of email is {0}.", c, objects, aorg));
                checkflg = true;

                conn.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                aorg = "accounting";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                aorg = "general";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                att = "yes";
            }
        }
    }
}
