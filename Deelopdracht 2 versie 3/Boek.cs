using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Deelopdracht_2_versie_3.SqlTools;

namespace Deelopdracht_2_versie_3
{
    class Boek
    {
        private int boekId;
        private string titel;
        private int auteurId;
        private string genre;
        private Vak vak;

        public Boek(Vak vak, DataRow parentRow)
        {
            this.vak = vak;
            this.boekId = Convert.ToInt32(parentRow["boekId"]);
            this.titel = parentRow["titel"].ToString();
            this.genre = parentRow["genre"].ToString();
            this.auteurId = Convert.ToInt32(parentRow["auteurId"]);
        }
    }
}
