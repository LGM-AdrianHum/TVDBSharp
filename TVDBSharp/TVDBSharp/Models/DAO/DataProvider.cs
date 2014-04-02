﻿using System.Net;
using System.Xml.Linq;

namespace TVDBSharp.Models.DAO {
    /// <summary>
    /// Standard implementation of the <see cref="IDataProvider"/> interface.
    /// </summary>
    public class DataProvider : IDataProvider {
        public string ApiKey { get; set; }

        public XDocument GetShow(int showID) {
            using (var web = new WebClient()) {
                var response = web.DownloadString(string.Format("http://thetvdb.com/api/{0}/series/{1}/all/", ApiKey, showID));
                return XDocument.Parse(response);
            }
        }

        public XDocument GetEpisode(int episodeId, string lang)
        {
            using (var web = new WebClient())
            {
                var response = web.DownloadString(string.Format("http://thetvdb.com/api/{0}/episodes/{1}/{2}.xml", ApiKey, episodeId, lang));
                return XDocument.Parse(response);
            }
        }

        public XDocument Search(string query) {
            using (var web = new WebClient()) {
                var response = web.DownloadString(string.Format("http://thetvdb.com/api/GetSeries.php?seriesname={0}", query));
                return XDocument.Parse(response);
            }
        }
    }
}