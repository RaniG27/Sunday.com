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
    [Activity(Label = "HomePage")]
    public class HomePage : Activity
    {
        Button btnNewProject;
        TextView btnLogOut;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HomePageLayout);

            btnNewProject = FindViewById<Button>(Resource.Id.btnNewProject);
            btnLogOut = FindViewById<TextView>(Resource.Id.txtLogout);
            btnNewProject.Click += NewProject_Click;
        }

        private void NewProject_Click(object sender, EventArgs e)
        {
            Intent HomeToNewProject = new Intent(this, typeof(NewProject));
            StartActivity(HomeToNewProject);
        }
    }
}