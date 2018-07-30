using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Elucidate
{
    public static class Util
    {
        public static string SnapRaidLatestVersion()
        {
            try
            {
                string url = "https://api.github.com/repos/amadvance/snapraid/releases/latest";
                
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);

                // execute the request
                IRestResponse response = client.Execute(request);
                var content = response.Content; // raw content as string
                var releases = JArray.Parse($"[{content}]");
                List<JToken> version = (from p in releases select p["tag_name"]).ToList();
                if (version.Count > 0 && version.FirstOrDefault() != null)
                {
                    return version.FirstOrDefault()?.ToString();
                }
            }
            catch
            {
                // ignored
            }

            return null;
        }

        public static string SnapRaidLocalVersion()
        {
            try
            {
                
                return null;
            }
            catch
            {
                // ignored
            }

            return null;
        }
    }
}
