using System.Collections.Generic;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public class UserSupportRequestManager : IUserSupportRequestService
    {
        private IUserSupportRequestDal _userSupportRequestDal;

        public UserSupportRequestManager(IUserSupportRequestDal userSupportRequestDal)
        {
            _userSupportRequestDal = userSupportRequestDal;
        }

        public IDataResult<List<UserSupportRequest>> GetUserSupportRequests()
        {
            return new SuccessDataResult<List<UserSupportRequest>>(_userSupportRequestDal.GetAll());
        }

        public IDataResult<UserSupportRequest> GetUserSupportRequest(int id)
        {
            return new SuccessDataResult<UserSupportRequest>(_userSupportRequestDal.Get(i => i.Id == id));
        }

        public IResult AddUserSupportRequest(UserSupportRequest userSupportRequest)
        {
            _userSupportRequestDal.Add(userSupportRequest);
            return new SuccessResult();
        }

        public IResult UpdateUserSupportRequest(UserSupportRequest userSupportRequest)
        {
            _userSupportRequestDal.Update(userSupportRequest);
            return new SuccessResult();
        }

        public IResult DeleteUserSupportRequest(UserSupportRequest userSupportRequest)
        {
            _userSupportRequestDal.Delete(userSupportRequest);
            return new SuccessResult();
        }
    }
}