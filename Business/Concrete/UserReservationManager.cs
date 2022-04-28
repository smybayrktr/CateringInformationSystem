using System.Collections.Generic;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public class UserReservationManager:IUserReservationService
    {
        private IUserReservationDal _userReservationDal;

        public UserReservationManager(IUserReservationDal userReservationDal)
        {
            _userReservationDal = userReservationDal;
        }

        public IDataResult<List<UserReservation>> GetUserReservations()
        {
            return new SuccessDataResult<List<UserReservation>>(_userReservationDal.GetAll());
        }

        public IDataResult<UserReservation> GetUserReservation(int id)
        {
            return new SuccessDataResult<UserReservation>(_userReservationDal.Get(i => i.Id == id));
        }

        public IResult AddUserReservation(UserReservation userReservation)
        {
            _userReservationDal.Add(userReservation);
            return new SuccessResult();
        }

        public IResult UpdateUserReservation(UserReservation userReservation)
        {
            _userReservationDal.Update(userReservation);
            return new SuccessResult();
        }

        public IResult DeleteUserReservation(UserReservation userReservation)
        {
            _userReservationDal.Delete(userReservation);
            return new SuccessResult();
        }
    }
}