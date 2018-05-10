using ProtoType.Demo.Domain.Abstract.Entity.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType.Demo.Domain.Abstract.Repository.ElasticSearch
{
    public interface IPeopleElasticRepository
    {


        void CreatePeopleDocument(IPeople people);

        IEnumerable<IPeople> SearchPeopleDocumentsByField(string typeName, string searchQuery);



    }
}
