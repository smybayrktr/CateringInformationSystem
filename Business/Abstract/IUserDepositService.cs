using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserDepositService
    {
        public IDataResult<List<UserDeposit>> GetUserDeposits();
        public IDataResult<UserDeposit> GetUserDeposit(int id);
        public IResult AddUserDeposit(UserDeposit userDeposit);
        public IResult UpdateUserDeposit(UserDeposit userDeposit);
        public IResult DeleteUserDeposit(int id);
    }
}