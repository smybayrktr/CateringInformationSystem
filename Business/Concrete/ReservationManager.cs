using System.Collections.Generic;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public class ReservationManager:IReservationService
    {
        private IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public IDataResult<List<Reservation>> GetReservations()
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll());
        }

        public IDataResult<Reservation> GetReservation(int id)
        {
            return new SuccessDataResult<Reservation>(_reservationDal.Get(i => i.Id == id));
        }

        public IResult AddReservation(Reservation reservation)
        {
            _reservationDal.Add(reservation);
            return new SuccessResult();
        }

        public IResult UpdateReservation(Reservation reservation)
        {
            _reservationDal.Update(reservation);
            return new SuccessResult();
        }

        public IResult DeleteReservation(Reservation reservation)
        {
            _reservationDal.Delete(reservation);
            return new SuccessResult();
        }

        public IDataResult<List<Reservation>> GetReservationsByUserId(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<Reservation>> GetReservationsByUserSchoolNumber(string number)
        {
            throw new System.NotImplementedException();
        }
    }
}