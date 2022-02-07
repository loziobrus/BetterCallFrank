using BCF.Model.Entities;
using System.Linq;

namespace BCF.DataAccess.Interfaces.Repositories
{
    public interface IWarehouseRepository : IBaseRepository<Warehouse, string>
    {
        public new IQueryable<Warehouse> GetAll();
    }
}
