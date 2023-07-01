using MongoDB.Bson;
using MongoDB.Driver;
using Worker.Helpers;

namespace Worker.Persistence.Clientes
{
    public class ClientesMongoDB : IClientesMongoDB
    {
        private IMongoCollection<BsonDocument> collection;

        public ClientesMongoDB(ConnectionStringsConfiguration connectionStringsConfiguration)
        {
            var client = new MongoClient(connectionStringsConfiguration.ConnectionStrings.MongoDB);
            var database = client.GetDatabase("gsl");
            collection = database.GetCollection<BsonDocument>("clientes");
        }

        public void InserirObjeto(GSL.SharedModel.Message.AdicionarClienteMessage adicionarClienteMessage)
        {
            BsonDocument bsonDocument = adicionarClienteMessage.ToBsonDocument();
            collection.InsertOne(bsonDocument);
        }
    }
}