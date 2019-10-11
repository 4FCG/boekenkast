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
        private int locatieId;
        private string naam;
        private List<Boekenkast> boekenkasten = new List<Boekenkast>();
        public Locatie(DataRow parentRow)
        {
            this.locatieId = Convert.ToInt32(parentRow["locatieId"]);
            this.naam = parentRow["naam"].ToString();
            using (DataTable boekenkasten = SqlRead("SELECT * FROM Boekenkast WHERE locatieId = @locatieId ;", this.locatieId))
            {
                foreach (DataRow childRow in boekenkasten.Rows)
                {
                    this.boekenkasten.Add(new Boekenkast(this, childRow));
                }
            }
        }
        public void Update(string naam)
        {
            this.naam = naam;
            SqlWrite("UPDATE Locatie SET naam = @naam WHERE locatieId = @locatieId ;", naam, this.locatieId);
        }

        public void NewBoekenkast(string plaats)
        {
            SqlWrite("INSERT INTO Boekenkast (plaats, locatieId) VALUES (@plaats , @locatieId );", plaats, this.locatieId);
            using (DataRow row = SqlRead("SELECT * FROM Boekenkast WHERE "))
            {

            }
                this.boekenkasten.Add(new Boekenkast(this, ));
        }
    }
}
