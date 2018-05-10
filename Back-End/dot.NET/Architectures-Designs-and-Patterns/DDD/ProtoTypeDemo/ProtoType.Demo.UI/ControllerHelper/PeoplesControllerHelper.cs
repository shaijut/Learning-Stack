using Newtonsoft.Json;
using ProtoType.Demo.Application.Abstract.DTO.People;
using ProtoType.Demo.UI.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ProtoType.Demo.UI.ControllerHelper
{
    public class PeoplesControllerHelper
    {

        private class PeopleWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest w = base.GetWebRequest(uri);
                w.Timeout = 20 * 60 * 1000;
                return w;
            }

        }


        public IPeople MapPeopleVmToDto(PeopleVM peopleVm)
        {

            IPeople peopleDto = new Application.DTO.People.People()
            {
            
                EmailID = peopleVm.EmailID,
                FirstName = peopleVm.FirstName,
                MidName = peopleVm.MidName,
                LastName = peopleVm.LastName,
                FullName = peopleVm.FullName
            };


            return peopleDto;

        }



        public void FillMongoAndElasticSearch(PeopleVM people)
        {

      
            using (var client = new PeopleWebClient())
            {
                var dataString = JsonConvert.SerializeObject(people);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.UploadString(new Uri("http://localhost:49987/odata4/People"), "POST", dataString);
            }


        }



    }
}