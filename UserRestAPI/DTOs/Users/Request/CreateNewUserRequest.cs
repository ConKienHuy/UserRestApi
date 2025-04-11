namespace UserRestAPI.DTOs.Users.Request
{
    public class CreateNewUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
