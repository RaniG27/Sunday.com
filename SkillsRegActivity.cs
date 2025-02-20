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
    [Activity(Label = "SkillsRegActivity")]
    public class SkillsRegActivity : Activity
    {
        private SeekBar[] seekBars;
        private TextView txtSeekValue;
        private LinearLayout[] tickContainers;
        private Button btnSkillSave;
        private SeekBar skProblemBar, skWriteBar, skPresBar, skResearchBar, skCreatBar, skDrawConclusionsBar;
        private int problemValue = 1, writeValue = 1, presValue = 1, researchValue = 1, creatValue = 1, conclusionsValue = 1; // Default values (1-10)

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SkillsRegLayout);
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

                Button btnSkillSave = FindViewById<Button>(Resource.Id.btnSkillSave);
                btnSkillSave.Click += (s, e) =>
                {
                    Toast.MakeText(this, $"Saved: {problemValue}, {writeValue}, {presValue}, {researchValue}, {creatValue}, {conclusionsValue}", ToastLength.Short).Show();
                };

                // Create your application here
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
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