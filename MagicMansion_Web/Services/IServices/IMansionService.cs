using MagicMansion_Web.Models.Dto;

namespace MagicMansion_Web.Services.IServices
{
	public interface IMansionService
	{
		Task<T> GetAllAsync<T>();
		Task<T> GetAsync<T>(int id);
		Task<T> CreateAsync<T>(MansionCreateDTO dto);
		Task<T> UpdateAsync<T>(MansionUpdateDTO dto);
		Task<T> DeleteAsync<T>(int id);
	}
}
