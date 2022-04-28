using System.Collections.Generic;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public class UserDepositManager:IUserDepositService
    {
        private IUserDepositDal _userDepositDal;

        public UserDepositManager(IUserDepositDal userDepositDal)
        {
            _userDepositDal = userDepositDal;
        }

        public IDataResult<List<UserDeposit>> GetUserDeposits()
        {
            return new SuccessDataResult<List<UserDeposit>>(_userDepositDal.GetAll());
        }

        public IDataResult<UserDeposit> GetUserDeposit(int id)
        {
            return new SuccessDataResult<UserDeposit>(_userDepositDal.Get(i => i.Id == id));
        }

        public IResult AddUserDeposit(UserDeposit userDeposit)
        {
            _userDepositDal.Add(userDeposit);
            return new SuccessResult();
        }

        public IResult UpdateUserDeposit(UserDeposit userDeposit)
        {
            _userDepositDal.Update(userDeposit);
            return new SuccessResult();
        }

        public IResult DeleteUserDeposit(UserDeposit userDeposit)
        {
            _userDepositDal.Delete(userDeposit);
            return new SuccessResult();
        }
    }
}