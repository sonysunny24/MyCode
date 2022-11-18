using aspnetcore_n_tier.BLL.Services;
using aspnetcore_n_tier.BLL.Services.IServices;
using aspnetcore_n_tier.DAL.Repositories.IRepositories;
using aspnetcore_n_tier.DTO.DTOs;
using aspnetcore_n_tier.Entity.Entities;
using aspnetcore_n_tier.Utility.Utilities;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace aspnetcore_n_tier.Test
{
    public class UserServiceTests
    {
        private IUserService _userService;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly IMapper _mapper;

        public UserServiceTests()
        {
            _userRepository = new Mock<IUserRepository>();

            var myProfile = new AutoMapperProfiles.AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);

            _userService = new UserService(_userRepository.Object, _mapper);
        }

        [Fact]
        public async Task GetUsers_ReturnsUserList()
        {
            //Arrange
            var userEntityList = new List<User>() {
                new User()
                {
                    UserId = 1,
                    Username = "user1",
                    Name = "name1",
                    Surname = "surname1"
                },
                new User()
                {
                    UserId = 2,
                    Username = "user2",
                    Name = "name2",
                    Surname = "surname2"
                }
            };

            _userRepository
                .Setup(repo => repo.GetList(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(Task.FromResult(userEntityList));

            //Act
            var result = await _userService.GetUsers();

            //Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetUser_ReturnsUser()
        {
            //Arrange
            var userEntity = new User()
            {
                UserId = 22,
                Username = "Test Username",
                Name = "Test Name",
                Surname = "Test Surname"
            };

            _userRepository
                .Setup(repo => repo.Get(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(Task.FromResult(userEntity));

            //Act
            var result = await _userService.GetUser(userEntity.UserId);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddUser_ReturnsUser()
        {
            //Arrange
            var userEntity = new User()
            {
                UserId = 22,
                Username = "Test Username",
                Name = "Test Name",
                Surname = "Test Surname"
            };

            _userRepository
                .Setup(repo => repo.Add(It.IsAny<User>()))
                .Returns(Task.FromResult(userEntity));

            //Act
            var result = await _userService.AddUser(Mock.Of<UserToAddDTO>());

            //Assert
            Assert.IsType<UserDTO>(result);
            Assert.Equal(userEntity.UserId, result.UserId);
        }

        [Fact]
        public async Task UpdateUser_ReturnsUser()
        {
            //Arrange
            var userEntity = new User()
            {
                UserId = 22,
                Username = "Test Username",
                Name = "Test Name",
                Surname = "Test Surname"
            };

            _userRepository
                .Setup(repo => repo.Update(It.IsAny<User>()))
                .Returns(Task.FromResult(userEntity));

            //Act
            var result = await _userService.UpdateUser(Mock.Of<UserDTO>());

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteUser_CallsRepositoryDelete()
        {
            //Arrange
            const int UserId = 5;

            _userRepository
                .Setup(repo => repo.Delete(It.IsAny<User>()))
                .Verifiable();

            //Act
            await _userService.DeleteUser(UserId);

            //Assert
            _userRepository.Verify(x => x.Delete(It.IsAny<User>()), Times.Once());
        }
    }
}
