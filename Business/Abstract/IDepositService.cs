using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDepositService
    {
        public Task<IDataResult<List<Deposit>>> GetDeposits();
        public Task<IDataResult<Deposit>> GetDeposit(int id);
        public Task<IResult> AddDeposit(Deposit deposit,User user);
        public Task<IResult> UpdateDeposit(Deposit deposit);
        public Task<IResult> DeleteDeposit(Deposit deposit,User user);
        public Task<IDataResult<List<Deposit>>> GetDepositsByUserId(int id);
        public Task<IDataResult<List<Deposit>>> GetDepositsByUserSchoolNumber(string number);
        

    }
}