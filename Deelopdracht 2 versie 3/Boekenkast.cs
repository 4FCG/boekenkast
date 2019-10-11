using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Deelopdracht_2_versie_3.SqlTools;

namespace Deelopdracht_2_versie_3
{
    class Boekenkast
    {
        private int kastId;
        private string plaats;
        private List<Vak> vakken;
        private Locatie locatie;

        public Boekenkast(Locatie locatie, DataRow parentRow)
        {
            this.kastId = Convert.ToInt32(parentRow["kastId"]);
            this.plaats = parentRow["plaats"].ToString();
            this.locatie = locatie;

            using (DataTable vakken = SqlRead("SELECT * FROM Vak WHERE kastId = @kastId ;", this.kastId))
            {
                foreach (DataRow childRow in vakken.Rows)
                {
                    this.vakken.Add(new Vak(this, childRow));
                }
            }
        }

    }
}
