using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITeketRepository
    {
        Ticket? GetUTicketById(int Id);
        void CreateTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);

    }
}
