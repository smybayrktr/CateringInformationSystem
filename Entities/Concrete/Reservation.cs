using System;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Reservation:IEntity
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CreateDate {get; set;}
    }
}