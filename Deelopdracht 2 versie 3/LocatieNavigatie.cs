using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deelopdracht_2_versie_3
{
    public partial class NavigatieScherm
    {
        public class LocatieNavigatie : NavigatieScherm
        {
            private Locatie locatie;

            public LocatieNavigatie(Form previousForm, Locatie locatie)
                : base(previousForm)
            {
                this.locatie = locatie;

                idLabel.Text = "locatieId: " + locatie.LocatieId;
                primaryObjectName.Text = "Locatie";
                secondaryObjectName.Text = "Boekenkasten";

                secondaryObjectSelection.DisplayMember = "Plaats";
                secondaryObjectSelection.DataSource = locatie.Boekenkasten;

                AddAttributeTextBox("Naam", "Naam:", locatie.Naam);

                saveButton.Click += new EventHandler(this.saveButton_Click);
                
            }

            private void saveButton_Click(object sender, EventArgs e)
            {
                this.locatie.Update((attributePanel.Controls.Find("Naam", true).First() as TextBox).Text);
            }
        }
    }
}
