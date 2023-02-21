using Entites;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILocationRepository
    {

        void ShareLocation(Location location);
        void RefreshLocation(Location location);
        IEnumerable<Location> GetAllSharedLocationForSelectedTrain(int trainNumber);
        Location GetLocationById(int id);
        Location findlatestlocationBYTicket(int ticketNumber);
        Location GetLocation(int trainNumber);
        Location GetLocation(string From ,string To);

       

    }
}
