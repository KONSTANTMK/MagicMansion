using MagicMansion_Utility;
using MagicMansion_Web.Models;
using MagicMansion_Web.Models.Dto;
using MagicMansion_Web.Services.IServices;

namespace MagicMansion_Web.Services
{
	public class MansionService : BaseService, IMansionService
	{
		private readonly IHttpClientFactory _clientFactory;
		private readonly string mansionUrl;
		public MansionService(IHttpClientFactory clientFactory,IConfiguration configuration):base(clientFactory)
		{
			_clientFactory= clientFactory;
			mansionUrl = configuration.GetValue<string>("ServiceUrls:MansionApi");
		}
		public Task<T> CreateAsync<T>(MansionCreateDTO dto)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = dto,
				Url = mansionUrl + "/api/MansionAPI"
			});
		}

		public Task<T> DeleteAsync<T>(int id)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.DELETE,
				Url = mansionUrl + "/api/MansionAPI/"+id
			});
		}

		public Task<T> GetAllAsync<T>()
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.GET,
				Url = mansionUrl + "/api/MansionAPI"
			});
		}

		public Task<T> GetAsync<T>(int id)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.GET,
				Url = mansionUrl + "/api/MansionAPI/" + id
			});
		}

		public Task<T> UpdateAsync<T>(MansionUpdateDTO dto)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.PUT,
				Data = dto,
				Url = mansionUrl + "/api/MansionAPI/"+dto.Id
			});
		}
	}
}
