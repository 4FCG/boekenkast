using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deelopdracht_2_versie_3
{
    public partial class ZoekSelectie : Form
    {
        private Form previousForm;
        public ZoekSelectie(Form previousForm)
        {
            this.previousForm = previousForm;
            InitializeComponent();

        }

        //per genre
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var nextForm = new ZoekScherm(this, 1, "SELECT * FROM Boek WHERE genre = @genre ;", "Genre");
            nextForm.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.previousForm.Show();
            this.Close();
        }

        //per titel
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var nextForm = new ZoekScherm(this, 1, "SELECT * FROM Boek WHERE titel = @titel ;", "Titel");
            nextForm.Show();
        }

        //per vak
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var nextForm = new ZoekScherm(this, 2, "SELECT * FROM Boek WHERE vakId = @vakId ;", "Vak", "SELECT * FROM Vak;", "naam", "vakId");
            nextForm.Show();
        }

        //totaal overzicht
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var nextForm = new ZoekScherm(this, 3, "SELECT * FROM Boek ;", "Alle boeken");
            nextForm.Show();
        }

        //per kast
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var nextForm = new ZoekScherm(this, 2, "SELECT * FROM Boek WHERE vakId IN (SELECT vakId FROM Vak WHERE boekenkastId = @boekenkastId );", "Boekenkast", "SELECT * FROM Boekenkast;", "plaats", "boekenkastId");
            nextForm.Show();
        }

        //per locatie
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var nextForm = new ZoekScherm(this, 2, "SELECT * FROM Boek WHERE vakId IN (SELECT vakId FROM Vak WHERE boekenkastId IN (SELECT boekenkastId FROM Boekenkast WHERE locatieId = @locatieId ));", "Locatie", "SELECT * FROM Locatie;", "naam", "locatieId");
            nextForm.Show();
        }
    }
}
