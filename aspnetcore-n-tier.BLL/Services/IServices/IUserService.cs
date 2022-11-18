using aspnetcore_n_tier.DTO.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetcore_n_tier.BLL.Services.IServices
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsers();
        Task<UserDTO> GetUser(int userId);
        Task<UserDTO> AddUser(UserToAddDTO userToAddDTO);
        Task<UserDTO> UpdateUser(UserDTO userToUpdateDTO);
        Task DeleteUser(int userId);
    }
}
