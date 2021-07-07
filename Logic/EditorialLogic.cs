using AssemblyStructure;
using Entities;

namespace Logic
{
    public partial class EditorialLogic : GenericRepository<Editorial>
    {
        public EditorialLogic() { }

        public EditorialLogic(IDBConfig dBConfig) : base(dBConfig) { }
    }
}
