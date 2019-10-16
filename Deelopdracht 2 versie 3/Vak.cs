using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Deelopdracht_2_versie_3.SqlTools;

namespace Deelopdracht_2_versie_3
{
    public class Vak : IAlgemeenDatabaseObject
    {
        private int vakId;
        private List<Boek> boeken = new List<Boek>();
        private Boekenkast boekenkast;

        public Vak(Boekenkast boekenkast, DataRow parentRow)
        {
            this.vakId = Convert.ToInt32(parentRow["vakId"]);
            this.boekenkast = boekenkast;

            using (DataTable boeken = SqlRead("SELECT * FROM Boek WHERE vakId = @vakId ;", this.vakId))
            {
                foreach (DataRow childRow in boeken.Rows)
                {
                    this.boeken.Add(new Boek(this, childRow));
                }
            }
        }

        public void Delete()
        {

        }
    }
}
