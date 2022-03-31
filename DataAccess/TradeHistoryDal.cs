using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Access Trade History
    /// </summary>
    public class TradeHistoryDal
    {
        /// <summary>
        /// Gets all Trade history from API
        /// </summary>
        /// <returns>All Trade Histories</returns>
        public List<TradeHistory> GetAll()
        {
            List<TradeHistory> tradeHistories = new List<TradeHistory>();
            dynamic json = JObject.Parse(HttpConnection.GetFullPageString());
            int dataCount = json.body.intraDayTradeHistoryList.Count;

            for (int i = 0; i < dataCount; i++)
            {
                TradeHistory data = JsonConvert.DeserializeObject<TradeHistory>(json.body.intraDayTradeHistoryList[i].ToString());
                tradeHistories.Add(data);
            }

            return tradeHistories;
        }
    }

      
}
