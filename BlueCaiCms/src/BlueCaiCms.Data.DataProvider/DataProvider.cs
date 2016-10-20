using BlueCaiCms.BLL;
using BlueCaiCms.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCaiCms.Data.DataProvider
{
    public class DataProvider : IDataProvider
    {
        private readonly BCDbContext dbContext;
        public DataProvider(BCDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<T> Find<T>() where T : class, new()
        {
            return dbContext.Set<T>();
        }

        public void Create<T>(T entity) where T : class, new()
        {
            dbContext.Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : class, new()
        {
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class, new()
        {
            dbContext.Set<T>().Remove(entity);
        }
    }
}
