using ProtoType.Demo.Application.Abstract.DTO.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType.Demo.Application.Abstract
{
    public interface IPeopleService
    {

        #region PUBLIC METHODS


        IEnumerable<IPeople> GetPeoples();

        int CreatePeople(IPeople people);


        // MongoDB
        void CreatePeopleDocumentInMongo(IPeople people);

        IEnumerable<IPeople> GetPeopleDocuments();

        // Elastic Search

        void CreatePeopleDocumentInElastic(IPeople people);

        IEnumerable<IPeople> SearchPeopleDocumentsByField(string typeName, string searchQuery);

        #endregion

    }
}
