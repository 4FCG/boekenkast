using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deelopdracht_2_versie_3
{
    public interface IDatabaseObject
    {
        Dictionary<string, object> ObjectData { get; }

        Dictionary<string, Type> RequiredData { get; }

        int Id { get; }

        string Naam { get; }

        void Delete();

        void Update(Dictionary<string, object> objectData);
    }
}
