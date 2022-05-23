using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IDepositDal:IEntityRepository<Deposit>
    {
        Task<List<Deposit>> GetDepositsByUserId(int id);
        Task<List<Deposit>> GetDepositsByUserSchoolNumber(string number);
    }
}