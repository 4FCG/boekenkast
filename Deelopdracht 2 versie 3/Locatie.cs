using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Deelopdracht_2_versie_3.SqlTools;

namespace Deelopdracht_2_versie_3
{
    class Locatie
    {
        public int LocatieId { get; }
        public string Naam { get; private set; }
        public List<Boekenkast> Boekenkasten { get; private set; } = new List<Boekenkast>();
        private List<Locatie> locaties;

        
        public Locatie(List<Locatie> locaties, object locatieId, object naam)
        {
            this.LocatieId = Convert.ToInt32(locatieId);
            this.Naam = naam.ToString();
            this.locaties = locaties;

            using (DataTable boekenkasten = SqlRead("SELECT * FROM Boekenkast WHERE locatieId = @locatieId ;", this.LocatieId))
            {
                foreach (DataRow childRow in boekenkasten.Rows)
                {
                    this.Boekenkasten.Add(new Boekenkast(this, childRow["kastId"], childRow["plaats"]));
                }
            }
        }
        public void Update(string naam)
        {
            this.Naam = naam;
            SqlWrite("UPDATE Locatie SET naam = @naam WHERE locatieId = @locatieId ;", naam, this.LocatieId);
        }

        public void NewBoekenkast(string plaats)
        {
            object kastId = SqlWrite("INSERT INTO Boekenkast (plaats, locatieId) OUTPUT INSERTED.kastId VALUES (@plaats , @locatieId );", plaats, this.LocatieId);
            this.Boekenkasten.Add(new Boekenkast(this, kastId, plaats));
        }

        public void Delete()
        {
            foreach (Boekenkast kast in this.Boekenkasten)
            {
                kast.Delete();
            }
            SqlWrite("DELETE FROM Locatie WHERE locatieId = @locatieId ;", this.LocatieId);
            this.locaties.Remove(this);
        }
    }
}
