using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfReservationDal:EfEntityRepositoryBase<Reservation, CateringISContext>,IReservationDal
    {
        public List<Reservation> GetReservationsByUserId(int id)
        {
            using (var context = new CateringISContext())
            {
                var result = from reservation in context.Reservations
                    join userReservation in context.UserReservations on reservation.Id equals userReservation.ReservationId
                    join user in context.Users on userReservation.UserId equals user.Id
                    select new Reservation()
                    {
                        Id = reservation.Id,
                        CreateDate = reservation.CreateDate,
                        ReservationDate = reservation.ReservationDate
                    };
                return result.ToList();
            }
        }

        public List<Reservation> GetReservationsByUserSchoolNumber(string number)
        {
            using (var context = new CateringISContext())
            {
                var result = from reservation in context.Reservations
                    join userReservation in context.UserReservations on reservation.Id equals userReservation.ReservationId
                    join user in context.Users on userReservation.UserSchoolNumber equals user.SchoolNumber
                    select new Reservation()
                    {
                        Id = reservation.Id,
                        CreateDate = reservation.CreateDate,
                        ReservationDate = reservation.ReservationDate
                    };
                return result.ToList();
            }
        }
    }
}