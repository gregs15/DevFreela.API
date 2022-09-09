﻿using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Core.DTOs;
using Zoan.Core.Repositories;

namespace Zoan.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;
        public SkillRepository(IConfiguration configuration)
        {

            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task <List<SkillDTO>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = " SELECT Id, Description FROM Skills ";

                var skills = await sqlConnection.QueryAsync<SkillDTO>(script);

                return skills.ToList();
            }
        }
    }
}


// COM EF CORE

// var skillsViewModel = skills
//  .Select(s => new SkillViewModel(s.Id, s.Description))
//.ToList();

//            return skillsViewModel;