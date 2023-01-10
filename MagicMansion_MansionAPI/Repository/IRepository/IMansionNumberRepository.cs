using MagicMansion_MansionAPI.Models;
using System.Linq.Expressions;

namespace MagicMansion_MansionAPI.Repository.IRepository
{
	public interface IMansionNumberRepository:IRepository<MansionNumber>
	{
		Task<MansionNumber> UpdateAsync(MansionNumber entity);
	}
}
