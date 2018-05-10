using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType.Demo.Application.Abstract.DTO.People
{
    public interface IPeople
    {

        #region PROPERTIES

        int PeopleID { get; set; }
        string EmailID { get; set; }
        string FirstName { get; set; }
        string MidName { get; set; }
        string LastName { get; set; }
        string FullName { get; set; }

    }



    #endregion


}
