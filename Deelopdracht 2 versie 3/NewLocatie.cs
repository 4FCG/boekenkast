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
    public partial class NewLocatie : Form
    {
        private List<Locatie> locaties;
        public NewLocatie(List<Locatie> locaties)
        {
            this.locaties = locaties;
            InitializeComponent();
            var attribute = new KeyValuePair<string, Type> ( "naam", typeof(string));
            AddAttributeTextBox(attributePanel, attribute, -1);

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var textBoxData = new Dictionary<string, object>();
            foreach (TextBox textBox in this.attributePanel.Controls.OfType<TextBox>())
            {
                textBoxData.Add(textBox.Name, textBox.Text);
            }
            this.locaties.Add(new Locatie(this.locaties, textBoxData));

            this.Close();
        }
    }
}
