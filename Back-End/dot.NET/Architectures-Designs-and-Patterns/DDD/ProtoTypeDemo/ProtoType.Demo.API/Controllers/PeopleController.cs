using ProtoType.Demo.API.ControllerHelper;
using ProtoType.Demo.API.Models.People;
using ProtoType.Demo.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProtoType.Demo.API.Controllers
{
    public class PeopleController : ApiController
    {

        private IPeopleService _peopleService;

     

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }



        // Web API to Get Data from Mongo and Search Using Elastic Search

        [Route("api/People/{query?}")]

        public IEnumerable<PeopleVM> Get(string query=null)
        {

            IEnumerable<PeopleVM> peoples = null;



            if (string.IsNullOrEmpty(query))

            {
                peoples = new PeopleControllerHelper().MapPeopleDtoToVm(_peopleService.GetPeopleDocuments());

            }

            else
            {
                peoples = new PeopleControllerHelper().MapPeopleDtoToVm(_peopleService.SearchPeopleDocumentsByField("peopletype", query));
            }


            return peoples;

        }

        
        // Odata API To Fill Data in Mongo and Elastic Search

        [HttpPost]
        public IHttpActionResult Post([FromBody] PeopleVM people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _peopleService.CreatePeopleDocumentInMongo(new PeopleControllerHelper().MapPeopleVmToDto(people));


                _peopleService.CreatePeopleDocumentInElastic(new PeopleControllerHelper().MapPeopleVmToDto(people));
            }

            catch (Exception ex)
            {
                return BadRequest();
            }

            //var message = Request.CreateResponse(HttpStatusCode.Created, people);

            return Ok();
        }



        //public HttpResponseMessage Post([FromBody] PeopleVM people)
        //{
        //    try
        //    {
        //        _peopleService.CreatePeople(people);

        //        var message = Request.CreateResponse(HttpStatusCode.Created, employee);
        //        message.Headers.Location = new Uri(Request.RequestUri + "/" +
        //            employee.Id.ToString());

        //        //    message.Headers.Location = new
        //        //Uri(Url.Link("GetEmployeeById", new { id = employee.Id.ToString() }));

        //        return message;

        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}


    }
}
