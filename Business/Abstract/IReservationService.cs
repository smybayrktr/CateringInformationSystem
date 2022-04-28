using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IReservationService
    {
        public IDataResult<List<Reservation>> GetReservations();
        public IDataResult<Reservation> GetReservation(int id);
        public IResult AddReservation(Reservation reservation);
        public IResult UpdateReservation(Reservation reservation);
        public IResult DeleteReservation(int id);
        public IDataResult<Reservation> GetReservationByUserId(int id);
        public IDataResult<Reservation> GetReservationByUserSchoolNumber(string number);
    }
}