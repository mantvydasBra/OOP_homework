using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace skirtaUzduotis
{
    public partial class frmSetExams : Form
    {
        public int Id { get; set; }
        private List<string> SetExams = new List<string>();
        private List<int> grades = new List<int>();
        //public List<string> exams = new List<string>();

        public frmSetExams(string name, List<string> exams)
        {
            InitializeComponent();
            lbl_name.Text = name;
            foreach (string e in exams)
            {
                switch(e)
                {
                    case "Lietuviu":
                        lstBox_Exams.Items.Add("Lietuvių k.");
                        break;
                    case "Anglu":
                        lstBox_Exams.Items.Add("Anglų k.");
                        break;
                    case "IT":
                        lstBox_Exams.Items.Add("Informacinės technologijos");
                        break;
                    default:
                        lstBox_Exams.Items.Add(e);
                        Console.WriteLine(e);
                        break;
                }
            }
        }
        const string connectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\manta\source\repos\skirtaUzduotis\skirtaUzduotis\loginInformacija.mdf;Integrated Security=True";

        private void SetExamNumber(object sender, EventArgs e)
        {
            int input;
            string exam = lstBox_Exams.SelectedItem.ToString();
            //Converting text for database
            switch (exam)
            {
                case "Lietuvių k.":
                    exam = "Lietuviu";
                    break;
                case "Anglų k.":
                    exam = "Anglu";
                    break;
                case "Informacinės technologijos":
                    exam = "IT";
                    break;
                default:
                    break;
            }

            do
            {
                //checking if the box isn't canceled
                if (Int32.TryParse(Interaction.InputBox("", "Įveskite pažymį nuo 0-100", "0"), out input)) { }
                else return;

                if (input < 0 || input > 100)
                {
                    MessageBox.Show("Ivedėte blogą skaičių!");
                }
            } while (input < 0 || input > 100);

            //saving entered grade and exam for another function
            if (SetExams.ElementAtOrDefault(lstBox_Exams.SelectedIndex) != null)
            {
                grades[lstBox_Exams.SelectedIndex] = input;
            }
            else
            {
                SetExams.Add(exam);
                grades.Add(input);
            }
            

            //saving selected item to update it
            string tempVal = Regex.Match(lstBox_Exams.SelectedItem.ToString(), @".+?(?= =)").ToString();  // TODO: edit this to be compatible with 2 words
            if (tempVal == "")
            {
                tempVal = Regex.Match(lstBox_Exams.SelectedItem.ToString(), @".*(?=\.?)").ToString();
            }
            lstBox_Exams.Items[lstBox_Exams.SelectedIndex] = tempVal + $" = {input}%";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!SetExams.Any() || !grades.Any())
            {
                MessageBox.Show("Įrašykite egzaminų įvertinimus.");
                return;
            }
            else if (SetExams.Count != lstBox_Exams.Items.Count)
            {
                MessageBox.Show("Įrašykite visų egzaminų įvertinimus.");
                return;
            }

            SqlConnection con = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand("", con);
            try
            {

                for (int i = 0; i < SetExams.Count(); i++)
                {
                    cmd.CommandText = $"UPDATE tbl_Dalykai SET {SetExams[i]} = {grades[i]} WHERE Id = {Id}";
                    con.Open();
                    cmd.ExecuteScalar();
                    con.Close();
                }
                this.Hide();
                MessageBox.Show("Sėkmingai įrašyti egzaminai");
                frmAdmin fa = new frmAdmin();
                fa.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdmin fa = new frmAdmin();
            fa.Show();
        }

        private void frmSetExams_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmAdmin fa = new frmAdmin();
            fa.Show();
        }
    }
}
