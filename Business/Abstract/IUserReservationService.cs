using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserReservationService
    {
        public IDataResult<List<UserReservation>> GetUserReservations();
        public IDataResult<UserReservation> GetUserReservation(int id);
        public IDataResult<UserReservation> AddUserReservation(UserReservation userReservation);
        public IDataResult<UserReservation> UpdateUserReservation(UserReservation userReservation);
        public IResult DeleteUserReservation(int id);
    }
}