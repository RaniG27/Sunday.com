﻿using Android.App;
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

        TextView txtAlreadyMember;
        Button btnSignUp;
        EditText edtUsername;
        EditText edtEmail;
        EditText edtPassword;
        EditText edtConfirmPassword;

        TextView txtStarUsername;
        TextView txtStarEmail;
        TextView txtStarPassword;
        TextView txtStarConfirmPassword;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SignUpLayout);
            // Find Views by ID with correct naming conventions
            txtAlreadyMember = FindViewById<TextView>(Resource.Id.txtAlreadyMember);
            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);

            edtUsername = FindViewById<EditText>(Resource.Id.edtSignUsername);
            edtEmail = FindViewById<EditText>(Resource.Id.edtSignEmail);
            edtPassword = FindViewById<EditText>(Resource.Id.edtSignPassword);
            edtConfirmPassword = FindViewById<EditText>(Resource.Id.edtSignConfirmPassword);

            txtStarUsername = FindViewById<TextView>(Resource.Id.txtStarUsername);
            txtStarEmail = FindViewById<TextView>(Resource.Id.txtStarEmail);
            txtStarPassword = FindViewById<TextView>(Resource.Id.txtStarPassword);
            txtStarConfirmPassword = FindViewById<TextView>(Resource.Id.txtStarConfirmPassword);





            txtAlreadyMember.Click += AlreadyMember_Click;
            btnSignUp.Click += BtnSignup_Click;
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {
            bool flag = true;
            txtStarUsername.Visibility = ViewStates.Invisible;
            txtStarEmail.Visibility = ViewStates.Invisible;
            txtStarPassword.Visibility = ViewStates.Invisible;
            txtStarConfirmPassword.Visibility = ViewStates.Invisible;
            if (!Validation.IsUserName(edtUsername.Text) || edtUsername.Text.Length <3 || edtUsername.Text.Length > 20)
            {
                flag = false;
                txtStarUsername.Visibility = ViewStates.Visible;
            }
            if (!Validation.IsMail(edtEmail.Text))
            {
                flag = false;
                txtStarEmail.Visibility = ViewStates.Visible;
            }
            if (!Validation.IsPass(edtPassword.Text))
            {
                flag = false;
                txtStarPassword.Visibility = ViewStates.Visible;
                txtStarConfirmPassword.Visibility = ViewStates.Visible;
            }
            else if (edtConfirmPassword.Text != edtPassword.Text)
            {
                flag = false;
                txtStarConfirmPassword.Visibility = ViewStates.Visible;
            }
            if (flag)
            {
                Intent skillIntent = new Intent(this, typeof(SkillsRegActivity));
                StartActivity(skillIntent);
            }
        }

        private void AlreadyMember_Click(object sender, EventArgs e)
        {
            Intent mainIntent = new Intent(this, typeof(MainActivity));
            StartActivity(mainIntent);
        }
    }
}