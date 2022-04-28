using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class UserFeedback:IEntity
    {
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserSchoolNumber { get; set; }
        public int FeedbackId { get; set; }
    }
}