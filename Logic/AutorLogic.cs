using AssemblyStructure;
using Entities;

namespace Logic
{
    public partial class AutorLogic : GenericRepository<Autor>
    {
        public AutorLogic() { }

        public AutorLogic(IDBConfig dBConfig) : base(dBConfig) { }
    }
}
