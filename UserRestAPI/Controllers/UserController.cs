using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRestAPI.DTOs.Users.Request;
using UserRestAPI.DTOs.Users.Response;
using UserRestAPI.Models;
using UserRestAPI.Services;

namespace UserRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<UserResponse>> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            User user = _userService.GetById(id);
            if (user == null) return NotFound(); // 404
            return user; // 200, with body
        }

        [HttpPost]
        public ActionResult<User> Create(CreateNewUserRequest request)
        {
            User user = _userService.CreateNew(request);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult<User> UpdateInfo(int id, UpdateInfoUserRequest request)
        {
            User user = _userService.UpdateInfo(id, request);

            if (user == null) 
                return NotFound(id);
            else
                return Ok(user); //200
        }

        [HttpPut("{id}/change-password")]
        public ActionResult<User> ChangePassword(int id, UpdatePasswordUserRequest request)
        {
            var user = _userService.ChangePassword(id, request);
            
            if (user == null) 
                return NotFound("User with id " +id +"not found");
            else
                return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int result = _userService.DeletById(id);
            
            if (result == 0) 
                return NotFound("User with id " + id + "not found");
            else
                return Ok("Delete sucssecfully");
        }
    }
}
