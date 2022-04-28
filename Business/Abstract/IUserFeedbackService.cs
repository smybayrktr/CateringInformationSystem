using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserFeedbackService
    {
        public IDataResult<List<UserFeedback>> GetUserFeedbacks();
        public IDataResult<UserFeedback> GetUserFeedback(int id);
        public IDataResult<UserFeedback> AddUserFeedback(UserFeedback userFeedback);
        public IDataResult<UserFeedback> UpdateUserFeedback(UserFeedback userFeedback);
        public IResult DeleteUserFeedback(int id);
    }
}