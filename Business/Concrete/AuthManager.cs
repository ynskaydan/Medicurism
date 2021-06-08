using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Security.Hashing;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        ITokenHelper _tokenHelper;
        IUserService _userService;

        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user,claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages<User>.TokenCreated);

        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var result = BusinessRules.Run(CheckUser(userForLoginDto.Email),CheckPasswordHash(userForLoginDto));
            if (!result.Success)
            {
                return new ErrorDataResult<User>(result.Message);
            }

            return new SuccessDataResult<User>(CheckUser(userForLoginDto.Email).Data, Messages<User>.SuccessLogin);



        }

        private IResult CheckPasswordHash(UserForLoginDto userForLoginDto)
        {
            var userForCheck = _userService.GetByMail(userForLoginDto.Email);
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userForCheck.PasswordHash,userForCheck.PasswordSalt))
            {
                return new ErrorResult(Messages<User>.PasswordNotVerified);
            }

            return new SuccessResult();

        }

        private IDataResult<User> CheckUser(string email)
        {
            User userForCheck = _userService.GetByMail(email);
            if (userForCheck == null)
            {
                return new ErrorDataResult<User>(Messages<User>.NotFound);
            }
            return new SuccessDataResult<User>(userForCheck);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            //IResult result = BusinessRules.Run(UserExist(userForRegisterDto.Email));
            //if (!result.Success)
            //{
            //   return new ErrorDataResult<User>(result.Message);
            //}
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages<User>.SuccessRegister);
        }

        public IResult UserExist(string email)
        {
              if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages<User>.AlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
