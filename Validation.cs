using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sunday.com 
{
    internal class Validation
    {
        private static string mail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        private static string pass = @"^(?=(.*[a-zA-Z]))(?=(.*[0-9]))[a-zA-Z0-9._%+-=!#]{8,20}$";
        private static string letter = @"^[a-zA-Z]+$";
        private static string num = @"^\d+$";
        private static string username = @"^[a-zA-Z0-9_]+$";

        public static bool IsNumber(string str)
        {
            Regex reg = new Regex(num); // nums
            return reg.IsMatch(str);
        }
        public static bool IsUserName(string str)
        {
            Regex reg = new Regex(username); // nums
            return reg.IsMatch(str);
        }
        public static bool IsLetter(string str)
        {
            Regex reg = new Regex(letter); // letters
            return reg.IsMatch(str);
        }
        public static bool IsPass(string str)
        {
            Regex reg = new Regex(pass); // 8-20 chars, must contain 1 number and 1 letter
            return reg.IsMatch(str);
        }
        public static bool IsMail(string str)
        {
            Regex reg = new Regex(mail); // chars + @ + chars + . + 2 or more letters
            return reg.IsMatch(str);
        }
    }
}