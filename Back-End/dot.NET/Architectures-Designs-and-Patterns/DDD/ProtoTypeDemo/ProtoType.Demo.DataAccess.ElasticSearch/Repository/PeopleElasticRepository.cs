using ProtoType.Demo.Domain.Abstract.Repository.ElasticSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoType.Demo.Domain.Abstract.Entity.People;
using ProtoType.Demo.DataAccess.ElasticSearch.Manager;
using Nest;
using ProtoType.Demo.Domain.Entity.People;

namespace ProtoType.Demo.DataAccess.ElasticSearch.Repository
{
    public class PeopleElasticRepository : IPeopleElasticRepository
    {
        private ElasticConnectionManager _elasticManager;
        public PeopleElasticRepository(ElasticConnectionManager elasticManager)
        {
            _elasticManager = elasticManager;
        }



        public void CreatePeopleDocument(IPeople people)
        {
            var response = _elasticManager.client().Index(people, i => i
           .Index("peopleindex")
           .Type("peopletype")
           .Id(people.PeopleID)
           .Refresh(0));
        }

        public IEnumerable<IPeople> SearchPeopleDocumentsByField(string typeName, string searchQuery)
        {

            IEnumerable<People> searchResponse =
                               _elasticManager.client().Search<People>(s =>
                                      s.Type(typeName)
                                      .Query(q => q.Match(m => m.Field(f => f.FirstName).Query(searchQuery)))).Hits.Select(h => h.Source).ToList();

            return searchResponse;

        }
    }
}
