using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Deelopdracht_2_versie_3.SqlTools;

namespace Deelopdracht_2_versie_3
{
    static class FormTools
    {
        private class Item 
        { 
            public string Naam { get; }
            public int Id { get;  }

            public Item(string naam, int id)
            {
                this.Naam = naam;
                this.Id = id;
            }
        }
        //Adds textbox, with a lable in front of it, to the attributePanel at the appropriate height.
        public static void AddAttributeTextBox(Panel attributePanel, KeyValuePair<string, Type> attribute, object value)
        {
            int verticalOffset = attributePanel.Controls.Count * 15;

            //display label in front of textbox
            Label displayLabel = new Label
            {
                Text = attribute.Key + ":",
                Location = new Point(0, verticalOffset + 3),
                AutoSize = true
            };
            attributePanel.Controls.Add(displayLabel);

            if (typeof(IDatabaseObject).IsAssignableFrom(attribute.Value))
            {
                //Combobox with filled with all other objects of the same type, current value as default
                ComboBox comboBox = new ComboBox
                {
                    Name = attribute.Key,
                    ValueMember = "Id",
                    DisplayMember = "Naam",
                    Location = new Point(displayLabel.Width + 5, verticalOffset)
                };

                List<Item> items = new List<Item>();
                foreach (Dictionary<string, object> databaseObject in SearchDatabaseObject(attribute.Value)) 
                {
                    string naam; 
                    if (typeof(Boekenkast).Equals(attribute.Value))
                    {
                        naam = databaseObject["plaats"].ToString();
                    }
                    else
                    {
                        naam = databaseObject["naam"].ToString();
                    }
                    
                    var item = new Item(naam, Convert.ToInt32(databaseObject[attribute.Key]));
                    items.Add(item);
                }
                if (items.Count > 1)
                {
                    int index = items.FindIndex(i => i.Id == (int)value);
                    if (index > -1)
                    {
                        Item defaultItem = items[index];
                        items[index] = items[0];
                        items[0] = defaultItem;
                    }
                }
                comboBox.DataSource = items;

                attributePanel.Controls.Add(comboBox);
                
            }
            else
            {
                if (value.ToString() == "-1")
                {
                    value = "";
                }
                //textbox with current value as default
                attributePanel.Controls.Add(new TextBox
                {
                    Name = attribute.Key,
                    Text = value.ToString(),
                    Location = new Point(displayLabel.Width + 5, verticalOffset)
                });
            }
        }
    }
}
