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
    public partial class Diagnose : Form
    {
        public Diagnose()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form FrmMain = new MainForm();
            FrmMain.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((chkHeadache.Checked && chkFever.Checked && chkAppetite.Checked && chkConstipation.Checked) && 
                (chkVomit.Checked || chkImpaired.Checked || chkConvulsion.Checked || chkProstration.Checked || 
                chkDeepBreathing.Checked || chkRespiratoryDistress.Checked || chkBleeding.Checked || 
                chkAnemia.Checked || chkJaundice.Checked || chkMusclePain.Checked || chkComa.Checked || 
                chkBloodyStools.Checked) && 
                !(chkAbdominalPain.Checked || chkAgitation.Checked || chkDelirium.Checked || chkFlunctuatingMood.Checked || 
                chkHallucinations.Checked || chkNoseBleeding.Checked || chkFatigue.Checked))
            {
                lblDisease.Text = "You are Suffering from MALARIA";
                lblDrugs.Text = "Amatem Forte 80mg/480mg,\tArtemether 480mg,\tLumfantrin,\tArtesunate 100mg,\t" +
                    "Maldox 500/25mg,\tLaridox 500/25mg,\tFansidar Sulfadoxine 500/25mg,\tLynsunate Forte 480/80mg,\tAmalar,\tetc.\n" +
                    "NOTE: CONSULT A PHARMACIST FOR DOSAGE AND ADMISNISTRATION";
                lblPrevention.Text = "Stay Clear of Mosquitoes,\t\n\nFOR MORE HELP, Contact Dr. JOEL on: 08037116208, \nDr. Dada: on 08056139806";
            }
            else if((chkHeadache.Checked && chkFever.Checked && chkAppetite.Checked && chkConstipation.Checked) && 
                (chkAbdominalPain.Checked || chkAgitation.Checked || chkDelirium.Checked || chkFlunctuatingMood.Checked || 
                chkHallucinations.Checked || chkNoseBleeding.Checked || chkFatigue.Checked) && 
                !(chkVomit.Checked || chkImpaired.Checked || chkConvulsion.Checked || chkProstration.Checked || 
                chkDeepBreathing.Checked || chkRespiratoryDistress.Checked || chkBleeding.Checked || 
                chkAnemia.Checked || chkJaundice.Checked || chkMusclePain.Checked || chkComa.Checked || 
                chkBloodyStools.Checked))
            {
                lblDisease.Text = "You are suffering from TYPHOID";
                lblDrugs.Text = "ANTI-BIOTICS, Like: Ciprofloxacin, Ofloxacin, Levojloxacin,clindamycin,Cefuroxine, Azithromycin, Norfloxacin, Gatijloxacin, clorithromycin, Erithromycin.  etc.";
                lblPrevention.Text = "Boil water before drinking.\n\nFOR MORE HELP, Contact Dr. JOEL on: 08037116208, \nDr. Dada: on 08056139806";
            }
            else
            {
                lblDisease.Text = "Your ailment is beyond the scope of this Software";
                lblDrugs.Text = "VISIT A NEARBY HOSPITAL";
                lblPrevention.Text = "PLEASE VISIT A NEARBY HOSPITAL AND FOLLOW DOCTOR'S INSTRUCTION.\n\nFOR MORE HELP, Contact Dr. JOEL on: 08037116208, \nDr. Dada: on 08056139806";
            }
        }

        private void Diagnose_Load(object sender, EventArgs e)
        {

        }

        private void lblPrevention_Click(object sender, EventArgs e)
        {

        }
    }
}
