using MagicMansion_MansionAPI.Models;
using System.Linq.Expressions;

namespace MagicMansion_MansionAPI.Repository.IRepository
{
	public interface IMansionRepository:IRepository<Mansion>
	{
		Task<Mansion> UpdateAsync(Mansion entity);
	}
}
