using System;
using System.IO;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Android.Support.V7.Widget;
using TestTask.Models;
using Android.Content;
using System.Text.Json;

namespace TestTask
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private const string Url = "https://partner.market.yandex.ru/pages/help/YML.xml";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            var ymlCatalog = await GetYmlCatalog();
            var lazyJsonOffers = ymlCatalog.Shop.Offers.Select(offer => new Lazy<string>(() =>
                JsonSerializer.Serialize(offer,
                    new JsonSerializerOptions
                        {WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping}))).ToList();
            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            recyclerView?.SetLayoutManager(new LinearLayoutManager(this));

            var adapter = new OfferAdapter(ymlCatalog.Shop.Offers);
            adapter.ItemClick += (sender, position) =>
            {
                var intent = new Intent(this, typeof(OfferActivity));
                intent.PutExtra("json", lazyJsonOffers[position].Value);
                StartActivity(intent);
            };
            recyclerView?.SetAdapter(adapter);
        }

        private static async Task<YmlCatalog> GetYmlCatalog()
        {
            var xmlBytes = await new HttpClient().GetByteArrayAsync(Url);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var xmlSerializer = new XmlSerializer(typeof(YmlCatalog));
            return (YmlCatalog) xmlSerializer.Deserialize(new MemoryStream(xmlBytes));
        }
    }
}