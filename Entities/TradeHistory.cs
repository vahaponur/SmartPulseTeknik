using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Represents the trading history model
    /// </summary>
    public class TradeHistory:ICloneable
    {
        #region Private Fields
        /// <summary>
        /// Date of the trade
        /// </summary>
        DateTime _date;

        /// <summary>
        /// Unique Id of the trade
        /// </summary>
        long _id;

        /// <summary>
        /// Conract string of trade
        /// </summary>
        string _conract;

        /// <summary>
        /// Unit price of the trade
        /// </summary>
        decimal _price;

        /// <summary>
        /// Quantity of entity of the trade
        /// </summary>
        double _quantity;
        #endregion

        #region Public Properties

        
        public DateTime Date
        {
            get => _date;
            set {_date = value; }
        }
        
        public long Id
        {
            get => _id;
            set {_id = value; }
        }

        public string Conract
        {
            get => _conract;
            set { _conract = value; }
        }

        public decimal Price
        {
            get => _price;
            set
            {
               _price = value;
            }
        }
        public double Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
            }
        }

        public object Clone()
        {
            return new TradeHistory { Conract = _conract, Date = _date, Id = _id, Price = _price, Quantity = _quantity };
        }
        #endregion
        public override string ToString()
        {
            return Price.ToString() + " " + Quantity.ToString() + " "+Id.ToString();
        }
    }
}
