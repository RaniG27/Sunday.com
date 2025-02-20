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
            // Find Views by ID with correct naming conventions
            TextView txtAlreadyMember = FindViewById<TextView>(Resource.Id.txtAlreadyMember);
            Button btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);

            EditText edtUsername = FindViewById<EditText>(Resource.Id.edtSignUsername);
            EditText edtEmail = FindViewById<EditText>(Resource.Id.edtSignEmail);
            EditText edtPassword = FindViewById<EditText>(Resource.Id.edtSignPassword);
            EditText edtConfirmPassword = FindViewById<EditText>(Resource.Id.edtSignConfirmPassword);

            TextView txtStarUsername = FindViewById<TextView>(Resource.Id.txtStarUsername);
            TextView txtStarEmail = FindViewById<TextView>(Resource.Id.txtStarEmail);
            TextView txtStarPassword = FindViewById<TextView>(Resource.Id.txtStarPassword);
            TextView txtStarConfirmPassword = FindViewById<TextView>(Resource.Id.txtStarConfirmPassword);





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
                // ------------------------ intent needs to be changed to strengths ------------------------
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