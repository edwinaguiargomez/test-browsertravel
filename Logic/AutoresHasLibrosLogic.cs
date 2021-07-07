using AssemblyStructure;
using Entities;

namespace Logic
{
    public partial class AutoresHasLibrosLogic : GenericRepository<AutoresHasLibros>
    {
        public AutoresHasLibrosLogic() { }

        public AutoresHasLibrosLogic(IDBConfig dBConfig) : base(dBConfig) { }
    }
}
