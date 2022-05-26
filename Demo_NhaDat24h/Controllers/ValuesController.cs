using System.IO;
using System.Net;
using System.Web.Http;

namespace Demo_NhaDat24h.Controllers
{
    public class ValuesController : ApiController
    {
      
        // GET api/values/5
        [Route("google-api")]
        public string Get()
        {
            return "CUSTOM GOOGLE API";
        }

        [Route("google-api")]
        public string Get(string q)
        {
            var results = Suggests(q);
            return results;
        }
        static string Suggests(string q)
        {
            var key = Properties.Settings.Default.GOOGLE_API_KEY; 
            var url = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=" + q + "&key=" + key;

            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            return data;

        }
    }
}