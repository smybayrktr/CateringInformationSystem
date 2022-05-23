using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFeedbackDal:EfEntityRepositoryBase<Feedback, CateringISContext>,IFeedbackDal
    {
        public async Task<List<Feedback>> GetFeedbacksByUserId(int id)
        {
            using (var context = new CateringISContext())
            {
                var result = from feedback in context.Feedbacks 
                    join userFeedback in context.UserFeedbacks on feedback.Id equals userFeedback.FeedbackId
                    where userFeedback.UserId == id                    
                    select new Feedback()
                    {
                        Id = feedback.Id,
                        CreateDate = feedback.CreateDate,
                        Title = feedback.Title,
                        Body = feedback.Body
                    };
                return await result.ToListAsync();
            }
        }

        public async Task<List<Feedback>> GetFeedbacksByUserSchoolNumber(string number)
        {
            using (var context = new CateringISContext())
            {
                var result = from feedback in context.Feedbacks
                    join userFeedback in context.UserFeedbacks on feedback.Id equals userFeedback.FeedbackId
                    where userFeedback.UserSchoolNumber == number
                    select new Feedback()
                    {
                        Id = feedback.Id,
                        CreateDate = feedback.CreateDate,
                        Title = feedback.Title,
                        Body = feedback.Body
                    };
                return await result.ToListAsync();
            }
        }
    }
}