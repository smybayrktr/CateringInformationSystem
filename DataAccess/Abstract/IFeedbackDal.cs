using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IFeedbackDal:IEntityRepository<Feedback>
    {
        Task<List<Feedback>> GetFeedbacksByUserId(int id);
        Task<List<Feedback>> GetFeedbacksByUserSchoolNumber(string number);
    }
}