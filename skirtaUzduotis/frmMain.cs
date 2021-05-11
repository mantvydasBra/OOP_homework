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

namespace skirtaUzduotis
{
    public partial class FrmMain : Form
    {
        public FrmMain(string name, string personalID)
        {
            InitializeComponent();
            lbl_name.Text = name;
            lbl_ID.Text = personalID;
        }

        const string connectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\manta\source\repos\skirtaUzduotis\skirtaUzduotis\loginInformacija.mdf;Integrated Security=True";

        public void DisplayExams(int id)
        {
            SqlConnection con = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand($"Select * from tbl_Dalykai where Id = {id}", con);
            try
            {
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();

                int count = ds.Tables[0].Rows.Count;
                if (count == 1)
                {
                    foreach (DataColumn column in ds.Tables[0].Columns)
                    {
                        //Printing only not null exams
                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][column].ToString()) && column.ToString() != "Id")
                        {
                            switch (column.ToString())
                            {
                                case "Lietuviu":
                                    txtbx_exams.Text += $"Lietuvių k. - {ds.Tables[0].Rows[0][column]}%\n";
                                    break;
                                case "Anglu":
                                    txtbx_exams.Text += $"Anglų k. - {ds.Tables[0].Rows[0][column]}%\n";
                                    break;
                                case "IT":
                                    txtbx_exams.Text += $"Informacinės technologijos - {ds.Tables[0].Rows[0][column]}%\n";
                                    break;
                                default:
                                    txtbx_exams.Text += $"{column} - {ds.Tables[0].Rows[0][column]}%\n";
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    txtbx_exams.Text = "Nėra egzaminų";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //btn_LogOut Click event handler
        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginScreen login = new loginScreen();
            login.Show();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            loginScreen login = new loginScreen();
            login.Show();
        }
    }
}
