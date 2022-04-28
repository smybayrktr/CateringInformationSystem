using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public class DepositManager:IDepositService
    {
        public IDataResult<List<Deposit>> GetDeposits()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Deposit> GetDeposit(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Deposit> AddDeposit(Deposit deposit)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Deposit> UpdateDeposit(Deposit deposit)
        {
            throw new System.NotImplementedException();
        }

        public IResult DeleteDeposit(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Deposit> GetDepositByUserId(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Deposit> GetDepositByUserSchoolNumber(string number)
        {
            throw new System.NotImplementedException();
        }
    }
}