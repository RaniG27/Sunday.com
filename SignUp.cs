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

namespace Sunday.com
{
    [Activity(Label = "SignUp")]
    public class SignUp : Activity
    {
        TextView AlreadyMember;
        EditText name;
        EditText mail;
        EditText pass;
        EditText confirm;
        Button btnSignup;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SignUpLayout);

            AlreadyMember = FindViewById<TextView>(Resource.Id.txtAlreadyMember);
            btnSignup = FindViewById<Button>(Resource.Id.btnSignUp);

            name = FindViewById<EditText>(Resource.Id.SignUsername);
            mail = FindViewById<EditText>(Resource.Id.SignEmail);
            pass = FindViewById<EditText>(Resource.Id.SignPassword);
            confirm = FindViewById<EditText>(Resource.Id.SignConfirmPassword);




            AlreadyMember.Click += AlreadyMember_Click;
            btnSignup.Click += BtnSignup_Click;
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {

        }

        private void AlreadyMember_Click(object sender, EventArgs e)
        {
            Intent SignUpTomain = new Intent(this, typeof(MainActivity));
            StartActivity(SignUpTomain);
        }
    }
}