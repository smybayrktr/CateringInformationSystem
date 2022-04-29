using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDepositDal:EfEntityRepositoryBase<Deposit, CateringISContext>,IDepositDal
    {
        public List<Deposit> GetDepositsByUserId(int id)
        {
            using (var context = new CateringISContext())
            {
                var result = from deposit in context.Deposits
                    join userDeposit in context.UserDeposits on deposit.Id equals userDeposit.DepositId
                        join user in context.Users on userDeposit.UserId equals user.Id
                        select new Deposit()
                        {
                            Id = deposit.Id,
                            Amount = deposit.Amount,
                            CreateDate = deposit.CreateDate
                        };
                return result.ToList();
            }
        }

        public List<Deposit> GetDepositsByUserSchoolNumber(string number)
        {
            using (var context = new CateringISContext())
            {
                var result = from deposit in context.Deposits
                    join userDeposit in context.UserDeposits on deposit.Id equals userDeposit.DepositId
                    join user in context.Users on userDeposit.UserSchoolNumber equals user.SchoolNumber
                    select new Deposit()
                    {
                        Id = deposit.Id,
                        Amount = deposit.Amount,
                        CreateDate = deposit.CreateDate
                    };
                return result.ToList();
            }
        }
    }
}