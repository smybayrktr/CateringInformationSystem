using System.Collections.Generic;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public class UserFeedbackManager:IUserFeedbackService
    {
        private IUserFeedbackDal _userFeedbackDal;

        public UserFeedbackManager(IUserFeedbackDal userFeedbackDal)
        {
            _userFeedbackDal = userFeedbackDal;
        }

        public IDataResult<List<UserFeedback>> GetUserFeedbacks()
        {
            return new SuccessDataResult<List<UserFeedback>>(_userFeedbackDal.GetAll());
        }

        public IDataResult<UserFeedback> GetUserFeedback(int id)
        {
            return new SuccessDataResult<UserFeedback>(_userFeedbackDal.Get(i => i.Id == id));
        }

        public IResult AddUserFeedback(UserFeedback userFeedback)
        {
            _userFeedbackDal.Add(userFeedback);
            return new SuccessResult();
        }

        public IResult UpdateUserFeedback(UserFeedback userFeedback)
        {
            _userFeedbackDal.Update(userFeedback);
            return new SuccessResult();
        }

        public IResult DeleteUserFeedback(UserFeedback userFeedback)
        {
            _userFeedbackDal.Delete(userFeedback);
            return new SuccessResult();
        }
    }
}