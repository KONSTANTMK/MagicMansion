using AutoMapper;
using MagicMansion_Web.Models.Dto;
using MagicMansion_Web.Models;

namespace MagicMansion_Web
{
	public class MappingConfig:Profile
	{
		public MappingConfig()
		{
			CreateMap<MansionDTO, MansionCreateDTO>().ReverseMap();
			CreateMap<MansionDTO, MansionUpdateDTO>().ReverseMap();

			CreateMap<MansionNumberDTO, MansionNumberCreateDTO>().ReverseMap();
			CreateMap<MansionNumberDTO, MansionNumberUpdateDTO>().ReverseMap();
		}
	}
}
