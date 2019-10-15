using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Deelopdracht_2_versie_3.SqlTools;

namespace Deelopdracht_2_versie_3
{
    public partial class Hoofdpagina : Form
    {
        public List<Locatie> Locaties { get; set; } = new List<Locatie>();
        public Hoofdpagina()
        {
            InitializeComponent();
            using (DataTable locatieData = SqlRead("SELECT * FROM Locatie"))
            {
                foreach (DataRow row in locatieData.Rows)
                {
                    this.Locaties.Add(new Locatie(this.Locaties, row["locatieId"], row["naam"]));
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NavigatieScherm.LocatieNavigatie form1 = new NavigatieScherm.LocatieNavigatie(this, this.Locaties[0]);
            form1.Show();
        }
    }
}
