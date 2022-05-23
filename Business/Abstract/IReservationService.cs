using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IReservationService
    {
        public Task<IDataResult<List<Reservation>>> GetReservations();
        public Task<IDataResult<Reservation>> GetReservation(int id);
        public Task<IResult> AddReservation(Reservation reservation,User user);
        public Task<IResult> UpdateReservation(Reservation reservation);
        public Task<IResult> DeleteReservation(Reservation reservation,User user);
        public Task<IDataResult<List<Reservation>>> GetReservationsByUserId(int id);
        public Task<IDataResult<List<Reservation>>> GetReservationsByUserSchoolNumber(string number);
    }
}