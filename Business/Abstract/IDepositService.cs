using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDepositService
    {
        public IDataResult<List<Deposit>> GetDeposits();
        public IDataResult<Deposit> GetDeposit(int id);
        public IResult AddDeposit(Deposit deposit);
        public IResult UpdateDeposit(Deposit deposit);
        public IResult DeleteDeposit(Deposit deposit);
        public IDataResult<Deposit> GetDepositByUserId(int id);
        public IDataResult<Deposit> GetDepositByUserSchoolNumber(string number);
        

    }
}