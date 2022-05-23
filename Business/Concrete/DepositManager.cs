using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
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

        public async Task<IDataResult<List<Deposit>>> GetDeposits()
        {
            var result = await _depositDal.GetAll();
            return new SuccessDataResult<List<Deposit>>(result, Messages.Listed);
        }

        public async Task<IDataResult<Deposit>> GetDeposit(int id)
        {
            var result = await _depositDal.Get(p => p.Id == id);
            return new SuccessDataResult<Deposit>(result, Messages.Listed);
        }

        public async Task<IResult> AddDeposit(Deposit deposit,User user)
        {
            await _depositDal.Add(deposit);
            var userDeposit = new UserDeposit
            {
                UserId = user.Id,
                UserSchoolNumber = user.SchoolNumber,
                DepositId = deposit.Id
            };
            await _userDepositDal.Add(userDeposit);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IResult> UpdateDeposit(Deposit deposit)
        {
            await _depositDal.Update(deposit);
            return new SuccessResult(Messages.Updated);
        }

        public async Task<IResult> DeleteDeposit(Deposit deposit,User user)
        {
            await _depositDal.Delete(deposit);
            var depositToDelete = await _userDepositDal.Get(p => p.DepositId == deposit.Id && p.UserId == user.Id);
            await _userDepositDal.Delete(depositToDelete);
            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IDataResult<List<Deposit>>> GetDepositsByUserId(int id)
        {
            var result = await _depositDal.GetDepositsByUserId(id);
            return new SuccessDataResult<List<Deposit>>(result, Messages.Listed);
        }

        public async Task<IDataResult<List<Deposit>>> GetDepositsByUserSchoolNumber(string number)
        {
            var result = await _depositDal.GetDepositsByUserSchoolNumber(number);
            return new SuccessDataResult<List<Deposit>>(result, Messages.Listed);
        }
    }
}