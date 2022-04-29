using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ISupportRequestDal:IEntityRepository<SupportRequest>
    {
        List<SupportRequest> GetSupportRequestsByUserId(int id);
        List<SupportRequest> GetSupportRequestsByUserSchoolNumber(string number);
    }
}