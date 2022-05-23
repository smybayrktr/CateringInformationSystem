using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDepositService
    {
        public IDataResult<List<Deposit>> GetDeposits();
        public IDataResult<Deposit> GetDeposit(int id);
        public IResult AddDeposit(Deposit deposit,User user);
        public IResult UpdateDeposit(Deposit deposit);
        public IResult DeleteDeposit(Deposit deposit);
        public IDataResult<List<Deposit>> GetDepositsByUserId(int id);
        public IDataResult<List<Deposit>> GetDepositsByUserSchoolNumber(string number);
        

    }
}