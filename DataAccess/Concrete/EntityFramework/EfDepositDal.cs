using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDepositDal:EfEntityRepositoryBase<Deposit, CateringISContext>,IDepositDal
    {
        public async Task<List<Deposit>> GetDepositsByUserId(int id)
        {
            using (var context = new CateringISContext())
            {
                var result = from deposit in context.Deposits
                    join userDeposit in context.UserDeposits on deposit.Id equals userDeposit.DepositId
                        where userDeposit.UserId == id
                        select new Deposit()
                        {
                            Id = deposit.Id,
                            Amount = deposit.Amount,
                            CreateDate = deposit.CreateDate
                        };
                return await result.ToListAsync();
            }
        }

        public async Task<List<Deposit>> GetDepositsByUserSchoolNumber(string number)
        {
            using (var context = new CateringISContext())
            {
                var result = from deposit in context.Deposits
                    join userDeposit in context.UserDeposits on deposit.Id equals userDeposit.DepositId
                    where userDeposit.UserSchoolNumber == number
                    select new Deposit()
                    {
                        Id = deposit.Id,
                        Amount = deposit.Amount,
                        CreateDate = deposit.CreateDate
                    };
                return await result.ToListAsync();
            }
        }
    }
}