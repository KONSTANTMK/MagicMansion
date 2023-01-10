using MagicMansion_MansionAPI.Data;
using MagicMansion_MansionAPI.Models;
using MagicMansion_MansionAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicMansion_MansionAPI.Repository
{
	public class MansionRepository : IMansionRepository
	{
		private readonly ApplicationDbContext _db;
		public MansionRepository(ApplicationDbContext db)
		{
			_db= db;
		}
		public async Task CreateAsync(Mansion entity)
		{
			await _db.Mansions.AddAsync(entity);
			await SaveAsync();
		}

		public async Task<Mansion> GetAsync(Expression<Func<Mansion,bool>> filter = null, bool tracked = true)
		{
			IQueryable<Mansion> query = _db.Mansions;
			if (!tracked) query = query.AsNoTracking();
			if(filter !=null) query = query.Where(filter);
			return await query.FirstOrDefaultAsync();
		}

		public async Task<List<Mansion>> GetAllAsync(Expression<Func<Mansion,bool>> filter = null)
		{
			IQueryable<Mansion> query = _db.Mansions;
			if (filter == null) query = query.Where(filter);
			return await query.ToListAsync();
		}

		public async Task RemoveAsync(Mansion entity)
		{
			_db.Mansions.Remove(entity);
			await SaveAsync();
		}

		public async Task SaveAsync()
		{
			 await _db.SaveChangesAsync();
		}

		public async Task UpdateAsync(Mansion entity)
		{
			_db.Mansions.Update(entity);
			await SaveAsync();
		}
	}
}
