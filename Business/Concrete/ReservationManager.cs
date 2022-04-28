using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public class ReservationManager:IReservationService
    {
        public IDataResult<List<Reservation>> GetReservations()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Reservation> GetReservation(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Reservation> AddReservation(Reservation reservation)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Reservation> UpdateReservation(Reservation reservation)
        {
            throw new System.NotImplementedException();
        }

        public IResult DeleteReservation(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Reservation> GetReservationByUserId(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Reservation> GetReservationByUserSchoolNumber(string number)
        {
            throw new System.NotImplementedException();
        }
    }
}