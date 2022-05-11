using System.Collections.Generic;
using Business.Constants;
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
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Reservation> GetReservation(int id)
        {
            return new SuccessDataResult<Reservation>(_reservationDal.Get(i => i.Id == id), Messages.Listed);
        }

        public IResult AddReservation(Reservation reservation)
        {
            _reservationDal.Add(reservation);
            return new SuccessResult(Messages.Added);
        }

        public IResult UpdateReservation(Reservation reservation)
        {
            _reservationDal.Update(reservation);
            return new SuccessResult(Messages.Updated);
        }

        public IResult DeleteReservation(Reservation reservation)
        {
            _reservationDal.Delete(reservation);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Reservation>> GetReservationsByUserId(int id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetReservationsByUserId(id), Messages.Listed);
        }

        public IDataResult<List<Reservation>> GetReservationsByUserSchoolNumber(string number)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetReservationsByUserSchoolNumber(number),Messages.Listed)
        }
    }
}