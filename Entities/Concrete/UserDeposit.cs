using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class UserDeposit:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserSchoolNumber { get; set; }
        public int DepositId { get; set; }
    }
}