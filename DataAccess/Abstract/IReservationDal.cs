using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IReservationDal:IEntityRepository<Reservation>
    {
        List<Reservation> GetReservationsByUserId(int id);
        List<Reservation> GetReservationsByUserSchoolNumber(string number);
    }
}