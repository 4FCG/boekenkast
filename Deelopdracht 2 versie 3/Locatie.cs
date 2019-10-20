using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Deelopdracht_2_versie_3.SqlTools;

namespace Deelopdracht_2_versie_3
{
    public class Locatie : IDatabaseObject
    {
        public Dictionary<string, object> ObjectData { get; private set; }
        public Dictionary<string, Type> RequiredData { get; private set; } = new Dictionary<string, Type>
        {
            ["naam"] = typeof(string),
        };

        public List<Locatie> Source { get; private set; }

        public int Id { get; private set; }

        public string Naam { get { return this.ObjectData["naam"].ToString(); } }

        public Locatie(List<Locatie> container, Dictionary<string, object> objectData)
        {
            this.Source = container;
            this.ObjectData = new Dictionary<string, object>
            {
                ["contents"] = new List<Boekenkast>()
            };
            this.ObjectData["naam"] = objectData["naam"].ToString();
            this.ObjectData["contentsNaam"] = "Boekenkasten";
            this.ObjectData["contentsData"] = new Dictionary<string, Type>
            {
                ["locatieId"] = typeof(Locatie),
                ["plaats"] = typeof(string),
            };

            if (objectData.ContainsKey("locatieId"))
            {
                this.Id = Convert.ToInt32(objectData["locatieId"]);
                using (DataTable boekenkasten = SqlRead("SELECT * FROM Boekenkast WHERE locatieId = @locatieId ;", this.Id))
                {
                    foreach (DataRow row in boekenkasten.Rows)
                    {
                        (this.ObjectData["contents"] as List<Boekenkast>).Add(new Boekenkast(this, RowToDict(row)));
                    }
                }
            }
            else
            {
                object locatieId = SqlWrite("INSERT INTO Locatie (naam) OUTPUT INSERTED.locatieId VALUES (@naam );", objectData["naam"]);
                this.Id = Convert.ToInt32(locatieId);
            }
        }

        public void Update(Dictionary<string, object> objectData)
        {
            this.ObjectData["naam"] = objectData["naam"].ToString();
            SqlWrite("UPDATE Locatie SET naam = @naam WHERE locatieId = @locatieId ;", objectData["naam"], this.Id);
        }

        public void Delete()
        {
            foreach (Boekenkast kast in (this.ObjectData["contents"] as List<Boekenkast>).ToList<Boekenkast>())
            {
                kast.Delete();
            }
            SqlWrite("DELETE FROM Locatie WHERE locatieId = @locatieId ;", this.Id);
            this.Source.Remove(this);
        }
    }
}
