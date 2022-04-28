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
        public IResult DeleteUser(int id);
        public IDataResult<User> GetUserByUserId(int id);
        public IDataResult<User> GetUserByUserSchoolNumber(string number);
    }
}
