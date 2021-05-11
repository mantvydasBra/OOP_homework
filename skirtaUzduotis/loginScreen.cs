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
    public partial class loginScreen : Form
    {
        public loginScreen()
        {
            InitializeComponent();
        }
        //String to connect to LocalDB
        string connectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\manta\source\repos\skirtaUzduotis\skirtaUzduotis\loginInformacija.mdf;Integrated Security=True";

        //btn_Login Click event
        private void btn_Login_Click_1(object sender, EventArgs e)
        {
            //checking if information is entered
            if (txt_Username.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Įrašykite informaciją!");
                return;
            }
            try
            {
                //Creating sql connection
                SqlConnection con = new SqlConnection(connectionStr);
                SqlCommand cmd = new SqlCommand("Select * from tbl_LoginInfo where UserName=@username and Password=@password", con);
                //Adding reference
                cmd.Parameters.AddWithValue("@username", txt_Username.Text);
                cmd.Parameters.AddWithValue("@password", txt_Password.Text);
                //Opening connection
                con.Open();

                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();

                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, then show Main form
                if (count == 1)
                {
                    MessageBox.Show("Sėkmingai prisijungta!");
                    this.Hide();
                    if (txt_Username.Text == "Admin")
                    {
                        frmAdmin fmA = new frmAdmin();
                        fmA.Show();
                    }
                    else
                    {
                        string surname = Convert.ToString(ds.Tables[0].Rows[0]["Surname"]);
                        int id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                        string personalID = Convert.ToString(ds.Tables[0].Rows[0]["PersonalID"]);
                        string fullName = txt_Username.Text + " " + surname;
                        FrmMain fm = new FrmMain(fullName, personalID);
                        fm.Text = fullName;
                        
                        fm.DisplayExams(id);
                        fm.Show();
                    }                    
                }
                else
                {
                    MessageBox.Show("Prisijungimas nesėkmingas. Patikrinkite įvestą informaciją.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loginScreen_Closing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
