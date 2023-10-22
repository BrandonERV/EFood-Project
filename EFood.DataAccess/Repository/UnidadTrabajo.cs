using EFood.DataAccess.Data;
using EFood.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository
{
    public class UnidadTrabajo : IUnidadTrabajo
    {

        private readonly ApplicationDbContext _db;

        public IUserRepository User { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            User = new UserRepository(_db);
        }


        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();    
        }
    }
}
