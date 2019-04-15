using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace TestCI.Droid
{
    [Activity(Label = "TestCI", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        Toast toast = Toast.MakeText(Application.Context, "Press back again to exit", ToastLength.Short);
        bool doubleBackToExitPressedOnce = false;

        public override void OnBackPressed()
        {
            if (doubleBackToExitPressedOnce)
            {
                toast.Cancel();
                base.OnBackPressed();
                return;
            }

            toast.SetMargin(0, 0);
            toast.Show();

            this.doubleBackToExitPressedOnce = true;

            new Handler().PostDelayed(() =>
            {
                doubleBackToExitPressedOnce = false;
            }, 2000);

        }
    }
}

