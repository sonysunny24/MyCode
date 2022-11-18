using aspnetcore_n_tier.BLL.Services.IServices;
using aspnetcore_n_tier.DAL.Repositories.IRepositories;
using aspnetcore_n_tier.DTO.DTOs;
using aspnetcore_n_tier.Entity.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetcore_n_tier.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDTO>> GetUsers()
        {
            var usersToReturn = await _userRepository.GetList();
            return _mapper.Map<List<UserDTO>>(usersToReturn);
        }

        public async Task<UserDTO> GetUser(int userId)
        {
            var userToReturn = await _userRepository.Get(x => x.UserId == userId);
            return _mapper.Map<UserDTO>(userToReturn);
        }

        public async Task<UserDTO> AddUser(UserToAddDTO userToAddDTO)
        {
            var addedUser = await _userRepository.Add(_mapper.Map<User>(userToAddDTO));
            return _mapper.Map<UserDTO>(addedUser);
        }

        public async Task<UserDTO> UpdateUser(UserDTO userToUpdateDTO)
        {
            var userToUpdate = _mapper.Map<User>(userToUpdateDTO);
            return _mapper.Map<UserDTO>(await _userRepository.Update(userToUpdate));
        }

        public async Task DeleteUser(int userId)
        {
            var userToDelete = await _userRepository.Get(x => x.UserId == userId);
            await _userRepository.Delete(userToDelete);
        }
    }
}
