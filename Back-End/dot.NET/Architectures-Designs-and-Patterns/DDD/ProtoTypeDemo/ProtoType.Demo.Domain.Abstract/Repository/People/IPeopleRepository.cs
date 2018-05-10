using ProtoType.Demo.Domain.Abstract.Entity.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType.Demo.Domain.Abstract.Repository.People
{
    public interface IPeopleRepository : IDisposable
    {

        int CreatePeople(IPeople people);


        IEnumerable<IPeople> GetPeoples();
              


    }

}
