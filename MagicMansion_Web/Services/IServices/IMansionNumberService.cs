using MagicMansion_Web.Models.Dto;

namespace MagicMansion_Web.Services.IServices
{
	public interface IMansionNumberService
	{
		Task<T> GetAllAsync<T>();
		Task<T> GetAsync<T>(int id);
		Task<T> CreateAsync<T>(MansionNumberCreateDTO dto);
		Task<T> UpdateAsync<T>(MansionNumberUpdateDTO dto);
		Task<T> DeleteAsync<T>(int id);
	}
}
