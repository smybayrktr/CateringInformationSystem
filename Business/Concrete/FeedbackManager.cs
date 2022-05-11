using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
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
            return new SuccessDataResult<List<Feedback>>(_feedbackDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Feedback> GetFeedback(int id)
        {
            return new SuccessDataResult<Feedback>(_feedbackDal.Get(i => i.Id == id), Messages.Listed);
        }

        public IResult AddFeedback(Feedback feedback)
        {
            _feedbackDal.Add(feedback);
            return new SuccessResult(Messages.Added);
        }

        public IResult UpdateFeedback(Feedback feedback)
        {
            _feedbackDal.Update(feedback);
            return new SuccessResult(Messages.Updated);
        }

        public IResult DeleteFeedback(Feedback feedback)
        { 
            _feedbackDal.Delete(feedback);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Feedback>> GetFeedbacksByUserId(int id)
        {
            var result = _feedbackDal.GetFeedbacksByUserId(id);
            return new SuccessDataResult<List<Feedback>>(result, Messages.Listed);
        }

        public IDataResult<List<Feedback>> GetFeedbacksByUserSchoolNumber(string number)
        {
            var result = _feedbackDal.GetFeedbacksByUserSchoolNumber(number);
            return new SuccessDataResult<List<Feedback>>(result, Messages.Listed);
        }
    }
}