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
    public partial class ZoekScherm : Form
    {
        private Form previousForm;
        private string query;
        private int inputType;
        public ZoekScherm(Form previousForm, int inputType, string query, string zoeknaam, string sourceQuery = "", string displayMember = "", string valueMember = "")
        {
            this.previousForm = previousForm;
            this.query = query;
            this.inputType = inputType;
            InitializeComponent();
            label1.Text = zoeknaam;
            this.textBox1.Hide();
            this.comboBox1.Hide();

            if (this.inputType == 1)
            {
                this.textBox1.Show();
            }
            else if (this.inputType == 2)
            {
                this.comboBox1.Show();
                DataTable datatable = SqlTools.SqlRead(sourceQuery);
                comboBox1.ValueMember = valueMember;
                comboBox1.DisplayMember = displayMember;
                comboBox1.DataSource = datatable;
            }
            else
            {
                zoekButton.Hide();
                using (DataTable datatable = SqlTools.SqlRead(this.query))
                {
                    dataGridView1.DataSource = datatable;
                }
            }
        }

        private void zoekButton_Click(object sender, EventArgs e)
        {
            if (this.inputType == 1)//textbox
            {
                if (textBox1.TextLength > 0)
                {
                    using (DataTable datatable = SqlTools.SqlRead(this.query, textBox1.Text))
                    {
                        dataGridView1.DataSource = datatable;
                    }
                }
            }
            else if (this.inputType == 2) //combobox
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    using (DataTable datatable = SqlTools.SqlRead(this.query, comboBox1.SelectedValue))
                    {
                        dataGridView1.DataSource = datatable;
                    }
                }
            }
            else//no input
            {

            }
            
            
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.previousForm.Show();
            this.Close();
        }
    }
}
