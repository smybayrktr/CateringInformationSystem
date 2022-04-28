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
        public IResult AddUser(User user);
        public IResult UpdateUser(User user);
        public IResult DeleteUser(User user);
        public IDataResult<User> GetUserByUserSchoolNumber(string number);
        public IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
