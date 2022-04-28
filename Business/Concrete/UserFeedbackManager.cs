using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public class UserFeedbackManager:IUserFeedbackService
    {
        public IDataResult<List<UserFeedback>> GetUserFeedbacks()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<UserFeedback> GetUserFeedback(int id)
        {
            throw new System.NotImplementedException();
        }

        public IResult AddUserFeedback(UserFeedback userFeedback)
        {
            throw new System.NotImplementedException();
        }

        public IResult UpdateUserFeedback(UserFeedback userFeedback)
        {
            throw new System.NotImplementedException();
        }

        public IResult DeleteUserFeedback(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}