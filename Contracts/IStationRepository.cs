﻿using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IStationRepository
    {
        IEnumerable<Station> GetAllStations();
        Station? GetStationById(int ID);
        IEnumerable<Station> GetStationsForOneTrain(int ID);

        void CreateStation(Station station);
        void DeleteStation(Station station);
        void UpdateStation(Station station);
    }
}
