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
        public IResult DeleteReservation(Reservation reservation);
        public IDataResult<List<Reservation>> GetReservationsByUserId(int id);
        public IDataResult<List<Reservation>> GetReservationsByUserSchoolNumber(string number);
    }
}