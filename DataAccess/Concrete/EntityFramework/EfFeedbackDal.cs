using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFeedbackDal:EfEntityRepositoryBase<Feedback, CateringISContext>,IFeedbackDal
    {
        public List<Feedback> GetFeedbacksByUserId(int id)
        {
            using (var context = new CateringISContext())
            {
                var result = from feedback in context.Feedbacks 
                    join userFeedback in context.UserFeedbacks on feedback.Id equals userFeedback.FeedbackId
                    join user in context.Users on userFeedback.UserId equals user.Id
                    select new Feedback()
                    {
                        Id = feedback.Id,
                        CreateDate = feedback.CreateDate,
                        Title = feedback.Title,
                        Body = feedback.Body
                    };
                return result.ToList();
            }
        }

        public List<Feedback> GetFeedbacksByUserSchoolNumber(string number)
        {
            using (var context = new CateringISContext())
            {
                var result = from feedback in context.Feedbacks
                    join userFeedback in context.UserFeedbacks on feedback.Id equals userFeedback.FeedbackId
                    join user in context.Users on userFeedback.UserSchoolNumber equals user.SchoolNumber
                    select new Feedback()
                    {
                        Id = feedback.Id,
                        CreateDate = feedback.CreateDate,
                        Title = feedback.Title,
                        Body = feedback.Body
                    };
                return result.ToList();
            }
        }
    }
}