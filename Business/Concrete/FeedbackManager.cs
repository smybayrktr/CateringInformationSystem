using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FeedbackManager:IFeedbackService
    {
        private IFeedbackDal _feedbackDal;
        private IUserFeedbackDal _userFeedbackDal;

        public FeedbackManager(IFeedbackDal feedbackDal)
        {
            _feedbackDal = feedbackDal;
        }

        public async Task<IDataResult<List<Feedback>>> GetFeedbacks()
        {
            var result = await _feedbackDal.GetAll();
            return new SuccessDataResult<List<Feedback>>(result, Messages.Listed);
        }

        public async Task<IDataResult<Feedback>> GetFeedback(int id)
        {
            var result = await _feedbackDal.Get(i => i.Id == id);
            return new SuccessDataResult<Feedback>(result, Messages.Listed);
        }

        public async Task<IResult> AddFeedback(Feedback feedback,User user)
        {
            await _feedbackDal.Add(feedback);
            var userFeedback = new UserFeedback
            {
                UserId = user.Id,
                UserSchoolNumber = user.SchoolNumber,
                FeedbackId = feedback.Id
            };
            await _userFeedbackDal.Add(userFeedback);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IResult> UpdateFeedback(Feedback feedback)
        {
            await _feedbackDal.Update(feedback);
            return new SuccessResult(Messages.Updated);
        }

        public async Task<IResult> DeleteFeedback(Feedback feedback,User user)
        { 
            await _feedbackDal.Delete(feedback);
            var feedbackToDelete = await _userFeedbackDal.Get(p => p.FeedbackId == feedback.Id && p.UserId == user.Id);
            await _userFeedbackDal.Delete(feedbackToDelete);
            return new SuccessResult(Messages.Updated);
        }

        public async Task<IDataResult<List<Feedback>>> GetFeedbacksByUserId(int id)
        {
            var result = await _feedbackDal.GetFeedbacksByUserId(id);
            return new SuccessDataResult<List<Feedback>>(result, Messages.Listed);
        }

        public async Task<IDataResult<List<Feedback>>> GetFeedbacksByUserSchoolNumber(string number)
        {
            var result = await _feedbackDal.GetFeedbacksByUserSchoolNumber(number);
            return new SuccessDataResult<List<Feedback>>(result, Messages.Listed);
        }
    }
}