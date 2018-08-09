using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Elucidate.HelperClasses
{
    public class VersionCheck
    {
        public bool IsNewVersionAvailable(string thisAppVersion)
        {
            return false;
        }
        public string GetLatestVersionBuildNumber()
        {
            try
            {
                string url = "https://api.github.com/repos/blueblock/elucidate/releases/latest";

                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);

                // execute the request
                IRestResponse response = client.Execute(request);
                var content = response.Content; // raw content as string
                var releases = JArray.Parse($"[{content}]");
                List<JToken> version = (from p in releases select p["tag_name"]).ToList();
                if (version.Count > 0 && version.FirstOrDefault() != null)
                {
                    var v = version.FirstOrDefault()?.ToString();
                    return v;
                }
            }
            catch
            {
                // ignored
            }
            return string.Empty;
        }

        public bool DownloadLatestVersion()
        {
            return true;
        }

        public void InstallNewVersion()
        {

        }
    }
}
