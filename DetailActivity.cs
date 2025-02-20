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
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.);

            // Get the selected item from the intent
            string receivedItem = Intent.GetStringExtra("selectedItem") ?? "No Data";

            // Find TextView and set the received item
            TextView textView = FindViewById<TextView>(Resource.Id.txtDetail);
            textView.Text = "You selected: " + receivedItem;
        }
    }
}