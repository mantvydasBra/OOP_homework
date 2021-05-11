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
using System.Text.RegularExpressions;

namespace skirtaUzduotis
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            FillUserList();
        }
        const string connectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\manta\source\repos\skirtaUzduotis\skirtaUzduotis\loginInformacija.mdf;Integrated Security=True";

        public void FillUserList()
        {
            lbox_naudotojai.Items.Clear();
            SqlConnection con = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand("Select * from tbl_LoginInfo", con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string idName = reader.GetInt32(0).ToString() + " - " + reader.GetString(1);
                    lbox_naudotojai.Items.Add(idName);
                }
                reader.Close();
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void lbox_naudotojai_DoubleClick(object sender, EventArgs e)
        {
            if (lbox_naudotojai.SelectedItem != null)
            {
                string clicked = lbox_naudotojai.SelectedItem.ToString();
                //can't select admin
                if (clicked == "0 - Admin") return;
                //get selected item id
                int id = Int32.Parse(Regex.Match(clicked, @"\d+").Value);
                SqlConnection con = new SqlConnection(connectionStr);
                SqlCommand cmd = new SqlCommand($"Select UserName, Surname from tbl_LoginInfo where Id = {id}", con);
                SqlDataReader reader;
                List<string> exams = new List<string>();


                try
                {
                    string name = "";
                    con.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        name = reader.GetString(0) + " " + reader.GetString(1);
                    }
                    reader.Close();
                    cmd.CommandText = $"Select * from tbl_Dalykai where Id = {id}";
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (!reader.IsDBNull(i) && reader.GetName(i) != "Id")
                            {
                                exams.Add(reader.GetName(i));
                            }
                        }
                        
                    }
                    reader.Close();
                    con.Close();
                    this.Hide();
                    frmSetExams se = new frmSetExams(name, exams);
                    se.Id = id;
                    se.Show();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                
            }
        }

        private void btn_LogOutAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginScreen login = new loginScreen();
            login.Show();
        }

        private void bt_addNewUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUserAdd addUser = new frmUserAdd();
            addUser.Show();
        }

        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            loginScreen login = new loginScreen();
            login.Show();
        }
    }
}
