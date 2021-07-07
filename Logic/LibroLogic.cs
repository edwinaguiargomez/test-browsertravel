using AssemblyStructure;
using Entities;

namespace Logic
{
    public partial class LibroLogic : GenericRepository<Libro>
    {
        public LibroLogic() { }

        public LibroLogic(IDBConfig dBConfig) : base(dBConfig) { }
    }
}
