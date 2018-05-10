using ProtoType.Demo.Domain.Abstract.Entity.People;
using ProtoType.Demo.Domain.Abstract.Repository.ElasticSearch;
using ProtoType.Demo.Domain.Abstract.Repository.MongoDB;
using ProtoType.Demo.Domain.Abstract.Repository.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType.Demo.Domain.Entity.People
{
    public class People : IPeople
    {

        #region PRIVATE FIELDS

        private IPeopleRepository _peopleSqlRepository;

        private IPeopleMongoRepository _peopleMongoRepository;

        private IPeopleElasticRepository _peopleElasticRepository;
        #endregion

        #region CONSTRUCTORS


        public People()
        {

        }
        public People(IPeopleRepository peopleSqlRepository , IPeopleMongoRepository peopleMongoRepository , IPeopleElasticRepository peopleElasticRepository)
        { 

            _peopleSqlRepository = peopleSqlRepository;
            _peopleMongoRepository = peopleMongoRepository;
            _peopleElasticRepository = peopleElasticRepository;
        }

       
        #endregion

        #region PROPERTIES

        public int PeopleID { get; set; }
        public string EmailID { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        #endregion



        #region PUBLIC METHODS



        public IEnumerable<IPeople> GetPeoples()
        {

           return _peopleSqlRepository.GetPeoples();
        }

        public int CreatePeople(IPeople people)
        {


          return  _peopleSqlRepository.CreatePeople(people);

        }

        // Mongo DB

        public void CreatePeopleDocumentInMongo(IPeople people)
        {
            _peopleMongoRepository.CreatePeopleDocument(people);
        }

        public IEnumerable<IPeople> GetPeopleDocuments()
        {
            return _peopleMongoRepository.GetPeopleDocuments();
        }

        // Elastic Search

        public void CreatePeopleDocumentInElastic(IPeople people)
        {
            _peopleElasticRepository.CreatePeopleDocument(people);
        }

        public IEnumerable<IPeople> SearchPeopleDocumentsByField(string typeName, string searchQuery)
        {
           return _peopleElasticRepository.SearchPeopleDocumentsByField(typeName, searchQuery);
        }

        #endregion

    }
}
