using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Microsoft365_E5_Renew_X.Infrastructure.Respository;

public interface IRepositoryBase<TEntity, TPrimaryKey> where TEntity : class
{
	IQueryable<TEntity> GetAll();

	List<TEntity> GetAllList();

	Task<List<TEntity>> GetAllListAsync();

	List<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

	Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);

	TEntity Single(Expression<Func<TEntity, bool>> predicate);

	Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

	TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

	Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

	TEntity Insert(TEntity entity);

	Task<TEntity> InsertAsync(TEntity entity);

	TEntity Update(TEntity entity);

	Task<TEntity> UpdateAsync(TEntity entity);

	void Delete(TEntity entity);

	Task DeleteAsync(TEntity entity);

	void Delete(Expression<Func<TEntity, bool>> predicate);

	Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

	int Count();

	Task<int> CountAsync();

	int Count(Expression<Func<TEntity, bool>> predicate);

	Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

	long LongCount();

	Task<long> LongCountAsync();

	long LongCount(Expression<Func<TEntity, bool>> predicate);

	Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);
}
