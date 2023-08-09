using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Repository.BaseRepository;

public class GenericRepository<T> : IGenericRepostory<T> where T : class
{
    private DbContext DbContext { get; set; }

    public GenericRepository(DbContext dbContext)
    {
        this.DbContext = dbContext;
    }

    public IQueryable<T> FindByConditionAsync(Expression<Func<T, bool>> expression)
    {
        return DbContext.Set<T>().Where(expression);
    }

    public IQueryable<T> GetAllAsync()
    {
        return DbContext.Set<T>();
    }

    public void Create(T entity)
    {
        DbContext.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        DbContext.Set<T>().Remove(entity);
    }

    // Similar to commit;
    public void Save()
    {
        DbContext.SaveChanges();
    }

    public void Update(T entity)
    {
        DbContext.Set<T>().Update(entity);
    }
}

