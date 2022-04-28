using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserForLoginDto:IDto
    {
        public string UserSchoolNumber { get; set; }
        public string Password { get; set; }
    }
}