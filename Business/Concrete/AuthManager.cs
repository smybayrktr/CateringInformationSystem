using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto, string password)
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
            await _userService.AddUser(user);
            return new SuccessDataResult<User>(user, Messages.Register);
        }
        
        public async Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = await _userManager.FindByEmailAsync(userForLoginDto.Email);
            if (userToCheck == null) return new ErrorDataResult<User>("Kullanıcı bulunamadı");

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.HashPassword,
                    userToCheck.PasswordSalt)) return new ErrorDataResult<User>("Parola hatası");

            await _signInManager.SignOutAsync();
            await _signInManager.PasswordSignInAsync(userToCheck,userForLoginDto.Password,false,false);
            
            return new SuccessDataResult<User>(userToCheck, "Başarılı giriş");
        }
        
        public async Task<IResult> UserExists(string userSchoolNumber)
        {
            if (await _userService.GetUserByUserSchoolNumber(userSchoolNumber) != null)
            {
                return new ErrorResult(Messages.UserExists);
            }
            return new SuccessResult();
        }
        
        public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
        {
            var claims = await _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.CreatedToken);
        }
    }
}