using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        public Task<IDataResult<List<User>>> GetUsers();
        public Task<IDataResult<User>> GetUser(int id);
        public Task<IResult> AddUser(User user);
        public Task<IResult> UpdateUser(User user);
        public Task<IResult> DeleteUser(User user);
        public Task<IDataResult<User>> GetUserByUserSchoolNumber(string number);
        public Task<IDataResult<List<OperationClaim>>> GetClaims(User user);
    }
}
