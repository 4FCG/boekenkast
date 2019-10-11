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
    public partial class Form1 : Form
    {
        private List<Locatie> locaties = new List<Locatie>();
        public Form1()
        {
            InitializeComponent();

            using(DataTable locaties = SqlRead("SELECT * FROM Locatie"))
            {
                foreach(DataRow row in locaties.Rows)
                {
                    this.locaties.Add(new Locatie(row));
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
