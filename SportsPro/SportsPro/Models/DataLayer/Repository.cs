using Microsoft.EntityFrameworkCore;
using SportsPro.Models.DomainModels;
namespace SportsPro.Models.DataLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected SportsContext Context { get; set; }
        private DbSet<T> dbset { get; set; }
        public Repository(SportsContext ctx)
        {
            Context = ctx;
            dbset = Context.Set<T>();
        }
        public void Delete(T entity) => dbset.Remove(entity);

        public T? Get(int id) => dbset.Find(id);

        public T? Get(QueryOptions<T> options)
        {
            IQueryable<T> query = dbset;
            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }
            if (options.HasWhere)
                query = query.Where(options.Where);
            return query.FirstOrDefault();
        }

        public void Insert(T entity) => dbset.Add(entity);

        public IEnumerable<T> List(QueryOptions<T> options)
        {
            IQueryable<T> query = dbset;
            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }
            if (options.HasWhere)
                query = query.Where(options.Where);
            if (options.HasOrderBy)
            {
                if (options.HasThenOrderBy)
                {
                    query = query.OrderBy(options.OrderBy).ThenBy(options.ThenOrderBy);
                }
                else
                {
                    query = query.OrderBy(options.OrderBy);
                }
            }
            return query.ToList();
        }

        public void Save() => Context.SaveChanges();

        public void Update(T entity) => dbset.Update(entity);
    }
}
