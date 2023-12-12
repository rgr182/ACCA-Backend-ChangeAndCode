using ACCA_Backend.DataAccess.DTO;
using ACCA_Backend.DataAccess.Entities;
using ACCA_Backend.DataAccess.Repository.Interfaces;
using ACCA_Backend.DataAccess.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACCA_Backend.DataAccess.Services
{
    public class UsersService : IUsersService
    {
        readonly ILogger<UsersService> _logger;
        readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository,
                              ILogger<UsersService> logger)
        {
            _usersRepository = usersRepository;
            _logger = logger;
        }

        public async Task<Users> GetUserByEmailAndPassword(string email, string pass)
        {
            try
            {
                Users user = await _usersRepository.GetUserByEmailAndPassword(email, pass);
                if (email == null)
                {
                    throw new UnauthorizedAccessException();
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
        public async Task<Users> GetUser(int userId)
        {
            try
            {
                Users user = await _usersRepository.GetUser(userId);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
        public async Task<List<Users>> GetUsers()
        {
            try
            {
                List<Users> users = await _usersRepository.GetUsers();
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task<Users> DeleteUser(int UserId)
        {
            try
            {
                Users user = await _usersRepository.DeleteUser(UserId);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task<UsersDTO> PostUser(UsersDTO user)
        {
            try
            {
                await _usersRepository.PostUser(user);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<Users> UpdateUser(UsersDTO user)
        {
            try
            {
                var userUpdated = await _usersRepository.UpdateUser(user);
                return userUpdated;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
