using UserRestAPI.DataAcess;
using UserRestAPI.DTOs.Users.Request;
using UserRestAPI.DTOs.Users.Response;
using UserRestAPI.Models;

namespace UserRestAPI.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public  List<UserResponse> GetAll() 
        {
            List<User> userModelList = _context.Users.ToList();

            // No Password
            List<UserResponse> userDTOList = userModelList.Select(u => new UserResponse
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            }).ToList();

            return userDTOList;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(us => us.Id == id);
        }

        public User CreateNew(CreateNewUserRequest userRequest)
        {
            User newUser = new User();
            newUser.Name = userRequest.Name;
            newUser.Email = userRequest.Email;
            newUser.Password = userRequest.Password;

            _context.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public User UpdateInfo(int id, UpdateInfoUserRequest userRequest)
        {
            User existingUsser = _context.Users.FirstOrDefault(us => us.Id == id);
            if (existingUsser == null) return null;

            existingUsser.Name = userRequest.Name;
            existingUsser.Email = userRequest.Email;
            
            _context.SaveChanges();
            return existingUsser;
        }

        public User ChangePassword(int id, UpdatePasswordUserRequest userRequest)
        {
            User existingUser = _context.Users.FirstOrDefault(us => us.Id == id);
            if (existingUser == null) return null;

            existingUser.Name = userRequest.Password;

            _context.SaveChanges();
            return existingUser;
        }

        public int DeletById(int id)
        {
            User existingUser = _context.Users.FirstOrDefault(us => us.Id == id);
            if(existingUser == null) return 0;
    
            _context.Users.Remove(existingUser);
            _context.SaveChanges();

            return 1;
        }    
    }
}
