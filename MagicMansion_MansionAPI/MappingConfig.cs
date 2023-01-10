using AutoMapper;
using MagicMansion_MansionAPI.Models;
using MagicMansion_MansionAPI.Models.Dto;

namespace MagicMansion_MansionAPI
{
	public class MappingConfig:Profile
	{
		public MappingConfig()
		{
			CreateMap<Mansion, MansionDTO>();
			CreateMap<MansionDTO, Mansion>();
			CreateMap<Mansion, MansionCreateDTO>().ReverseMap();
			CreateMap<Mansion, MansionUpdateDTO>().ReverseMap();

			CreateMap<MansionNumber, MansionNumberDTO>().ReverseMap();
			CreateMap<MansionNumber, MansionNumberCreateDTO>().ReverseMap();
			CreateMap<MansionNumber, MansionNumberUpdateDTO>().ReverseMap();
		}
	}
}
