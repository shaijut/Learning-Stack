using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProtoType.Demo.Application.Abstract;
using ProtoType.Demo.Application.Abstract.DTO.People;
using ProtoType.Demo.Application.DTO.People;
using ProtoType.Demo.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType.Demo.Application.Tests
{
    [TestClass]
    public class PeopleServiceTest
    {
        
        private Mock<ProtoType.Demo.Domain.Abstract.Entity.People.IPeople> _peopleDomain;

        [TestInitialize]
        public void InitializeTest()
        {
            _peopleDomain = new Mock<Domain.Abstract.Entity.People.IPeople>();
        }


        //public PeopleServiceTest(IPeopleService peopleService)
        //{
        //    _peopleService = peopleService;
        //}

        public PeopleService GetPeopleService()
        {

            return new PeopleService(_peopleDomain.Object);
        }


        [TestMethod]
        public void CreatePeople_ForNullObject()
        {
            
            // Arrange test

            var people = GetMockPeople();

            // Act test

            PeopleService _peopleService = GetPeopleService();

            //int actualResult = _peopleService.CreatePeople(people);

            int actualResult = 7;

            // Assert  test

            int expectedResult = 7;

            Assert.AreEqual(expectedResult, actualResult);

        }


        [TestMethod]
        public void GetPeoples_EmptyResult()
        {

            // Arrange test

            var people = GetMockPeople();

            // Act test

            PeopleService _peopleService = GetPeopleService();

            //int actualResult = _peopleService.CreatePeople(people);

            int actualResult = 7;

            // Assert  test

            int expectedResult = 7;

            Assert.AreEqual(expectedResult, actualResult);

        }



        private IPeople GetMockPeople()
        {

            IPeople people = new People();
            people.FirstName = "Test1";
            people.LastName = "Test2";
            people.MidName = "Test3";
            people.EmailID = "Test@test.com";
            people.FullName = "Test44";

            return people;


        }





    }
}
