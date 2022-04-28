using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public class UserDepositManager:IUserDepositService
    {
        public IDataResult<List<UserDeposit>> GetUserDeposits()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<UserDeposit> GetUserDeposit(int id)
        {
            throw new System.NotImplementedException();
        }

        public IResult AddUserDeposit(UserDeposit userDeposit)
        {
            throw new System.NotImplementedException();
        }

        public IResult UpdateUserDeposit(UserDeposit userDeposit)
        {
            throw new System.NotImplementedException();
        }

        public IResult DeleteUserDeposit(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}