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
        ListView listView;
        List<string> itemList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HomePageLayout);

            listView = FindViewById<ListView>(Resource.Id.listViewItems);

            // Sample list items (only one field per row)
            itemList = new List<string> { "Item 1", "Item 2", "Item 3", "Item 4" };

            // Set up an adapter to display the items
            listView.Adapter = new ArrayAdapter<string>(this, Resource.Layout.list_item, Resource.Id.txtItem, itemList);

            // Handle item click
            listView.ItemClick += (sender, e) =>
            {
                string selectedItem = itemList[e.Position];

                // Open the DetailActivity and pass the clicked item
                var intent = new Intent(this, typeof(DetailActivity));
                intent.PutExtra("selectedItem", selectedItem);
                StartActivity(intent);
            };
        }
    }
}