using System.IO;
using System.Net;
using System.Web.Http;
using System.Web;

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
            var user_ip = GetUserIP();
            //var results = Suggests(q);
            return user_ip;
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

        private string GetUserIP()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}