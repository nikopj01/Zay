using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zay.ApplicationCore.Entities
{
    public class Order
    {
        public Order()
        {
            this.OrderAt = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Email { get; set; }
        public CartItem[] OrderItems { get; set; }
        public DateTime OrderAt { get; set; }
    }
}
