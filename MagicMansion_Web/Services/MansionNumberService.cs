using MagicMansion_Utility;
using MagicMansion_Web.Models;
using MagicMansion_Web.Models.Dto;
using MagicMansion_Web.Services.IServices;

namespace MagicMansion_Web.Services
{
	public class MansionNumberService : BaseService, IMansionNumberService
	{
		private readonly IHttpClientFactory _clientFactory;
		private string mansionUrl;
		public MansionNumberService(IHttpClientFactory clientFactory,IConfiguration configuration):base(clientFactory)
		{
			_clientFactory= clientFactory;
			mansionUrl = configuration.GetValue<string>("ServiceUrls:MansionApi");
		}
		public Task<T> CreateAsync<T>(MansionNumberCreateDTO dto)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = dto,
				Url = mansionUrl + "/api/MansionNumberAPI"
            });
		}

		public Task<T> DeleteAsync<T>(int id)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.DELETE,
				Url = mansionUrl + "/api/MansionNumberAPI/" + id
			});
		}

		public Task<T> GetAllAsync<T>()
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.GET,
				Url = mansionUrl + "/api/MansionNumberAPI"
            });
		}

		public Task<T> GetAsync<T>(int id)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.GET,
				Url = mansionUrl + "/api/MansionNumberAPI/" + id
			});
		}

		public Task<T> UpdateAsync<T>(MansionNumberUpdateDTO dto)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.PUT,
				Data = dto,
				Url = mansionUrl + "/api/MansionNumberAPI/" + dto.MansionNo
			});
		}
	}
}
