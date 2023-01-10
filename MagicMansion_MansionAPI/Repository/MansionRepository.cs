using MagicMansion_MansionAPI.Data;
using MagicMansion_MansionAPI.Models;
using MagicMansion_MansionAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicMansion_MansionAPI.Repository
{
	public class MansionRepository : Repository<Mansion>,IMansionRepository
	{
		private readonly ApplicationDbContext _db;
		public MansionRepository(ApplicationDbContext db):base(db)
		{
			_db= db;
		}

		public async Task<Mansion> UpdateAsync(Mansion entity)
		{
			entity.UpdatedDate= DateTime.Now;
			_db.Mansions.Update(entity);
			await _db.SaveChangesAsync();
			return entity;
		}
	}
}
