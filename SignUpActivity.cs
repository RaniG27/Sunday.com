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
    [Activity(Label = "SignUpActivity")]
    public class SignUpActivity : Activity
    {

        TextView AlreadyMember;
        Button btnSignup;
        EditText name;
        EditText mail;
        EditText pass;
        EditText confirm;

        TextView starName;
        TextView starMail;
        TextView starPass;
        TextView starConfirm;
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
            starName = FindViewById<TextView>(Resource.Id.StarUserName);
            starMail = FindViewById<TextView>(Resource.Id.StarEmail);
            starPass = FindViewById<TextView>(Resource.Id.StarPassword);
            starConfirm = FindViewById<TextView>(Resource.Id.StarConfirmPassword);




            AlreadyMember.Click += AlreadyMember_Click;
            btnSignup.Click += BtnSignup_Click;
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {
            bool flag = true;
            starName.Visibility = ViewStates.Invisible;
            starMail.Visibility = ViewStates.Invisible;
            starPass.Visibility = ViewStates.Invisible;
            starConfirm.Visibility = ViewStates.Invisible;
            if (!Validation.IsUserName(name.Text) || name.Text.Length <3 || name.Text.Length > 20)
            {
                flag = false;
                starName.Visibility = ViewStates.Visible;
            }
            if (!Validation.IsMail(mail.Text))
            {
                flag = false;
                starMail.Visibility = ViewStates.Visible;
            }
            if (!Validation.IsPass(pass.Text))
            {
                flag = false;
                starPass.Visibility = ViewStates.Visible;
                starConfirm.Visibility = ViewStates.Visible;
            }
            else if (confirm.Text != pass.Text)
            {
                flag = false;
                starConfirm.Visibility = ViewStates.Visible;
            }
            if (flag)
            {
                Intent SignUpTomain = new Intent(this, typeof(MainActivity));
                StartActivity(SignUpTomain);
            }
        }

        private void AlreadyMember_Click(object sender, EventArgs e)
        {
            Intent SignUpTomain = new Intent(this, typeof(MainActivity));
            StartActivity(SignUpTomain);
        }
    }
}