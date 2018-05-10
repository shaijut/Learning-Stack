using ProtoType.Demo.Application.Abstract.DTO.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType.Demo.Application.DTO.People
{
    public class People : IPeople
    {

        #region PROPERTIES

        public int PeopleID { get; set; }
        public string EmailID { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        #endregion

    }
}
