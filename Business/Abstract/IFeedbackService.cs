using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFeedbackService
    {
        public IDataResult<List<Feedback>> GetFeedbacks();
        public IDataResult<Feedback> GetFeedback(int id);
        public IDataResult<Feedback> AddFeedback(Feedback feedback);
        public IDataResult<Feedback> UpdateFeedback(Feedback feedback);
        public IResult DeleteFeedback(int id);
        public IDataResult<Feedback> GetFeedbackByUserId(int id);
        public IDataResult<Feedback> GetFeedbackByUserSchoolNumber(string number);
    }
}