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
        public static string ListedDto = "All " + typeof(T).Name + " details listed!";

    }
}
