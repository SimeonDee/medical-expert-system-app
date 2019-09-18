using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace JummyMedExp
{
    public partial class PatientsReg : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd;
        private OleDbDataReader rdr;
        private String thesql, cnStr;

        public PatientsReg()
        {
            InitializeComponent();
        }

        private void PatientsReg_Load(object sender, EventArgs e)
        {
            cboGender.Items.Add("Male");
            cboGender.Items.Add("Female");

            try
            {
                cnStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\SIMEON_DEE\\Desktop\\JummyProject\\JummyMedExpDbase.accdb; Persist Security Info=False;";
                conn = new OleDbConnection(cnStr);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                //MessageBox.Show("Connected");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form FrmLogin = new Form1();
            FrmLogin.Show();
            this.Hide();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            String LastID = "";
            int newID;
            thesql = "Select ID FROM RegPatients";
            try
            {
                cmd = new OleDbCommand(thesql, conn);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        LastID = rdr["ID"].ToString();
                    }

                    newID = Convert.ToInt32(LastID) + 1;

                    txtID.Text = "PAT/" + newID.ToString().PadLeft(4, '0');
                    MessageBox.Show("PLEASE NOTE:\n Your Patient ID is automatically your Username.\n\nPlease note it down somewhere safe");
                    panel4.Enabled = true;
                    txtUName.Text = txtID.Text;
                    txtName.Focus();
                    btnSubmit.Enabled = true;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rdr.HasRows ) rdr.Close();
            }
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(isValidControls())
            {
               // try
                //{
                    thesql = "INSERT INTO RegPatients(PatientID, PName, PGender, PAge, PAddress, Pswd, SecQue, SecAnswer) " +
                        "VALUES('" + txtID.Text.Trim() + "', '" + txtName.Text.Trim() + "', '" +
                        cboGender.Text.Trim() + "', " + Convert.ToInt32(txtAge.Text.Trim()) + ", '" +
                        txtAddress.Text.Trim() + "', '" + txtPassword.Text.Trim() + "', '" +
                        txtSecQuestion.Text.Trim() + "', '" + txtSecAnswer.Text.Trim() + "');";

                    cmd = new OleDbCommand(thesql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Registered");

                    txtID.Clear();
                    txtName.Clear();
                    cboGender.Text = "";
                    txtAge.Clear();
                    txtAddress.Clear();
                    txtUName.Clear();
                    txtPassword.Clear();
                    txtConfirmPassword.Clear();
                    txtSecQuestion.Clear();
                    txtSecAnswer.Clear();
                    panel4.Enabled = false;
                    btnSubmit.Enabled = false;

                //}
                //catch (Exception ex)
                //{
                  //  MessageBox.Show(ex.Message);
                //}
            }
            
        }

        private bool isValidControls()
        {
            bool ValReturned = true;
            if (txtID.Text == "") 
            {
                MessageBox.Show("Patient's ID Field is required");
                txtID.Focus();
                ValReturned = false;
            }
            else if(txtName.Text == "")
            {
                MessageBox.Show("Patient's name is required");
                txtName.Focus();
                ValReturned = false;
            }
            else if(cboGender.Text == "")
            {
                MessageBox.Show("Please select your gender");
                cboGender.Focus();
                ValReturned = false;
            }
            else if(txtAge.Text == "")
            {
                MessageBox.Show("Age is required");
                txtAge.Focus();
                ValReturned = false;
            }
            else if(txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Password and Confirm Password fields are required");
                txtPassword.Focus();
                ValReturned = false;
            }
            else if(txtSecQuestion.Text  == "" || txtSecAnswer.Text == "")
            {
                MessageBox.Show("Please suplly a Secured Question and Answer the Question, for password recovery");
                txtSecQuestion.Focus();
                ValReturned = false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text )
            {
                MessageBox.Show("Password Mismatched.\nPlease retype your password.");
                txtPassword.Focus();
                ValReturned = false;
            }

            return ValReturned;
        }
    }
}
