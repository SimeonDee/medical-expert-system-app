using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Data;
using System.Data.OleDb;

namespace JummyMedExp
{
    public partial class Form1 : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd;
        private OleDbDataReader rdr;
        private String cnStr;
        private String thesql;
        public static String PatientName{get; set;}
        public static String PatientID {get; set;}

        public Form1()
        {
            InitializeComponent();
            PatientName = "";
            PatientID = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            cnStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\SIMEON_DEE\\Desktop\\JummyProject\\JummyMedExpDbase.accdb; Persist Security Info=False;";
            try 
            {
                conn = new OleDbConnection(cnStr);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                //MessageBox.Show("Connected");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            Form reg = new PatientsReg();
            reg.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                thesql = "Select * FROM RegPatients WHERE PatientID = '" + txtUsername.Text.ToUpper() + "' AND Pswd = '" + txtPassword.Text.Trim() + "'";
                cmd = new OleDbCommand(thesql, conn);
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    rdr.Read();
                    PatientName = rdr["PName"].ToString();
                    PatientID = rdr["PatientID"].ToString();
                    Form FrmMain = new MainForm();
                    FrmMain.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid Login Details.\n You can Click on 'Sign Up' to register");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (!rdr.IsClosed) rdr.Close(); 
            }

         }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }               

        public String getPatientName()
        {
            return PatientName; 
        }

        public String getPatientID()
        {
            return PatientID;
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form FrmRecovery = new PasswordRecovery();
            FrmRecovery.Show();
            this.Hide();
        }

    }
}
