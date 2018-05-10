using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProtoType.Demo.Application.API.Controllers
{
    public class PeopleController : ApiController
    {

        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try
            {
                objds.Create(employee);

                var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                //message.Headers.Location = new Uri(Request.RequestUri +"/"+
                //    employee.Id.ToString());
                message.Headers.Location = new
            Uri(Url.Link("GetEmployeeById", new { id = employee.Id.ToString() }));

                return message;

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


    }
}
