using ProtoType.Demo.DataAccess.MongoDB.Manager;
using ProtoType.Demo.Domain.Abstract.Repository.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoType.Demo.Domain.Abstract.Entity.People;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace ProtoType.Demo.DataAccess.MongoDB.Repository.People
{
   public class PeopleMongoRepository : IPeopleMongoRepository
    {
        private MongoConnectionManager _mongoManager;

        public PeopleMongoRepository(MongoConnectionManager mongoManager)
        {
            _mongoManager = mongoManager;

        }

        static PeopleMongoRepository()
        {

            //to ignore mongo document _id field while deserialization

            BsonClassMap.RegisterClassMap<ProtoType.Demo.Domain.Entity.People.People>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
            });
        }

        public void CreatePeopleDocument(IPeople people)
        {
            //var bsonDocument = people.ToBsonDocument();

            // To remove the _t field

            var jsonDocument = Newtonsoft.Json.JsonConvert.SerializeObject(people);
            var bsonDocument = BsonSerializer.Deserialize<BsonDocument>(jsonDocument);

         
            _mongoManager.db().GetCollection<IPeople>("PeopleCollection").Save(bsonDocument);
        }

     

        public IEnumerable<IPeople> GetPeopleDocuments()
        {

       

            var peopleCollection = _mongoManager.db().GetCollection<ProtoType.Demo.Domain.Entity.People.People>("PeopleCollection").FindAll();

            var peopleDocuments = peopleCollection.AsQueryable().Select(x => new ProtoType.Demo.Domain.Entity.People.People()
            {
                 PeopleID = x.PeopleID,
                 FirstName = x.FirstName,
                 MidName = x.MidName,
                 LastName = x.LastName,
                 FullName = x.FullName,
                 EmailID = x.EmailID
            });

            return peopleDocuments;


        }




        public void GetPeopleDocumentsTest()
        {
            ValidateCollectionArgs s = new ValidateCollectionArgs
            {
                Full = false,
                ScanData = false
            };

            //var peopleCollection = _mongoManager.db().GetCollection("TestDemo").Settings.;


            //var collection = _mongoManager.db().GetCollection<BsonDocument>("PeopleCollection");
            //MongoCursor<BsonDocument> cursor = collection.FindAll();


            var command = new CommandDocument { { "find", "TestDemo" } };
            var result = _mongoManager.db().RunCommand(command);


            //var peopleDocuments = peopleCollection.AsQueryable().Select(x => new ProtoType.Demo.Domain.Entity.People.People()
            //{
            //    PeopleID = x.PeopleID,
            //    FirstName = x.FirstName,
            //    MidName = x.MidName,
            //    LastName = x.LastName,
            //    FullName = x.FullName,
            //    EmailID = x.EmailID
            //});

            //return peopleDocuments;


        }
    }
}
