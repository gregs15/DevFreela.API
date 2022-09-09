﻿using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Application.ViewModels;
using Zoan.Core.DTOs;
using Zoan.Core.Repositories;

namespace Zoan.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillDTO>>
    {


        private readonly ISkillRepository _skillRepository;
        public GetAllSkillsQueryHandler( ISkillRepository skillRepository)
        {

            _skillRepository = skillRepository;
        }
        public async Task<List<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {

            return await _skillRepository.GetAllAsync();
           
            
        }
    }
}
