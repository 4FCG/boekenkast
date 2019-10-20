using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Deelopdracht_2_versie_3.SqlTools;

namespace Deelopdracht_2_versie_3
{
    public class Vak : IDatabaseObject
    {
        public Dictionary<string, object> ObjectData { get; private set; }
        public Dictionary<string, Type> RequiredData { get; private set; } = new Dictionary<string, Type>
        {
            ["boekenkastId"] = typeof(Boekenkast),
            ["naam"] = typeof(string),
        };
        public List<Locatie> Source { get; private set; }
        public Boekenkast Boekenkast { get; private set; }

        public int Id { get; private set; }

        public string Naam { get { return this.ObjectData["naam"].ToString(); } }

        public Vak(Boekenkast boekenkast, Dictionary<string, object> objectData)
        {
            this.Boekenkast = boekenkast;

            this.ObjectData = new Dictionary<string, object>
            {
                ["contents"] = new List<Boek>()
            };
            this.ObjectData["boekenkastId"] = Convert.ToInt32(objectData["boekenkastId"]);
            this.ObjectData["naam"] = objectData["naam"].ToString();
            this.ObjectData["contentsNaam"] = "Boeken";
            this.ObjectData["contentsData"] = new Dictionary<string, Type>
            {
                ["vakId"] = typeof(Vak),
                ["titel"] = typeof(string),
                ["genre"] = typeof(string),
                ["auteurId"] = typeof(string)
            };

            if (objectData.ContainsKey("vakId"))
            {
                this.Id = Convert.ToInt32(objectData["vakId"]);
                using (DataTable boeken = SqlRead("SELECT * FROM Boek WHERE vakId = @vakId ;", this.Id))
                {
                    foreach (DataRow row in boeken.Rows)
                    {
                        (this.ObjectData["contents"] as List<Boek>).Add(new Boek(this, RowToDict(row)));
                    }
                }
            }
            else
            {
                object vakId = SqlWrite("INSERT INTO Vak (boekenkastId, naam) OUTPUT INSERTED.vakId VALUES (@boekenkastId , @naam );", objectData["boekenkastId"], objectData["naam"]);
                this.Id = Convert.ToInt32(vakId);
            }
        }

        public void Delete()
        {
            foreach (Boek boek in (this.ObjectData["contents"] as List<Boek>).ToList<Boek>())
            {
                boek.Delete();
            }
            SqlWrite("DELETE FROM Vak WHERE vakId = @vakId ;", this.Id);
            (this.Boekenkast.ObjectData["contents"] as List<Vak>).Remove(this);
        }

        public void Update(Dictionary<string, object> objectData)
        {
            this.ObjectData["boekenkastId"] = Convert.ToInt32(objectData["boekenkastId"]);
            this.ObjectData["naam"] = objectData["naam"].ToString();
            (this.Boekenkast.ObjectData["contents"] as List<Vak>).Remove(this);
            foreach(Locatie locatie in this.Boekenkast.Locatie.Source)
            {
                foreach(Boekenkast boekenkast in (locatie.ObjectData["contents"] as List<Boekenkast>))
                {
                    if (boekenkast.Id == Convert.ToInt32(objectData["boekenkastId"]))
                    {
                        (boekenkast.ObjectData["contents"] as List<Vak>).Add(this);
                    }
                }
            }
            SqlWrite("UPDATE Vak SET naam = @naam , boekenkastId = @boekenkastId WHERE vakId = @vakId ;", objectData["naam"], objectData["boekenkastId"], this.Id);
        }
    }
}
