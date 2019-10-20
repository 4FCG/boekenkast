using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Deelopdracht_2_versie_3.SqlTools;

namespace Deelopdracht_2_versie_3
{
    public class Boekenkast : IDatabaseObject
    {
        public Dictionary<string, object> ObjectData { get; private set; }
        public Dictionary<string, Type> RequiredData { get; private set; } = new Dictionary<string, Type>
        {
            ["locatieId"] = typeof(Locatie),
            ["plaats"] = typeof(string),
        };
        public Locatie Locatie { get; private set; }

        public int Id { get; private set; }

        public string Naam { get { return this.ObjectData["plaats"].ToString(); } }

        public Boekenkast(Locatie locatie, Dictionary<string, object> objectData)
        {
            this.Locatie = locatie;

            this.ObjectData = new Dictionary<string, object>
            {
                ["contents"] = new List<Vak>()
            };
            this.ObjectData["locatieId"] = Convert.ToInt32(objectData["locatieId"]);
            this.ObjectData["plaats"] = objectData["plaats"].ToString();
            this.ObjectData["contentsNaam"] = "Vakken";
            this.ObjectData["contentsData"] = new Dictionary<string, Type>
            {
                ["boekenkastId"] = typeof(Boekenkast),
                ["naam"] = typeof(string),
            };

            if (objectData.ContainsKey("boekenkastId"))
            {
                this.Id = Convert.ToInt32(objectData["boekenkastId"]);
                using (DataTable vakken = SqlRead("SELECT * FROM Vak WHERE boekenkastId = @boekenkastId ;", this.Id))
                {
                    foreach (DataRow row in vakken.Rows)
                    {
                        (this.ObjectData["contents"] as List<Vak>).Add(new Vak(this, RowToDict(row)));
                    }
                }
            }
            else
            {
                Console.WriteLine(objectData["plaats"]);
                Console.WriteLine(objectData["locatieId"]);
                object boekenkastId = SqlWrite("INSERT INTO Boekenkast (plaats, locatieId) OUTPUT INSERTED.boekenkastId VALUES (@plaats , @locatieId );", objectData["plaats"], objectData["locatieId"]);
                this.Id = Convert.ToInt32(boekenkastId);
            }
        }

        public void Delete()
        {
            foreach (Vak vak in (this.ObjectData["contents"] as List<Vak>).ToList<Vak>())
            {
                vak.Delete();
            }
            SqlWrite("DELETE FROM Boekenkast WHERE boekenkastId = @boekenkastId ;", this.Id);
            (this.Locatie.ObjectData["contents"] as List<Boekenkast>).Remove(this);
        }

        public void Update(Dictionary<string, object> objectData)
        {
            this.ObjectData["locatieId"] = Convert.ToInt32(objectData["locatieId"]);
            this.ObjectData["plaats"] = objectData["plaats"].ToString();
            (this.Locatie.ObjectData["contents"] as List<Boekenkast>).Remove(this);
            (this.Locatie.Source.Find(l => l.Id == Convert.ToInt32(objectData["locatieId"])).ObjectData["contents"] as List<Boekenkast>).Add(this);
            SqlWrite("UPDATE Boekenkast SET plaats = @plaats , locatieId = @locatieId WHERE boekenkastId = @boekenkastId ;", objectData["plaats"], objectData["locatieId"], this.Id);
        }
    }
}
