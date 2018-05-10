using ProtoType.Demo.API.Models.People;
using ProtoType.Demo.Application.Abstract.DTO.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProtoType.Demo.API.ControllerHelper
{
    public class PeopleControllerHelper
    {


        public IEnumerable<PeopleVM> MapPeopleDtoToVm(IEnumerable<IPeople> peopleDto)
        {

            IEnumerable<PeopleVM> peopleList = peopleDto.Select(people =>
                                              new PeopleVM()
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


        public IPeople MapPeopleVmToDto(PeopleVM peopleVm)
        {

            IPeople peopleDto =  new Application.DTO.People.People()
                                    {
                                        PeopleID = peopleVm.PeopleID,
                                        EmailID = peopleVm.EmailID,
                                        FirstName = peopleVm.FirstName,
                                        MidName = peopleVm.MidName,
                                        LastName = peopleVm.LastName,
                                        FullName = peopleVm.FullName
                                    };


            return peopleDto;

        }


    }
}