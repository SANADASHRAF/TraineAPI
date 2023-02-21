using Contracts;
using Entites;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LocationRepository : RepositoryBase<Location> , ILocationRepository
    {
        public LocationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }


        public Location GetLocationById(int id)
        {
            return FindByCondition(x => x.Id.Equals(id)).SingleOrDefault();
        }

        public Location findlatestlocationBYTicket(int ticketNumber)
        {
            return FindByCondition(x => x.TicketNumber.Equals(ticketNumber)).SingleOrDefault();
        }

        public IEnumerable<Location> GetAllSharedLocationForSelectedTrain(int trainNumber)
        {
            return FindByCondition(x => x.TrainNumber.Equals(trainNumber)).ToList();
        }


        public void ShareLocation(Location location)
        {
            Create(location);
        }

        public void RefreshLocation(Location location)
        {
            Update(location);
        }

        public Location GetLocation(int trainNumber)
        {
            throw new NotImplementedException();
        }

        public Location GetLocation(string From, string To)
        {
            throw new NotImplementedException();
        }

        
    }
}
