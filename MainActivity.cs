﻿using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Android;
using Android.Content;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
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
        FirebaseClient firebase = new FirebaseClient("https://sundaydb-2ca02-default-rtdb.europe-west1.firebasedatabase.app/");

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
            string spName = sp.GetString("name", null);
            string spPass = sp.GetString("pass", null);
            bool spRem = sp.GetBoolean("remember", false);
            if (spName != null && spPass != null && spRem)
            {
                Intent intent1 = new Intent(this, typeof(HomePage));
                StartActivity(intent1);
            }
            else if (!spRem)
            {
                var editor = sp.Edit();

                editor.PutBoolean("remember", false);
                editor.PutString("name", null);
                editor.PutString("pass", null);
                editor.Commit();

            }
        }

        public async Task<string> LoginUser(string username, string password)
        {
            try
            {
                var user =  await firebase.Child("Users").Child(username).OnceSingleAsync<User>();

                if (user != null)
                {
                    // Compare password
                    if (user.Password == password) // 🔹 (If passwords are not hashed)
                    {
                        Intent intent1 = new Intent(this, typeof(HomePage));
                        StartActivity(intent1);
                        return "correct info";
                     
                    }
                    else
                    {
                        Toast.MakeText(this, "Incorrect info!", ToastLength.Long).Show();
                        return "incorrect info";
                    }
                }
                else
                {
                    Toast.MakeText(this, "Incorrect info!", ToastLength.Long).Show();
                    return "incorrect info";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login Error: {ex.Message}");
                return "incorrect info";
            }
        }
    


        private void Create_Click(object sender, EventArgs e)
        {
            Intent intent1 = new Intent(this, typeof(SignUpActivity));
            StartActivity(intent1);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            LoginUser(name.Text, pass.Text);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}