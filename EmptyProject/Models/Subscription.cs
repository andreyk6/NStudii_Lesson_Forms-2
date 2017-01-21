using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyProject.Models
{
    public class Subscription
    {
        public Guid Id { get; set; }

        public DateTime ExperationData { get; set; }


        public virtual User User { get; set; }
        public Guid SubscriptionTypeId { get; set; }
        public virtual SubscriptionType SubscriptionType { get; set; }

    }
}