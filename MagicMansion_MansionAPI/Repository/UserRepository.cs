using MagicMansion_MansionAPI.Data;
using MagicMansion_MansionAPI.Models.Dto;
using MagicMansion_MansionAPI.Models;
using MagicMansion_MansionAPI.Repository.IRepostiory;

namespace MagicMansion_MansionAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool IsUniqueUser(string username)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}