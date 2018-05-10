using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType.Demo.DataAccess.MongoDB.Manager
{
   public  class MongoConnectionManager
    {

        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public MongoConnectionManager()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("PeopleDB");
        }


        public MongoDatabase db()
        {

            return _db;
        }


    }
}
