

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace incercarea1
{
    internal class UsersModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string LastModified { get; set; }
        public string Created { get; set; }
        public string Role { get; set; }
        public string VerificationQuestion { get; set; }
        public string VerificationAnswer { get; set; }

    }
}




       

