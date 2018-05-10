using Hangfire;
using ProtoType.Demo.Application.Abstract;
using ProtoType.Demo.UI.ControllerHelper;
using ProtoType.Demo.UI.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProtoType.Demo.UI.Controllers
{
    public class PeoplesController : Controller
    {

        private IPeopleService _peopleService;



        public PeoplesController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }


        // GET: Peoples
        public ActionResult Index()
        {
            DataAccess.MongoDB.Manager.MongoConnectionManager man = new DataAccess.MongoDB.Manager.MongoConnectionManager();

            DataAccess.MongoDB.Repository.People.PeopleMongoRepository data = new DataAccess.MongoDB.Repository.People.PeopleMongoRepository(man);

            data.GetPeopleDocumentsTest();

            return View();
        }



        public ActionResult CreatePeople(PeopleVM people)
        {
     
           int peopleID = _peopleService.CreatePeople(new PeoplesControllerHelper().MapPeopleVmToDto(people));


            // Create Hang Fire Job 

            people.PeopleID = peopleID;

            BackgroundJob.Enqueue<PeoplesControllerHelper> (x => x.FillMongoAndElasticSearch(people));

  

            return Json(people);
        }


       
     

    }
}