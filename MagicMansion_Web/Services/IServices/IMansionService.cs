using MagicMansion_Web.Models.Dto;

namespace MagicMansion_Web.Services.IServices
{
	public interface IMansionService
	{
		Task<T> GetAllAsync<T>(string token);
		Task<T> GetAsync<T>(int id, string token);
		Task<T> CreateAsync<T>(MansionCreateDTO dto, string token);
		Task<T> UpdateAsync<T>(MansionUpdateDTO dto, string token);
		Task<T> DeleteAsync<T>(int id, string token);
	}
}
