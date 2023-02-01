﻿using Contracts;
using Entites;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
        public AdminRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Admin> GetAllAdmins()=>
            FindAll()
            .OrderBy(c => c.Name)
            .ToList();
        
        public Admin GetAdminById(int Id) =>
            FindByCondition(c => c.Id.Equals(Id)).SingleOrDefault();

    }
}
