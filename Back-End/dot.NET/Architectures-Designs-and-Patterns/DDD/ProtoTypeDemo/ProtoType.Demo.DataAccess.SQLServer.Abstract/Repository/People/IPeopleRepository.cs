using ProtoType.Demo.Domain.Abstract.Entity.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType.Demo.DataAccess.SQLServer.Abstract.Repository.People
{
    public interface IPeopleRepository : IDisposable
    {

        IEnumerable<IPeople> GetPeoples();

        void CreatePeople(IPeople people);

        void Save();
    }
}
