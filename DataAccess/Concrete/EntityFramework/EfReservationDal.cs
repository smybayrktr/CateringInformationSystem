using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfReservationDal:EfEntityRepositoryBase<Reservation, CateringISContext>,IReservationDal
    {
        public async Task<List<Reservation>> GetReservationsByUserId(int id)
        {
            using (var context = new CateringISContext())
            {
                var result = from reservation in context.Reservations
                    join userReservation in context.UserReservations on reservation.Id equals userReservation.ReservationId
                    where userReservation.UserId == id
                    select new Reservation()
                    {
                        Id = reservation.Id,
                        CreateDate = reservation.CreateDate,
                        ReservationDate = reservation.ReservationDate
                    };
                return await result.ToListAsync();
            }
        }

        public async Task<List<Reservation>> GetReservationsByUserSchoolNumber(string number)
        {
            using (var context = new CateringISContext())
            {
                var result = from reservation in context.Reservations
                    join userReservation in context.UserReservations on reservation.Id equals userReservation.ReservationId
                    where userReservation.UserSchoolNumber == number
                    select new Reservation()
                    {
                        Id = reservation.Id,
                        CreateDate = reservation.CreateDate,
                        ReservationDate = reservation.ReservationDate
                    };
                return await result.ToListAsync();
            }
        }
    }
}