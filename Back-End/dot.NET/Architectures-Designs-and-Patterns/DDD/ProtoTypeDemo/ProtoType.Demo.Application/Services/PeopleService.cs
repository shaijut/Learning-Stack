using ProtoType.Demo.Application.Abstract;
using ProtoType.Demo.Application.Abstract.DTO.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType.Demo.Application.Services
{
    public class PeopleService : IPeopleService
    {

        #region PRIVATE FIELDS

        private ProtoType.Demo.Domain.Abstract.Entity.People.IPeople _peopleDomain;


        #endregion

        #region CONSTRUCTORS

        public PeopleService(ProtoType.Demo.Domain.Abstract.Entity.People.IPeople peopleDomain)
        {
            _peopleDomain = peopleDomain;
        }

        #endregion

        #region PUBLIC METHODS


        public int CreatePeople(IPeople people)
        {

           return _peopleDomain.CreatePeople(MapCreatePeopleFromDTOToDomain(people));

        }

        public IEnumerable<IPeople> GetPeoples()
        {

           return GetPeoplesDTOFromDomain(_peopleDomain.GetPeoples());
        }




        // Mongo DB Service


        public void CreatePeopleDocumentInMongo(IPeople people)
        {
            _peopleDomain.CreatePeopleDocumentInMongo(MapCreatePeopleFromDTOToDomain(people));
        }


        public IEnumerable<IPeople> GetPeopleDocuments()
        {
            return GetPeoplesDTOFromDomain(_peopleDomain.GetPeopleDocuments());
        }


        // Elastic Search Service


        public void CreatePeopleDocumentInElastic(IPeople people)
        {
            _peopleDomain.CreatePeopleDocumentInElastic(MapCreatePeopleFromDTOToDomain(people));
        }

        public IEnumerable<IPeople> SearchPeopleDocumentsByField(string typeName, string searchQuery)
        {
            return GetPeoplesDTOFromDomain(_peopleDomain.SearchPeopleDocumentsByField(typeName, searchQuery));
        }


        #endregion


        #region PRIVATE METHODS

        private IEnumerable<IPeople> GetPeoplesDTOFromDomain(IEnumerable<Domain.Abstract.Entity.People.IPeople> peoplesDomain)
        {

            IEnumerable<IPeople> peopleList = peoplesDomain.Select(people =>
                                              new DTO.People.People()
                                              {
                                                  PeopleID = people.PeopleID,
                                                  EmailID = people.EmailID,
                                                  FirstName = people.FirstName,
                                                  MidName = people.MidName,
                                                  LastName = people.LastName,
                                                  FullName = people.FullName
                                              }).ToList();


            return peopleList;

        }



        private Domain.Abstract.Entity.People.IPeople MapCreatePeopleFromDTOToDomain(IPeople people)
        {
            Domain.Abstract.Entity.People.IPeople peoplesDomain = new Domain.Entity.People.People();

            peoplesDomain.PeopleID = people.PeopleID;
            peoplesDomain.EmailID = people.EmailID;
            peoplesDomain.FirstName = people.FirstName;
            peoplesDomain.MidName = people.MidName;
            peoplesDomain.LastName = people.LastName;
            peoplesDomain.FullName = people.FullName;

            return peoplesDomain;

        }

        #endregion

    }
}
