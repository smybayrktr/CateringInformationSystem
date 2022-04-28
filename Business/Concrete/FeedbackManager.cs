using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public class FeedbackManager:IFeedbackService
    {
        public IDataResult<List<Feedback>> GetFeedbacks()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Feedback> GetFeedback(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Feedback> AddFeedback(Feedback feedback)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Feedback> UpdateFeedback(Feedback feedback)
        {
            throw new System.NotImplementedException();
        }

        public IResult DeleteFeedback(int id)
        {
            throw new System.NotImplementedException();
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