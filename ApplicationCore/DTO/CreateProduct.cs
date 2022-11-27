using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zay.ApplicationCore.Entities;

namespace Zay.ApplicationCore.DTO
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsFeatured { get; set; }
        public string[] ImgUrls { get; set; }
        public Review[] Reviews { get; set; }
        public Stock[] Stocks { get; set; }
    }
}
