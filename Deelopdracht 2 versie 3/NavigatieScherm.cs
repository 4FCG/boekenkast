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

        public NavigatieScherm(Form previousForm)
        {
            this.previousForm = previousForm;
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
    }
}
