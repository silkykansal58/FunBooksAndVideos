using System;
using System.Linq.Expressions;

namespace FunBooksAndVideos.Repository.BaseRepository
{
    // TBD - difference between IQueryable , IEumerable.

    // With IQuerybale you can attach Async.
    // IEnumerbale we can't use Async.

	public interface IGenericRepostory<T>  where T : class
	{
        IQueryable<T> GetAllAsync();
        IQueryable<T> FindByConditionAsync(Expression<Func<T,bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}

