﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Core.Repositories;
using Zoan.Infrastructure.Persistence;

namespace Zoan.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler: IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public DeleteProjectCommandHandler(IProjectRepository projectRepository)
        {
           _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            if (project != null)
            {
                project.Cancel();
               await  _projectRepository.SaveChangesAsync();

               
            }

            return Unit.Value;
        }
    }
}
