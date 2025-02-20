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
using SQLite;

namespace Sunday.com
{
    internal class User
    {
        [PrimaryKey, Column("Email")]
        public string Email { get; set; }

        [Column("Uname")]
        public string UserName { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("ProblemSolving")]
        public int ProblemSolving { get; set; }

        [Column("Writing")]
        public int Writing { get; set; }

        [Column("Presentation")]
        public int Presentation { get; set; }

        [Column("Research")]
        public int Research { get; set; }

        [Column("Creativity")]
        public int Creativity { get; set; }

        [Column("DrawingConclusions")]
        public int DrawingConclusions { get; set; }



        public User(string uname, string email, string password)
        {
            this.Email = email;
            this.UserName = uname;
            this.Password = password;
        }
    }
}