using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public class ReservationManager:IReservationService
    {
        private IReservationDal _reservationDal;
        private IUserReservationDal _userReservationDal;

        public ReservationManager(IReservationDal reservationDal, IUserReservationDal userReservationDal)
        {
            _reservationDal = reservationDal;
            _userReservationDal = userReservationDal;
        }

        public async Task<IDataResult<List<Reservation>>> GetReservations()
        {
            var result = await _reservationDal.GetAll();
            return new SuccessDataResult<List<Reservation>>(result, Messages.Listed);
        }

        public async Task<IDataResult<Reservation>> GetReservation(int id)
        {
            var result = await _reservationDal.Get(i => i.Id == id);
            return new SuccessDataResult<Reservation>(result, Messages.Listed);
        }

        public async Task<IResult> AddReservation(Reservation reservation,User user)
        {
            await _reservationDal.Add(reservation);
            var userReservation = new UserReservation
            {
                UserId = user.Id,
                UserSchoolNumber = user.SchoolNumber,
                ReservationId = reservation.Id
            };
            await _userReservationDal.Add(userReservation);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IResult> UpdateReservation(Reservation reservation)
        {
            await _reservationDal.Update(reservation);
            return new SuccessResult(Messages.Updated);
        }

        public async Task<IResult> DeleteReservation(Reservation reservation,User user)
        {
            await _reservationDal.Delete(reservation);
            var reservationToDelete = await _userReservationDal.Get(p => p.ReservationId == reservation.Id && p.UserId == user.Id);
            await _userReservationDal.Delete(reservationToDelete);
            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IDataResult<List<Reservation>>> GetReservationsByUserId(int id)
        {
            var result = await _reservationDal.GetReservationsByUserId(id);
            return new SuccessDataResult<List<Reservation>>(result, Messages.Listed);
        }

        public async Task<IDataResult<List<Reservation>>> GetReservationsByUserSchoolNumber(string number)
        {
            var result = await _reservationDal.GetReservationsByUserSchoolNumber(number);
            return new SuccessDataResult<List<Reservation>>(result, Messages.Listed);
        }
    }
}