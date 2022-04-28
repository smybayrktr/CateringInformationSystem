using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class UserReservation:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserSchoolNumber { get; set; }
        public int ReservationId { get; set; }
    }
}