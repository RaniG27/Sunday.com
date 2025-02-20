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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SignUpLayout);

            AlreadyMember = FindViewById<TextView>(Resource.Id.txtAlreadyMember);
            AlreadyMember.Click += AlreadyMember_Click;
        }

        private void AlreadyMember_Click(object sender, EventArgs e)
        {
            Intent SignUpTomain = new Intent(this, typeof(MainActivity));
            StartActivity(SignUpTomain);
        }
    }
}