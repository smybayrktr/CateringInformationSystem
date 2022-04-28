using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FeedbackManager:IFeedbackService
    {
        private IFeedbackDal _feedbackDal;

        public FeedbackManager(IFeedbackDal feedbackDal)
        {
            _feedbackDal = feedbackDal;
        }

        public IDataResult<List<Feedback>> GetFeedbacks()
        {
            return new SuccessDataResult<List<Feedback>>(_feedbackDal.GetAll());
        }

        public IDataResult<Feedback> GetFeedback(int id)
        {
            return new SuccessDataResult<Feedback>(_feedbackDal.Get(i => i.Id == id));
        }

        public IResult AddFeedback(Feedback feedback)
        {
            _feedbackDal.Add(feedback);
            return new SuccessResult();
        }

        public IResult UpdateFeedback(Feedback feedback)
        {
            _feedbackDal.Update(feedback);
            return new SuccessResult();
        }

        public IResult DeleteFeedback(Feedback feedback)
        { 
            _feedbackDal.Delete(feedback);
            return new SuccessResult();
        }

        public IDataResult<Feedback> GetFeedbackByUserId(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Feedback> GetFeedbackByUserSchoolNumber(string number)
        {
            throw new System.NotImplementedException();
        }
    }
}