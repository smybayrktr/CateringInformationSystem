using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IReservationDal:IEntityRepository<Reservation>
    {
        Task<List<Reservation>> GetReservationsByUserId(int id);
        Task<List<Reservation>> GetReservationsByUserSchoolNumber(string number);
    }
}