using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IDataResult<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetUserByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetUserByUserSchoolNumber(string number)
        {
            throw new NotImplementedException();
        }
    }
}
