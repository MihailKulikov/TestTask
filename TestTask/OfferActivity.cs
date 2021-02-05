using Android.App;
using Android.OS;
using Android.Widget;

namespace TestTask
{
    [Activity(Label = "OfferActivity")]
    public class OfferActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_offer);
            var offerView = FindViewById<TextView>(Resource.Id.jsonView);
            if (offerView != null) offerView.Text = Intent?.Extras?.GetString("json") ?? "Not found";
        }
    }
}