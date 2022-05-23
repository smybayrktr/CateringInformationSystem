using System.Collections.Generic;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Business.Abstract
{
    public class DepositManager:IDepositService
    {
        private IDepositDal _depositDal;
        private IUserDepositDal _userDepositDal;

        public DepositManager(IDepositDal depositDal, IUserDepositDal userDepositDal)
        {
            _depositDal = depositDal;
            _userDepositDal = userDepositDal;
        }

        public IDataResult<List<Deposit>> GetDeposits()
        {
            return new SuccessDataResult<List<Deposit>>(_depositDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Deposit> GetDeposit(int id)
        {
            return new SuccessDataResult<Deposit>(_depositDal.Get(p => p.Id == id), Messages.Listed);
        }

        public IResult AddDeposit(Deposit deposit,User user)
        {
            _depositDal.Add(deposit);
            var userDeposit = new UserDeposit
            {
                UserId = user.Id,
                UserSchoolNumber = user.SchoolNumber,
                DepositId = deposit.Id
            };
            _userDepositDal.Add(userDeposit);
            return new SuccessResult(Messages.Added);
        }

        public IResult UpdateDeposit(Deposit deposit)
        {
            _depositDal.Update(deposit);
            return new SuccessResult(Messages.Updated);
        }

        public IResult DeleteDeposit(Deposit deposit)
        {
            _depositDal.Delete(deposit);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Deposit>> GetDepositsByUserId(int id)
        {
            var result = _depositDal.GetDepositsByUserId(id);
            return new SuccessDataResult<List<Deposit>>(result, Messages.Listed);
        }

        public IDataResult<List<Deposit>> GetDepositsByUserSchoolNumber(string number)
        {
            var result = _depositDal.GetDepositsByUserSchoolNumber(number);
            return new SuccessDataResult<List<Deposit>>(result, Messages.Listed);
        }
    }
}