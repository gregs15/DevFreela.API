using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Core.Repositories;
using Zoan.Infrastructure.Persistence;

namespace Zoan.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        
        public StartProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {

           var project =  await _projectRepository.GetByIdAsync(request.Id);

           project.Start();

            await _projectRepository.StartAsync(project);


            return Unit.Value;
        }
    }
}


//com EFCORE


//  var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

//  project.Start();
// _dbContext.SaveChanges();