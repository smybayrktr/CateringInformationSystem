using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IFeedbackDal:IEntityRepository<Feedback>
    {
        List<Feedback> GetFeedbacksByUserId(int id);
        List<Feedback> GetFeedbacksByUserSchoolNumber(string number);
    }
}