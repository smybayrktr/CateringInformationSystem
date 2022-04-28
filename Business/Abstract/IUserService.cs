using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        public IDataResult<List<User>> GetUsers();
        public IDataResult<User> GetUser(int id);
        public IDataResult<User> AddUser(User user);
        public IDataResult<User> UpdateUser(User user);
        public IResult DeleteUser(int id);
        public IDataResult<User> GetUserByUserId(int id);
        public IDataResult<User> GetUserByUserSchoolNumber(string number);
        public IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
