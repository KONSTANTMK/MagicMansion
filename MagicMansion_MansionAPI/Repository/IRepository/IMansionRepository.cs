using MagicMansion_MansionAPI.Models;
using System.Linq.Expressions;

namespace MagicMansion_MansionAPI.Repository.IRepository
{
	public interface IMansionRepository
	{
		Task<List<Mansion>> GetAllAsync(Expression<Func<Mansion,bool>> filter=null);
		Task<Mansion> GetAsync(Expression<Func<Mansion,bool>> filter = null,bool tracked=true);
		Task CreateAsync(Mansion entity);
		Task UpdateAsync(Mansion entity);
		Task RemoveAsync(Mansion entity);
		Task SaveAsync();
	}
}
