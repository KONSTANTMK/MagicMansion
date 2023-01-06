using MagicMansion_MansionAPI.Models.Dto;

namespace MagicMansion_MansionAPI.Data
{
    public static class MansionStore
    {
        public static List<MansionDTO> masionList = new List<MansionDTO>
            {
                new MansionDTO{Id=1,Name="Pool View"},
                new MansionDTO{Id=2,Name="Beach View"}
            };
    }
}
