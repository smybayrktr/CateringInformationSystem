using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserSupportRequestService
    {
        public IDataResult<List<UserSupportRequest>> GetUserSupportRequests();
        public IDataResult<UserSupportRequest> GetUserSupportRequest(int id);
        public IDataResult<UserSupportRequest> AddUserSupportRequest(UserSupportRequest userSupportRequest);
        public IDataResult<UserSupportRequest> UpdateUserSupportRequest(UserSupportRequest userSupportRequest);
        public IResult DeleteUserSupportRequest(int id);
    }
}