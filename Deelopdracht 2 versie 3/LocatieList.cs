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
    public partial class LocatieList : Form
    {
        private List<Locatie> locaties;
        private Form previousForm;
        public LocatieList(List<Locatie> locaties, Form previousForm)
        {
            this.previousForm = previousForm;
            this.locaties = locaties;
            InitializeComponent();
            secondaryObjectSelection.DisplayMember = "Naam";
            secondaryObjectSelection.DataSource = this.locaties;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var addForm = new NewLocatie(this.locaties);
            addForm.ShowDialog();
            backButton_Click(sender, e);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (this.secondaryObjectSelection.SelectedIndex != -1)
            {
                this.Hide();
                Form nextForm = new NavigatieScherm(this, this.secondaryObjectSelection.SelectedItem as IDatabaseObject);
                nextForm.Show();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.previousForm.Show();
            this.Close();
        }
    }
}
