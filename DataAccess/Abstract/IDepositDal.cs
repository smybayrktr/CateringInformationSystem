using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IDepositDal:IEntityRepository<Deposit>
    {
        List<Deposit> GetDepositsByUserId(int id);
        List<Deposit> GetDepositsByUserSchoolNumber(string number);
    }
}