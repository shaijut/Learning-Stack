using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType.Demo.Domain.Abstract.Entity.People
{
    public interface IPeople
    {

        #region PROPERTIES

        int PeopleID { get; set; }
        string EmailID { get; set; }
        string FirstName { get; set; }
        string MidName { get; set; }
        string LastName { get; set; }
        string FullName { get; set; }

        #endregion


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
