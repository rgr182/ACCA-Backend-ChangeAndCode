using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ACCA_Backend.DataAccess.Services.Interfaces;
using ACCA_Backend.DataAccess.Entities;
using ACCA_Backend.DataAccess.DTO;

namespace ACCA_Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        readonly IUsersService _usersService;
        public ILogger<UsersController> _logger;
        public UsersController(IUsersService usersService, ILogger<UsersController>
            logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/User")]
        public async Task<ActionResult<Users>> GetUser(int userId)
        {
            try
            {
                var getUser = await _usersService.GetUser(userId);

                if (getUser == null)
                {
                    return NoContent();
                }
                return Ok(getUser);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }

        }

        [HttpGet]
        [Route("/Users")]
        public async Task<ActionResult<List<Users>>> GetUsers()
        {
            try
            {
                var getUsers = await _usersService.GetUsers();
                if (getUsers == null)
                {
                    return NoContent();
                }
                return Ok(getUsers);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpPost]
        [Route("/User")]
        public async Task<ActionResult<Users>> PostUser(UsersDTO userId)
        {
            {
                try
                {
                    var User = await _usersService.PostUser(userId);
                    return Ok(User);
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.ToLower().Contains("duplicate"))
                        return BadRequest("User already exist");
                    else
                        return Problem("Some error happened please contact Sys Admin");
                }
            }
        }
        [HttpPut]
        [Route("/User")]
        public async Task<ActionResult<UsersDTO>> UpdateUser(UsersDTO userId)
        {
            try
            {
                var User = await _usersService.UpdateUser(userId);
                if (User == null)
                {
                    return BadRequest("User don´t exist");
                }
                return Ok(User);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpDelete]
        [Route("/User")]
        public async Task<ActionResult<Users>> DeleteUser(int userId)
        {
            try
            {
                var User = await _usersService.DeleteUser(userId);
                if (User == null)
                {
                    return BadRequest("User don´t exist");
                }
                return Ok(User);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}