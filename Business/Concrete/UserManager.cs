using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<IDataResult<List<User>>> GetUsers()
        {
            var result = await _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result, Messages.Listed);
        }

        public async Task<IDataResult<User>> GetUser(int id)
        {
            var result = await _userDal.Get(i => i.Id == id);
            return new SuccessDataResult<User>(result, Messages.Listed);
        }

        public async Task<IResult> AddUser(User user)
        {
            await _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IResult> UpdateUser(User user)
        {
            await _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }

        public async Task<IResult> DeleteUser(User user)
        {
            await _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IDataResult<User>> GetUserByUserSchoolNumber(string number)
        {
            var result = await _userDal.Get(n => n.SchoolNumber == number);
            return new SuccessDataResult<User>(result, Messages.Listed);
        }

        public async Task<IDataResult<List<OperationClaim>>> GetClaims(User user)
        {
            var result = await _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result, Messages.Listed);
        }
    }
}
