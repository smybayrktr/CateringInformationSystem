using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserReservationService
    {
        public IDataResult<List<UserReservation>> GetUserReservations();
        public IDataResult<UserReservation> GetUserReservation(int id);
        public IResult AddUserReservation(UserReservation userReservation);
        public IResult UpdateUserReservation(UserReservation userReservation);
        public IResult DeleteUserReservation(UserReservation userReservation);
    }
}