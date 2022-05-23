using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ISupportRequestDal:IEntityRepository<SupportRequest>
    {
        Task<List<SupportRequest>> GetSupportRequestsByUserId(int id);
        Task<List<SupportRequest>> GetSupportRequestsByUserSchoolNumber(string number);
    }
}