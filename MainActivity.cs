using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Android;
using Android.Content;

namespace Sunday.com
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView login;
        EditText name;
        EditText pass;
        Android.Content.ISharedPreferences sp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            login = FindViewById<TextView>(Resource.Id.createAccount);
            name = FindViewById<EditText>(Resource.Id.username);
            pass = FindViewById<EditText>(Resource.Id.password);

            login.Click += Login_Click;

            // ---------------- shared pref ----------------
            string spName = sp.GetString("user", null);
            string spPass = sp.GetString("pass", null);
            if (spName != null && spPass != null)
            {
                name.Text = spName;
                pass.Text = spPass;
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            // ------------------------ missing database ------------------------
            Intent mainToSignUp = new Intent();
            var editor = sp.Edit();
            editor.PutBoolean("remember", cbRem.Checked);
            editor.PutString("email", edMail.Text);
            editor.PutString("pass", edPass.Text);
            editor.PutString("fname", "itay");
            editor.Commit();
            sp = this.GetSharedPreferences("details", Android.Content.FileCreationMode.Private);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}