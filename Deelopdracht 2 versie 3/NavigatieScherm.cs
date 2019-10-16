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
    public partial class NavigatieScherm : Form
    {
        private Form previousForm;
        private IAlgemeenDatabaseObject databaseObject;

        public NavigatieScherm(Form previousForm, IAlgemeenDatabaseObject databaseObject)
        {
            this.previousForm = previousForm;
            this.databaseObject = databaseObject;
            InitializeComponent();
            this.attributePanel.AutoScroll = true;
        }

        private void NavigatieScherm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void idLabel_Click(object sender, EventArgs e)
        {

        }
        //Closes screen and returns to the previous screen
        private void backButton_Click(object sender, EventArgs e)
        {
            this.previousForm.Show();
            this.Close();
        }
        //Adds textbox, with a lable in front of it, to the attributePanel at the appropriate height.
        private void AddAttributeTextBox(string name, string text, string value)
        {
            int verticalOffset = this.attributePanel.Controls.Count * 25;

            //display label in front of textbox
            Label displayLabel = new Label
            {
                Text = text,
                Location = new Point(0, verticalOffset + 3),
                AutoSize = true
            };
            this.attributePanel.Controls.Add(displayLabel);

            //textbox with current value as default
            this.attributePanel.Controls.Add(new TextBox
            {
                Name = name,
                Text = value,
                Location = new Point(displayLabel.Width + 5, verticalOffset)
            });

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
            var textBoxData = new Dictionary<string, string>();

            foreach (TextBox textBox in this.attributePanel.Controls.OfType<TextBox>()) 
            {
                textBoxData.Add(textBox.Name, textBox.Text);   
            }

            this.databaseObject.Update(textBoxData);
        }
    }
}
