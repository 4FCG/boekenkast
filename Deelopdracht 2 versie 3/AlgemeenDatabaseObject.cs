using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deelopdracht_2_versie_3
{
    public interface IAlgemeenDatabaseObject
    {
        void Delete();

        void Update(Dictionary<string, string> objectData);
    }
}
