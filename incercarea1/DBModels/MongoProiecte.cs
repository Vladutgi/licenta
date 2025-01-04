using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace incercarea1
{
    internal class MongoProiecte
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Created { get; set; }
        public string LastUpdated { get; set; }
        public string Color { get; set; }
        public List<string> AssignedTo { get; set; }

    }
}
