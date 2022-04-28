using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public class UserSupportRequestManager : IUserSupportRequestService
    {
        public IDataResult<List<UserSupportRequest>> GetUserSupportRequests()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<UserSupportRequest> GetUserSupportRequest(int id)
        {
            throw new System.NotImplementedException();
        }

        public IResult AddUserSupportRequest(UserSupportRequest userSupportRequest)
        {
            throw new System.NotImplementedException();
        }

        public IResult UpdateUserSupportRequest(UserSupportRequest userSupportRequest)
        {
            throw new System.NotImplementedException();
        }

        public IResult DeleteUserSupportRequest(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}