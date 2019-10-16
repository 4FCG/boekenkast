using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Deelopdracht_2_versie_3.SqlTools;

namespace Deelopdracht_2_versie_3
{
    public class Boekenkast : IAlgemeenDatabaseObject
    {
        public int KastId { get; }
        public string Plaats { get; private set; }
        private List<Vak> vakken = new List<Vak>();
        public Locatie Locatie { get; private set; }

        public Boekenkast(Locatie locatie, object kastId, object plaats)
        {
            this.KastId = Convert.ToInt32(kastId);
            this.Plaats = plaats.ToString();
            this.Locatie = locatie;

            using (DataTable vakken = SqlRead("SELECT * FROM Vak WHERE kastId = @kastId ;", this.KastId))
            {
                foreach (DataRow childRow in vakken.Rows)
                {
                    this.vakken.Add(new Vak(this, childRow));
                }
            }
        }

        public void Delete()
        {

        }

        public void Update(Dictionary<string, string> objectData)
        {
            
        }
    }
}
