using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserDto:IDto
    {
        public string SchoolNumber { get; set; }
        public string Password { get; set; }
    }
}