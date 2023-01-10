using MagicMansion_MansionAPI.Data;
using MagicMansion_MansionAPI.Models;
using MagicMansion_MansionAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicMansion_MansionAPI.Repository
{
	public class MansionNumberRepository : Repository<MansionNumber>, IMansionNumberRepository
	{
		private readonly ApplicationDbContext _db;
		public MansionNumberRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public async Task<MansionNumber> UpdateAsync(MansionNumber entity)
		{
			entity.UpdatedDate = DateTime.Now;
			_db.MansionNumbers.Update(entity);
			await _db.SaveChangesAsync();
			return entity;
		}
	}
}
