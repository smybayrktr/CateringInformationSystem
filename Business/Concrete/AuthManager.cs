using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                HashPassword = passwordHash,
                PasswordSalt = passwordSalt,
                SchoolNumber = userForRegisterDto.UserSchoolNumber,
                Status = true,
                UserName = userForRegisterDto.Email
            };
            _userService.AddUser(user);
            return new SuccessDataResult<User>(user, Messages.Register);
        }
        
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetUserByUserSchoolNumber(userForLoginDto.UserSchoolNumber);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            byte[] hash = Encoding.ASCII.GetBytes(userToCheck.Data.PasswordHash);
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, hash,userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.ErrorPassword);
            }
        
            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessLogin);
        }
        
        public IResult UserExists(string userSchoolNumber)
        {
            if (_userService.GetUserByUserSchoolNumber(userSchoolNumber) != null)
            {
                return new ErrorResult(Messages.UserExists);
            }
            return new SuccessResult();
        }
        
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.CreatedToken);
        }
    }
}