using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFeedbackService
    {
        public IDataResult<List<Feedback>> GetFeedbacks();
        public IDataResult<Feedback> GetFeedback(int id);
        public IResult AddFeedback(Feedback feedback);
        public IResult UpdateFeedback(Feedback feedback);
        public IResult DeleteFeedback(Feedback feedback);
        public IDataResult<List<Feedback>> GetFeedbacksByUserId(int id);
        public IDataResult<List<Feedback>> GetFeedbacksByUserSchoolNumber(string number);
    }
}