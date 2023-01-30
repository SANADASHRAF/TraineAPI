﻿using Contracts;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StationRepository : RepositoryBase<Station>, IStationRepository
    {
        protected StationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
