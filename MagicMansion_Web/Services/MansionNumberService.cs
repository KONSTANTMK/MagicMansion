using MagicMansion_Utility;
using MagicMansion_Web.Models;
using MagicMansion_Web.Models.Dto;
using MagicMansion_Web.Services.IServices;
using Newtonsoft.Json.Linq;

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
		public Task<T> CreateAsync<T>(MansionNumberCreateDTO dto, string token)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = dto,
				Url = mansionUrl + "/api/MansionNumberAPI",
                Token = token
            });
		}

		public Task<T> DeleteAsync<T>(int id, string token)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.DELETE,
				Url = mansionUrl + "/api/MansionNumberAPI/" + id,
                Token = token
            });
		}

		public Task<T> GetAllAsync<T>(string token)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.GET,
				Url = mansionUrl + "/api/MansionNumberAPI",
                Token = token
            });
		}

		public Task<T> GetAsync<T>(int id, string token)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.GET,
				Url = mansionUrl + "/api/MansionNumberAPI/" + id,
                Token = token
            });
		}

		public Task<T> UpdateAsync<T>(MansionNumberUpdateDTO dto, string token)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.PUT,
				Data = dto,
				Url = mansionUrl + "/api/MansionNumberAPI/" + dto.MansionNo,
                Token = token
            });
		}
	}
}
