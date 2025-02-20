using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;

namespace Sunday.com
{
    [Activity(Label = "HomePage")]
    public class HomePage : Activity
    {
        Button btnNewProject;
        TextView btnLogOut;
        TextView test;
        FirebaseClient firebase = new FirebaseClient("https://sundaydb-2ca02-default-rtdb.europe-west1.firebasedatabase.app/");

        Android.Content.ISharedPreferences sp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HomePageLayout);

            sp = this.GetSharedPreferences("details", Android.Content.FileCreationMode.Private);
            btnNewProject = FindViewById<Button>(Resource.Id.btnNewProject);
            btnLogOut = FindViewById<TextView>(Resource.Id.txtLogout);
            test = FindViewById<TextView>(Resource.Id.firebasetest);
            btnLogOut.Click += BtnLogOut_Click;
            btnNewProject.Click += NewProject_Click;
        }


        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            var editor = sp.Edit();

                editor.PutBoolean("remember", false);
                editor.PutString("name", null);
                editor.PutString("pass", null);
            editor.Commit();
            Intent intent1 = new Intent(this, typeof(MainActivity));
            StartActivity(intent1);
        }

        private void NewProject_Click(object sender, EventArgs e)
        {
            Intent HomeToNewProject = new Intent(this, typeof(NewProject));
            StartActivity(HomeToNewProject);
        }
    }
}