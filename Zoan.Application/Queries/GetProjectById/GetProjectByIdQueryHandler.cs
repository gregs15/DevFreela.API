using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Application.ViewModels;
using Zoan.Core.Repositories;
using Zoan.Infrastructure.Persistence;

namespace Zoan.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler: IRequestHandler<GetProjectByIdQuery,ProjectDetailsViewModel>
    {
        private readonly IProjectRepository _projectRepository;
        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;

        }
                   
           
public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetDetailsByIdAsync(request.Id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
                );

            return projectDetailsViewModel;
        }
    }
    }

