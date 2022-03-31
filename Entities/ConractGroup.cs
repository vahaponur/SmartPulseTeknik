using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Represents the conract 
    /// </summary>
   public class ConractGroup
    {
        #region PrivateProperties
        /// <summary>
        /// Represents the conract of the group
        /// </summary>
        string _conract;
        /// <summary>
        /// Represents all trades made on the conract
        /// </summary>
        List<TradeHistory> _tradeHistories;
        /// <summary>
        /// Represents time of the conract
        /// </summary>
        DateTime _time;
        /// <summary>
        /// Total price of all trades
        /// </summary>
        decimal _totalPrice;
        /// <summary>
        /// Total quantity of all trades
        /// </summary>
        double _totalQuantity;
        /// <summary>
        /// Weighted average price of all trades
        /// </summary>
        double _weightedMeanPrice;
        #endregion

        #region Public Fields
        public string Conract
        {
            get => _conract;
            set => _conract = value;
        }
        public List<TradeHistory> TradeHistories
        {
            get => _tradeHistories;
            set => _tradeHistories = value;
        }
        public DateTime Time
        {
            get => _time;
        }
        public decimal TotalPrice
        {
            get => _totalPrice;
        }

        public double TotalQuantity
        {
            get => _totalQuantity;
        }
        public double WeightedMeanPrice
        {
            get => _weightedMeanPrice;
        }
        #endregion

        #region Contructors

     
        public ConractGroup(string conract,List<TradeHistory> tradeHistories)
        {
            _conract = conract;
            _tradeHistories = tradeHistories;
            _time = GetTimeFromConract();
            _totalPrice = GetTotalPrice();
            _totalQuantity = GetTotalQuantity();
            _weightedMeanPrice = GetWeightedMeanPrice();
        }

        #endregion

        #region PrivateMethods
        /// <summary>
        /// Returns time of this conract 
        /// </summary>
        /// <returns>Time of the conract</returns>
        DateTime GetTimeFromConract()
        {

            var year = "20" + _conract.Substring(2, 2);
            var month = _conract.Substring(4, 2);
            var day = _conract.Substring(6, 2);
            var hours = _conract.Substring(8, 2);
            var concatinated = year + "/" + month + "/" + day + "  " + hours + ":00";

            return DateTime.Parse(concatinated);

        }

        /// <summary>
        /// Returns Total Price of all trades
        /// </summary>
        /// <returns>Total Price</returns>
        decimal GetTotalPrice()
        {
            return _tradeHistories.Sum(t => (t.Price*(decimal)t.Quantity/10));
        }
        /// <summary>
        /// Returns Total Quantity of  
        /// </summary>
        /// <returns>Total Quantity</returns>
        double GetTotalQuantity()
        {
            return _tradeHistories.Sum(t => t.Quantity/10) ;
        }
        /// <summary>
        /// Returns Weighted Average Price
        /// </summary>
        /// <returns>Weighted Mean Price</returns>
        double GetWeightedMeanPrice()
        {
            return (double)GetTotalPrice() / GetTotalQuantity();
        }

        #endregion

        #region OverrideMethods
        /// <summary>
        /// Converts Contract Group to string for UI
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int lengtOfStr = 9;
            string quantityStr = TotalQuantity.ToString();
            string priceStr = TotalPrice.ToString();
            string weightStr = WeightedMeanPrice.ToString();

            quantityStr = quantityStr.Length > lengtOfStr ? quantityStr.Substring(0, 6) : quantityStr;
            priceStr = priceStr.Length > lengtOfStr ? priceStr.Substring(0, 6) : priceStr;
            weightStr = weightStr.Length > lengtOfStr ? weightStr.Substring(0, 6) : weightStr;
            return _time.ToString() + "    " + quantityStr + "                            " + priceStr + "                        " + weightStr;
        }
        #endregion
    }
}
