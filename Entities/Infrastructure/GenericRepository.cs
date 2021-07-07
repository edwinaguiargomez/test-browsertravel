using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebApi.Entities;

namespace Entities.Infrastructure
{
    public class GenericRepository<T> where T : EntityInfrastructure
    {
        private DbSet<T> DbSet;
        private Context Context = new Context();

        public GenericRepository()
        {
            this.DbSet = Context.Set<T>();
            Context.Database.EnsureCreated();
        }

        /// <summary>
        /// Obtiene lista completa del objeto enviada
        /// </summary>
        /// <returns></returns>
        public virtual List<T> Get()
        {
            return GetAll(x => true);
        }

        /// <summary>
        /// Obtiene el objeto enviado segun su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Get(Int32 id)
        {
            return GetById(x => x.Id == id);
        }

        /// <summary>
        /// Crea un registro del objeto enviado
        /// </summary>
        /// <param name="entidad"></param>
        public virtual T Create(T entidad)
        {
            try
            {
                Context.Entry(entidad).State = EntityState.Added;
                Context.SaveChanges();
                return entidad;

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza un registro del objeto enviado
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public virtual T Update(T entidad)
        {
            try
            {
                Context.Entry(entidad).State = EntityState.Modified;
                Context.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina un registro del objeto enviado
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public virtual T Remove(T entidad)
        {
            try
            {
                Context.Entry(entidad).State = EntityState.Deleted;
                Context.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        private T GetById(Expression<Func<T, bool>> predicate)
        {
            try
            {
                IQueryable<T> result = null;
                IEnumerable<INavigation> navigationProperties = Context.Model.FindEntityType(typeof(T)).GetNavigations();
                if (navigationProperties.Count() > 0)
                {
                    foreach (var item in navigationProperties)
                        result = this.DbSet.Include(item.Name);
                    return result.FirstOrDefault(predicate);
                }
                else
                    return this.DbSet.FirstOrDefault(predicate);
            }
            catch
            {
                throw;
            }
        }

        private List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            try
            {
                IQueryable<T> result = null;
                IEnumerable<INavigation> navigationProperties = Context.Model.FindEntityType(typeof(T)).GetNavigations();
                if (navigationProperties.Count() > 0)
                {
                    foreach (var item in navigationProperties)
                        result = this.DbSet.Include(item.Name);
                    return result.Where(predicate).ToList();
                }
                else
                    return this.DbSet.Where(predicate).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
