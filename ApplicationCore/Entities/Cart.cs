using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zay.ApplicationCore.Entities
{
    public class Cart
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Email { get; set; }
        public CartItem[] CartItems { get; set; }
    }

    public class CartItem
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
        public int Quantity { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
    }
}
