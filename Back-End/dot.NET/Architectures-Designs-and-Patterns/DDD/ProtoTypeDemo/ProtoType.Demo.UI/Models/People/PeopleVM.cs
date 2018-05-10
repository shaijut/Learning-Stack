using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProtoType.Demo.UI.Models.People
{
    public class PeopleVM
    {

        #region PROPERTIES
        public int Id { get; set; }
        public int PeopleID { get; set; }
        public string EmailID { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        #endregion


    }
}