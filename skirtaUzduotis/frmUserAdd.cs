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
    public partial class frmUserAdd : Form
    {
        public frmUserAdd()
        {
            InitializeComponent();
        }

        const string connectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\manta\source\repos\skirtaUzduotis\skirtaUzduotis\loginInformacija.mdf;Integrated Security=True";
        
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //Checking if given textboxes aren't empty
            if (!(txt_UserName.Text == "" && txt_Surname.Text == "" && txt_personalID.Text == "" && txt_Password.Text == ""))
            {
                if (txt_personalID.Text.Length == 11)
                {
                    if (lstbx_exams.CheckedIndices.Count >= 2 && lstbx_exams.CheckedIndices.Count <= 5)
                    {
                        try
                        {
                            int id;
                            SqlConnection con = new SqlConnection(connectionStr);
                            //Finding biggest Id
                            SqlCommand cmd = new SqlCommand("SELECT MAX(Id) FROM tbl_LoginInfo", con);

                            cmd.Connection = con;

                            con.Open();
                            //saving id
                            id = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                            //inserting new value
                            cmd.CommandText = $"INSERT INTO tbl_LoginInfo (Id, UserName, Password, PersonalID, Surname) VALUES ({id}, " +
                                $"'{txt_UserName.Text}', '{txt_Password.Text}', '{txt_personalID.Text}', '{txt_Surname.Text}')";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            //Getting a list of selected exams
                            List<string> checkeditems = lstbx_exams.CheckedItems.Cast<object>()
                                                                       .Select(item => item.ToString()).ToList();

                            try
                            {
                                con.Open();
                                cmd.CommandText = $"INSERT tbl_Dalykai (Id) VALUES ({id})";
                                cmd.ExecuteNonQuery();
                                foreach (var item in checkeditems)
                                {
                                    if (item == "Lietuvių k.")
                                    {
                                        cmd.CommandText = $"UPDATE tbl_Dalykai SET Lietuviu = 101 WHERE Id = {id}";
                                    }
                                    else if(item == "Anglų k.")
                                    {
                                        cmd.CommandText = $"UPDATE tbl_Dalykai SET Anglu = 101 WHERE Id = {id}";
                                    }
                                    else if (item == "Informacinės technologijos")
                                    {
                                        cmd.CommandText = $"UPDATE tbl_Dalykai SET IT = 101 WHERE Id = {id}";
                                    }
                                    else
                                    {
                                        cmd.CommandText = $"UPDATE tbl_Dalykai SET {item} = 101 WHERE Id = {id}";
                                    }
                                    cmd.ExecuteNonQuery();
                                }
                                con.Close();
                                

                            }
                            catch(Exception er)
                            {
                                MessageBox.Show(er.Message);
                            }

                            MessageBox.Show("Moksleivis sėkmingai pridėtas!");
                            frmAdmin fa = new frmAdmin();
                            this.Hide();
                            fa.Show();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Prašome parinkti ne mažiau nei 2 ir ne daugiau kaip 5 egzaminus!");
                    }
                }
                else
                {
                    MessageBox.Show("Asmens kodas turi turėti 11 skaitmenų!");
                }
                
            }
            else
            {
                MessageBox.Show("Prašome įrašyti visą informaciją!");
            }
        }
    }
}
