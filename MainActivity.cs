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
        Button login;
        TextView create;
        EditText name;
        EditText pass;
        CheckBox rem;
        Android.Content.ISharedPreferences sp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            login = FindViewById<Button>(Resource.Id.btnLogin);
            create = FindViewById<TextView>(Resource.Id.txtCreateAccount);
            name = FindViewById<EditText>(Resource.Id.edtUsername);
            pass = FindViewById<EditText>(Resource.Id.edtPassword);
            rem = FindViewById<CheckBox>(Resource.Id.cbRemember);

            login.Click += Login_Click;
            create.Click += Create_Click;
            sp = this.GetSharedPreferences("details", Android.Content.FileCreationMode.Private);

            // ---------------- shared pref ----------------
            string spName = sp.GetString("user", null);
            string spPass = sp.GetString("pass", null);
            if (spName != null && spPass != null)
            {
                name.Text = spName;
                pass.Text = spPass;
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            Intent intent1 = new Intent(this, typeof(SignUpActivity));
            StartActivity(intent1);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            // ------------------------ missing a database ------------------------
            Intent intent1 = new Intent(this, typeof(HomePage));
            StartActivity(intent1);
            var editor = sp.Edit();
            editor.PutBoolean("remember", rem.Checked);
            editor.PutString("name", name.Text);
            editor.PutString("pass", pass.Text);
            editor.Commit();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}