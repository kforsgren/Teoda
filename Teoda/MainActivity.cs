using Android.App;
using Android.Widget;
using Android.OS;

namespace Teoda
{
    [Activity(Label = "Teoda", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button btnEnterName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            btnEnterName = FindViewById<Button>(Resource.Id.btnEnterName);
            btnEnterName.Click += BtnEnterName_Click;
        }

        private void BtnEnterName_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(ActivityNameEnter));
        }
    }
}

