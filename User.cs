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
using Firebase.Database;
using Firebase.Database.Query;

namespace Sunday.com
{
    internal class User
    {

        public string Email { get; set; }


        public string UserName { get; set; }


        public string Password { get; set; }






        public User(string uname, string email, string password)
        {
            this.Email = email;
            this.UserName = uname;
            this.Password = password;
        }
    }
}