using MagicMansion_MansionAPI.Models.Dto;
using MagicMansion_MansionAPI.Models;

namespace MagicMansion_MansionAPI.Repository.IRepostiory
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO);
    }
}
