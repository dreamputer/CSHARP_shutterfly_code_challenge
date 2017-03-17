using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using System.IO;

namespace ShutterflyLTV
{
    public class DataStore
    {
        public List<Customer> Customers { get; private set; }
        public List<SiteVisit> SiteVisits { get; private set; }
        public List<Image> Images { get; private set; }
        public List<Order> Orders { get; private set; }
        public List<LTVCustomer> LTVCustomers { get; private set; }
        public DataStore()
        {
            this.Customers = new List<Customer>();
            this.SiteVisits = new List<SiteVisit>();
            this.Images = new List<Image>();
            this.Orders = new List<Order>();
            this.LTVCustomers = new List<LTVCustomer>();
        }

        public static void PersistToFile(object obj, string filePath)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            File.AppendAllText(filePath, json);
        }
    }

    public class Customer
    {
        public string key { get; set; }
        public DateTime event_time { get; set; }
        public string last_name { get; set; }
        public string adr_city { get; set; }
        public string adr_state { get; set; }
    }

    public class LTVCustomer
    {
        public string key { get; set; }
        public string last_name { get; set; }
        public double TotalLTV { get; set; }
    }

    public class SiteVisit
    {
        public string key { get; set; }
        public DateTime event_time { get; set; }
        public string customer_id { get; set; }
        public string tags { get; set; }
    }

    public class Image
    {
        public string key { get; set; }
        public DateTime event_time { get; set; }
        public string customer_id { get; set; }
        public string camera_make { get; set; }
        public string camera_model { get; set; }
    }

    public class Order
    {
        public string key { get; set; }
        public DateTime event_time { get; set; }
        public string customer_id { get; set; }
        public double total_amount { get; set; }
    }
}
