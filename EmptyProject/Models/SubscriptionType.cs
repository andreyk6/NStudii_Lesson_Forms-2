using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyProject.Models
{
    public class SubscriptionType:ModelBase
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}