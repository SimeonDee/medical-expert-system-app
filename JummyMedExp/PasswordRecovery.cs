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
    public partial class PasswordRecovery : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd;
        private OleDbDataReader rdr;
        private String cnStr, thesql;
        private String rightQue, rightAns, rightPswd;

        
        public PasswordRecovery()
        {
            InitializeComponent();
        }

        private void PasswordRecovery_Load(object sender, EventArgs e)
        {
            cnStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\SIMEON_DEE\\Desktop\\JummyProject\\JummyMedExpDbase.accdb; Persist Security Info=False;";
            try
            {
                conn = new OleDbConnection(cnStr);
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            thesql = "SELECT * FROM RegPatients WHERE PatientID = '" + txtID.Text.Trim().ToUpper() + "'";
            try
            {
                cmd = new OleDbCommand(thesql, conn);
                rdr = cmd.ExecuteReader();

                if(rdr.HasRows)
                {
                    rdr.Read();
                    rightQue = rdr["SecQue"].ToString();
                    rightAns = rdr["SecAnswer"].ToString();
                    rightPswd = rdr["Pswd"].ToString();

                    txtSecQuestion.Text = rightQue;

                }
                else
                {
                    MessageBox.Show("No such Patient ID existing");
                    txtID.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (!rdr.IsClosed) 
                    rdr.Close();   
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtSecAnswer.Text == "") 
            {
                MessageBox.Show("Please supply the correct answer to the security quention above");
                txtSecAnswer.Focus();

            }
            else if(txtSecAnswer.Text.Trim().ToUpper() == rightAns.ToUpper())
            {
                lblPasswordInfo.Text = "Your Password is << " + rightPswd + " >>";
            }
            else
            {
                MessageBox.Show("Wrong Answer supplied\nYou are an unauthorized user");
            }
                
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form FrmLogin = new Form1();
            FrmLogin.Show();
            this.Hide();
        }


    }
}
