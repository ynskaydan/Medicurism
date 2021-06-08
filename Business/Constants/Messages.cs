using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages<T> 
    {
        public static string Added = typeof(T).Name + " Added!";
        public static string Deleted = typeof(T).Name + " Deleted!";
        public static string Updated = typeof(T).Name + " Updated!";
        public static string Listed = typeof(T).Name + "s listed!";
        public static string Got = "This id matched with involved " + typeof(T).Name + "!";
        public static string ListedDto = "All " + typeof(T).Name + " details listed!";
        public static string OutBranchOfLimit = "This branch capacity is full! You can't add doctor!";
        public static string ThisNameAlreadyExist = "This name" + typeof(T).Name + " already given by another " + typeof(T).Name;
        public static string LimitExceeded = typeof(T).Name + " limit is exceeded you can't add another " + typeof(T);
        public static string NullType = "This " + typeof(T).Name + " isn't found among " + typeof(T).Name + "s";
        public static string NotFound = typeof(T).Name + " not found.";
        public static string PasswordNotVerified = typeof(T).Name + " password doesn't match.";
        public static string SuccessLogin = typeof(T).Name + " successfully loginned.";
        public static string AlreadyExist = typeof(T).Name + " already exist.";
        public static string SuccessRegister = typeof(T).Name + "successfully registered.";
        public static string TokenCreated = "Token created for " + typeof(T).Name;
    }
}
