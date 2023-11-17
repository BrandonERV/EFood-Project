using EFood.Models.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository.IRepository

{
    public interface IRepository<T> where T : class
    {

        Task<T> get(int id);

        Task<IEnumerable<T>> getAll(
            Expression<Func<T, bool>> filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string incluirPropiedades = null,
            bool isTracking = true
            );

        PagedList<T> getAllPaginated(
            Parameters parameters,
            Expression<Func<T, bool>> filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string incluirPropiedades = null,
            bool isTracking = true
            );

        Task<T> getFirst(
            Expression<Func<T, bool>> filtro = null,
            string incluirPropiedades = null,
            bool isTracking = true
            );

        Task Add(T entidad);

        void Remove(T entidad);

        void RemoveRange(IEnumerable<T> entidad);

    }
}