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
                    this.locaties.Add(new Locatie(this.locaties, row["locatieId"], row["naam"]));
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //BindingSource source = new BindingSource();
            //source.DataSource = locaties;
            comboBox1.DisplayMember = "Naam";
            comboBox1.DataSource = locaties;
            //RefreshList();
        }

        private void RefreshList()
        {
            comboBox1.Items.Clear();
            foreach (Locatie locatie in this.locaties)
            {
                
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ComboBox box = (ComboBox)sender;
            foreach (Boekenkast boekenkast in (box.SelectedValue as Locatie).Boekenkasten)
            {
                listView1.Items.Add(boekenkast.Plaats);
            }
        }
    }
}
