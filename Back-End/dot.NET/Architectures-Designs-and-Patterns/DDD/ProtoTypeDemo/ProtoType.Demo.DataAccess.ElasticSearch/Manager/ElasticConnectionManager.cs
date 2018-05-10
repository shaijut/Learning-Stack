using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType.Demo.DataAccess.ElasticSearch.Manager
{
    public class ElasticConnectionManager
    {

        public ElasticClient client()
        {
            ConnectionSettings connectionSettings;
            ElasticClient elasticClient;
            StaticConnectionPool connectionPool;

            //Connection string for Elasticsearch

            //Multiple node for fail over (cluster addresses)
            var nodes = new Uri[]
            {
                new Uri("http://localhost:9200/"),
                //new Uri("Add server 2 address")   //Add cluster addresses here
         
            };

            connectionPool = new StaticConnectionPool(nodes);
            connectionSettings = new ConnectionSettings(connectionPool).DefaultIndex("peopleindex");
            elasticClient = new ElasticClient(connectionSettings);

            return elasticClient;
        }

    }
    }
