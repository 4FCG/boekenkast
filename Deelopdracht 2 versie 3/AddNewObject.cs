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
    public partial class AddNewObject : Form
    {
        private Form previousForm;
        private IDatabaseObject databaseObject;
        public AddNewObject(Form previousForm, IDatabaseObject databaseObject)
        {
            this.databaseObject = databaseObject;
            this.previousForm = previousForm;

            InitializeComponent();
            foreach (KeyValuePair<string, Type> attribute in databaseObject.ObjectData["contentsData"] as Dictionary<string, Type>)
            {
                AddAttributeTextBox(attributePanel, attribute, -1);
            }
        }

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
            

            //Provide the appropriate database object to create based on current database object
            var objectType = this.databaseObject.GetType();
            var contentsList = this.databaseObject.ObjectData["contents"];

            if (objectType.Equals(typeof(Locatie)))
            {
                (contentsList as List<Boekenkast>).Add(new Boekenkast(this.databaseObject as Locatie, textBoxData));
            }
            else if (objectType.Equals(typeof(Boekenkast)))
            {
                (contentsList as List<Vak>).Add(new Vak(this.databaseObject as Boekenkast, textBoxData));
            }
            else if (objectType.Equals(typeof(Vak)))
            {
                (contentsList as List<Boek>).Add(new Boek(this.databaseObject as Vak, textBoxData));
            }

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
