using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDepositService
    {
        public IDataResult<List<Deposit>> GetDeposits();
        public IDataResult<Deposit> GetDeposit(int id);
        public IDataResult<Deposit> AddDeposit(Deposit deposit);
        public IDataResult<Deposit> UpdateDeposit(Deposit deposit);
        public IResult DeleteDeposit(int id);
        public IResult GetDepositByUserId(int id);
        public IDataResult<Deposit> GetDepositByUserSchoolNumber(string number);
        

    }
}