using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShutterflyLTV
{
    public class Analyzer
    {
        public List<LTVCustomer> TopXSimpleLTVCustomers(int top, DataStore ds, string filePath = null)
        {
            var joined = from c in ds.Customers
                         join o in ds.Orders
                         on c.key equals o.customer_id 
                         group new {c.key, o.total_amount} by new {c.key, c.last_name} into g
                         select new {key = g.Key.key, last_name = g.Key.last_name, total_amount = g.Sum(x=>x.total_amount)};
            foreach (var q in joined.OrderByDescending(j => j.total_amount).Take(top))
            {
                ds.LTVCustomers.Add(new LTVCustomer { key = q.key.ToString(), last_name = q.last_name.ToString(), TotalLTV = q.total_amount });
            }

            return ds.LTVCustomers;
        }
    }
}
