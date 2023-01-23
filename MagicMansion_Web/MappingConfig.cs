using AutoMapper;
using MagicMansion_Web.Models.Dto;

namespace MagicMansion_Web
{
	public class MappingConfig:Profile
	{
		public MappingConfig()
		{
			CreateMap<MansionDTO, MansionCreateDTO>().ReverseMap();
			CreateMap<MansionDTO, MansionUpdateDTO>().ReverseMap();

			CreateMap<Mansion, MansionCreateDTO>().ReverseMap();
			CreateMap<Mansion, MansionUpdateDTO>().ReverseMap();

			CreateMap<MansionNumber, MansionNumberDTO>().ReverseMap();
			CreateMap<MansionNumber, MansionNumberCreateDTO>().ReverseMap();
			CreateMap<MansionNumber, MansionNumberUpdateDTO>().ReverseMap();
		}
	}
}
