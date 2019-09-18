using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JummyMedExp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblCopyright.Text = Char.ConvertFromUtf32(169) + " " + lblCopyright.Text;
            lblGreetings.Text = "Welcome " + Form1.PatientName + "\n\t   [ " + Form1.PatientID + " ]";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form FrmLogin = new Form1();
            FrmLogin.Show();
            this.Hide();
        }

        private void btnDiagnose_Click(object sender, EventArgs e)
        {
            Form FrmDiagnose = new Diagnose();
            FrmDiagnose.Show();
            this.Hide();
        }

        private void diagnoseDiseaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmDiagnose = new Diagnose();
            FrmDiagnose.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult reply;
            reply = MessageBox.Show("Do You Really Want to Exit This Application?", "EXIT", MessageBoxButtons.YesNo);
            if(reply == System.Windows.Forms.DialogResult.Yes)
            {
                //Form FrmLogin = new Form1();
                //FrmLogin.Show();
                //this.Hide();
                Application.Exit();
            }
            else { MessageBox.Show("Thanks for staying back"); }
        }

        
    }
}
