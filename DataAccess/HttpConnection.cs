using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Represents connection to given connection string
    /// </summary>
    public static class HttpConnection
    {
        public static string startDate = "2022-02-07";
        public static string endDate = "2022-02-07";
         static  string connectionStr = "https://seffaflik.epias.com.tr/transparency/service/market/intra-day-trade-history?endDate="+endDate+"&startDate="+startDate; 

       public static string GetFullPageString()
        {
            return Get(connectionStr);
        }
         static string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
