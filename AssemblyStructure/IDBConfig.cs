using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyStructure
{
    public interface IDBConfig
    {
        string PathDB { get; set; }
        string GetStringConnection();
    }
}
