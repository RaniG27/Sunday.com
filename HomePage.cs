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
        Button newPorject;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HomePageLayout);

            newPorject = FindViewById<Button>(Resource.Id.newProject);
            newPorject.Click += NewPorject_Click;
        }

        private void NewPorject_Click(object sender, EventArgs e)
        {
            Intent HomeToNewProject = new Intent(this, typeof(NewProject));
            StartActivity(HomeToNewProject);
        }
    }
}