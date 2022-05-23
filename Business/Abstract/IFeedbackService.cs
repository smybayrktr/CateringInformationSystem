using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFeedbackService
    {
        public Task<IDataResult<List<Feedback>>> GetFeedbacks();
        public Task<IDataResult<Feedback>> GetFeedback(int id);
        public Task<IResult> AddFeedback(Feedback feedback,User user);
        public Task<IResult> UpdateFeedback(Feedback feedback);
        public Task<IResult> DeleteFeedback(Feedback feedback,User user);
        public Task<IDataResult<List<Feedback>>> GetFeedbacksByUserId(int id);
        public Task<IDataResult<List<Feedback>>> GetFeedbacksByUserSchoolNumber(string number);
    }
}