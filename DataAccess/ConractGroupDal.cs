using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Access ContractGroup
    /// </summary>
    public class ConractGroupDal
    {
        /// <summary>
        /// For getting lists of contract group trade histories
        /// </summary>
        readonly TradeHistoryDal _tradeHistoryDal = new TradeHistoryDal();

        public List<TradeHistory> _tradeHistories;
        public ConractGroupDal()
        {
            _tradeHistories = _tradeHistoryDal.GetAll();
        }

        /// <summary>
        /// Gets Contract by conract string
        /// </summary>
        /// <param name="conract">Contract string</param>
        /// <returns>Conract Group for given string</returns>
        public ConractGroup GetByConractStr( string conract)
        {
            List<TradeHistory> tradeHistories = _tradeHistories.Where(t => t.Conract == conract).ToList();
            return new ConractGroup(conract,tradeHistories);
        }

        /// <summary>
        /// A method to get all unique conract strings
        /// </summary>
        /// <returns>List of conract strings</returns>
        public List<string> GetAllDifferentConracts()
        {
            List<TradeHistory> tradeHistoriiiis = _tradeHistories.Select(t=>(TradeHistory)t.Clone()).ToList();
            List<string> conracts = new List<string>();

            foreach (var item in _tradeHistories)
            {
                var conract = item.Conract;
                var conractTrades = tradeHistoriiiis.Where(t => t.Conract == item.Conract).ToList();
                if (conractTrades.Count >   0)
                {
                    conracts.Add(conract);
                    foreach (var conractTrade in conractTrades)
                    {
                        tradeHistoriiiis.Remove(conractTrade);
                    }
                }
            }

            return conracts; 
        }


        /// <summary>
        /// Gets all conracts except starting with "PB"
        /// </summary>
        /// <returns>List of all conract groups</returns>
        public List<ConractGroup> GetAllWithoutPB()
        {
            List<string> conractStrings = GetAllDifferentConracts();
            List<ConractGroup> conractGroups = new List<ConractGroup>();
            foreach (var item in conractStrings)
            {
                if (item.Substring(0,2) == "PH")
                {
                    conractGroups.Add(GetByConractStr(item));
                }
            }

            return conractGroups;
        }
    }
}
