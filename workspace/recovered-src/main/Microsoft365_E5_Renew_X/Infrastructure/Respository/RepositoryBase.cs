using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Microsoft365_E5_Renew_X.Infrastructure.Respository;

public class RepositoryBase<TEntity, TPrimaryKey> : IRepositoryBase<TEntity, TPrimaryKey> where TEntity : class
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public TEntity entity;

		public _003C_003Ec__DisplayClass29_0()
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
			base._002Ector();
		}

		internal bool _003CAttachIfNot_003Eb__0(EntityEntry ent)
		{
			return _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030C._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ent, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030C._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030D) == entity;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CDeleteAsync_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public RepositoryBase<TEntity, TPrimaryKey> _003C_003E4__this;

		public TEntity entity;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			RepositoryBase<TEntity, TPrimaryKey> repositoryBase = _003C_003E4__this;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					repositoryBase.AttachIfNot(entity);
					repositoryBase.Table.Remove(entity);
					awaiter = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(repositoryBase.SaveAsync(), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030F);
					if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0310._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref awaiter, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0310._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0311))
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref awaiter, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0313);
			}
			catch (Exception ex)
			{
				_003C_003E1__state = -2;
				_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0314._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003C_003Et__builder, ex, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0314._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0315);
				return;
			}
			_003C_003E1__state = -2;
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0316._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003C_003Et__builder, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0316._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0317);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0318._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003C_003Et__builder, stateMachine, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0318._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0300);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CDeleteAsync_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public RepositoryBase<TEntity, TPrimaryKey> _003C_003E4__this;

		public Expression<Func<TEntity, bool>> predicate;

		private List<TEntity>.Enumerator _003C_003E7__wrap1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			RepositoryBase<TEntity, TPrimaryKey> repositoryBase = _003C_003E4__this;
			try
			{
				if (num != 0)
				{
					_003C_003E7__wrap1 = repositoryBase.GetAll().Where(predicate).ToList()
						.GetEnumerator();
				}
				try
				{
					if (num != 0)
					{
						goto IL_00bb;
					}
					TaskAwaiter awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00af;
					IL_00af:
					_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref awaiter, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0313);
					goto IL_00bb;
					IL_00bb:
					if (_003C_003E7__wrap1.MoveNext())
					{
						TEntity current = _003C_003E7__wrap1.Current;
						awaiter = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(repositoryBase.DeleteAsync(current), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030F);
						if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0310._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref awaiter, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0310._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0311))
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_00af;
					}
				}
				finally
				{
					if (num < 0)
					{
						((IDisposable)_003C_003E7__wrap1/*cast due to .constrained prefix*/).Dispose();
					}
				}
				_003C_003E7__wrap1 = default(List<TEntity>.Enumerator);
			}
			catch (Exception ex)
			{
				_003C_003E1__state = -2;
				_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0314._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003C_003Et__builder, ex, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0314._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0315);
				return;
			}
			_003C_003E1__state = -2;
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0316._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003C_003Et__builder, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0316._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0317);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0318._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003C_003Et__builder, stateMachine, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0318._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0300);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSaveAsync_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public RepositoryBase<TEntity, TPrimaryKey> _003C_003E4__this;

		private TaskAwaiter<int> _003C_003Eu__1;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			RepositoryBase<TEntity, TPrimaryKey> repositoryBase = _003C_003E4__this;
			try
			{
				TaskAwaiter<int> awaiter;
				if (num != 0)
				{
					awaiter = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(repositoryBase._dbContext, default(CancellationToken), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030B).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<int>);
					num = (_003C_003E1__state = -1);
				}
				awaiter.GetResult();
			}
			catch (Exception ex)
			{
				_003C_003E1__state = -2;
				_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0314._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003C_003Et__builder, ex, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0314._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0315);
				return;
			}
			_003C_003E1__state = -2;
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0316._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003C_003Et__builder, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0316._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0317);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0318._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003C_003Et__builder, stateMachine, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0318._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0300);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	protected readonly AppDbContext _dbContext;

	public virtual DbSet<TEntity> Table => _dbContext.Set<TEntity>();

	public RepositoryBase(AppDbContext dbContext)
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		base._002Ector();
		_dbContext = dbContext;
	}

	public IQueryable<TEntity> GetAll()
	{
		return Table.AsQueryable();
	}

	public List<TEntity> GetAllList()
	{
		return GetAll().ToList();
	}

	public async Task<List<TEntity>> GetAllListAsync()
	{
		return await GetAll().ToListAsync();
	}

	public List<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
	{
		return GetAll().Where(predicate).ToList();
	}

	public async Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
	{
		return await GetAll().Where(predicate).ToListAsync();
	}

	public TEntity Single(Expression<Func<TEntity, bool>> predicate)
	{
		return GetAll().Single(predicate);
	}

	public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
	{
		return await GetAll().SingleAsync(predicate);
	}

	public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
	{
		return GetAll().FirstOrDefault(predicate);
	}

	public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
	{
		return await GetAll().FirstOrDefaultAsync(predicate);
	}

	public TEntity Insert(TEntity entity)
	{
		TEntity entity2 = Table.Add(entity).Entity;
		Save();
		return entity2;
	}

	public async Task<TEntity> InsertAsync(TEntity entity)
	{
		EntityEntry<TEntity> entityEntry = await Table.AddAsync(entity);
		TaskAwaiter taskAwaiter = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(SaveAsync(), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030F);
		if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0310._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref taskAwaiter, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0310._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0311))
		{
			await taskAwaiter;
			TaskAwaiter taskAwaiter2 = default(TaskAwaiter);
			taskAwaiter = taskAwaiter2;
		}
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref taskAwaiter, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0313);
		return entityEntry.Entity;
	}

	public TEntity Update(TEntity entity)
	{
		AttachIfNot(entity);
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_dbContext.Entry(entity), EntityState.Modified, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0306);
		Save();
		return entity;
	}

	public async Task<TEntity> UpdateAsync(TEntity entity)
	{
		AttachIfNot(entity);
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_dbContext.Entry(entity), EntityState.Modified, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0306);
		TaskAwaiter taskAwaiter = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(SaveAsync(), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030F);
		if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0310._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref taskAwaiter, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0310._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0311))
		{
			await taskAwaiter;
			TaskAwaiter taskAwaiter2 = default(TaskAwaiter);
			taskAwaiter = taskAwaiter2;
		}
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref taskAwaiter, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_0313);
		return entity;
	}

	public void Delete(TEntity entity)
	{
		AttachIfNot(entity);
		Table.Remove(entity);
		Save();
	}

	[AsyncStateMachine(typeof(RepositoryBase<, >._003CDeleteAsync_003Ed__18))]
	public Task DeleteAsync(TEntity entity)
	{
		_003CDeleteAsync_003Ed__18 stateMachine = default(_003CDeleteAsync_003Ed__18);
		stateMachine._003C_003Et__builder = _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0307._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0307._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0308);
		stateMachine._003C_003E4__this = this;
		stateMachine.entity = entity;
		stateMachine._003C_003E1__state = -1;
		stateMachine._003C_003Et__builder.Start(ref stateMachine);
		return _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref stateMachine._003C_003Et__builder, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_030A);
	}

	public void Delete(Expression<Func<TEntity, bool>> predicate)
	{
		foreach (TEntity item in GetAll().Where(predicate).ToList())
		{
			Delete(item);
		}
	}

	[AsyncStateMachine(typeof(RepositoryBase<, >._003CDeleteAsync_003Ed__20))]
	public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
	{
		_003CDeleteAsync_003Ed__20 stateMachine = default(_003CDeleteAsync_003Ed__20);
		stateMachine._003C_003Et__builder = _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0307._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0307._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0308);
		stateMachine._003C_003E4__this = this;
		stateMachine.predicate = predicate;
		stateMachine._003C_003E1__state = -1;
		stateMachine._003C_003Et__builder.Start(ref stateMachine);
		return _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref stateMachine._003C_003Et__builder, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_030A);
	}

	public int Count()
	{
		return GetAll().Count();
	}

	public async Task<int> CountAsync()
	{
		return await GetAll().CountAsync();
	}

	public int Count(Expression<Func<TEntity, bool>> predicate)
	{
		return GetAll().Where(predicate).Count();
	}

	public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
	{
		return await GetAll().Where(predicate).CountAsync();
	}

	public long LongCount()
	{
		return GetAll().LongCount();
	}

	public async Task<long> LongCountAsync()
	{
		return await GetAll().LongCountAsync();
	}

	public long LongCount(Expression<Func<TEntity, bool>> predicate)
	{
		return GetAll().Where(predicate).LongCount();
	}

	public async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
	{
		return await GetAll().Where(predicate).LongCountAsync();
	}

	protected virtual void AttachIfNot(TEntity entity)
	{
		_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass29_0();
		CS_0024_003C_003E8__locals3.entity = entity;
		EntityEntry entityEntry = _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_030D._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_030B._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_dbContext, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_030B._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_030C), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_030D._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_030E).FirstOrDefault((EntityEntry ent) => _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030C._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ent, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030C._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030D) == CS_0024_003C_003E8__locals3.entity);
		if (entityEntry == null)
		{
			Table.Attach(CS_0024_003C_003E8__locals3.entity);
		}
	}

	protected void Save()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_dbContext, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_030F);
	}

	[AsyncStateMachine(typeof(RepositoryBase<, >._003CSaveAsync_003Ed__31))]
	protected Task SaveAsync()
	{
		_003CSaveAsync_003Ed__31 stateMachine = default(_003CSaveAsync_003Ed__31);
		stateMachine._003C_003Et__builder = _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0307._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0307._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0308);
		stateMachine._003C_003E4__this = this;
		stateMachine._003C_003E1__state = -1;
		stateMachine._003C_003Et__builder.Start(ref stateMachine);
		return _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref stateMachine._003C_003Et__builder, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_030A);
	}
}
