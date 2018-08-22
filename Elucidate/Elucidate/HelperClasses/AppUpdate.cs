using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Elucidate.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Elucidate.HelperClasses
{
    public static class AppUpdate
    {
        private static readonly string repoUrl = "https://api.github.com/repos/blueblock/elucidate/releases/latest";
        private static readonly string changelogUrl = "https://github.com/BlueBlock/Elucidate/wiki/ChangeLog";
        private static readonly string installerName = "Elucidate.Windows.Installer.msi";

        private static string InstallFile { get; set; }

        public static event EventHandler NewVersonAvailable;
        public static event EventHandler NewVersonInstallReady;
        
        // ReSharper disable once UnusedMember.Local
        private static void OnNewVersonAvailable(EventArgs e)
        {
            EventHandler handler = NewVersonAvailable;
            handler?.Invoke(null, e);
        }

        // ReSharper disable once UnusedMember.Local
        private static void OnNewVersonInstallReady(EventArgs e)
        {
            EventHandler handler = NewVersonInstallReady;
            handler?.Invoke(null, e);
        }

        public class VersionInfo
        {
            public string Version { get; set; }
            public string DownloadUrl { get; set; }
            public string ChangeLogUrl { get; set; }
        }

        public static string GetInstalledVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public static bool IsNewVersionAvailable()
        {
            try
            {
                Version installed = new Version(GetInstalledVersion());

                Log.Instance.Debug($"Version Installed: {string.Join(".", installed)}");

                Version latest = new Version(GetLatestVersionInfo().Version);

                Log.Instance.Debug($"Latest Version Found: {string.Join(".", latest)}");

                // version compare
                switch (installed.CompareTo(latest))
                {
                    case 0:
                        // installed is the same as the latest
                        return false;
                    case 1:
                        // installed is newer that the latest
                        return false;
                    case -1:
                        // installed is older than the latest
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Warn("Version Check failed: ");
                Log.Instance.Warn(ex);
            }

            return false;
        }

        public static VersionInfo GetLatestVersionInfo()
        {
            try
            {
                var client = new RestClient(repoUrl);

                var request = new RestRequest(Method.GET);

                // execute the request
                IRestResponse response = client.Execute(request);

                string content = response.Content; // raw content as string

                JObject release = JObject.Parse(content);

                string version = (string)release["tag_name"];

                string downloadUrl = (from p in release["assets"]
                                      where p["name"].ToString() == "Elucidate.Windows.Installer.msi"
                                      select (string)p["browser_download_url"]).FirstOrDefault();

                if (!string.IsNullOrEmpty(version) || !string.IsNullOrEmpty(downloadUrl))
                {
                    var info = new VersionInfo
                    {
                        Version = version,
                        DownloadUrl = downloadUrl,
                        ChangeLogUrl = changelogUrl
                    };
                    return info;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Warn("Downlaod of latest version json failed: ");
                Log.Instance.Warn(ex);
            }

            return new VersionInfo();
        }

        public static void InstallNewVersion()
        {
            Log.Instance.Debug($"Starting msi installer {InstallFile}");
            // install without prompt and auto start
            Process process = new Process
            {
                StartInfo =
                {
                    FileName = "msiexec",
                    WorkingDirectory = Path.GetTempPath(),
                    Arguments = $"/i \"{InstallFile}\" /passive STARTAPP=true",
                    Verb = "runas"
                }
            };
            process.Start();
        }

        public static async Task<bool> DownloadLatestVersionAsync(string url)
        {
            try
            {
                string path = Path.GetTempPath();
                string filename = installerName.Replace(".msi", $".{Util.GetUniqueKey(8)}.msi");
                InstallFile = Path.Combine(path, filename);
                Uri uri = new Uri(url);
                WebClient wc = new WebClient();
                Log.Instance.Debug("DownloadLatestVersionAsync START");
                await wc.DownloadFileTaskAsync(uri, InstallFile);
                Log.Instance.Debug("DownloadLatestVersionAsync END");
                File.SetAttributes(InstallFile, FileAttributes.Temporary);
                NewVersonInstallReady?.Invoke(null, new EventArgs());
                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.Warn(ex);
            }
            return false;
        }
    }
}
