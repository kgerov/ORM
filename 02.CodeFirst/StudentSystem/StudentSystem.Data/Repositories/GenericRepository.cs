using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
namespace StudentSystem.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public GenericRepository(IStudentSystemDbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IStudentSystemDbContext Context { get; set; }
        protected IDbSet<T> DbSet { get; set; }

        public IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public IQueryable<T> Find(Expression<System.Func<T, bool>> expression)
        {
            return this.DbSet.Where(expression);
        }

        public T Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
            return entity;
        }

        public T Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
            return entity;
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Delete(object id)
        {
            var entity = this.DbSet.Find(id);
            this.Delete(entity);
        }

        //public int SaveChanges()
        //{
        //    return this.Context.SaveChanges();
        //}

        private T ChangeState(T entity, EntityState state)
        {
            this.AttachIfDetached(entity);
            var entry = this.Context.Entry(entity);
            entry.State = state;

            return entity;
        }

        private void AttachIfDetached(T Entity)
        {
            var entry = this.Context.Entry(Entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
        }
    }
}
