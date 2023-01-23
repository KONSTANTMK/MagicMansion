using MagicMansion_Web.Models;

namespace MagicMansion_Web.Services.IServices
{
	public interface IBaseService
	{
		APIResponse responseModel { get; set; }
		Task<T> SendAsync<T>(APIRequest apiRequest);
	}
}
