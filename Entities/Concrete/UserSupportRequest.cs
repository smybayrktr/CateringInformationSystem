using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class UserSupportRequest:IEntity
    {
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserSchoolNumber { get; set; }
        public int SupportRequestId { get; set; }
    }
}