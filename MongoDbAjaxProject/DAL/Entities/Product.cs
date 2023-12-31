﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbAjaxProject.DAL.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductStock { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal ProductPrice { get; set; }
        public string CategoryID { get; set; }
    }
}
