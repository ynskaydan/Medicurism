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
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user,claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages<User>.TokenCreated);

        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            IResult result = BusinessRules.Run(CheckPasswordHash(userForLoginDto));
            if (!result.Success)
            {
                return new ErrorDataResult<User>(result.Message);
            }

            return new SuccessDataResult<User>(GetUser(userForLoginDto.Email).Data, Messages<User>.SuccessLogin);



        }

        private IDataResult<User> GetUser(string email)
        {
            var userToGet = _userService.GetByMail(email).Data;
            return new SuccessDataResult<User>(_userService.GetByMail(email).Data);
        }

        private IResult CheckPasswordHash(UserForLoginDto userForLoginDto)
        {
            //IResult result = BusinessRules.Run(CheckUser(userForLoginDto.Email));
            //if (!result.Success)
            //{
            //    return new ErrorResult(result.Message);
            //}

            var userForCheck = GetUser(userForLoginDto.Email).Data;
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userForCheck.PasswordHash,userForCheck.PasswordSalt))
            {
                return new ErrorResult(Messages<User>.PasswordNotVerified);
            }

            return new SuccessResult();

        }

        private IResult CheckUser(string email)
        {
            User userToCheck = GetUser(email).Data;
            if (userToCheck == null)
            {
                return new ErrorResult(Messages<User>.NotFound);
            }
            return new SuccessResult();
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
            var userToCheck = GetUser(email);
            if (userToCheck != null)
            {
                return new ErrorResult(Messages<User>.AlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
