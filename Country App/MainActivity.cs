using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Country_App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Spinner CountrySp;
        EditText CapitalEt;
        ImageView CountryImage;
        String[] Cap = { "New Delhi", "Ottawa", "Madrid", "Paris", "Brasília", "Beijing", "London" };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            CountrySp = (Spinner)FindViewById(Resource.Id.SpCountryName);
            CapitalEt = (EditText)FindViewById(Resource.Id.EtCapitalName);
            CountryImage = (ImageView)FindViewById(Resource.Id.IvCountry);

            var carNamesAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.CountryNames, Android.Resource.Layout.SimpleSpinnerItem);
            CountrySp.Adapter = carNamesAdapter;

            CountrySp.ItemSelected += delegate
            {
                long i = CountrySp.SelectedItemId;
                CapitalEt.Text = Cap[i].ToString();
                Toast.MakeText(this, "The Selected Country is : " + CountrySp.SelectedItem, ToastLength.Long).Show();
                string imgName = "img" + i;
                int imgId = this.Resources.GetIdentifier(imgName, "mipmap", this.PackageName);
                CountryImage.SetImageResource(imgId);
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

