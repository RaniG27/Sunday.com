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
    [Activity(Label = "NewProject")]
    public class NewProject : Activity, Android.Views.View.IOnClickListener
    {
        int count = 1;
        string[] arr = new string[6];

        LinearLayout TableLay;
        Button btnAdd;
        Button btnDinamicAdd;
        EditText edtUserName;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NewProjectLayout);

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);


            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinnerProjectLevel);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.levels_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            //פה לשים את המשתמש הנוכחי במערך בכדי לעבוד איתו

            btnAdd = FindViewById<Button>(Resource.Id.BtnAdd);
            btnAdd.SetOnClickListener(this);
            TableLay = FindViewById<LinearLayout>(Resource.Id.TableLayout);




        }

        public void OnClick(View v)
        {

            if (count < 5) // Only allow 5 additional people (count starts from 0)
            {
                LinearLayout lay = new LinearLayout(this)
                {
                    Orientation = Orientation.Horizontal
                };

                // Create the "+" button
                btnDinamicAdd = new Button(this);
                btnDinamicAdd.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                btnDinamicAdd.SetTextSize(Android.Util.ComplexUnitType.Sp, 20);
                btnDinamicAdd.Text = "+";
                btnDinamicAdd.SetBackgroundColor(Android.Graphics.Color.ParseColor("#F9B1AF"));
                btnDinamicAdd.SetOnClickListener(this);
                lay.AddView(btnDinamicAdd);

                // Create the EditText for the new person
                edtUserName = new EditText(this);
                edtUserName.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                edtUserName.SetTextSize(Android.Util.ComplexUnitType.Sp, 18);
                edtUserName.Hint = "Enter your partner's username";
                lay.AddView(edtUserName);
                TableLay.AddView(lay);

                // Update the array dynamically when text changes
                edtUserName.TextChanged += (sender, e) => {
                    arr[0] = FindViewById<EditText>(Resource.Id.firstPersonId).Text;
                    arr[count] = edtUserName.Text; // +1 because arr[0] is already occupied
                };

                count++; // Increment count (total people tracked)
            }
            else
            {
                // Show a warning when trying to add more than 5 additional people
                Toast.MakeText(this, "You can only add up to 5 partners.", ToastLength.Short).Show();
                for (int i = 0; i < arr.Length; i++)
                {
                    FindViewById<TextView>(Resource.Id.temp).Text += arr[i] + " ";
                }
            }
        }


        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;


        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
    }
}