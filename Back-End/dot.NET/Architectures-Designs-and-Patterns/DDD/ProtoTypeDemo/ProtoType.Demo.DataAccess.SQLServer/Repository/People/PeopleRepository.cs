using ProtoType.Demo.DataAccess.EF;
using ProtoType.Demo.Domain.Abstract.Entity.People;
using ProtoType.Demo.Domain.Abstract.Repository.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType.Demo.DataAccess.SQLServer.Repository.People
{
    public class PeopleRepository : IPeopleRepository , IDisposable
    {
        private ProtoTypeDBEntities _context;

        public PeopleRepository(ProtoTypeDBEntities context)
        {
            this._context = context;
        }
        public IEnumerable<IPeople> GetPeoples()
        {

            List<IPeople> peoples = 
                                     (from people in _context.People_T
                                     select new ProtoType.Demo.Domain.Entity.People.People
                                     {
                                         PeopleID = people.PeopleID,
                                         EmailID = people.EmailID,
                                         FirstName = people.FirstName,
                                         MidName = people.MidName,
                                         LastName = people.LastName,
                                         FullName = people.FullName
                                     }).ToList<IPeople>();



            return peoples;

        }


       public int CreatePeople(IPeople people)
        {

            People_T peopleDetails = new People_T();

            peopleDetails.EmailID = people.EmailID;
            peopleDetails.FirstName = people.FirstName;
            peopleDetails.MidName = people.MidName;
            peopleDetails.LastName = people.LastName;
            peopleDetails.FullName = people.FullName;

            _context.People_T.Add(peopleDetails);
            Save();
            return peopleDetails.PeopleID;
        }


        public void Save()
        {

            _context.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
