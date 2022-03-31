using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using DataAccess;
using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ConractGroupDal conractGroupDal = new ConractGroupDal();
            List<string> conracts = conractGroupDal.GetAllDifferentConracts();
            var conGr = conractGroupDal.GetAllWithoutPB();
            conGr.Sort(new DateComparer());
            Console.WriteLine("Tarih               " + "Toplam İşlem Miktarı (MWh) " + " Toplam İşlem Tutarı(TL) " + "    Ağırlıklı Ortalama Fiyat (TL/MHw)");
            foreach (var item in conGr)
            {
                Console.WriteLine(item);
            }

        }
     
    }

    /// <summary>
    /// Compares Contract Groups by date (Before is first)
    /// </summary>
    public class DateComparer : IComparer<ConractGroup>
    {

        public int Compare(ConractGroup x, ConractGroup y)
        {
            DateTime dateTime1 = x.Time;
            DateTime dateTime2 = y.Time;
            return DateTime.Compare(dateTime1,dateTime2);
        }
    }
}
