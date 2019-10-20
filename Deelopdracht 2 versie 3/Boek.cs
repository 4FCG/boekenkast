using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Deelopdracht_2_versie_3.SqlTools;

namespace Deelopdracht_2_versie_3
{
    public class Boek : IDatabaseObject
    {
        public Dictionary<string, object> ObjectData { get; private set; }
        public Dictionary<string, Type> RequiredData { get; private set; } = new Dictionary<string, Type> 
        { 
            ["vakId"] = typeof(Vak),
            ["titel"] = typeof(string),
            ["genre"] = typeof(string),
            ["auteurId"] = typeof(string)
        };
        public List<Locatie> Source { get; private set; }
        public Vak Vak { get; private set; }

        public int Id { get; private set; }

        public string Naam { get { return this.ObjectData["titel"].ToString(); } }

        public Boek(Vak vak, Dictionary<string, object> objectData)
        {
            this.Vak = vak;

            this.ObjectData = new Dictionary<string, object>();
            this.ObjectData["vakId"] = Convert.ToInt32(objectData["vakId"]);
            this.ObjectData["titel"] = objectData["titel"].ToString();
            this.ObjectData["genre"] = objectData["genre"].ToString();
            this.ObjectData["auteurId"] = Convert.ToInt32(objectData["auteurId"]);

            if (objectData.ContainsKey("boekId"))
            {
                this.Id = Convert.ToInt32(objectData["boekId"]);
            }
            else
            {
                object boekId = SqlWrite("INSERT INTO Boek (vakId, auteurId, titel, genre) OUTPUT INSERTED.boekId VALUES (@vakId , @auteurId , @titel , @genre );", this.ObjectData["vakId"], this.ObjectData["auteurId"], this.ObjectData["titel"], this.ObjectData["genre"]);
                this.Id = Convert.ToInt32(boekId);
            }
        }

        public void Delete()
        {
            SqlWrite("DELETE FROM Boek WHERE boekId = @boekId ;", this.Id);
            (this.Vak.ObjectData["contents"] as List<Boek>).Remove(this);
        }

        public void Update(Dictionary<string, object> objectData)
        {
            this.ObjectData["vakId"] = Convert.ToInt32(objectData["vakId"]);
            this.ObjectData["titel"] = objectData["titel"].ToString();
            this.ObjectData["genre"] = objectData["genre"].ToString();
            this.ObjectData["auteurId"] = Convert.ToInt32(objectData["auteurId"]);

            (this.Vak.ObjectData["contents"] as List<Boek>).Remove(this);
            foreach (Locatie locatie in this.Vak.Boekenkast.Locatie.Source)
            {
                foreach (Boekenkast boekenkast in (locatie.ObjectData["contents"] as List<Boekenkast>))
                {
                    foreach (Vak vak in (boekenkast.ObjectData["contents"] as List<Vak>))
                    {
                        if (vak.Id == Convert.ToInt32(objectData["vakId"]))
                        {
                            (vak.ObjectData["contents"] as List<Boek>).Add(this);
                        }
                    }
                }
            }
            SqlWrite("UPDATE Boek SET vakId = @vakId , titel = @titel , genre = @genre , auteurId = @auteurId WHERE boekId = @boekId ;", objectData["vakId"], objectData["titel"], objectData["genre"], objectData["auteurId"], this.Id);
        }
    }
}
