using static MagicMansion_Utility.SD;
using System.Security.AccessControl;
namespace MagicMansion_Web.Models
{
	public class APIRequest
	{
		public ApiType ApiType { get; set; } = ApiType.GET;
		public string Url { get; set; }
		public object Data { get; set; }
		public string Token { get; set; }
	}
}
