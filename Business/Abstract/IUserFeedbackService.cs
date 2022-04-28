using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserFeedbackService
    {
        public IDataResult<List<UserFeedback>> GetUserFeedbacks();
        public IDataResult<UserFeedback> GetUserFeedback(int id);
        public IResult AddUserFeedback(UserFeedback userFeedback);
        public IResult UpdateUserFeedback(UserFeedback userFeedback);
        public IResult DeleteUserFeedback(UserFeedback userFeedback);
    }
}