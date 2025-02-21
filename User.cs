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

        public int Solving { get; set; }

        public int Writing { get; set; }

        public int Charisma { get; set; }

        public int Researching { get; set; }

        public int Creativity { get; set; }

        public int Conclusions { get; set; }








        public User(string uname, string email, string password, int Solving, int Writing, int Charisma, int Researching, int Creativity, int Conclusions)
        {
            this.Email = email;
            this.UserName = uname;
            this.Password = password;
            this.Solving = Solving;
            this.Writing = Writing;
            this.Charisma = Charisma;
            this.Researching = Researching;
            this.Creativity = Creativity;
            this.Conclusions = Conclusions;
        }
    }
}