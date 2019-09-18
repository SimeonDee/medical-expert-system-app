using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace JummyMedExp
{
    public partial class Form1 : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd;
        private OleDbDataReader rdr;
        private String cnStr;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cnStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\USER\\Documents\\JummyMedicalExpertSystem.accdb; Persist Seurity Info=False;";
            //try 
            //{
                conn = new OleDbConnection(cnStr);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                MessageBox.Show("Connected");

            //}
            //catch (Exception ex)
            //{

              //  MessageBox.Show(ex.Message);
            //}
        }
    }
}
