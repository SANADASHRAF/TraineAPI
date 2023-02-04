using Contracts;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TeketRepository : RepositoryBase<Ticket>, ITeketRepository
    {
        public TeketRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }


        public Ticket? GetUTicketById(int Id)
        {
            return FindByCondition(c => c.Id.Equals(Id)).SingleOrDefault();
        }
        public void CreateTicket(Ticket ticket)
        {
            Create(ticket);
        }

        public void UpdateTicket(Ticket ticket)
        {
            Update(ticket);
        }
    }
}
