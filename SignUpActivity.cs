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
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using static Android.Provider.Telephony.Mms;


namespace Sunday.com
{
    [Activity(Label = "SignUpActivity")]
    public class SignUpActivity : Activity
    {

        TextView txtAlreadyMember;
        Button btnSignUp;
        EditText edtUsername;
        EditText edtEmail;
        EditText edtPassword;
        EditText edtConfirmPassword;

        TextView txtStarUsername;
        TextView txtStarEmail;
        TextView txtStarPassword;
        TextView txtStarConfirmPassword;
        FirebaseClient firebase = new FirebaseClient("https://sundaydb-2ca02-default-rtdb.europe-west1.firebasedatabase.app/");
        private SeekBar[] seekBars;
        private TextView txtSeekValue;
        private LinearLayout[] tickContainers;
        private Button btnSkillSave;
        private SeekBar skProblemBar, skWriteBar, skPresBar, skResearchBar, skCreatBar, skDrawConclusionsBar;
        private int problemValue = 1, writeValue = 1, presValue = 1, researchValue = 1, creatValue = 1, conclusionsValue = 1; // Default values (1-10)
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SignUpLayout);
            // Find Views by ID with correct naming conventions
            txtAlreadyMember = FindViewById<TextView>(Resource.Id.txtAlreadyMember);
            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);

            edtUsername = FindViewById<EditText>(Resource.Id.edtSignUsername);
            edtEmail = FindViewById<EditText>(Resource.Id.edtSignEmail);
            edtPassword = FindViewById<EditText>(Resource.Id.edtSignPassword);
            edtConfirmPassword = FindViewById<EditText>(Resource.Id.edtSignConfirmPassword);

            txtStarUsername = FindViewById<TextView>(Resource.Id.txtStarUsername);
            txtStarEmail = FindViewById<TextView>(Resource.Id.txtStarEmail);
            txtStarPassword = FindViewById<TextView>(Resource.Id.txtStarPassword);
            txtStarConfirmPassword = FindViewById<TextView>(Resource.Id.txtStarConfirmPassword);





            txtAlreadyMember.Click += AlreadyMember_Click;
            btnSignUp.Click += BtnSignup_Click;
            skProblemBar = FindViewById<SeekBar>(Resource.Id.skProblemBar);
            skWriteBar = FindViewById<SeekBar>(Resource.Id.skWriteBar);
            skPresBar = FindViewById<SeekBar>(Resource.Id.skPresBar);
            skResearchBar = FindViewById<SeekBar>(Resource.Id.skResearchBar);
            skCreatBar = FindViewById<SeekBar>(Resource.Id.skCreatBar);

            skDrawConclusionsBar = FindViewById<SeekBar>(Resource.Id.skDrawConclusionsBar);
            seekBars = new SeekBar[]
       {
            FindViewById<SeekBar>(Resource.Id.skProblemBar),
            FindViewById<SeekBar>(Resource.Id.skWriteBar),
            FindViewById<SeekBar>(Resource.Id.skPresBar),
            FindViewById<SeekBar>(Resource.Id.skResearchBar),
            FindViewById<SeekBar>(Resource.Id.skCreatBar),
            FindViewById<SeekBar>(Resource.Id.skDrawConclusionsBar)
       };
            skProblemBar.ProgressChanged += (s, e) => problemValue = e.Progress + 1;
            skWriteBar.ProgressChanged += (s, e) => writeValue = e.Progress + 1;
            skPresBar.ProgressChanged += (s, e) => presValue = e.Progress + 1;
            skResearchBar.ProgressChanged += (s, e) => researchValue = e.Progress + 1;
            skCreatBar.ProgressChanged += (s, e) => creatValue = e.Progress + 1;
            skDrawConclusionsBar.ProgressChanged += (s, e) => conclusionsValue = e.Progress + 1;


            tickContainers = new LinearLayout[]
            {
            FindViewById<LinearLayout>(Resource.Id.tickContainer1),
            FindViewById<LinearLayout>(Resource.Id.tickContainer2),
            FindViewById<LinearLayout>(Resource.Id.tickContainer3),
            FindViewById<LinearLayout>(Resource.Id.tickContainer4),
            FindViewById<LinearLayout>(Resource.Id.tickContainer5),
            FindViewById<LinearLayout>(Resource.Id.tickContainer6)
            };
            // Create tick marks for each SeekBar
            for (int i = 0; i < seekBars.Length; i++)
            {
                CreateTickMarks(i);

                // Handle SeekBar value changes
                int index = i; // Local copy for the event handler
                seekBars[index].ProgressChanged += (s, e) =>
                {
                    // Convert SeekBar progress from 0-9 to 1-10
                    int value = e.Progress + 1;
                };
            }
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {
            bool flag = true;
            txtStarUsername.Visibility = ViewStates.Invisible;
            txtStarEmail.Visibility = ViewStates.Invisible;
            txtStarPassword.Visibility = ViewStates.Invisible;
            txtStarConfirmPassword.Visibility = ViewStates.Invisible;
            if (!Validation.IsUserName(edtUsername.Text) || edtUsername.Text.Length <3 || edtUsername.Text.Length > 20)
            {
                flag = false;       
                txtStarUsername.Visibility = ViewStates.Visible;
            }
            if (!Validation.IsMail(edtEmail.Text))
            {
                flag = false;
                txtStarEmail.Visibility = ViewStates.Visible;
            }
            if (!Validation.IsPass(edtPassword.Text))
            {
                flag = false;
                txtStarPassword.Visibility = ViewStates.Visible;
                txtStarConfirmPassword.Visibility = ViewStates.Visible;
            }
            else if (edtConfirmPassword.Text != edtPassword.Text)
            {
                flag = false;
                txtStarConfirmPassword.Visibility = ViewStates.Visible;
            }
            if (flag)
            {              
                Intent homeIntent = new Intent(this, typeof(HomePage));
             StartActivity(homeIntent);
            }
        }

        private void AlreadyMember_Click(object sender, EventArgs e)
        {
            Intent mainIntent = new Intent(this, typeof(MainActivity));
            StartActivity(mainIntent);
        }
        private void CreateTickMarks(int index)
        {
            int totalTicks = 10; // Values from 1 to 10
            for (int i = 1; i <= totalTicks; i++)
            {
                TextView tick = new TextView(this)
                {
                    Text = i.ToString(),
                    TextSize = 14,
                    Gravity = GravityFlags.Center
                };
                tick.SetTextColor(Android.Graphics.Color.LightPink);

                // Add weight for even spacing
                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.WrapContent, 1);
                tick.LayoutParameters = layoutParams;

                tickContainers[index].AddView(tick);
            }

        }
    }
}