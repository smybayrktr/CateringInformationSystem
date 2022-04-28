using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public class UserReservationManager:IUserReservationService
    {
        public IDataResult<List<UserReservation>> GetUserReservations()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<UserReservation> GetUserReservation(int id)
        {
            throw new System.NotImplementedException();
        }

        public IResult AddUserReservation(UserReservation userReservation)
        {
            throw new System.NotImplementedException();
        }

        public IResult UpdateUserReservation(UserReservation userReservation)
        {
            throw new System.NotImplementedException();
        }

        public IResult DeleteUserReservation(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}