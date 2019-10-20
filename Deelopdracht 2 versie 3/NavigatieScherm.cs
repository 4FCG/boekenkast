using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Deelopdracht_2_versie_3.FormTools;

namespace Deelopdracht_2_versie_3
{
    public partial class NavigatieScherm : Form
    {
        private Form previousForm;
        private IDatabaseObject databaseObject;

        public NavigatieScherm(Form previousForm, IDatabaseObject databaseObject)
        {
            this.previousForm = previousForm;
            this.databaseObject = databaseObject;
            
            InitializeComponent();
            this.attributePanel.AutoScroll = true;

            this.idLabel.Text = "Id: " + databaseObject.Id;

            this.primaryObjectName.Text = databaseObject.GetType().Name;

            foreach (KeyValuePair<string, Type> attribute in databaseObject.RequiredData)
            {
                AddAttributeTextBox(attributePanel, attribute, databaseObject.ObjectData[attribute.Key]);
            }

            secondaryObjectName.Text = databaseObject.ObjectData["contentsNaam"].ToString();
            secondaryObjectSelection.DisplayMember = "Naam";
            secondaryObjectSelection.DataSource = this.databaseObject.ObjectData["contents"];

        }

        //Closes screen and returns to the previous screen
        private void backButton_Click(object sender, EventArgs e)
        {
            this.previousForm.Show();
            this.Close();
        }
        
        //Delete button event, calls delete on database object.
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmMessage = MessageBox.Show("Weet u zeker dat u dit wilt verwijderen?", "Verwijderen", MessageBoxButtons.OKCancel);

            if (confirmMessage == DialogResult.OK)
            {
                this.databaseObject.Delete();
                backButton_Click(sender, e);
            }
        }
        //Sends values of all textbox fields to the update function of the database object.
        private void saveButton_Click(object sender, EventArgs e)
        {
            var textBoxData = new Dictionary<string, object>();

            foreach (TextBox textBox in this.attributePanel.Controls.OfType<TextBox>())
            {
                textBoxData.Add(textBox.Name, textBox.Text);
            }
            foreach (ComboBox comboBox in this.attributePanel.Controls.OfType<ComboBox>())
            {
                textBoxData.Add(comboBox.Name, comboBox.SelectedValue);
            }

            this.databaseObject.Update(textBoxData);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (this.secondaryObjectSelection.SelectedIndex != -1)
            {
                this.Hide();
                Form nextForm;
                if (this.databaseObject.GetType().Equals(typeof(Vak)))
                {
                    nextForm = new BoekEdit(this, this.secondaryObjectSelection.SelectedItem as IDatabaseObject);
                }
                else
                {
                    nextForm = new NavigatieScherm(this, this.secondaryObjectSelection.SelectedItem as IDatabaseObject);
                }
                nextForm.Show();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddNewObject addForm = new AddNewObject(this, this.databaseObject);
            addForm.ShowDialog();
        }
    }
}
